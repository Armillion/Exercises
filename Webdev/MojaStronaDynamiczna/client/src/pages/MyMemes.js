import React from 'react'
import axios from 'axios'
import { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'

function MyMemes() {
	const [memesArray, getMemes] = useState([])
	
	useEffect(() => {
		axios.get(`http://localhost:3001/memes/my-memes`, {headers: { access_token: sessionStorage.getItem("jwt") }}).then((response) => {
			getMemes(response.data)
		})
	}, [])
	
	function upvoteMeme (meme_id) {
		axios.get(`http://localhost:3001/upvotes/meme/${meme_id}`, {headers: { access_token: sessionStorage.getItem("jwt") }}).then((response) => {
			if (response.data.message === "upvoted") {
				document.querySelector(`#meme-${meme_id} .upvote_cnt`).innerHTML = parseInt(document.querySelector(`#meme-${meme_id} .upvote_cnt`).innerHTML) + 1;
				document.querySelector(`#meme-${meme_id} .upvote_arrow`).src = "img/upvoted.png"
			} else {
				document.querySelector(`#meme-${meme_id} .upvote_cnt`).innerHTML = parseInt(document.querySelector(`#meme-${meme_id} .upvote_cnt`).innerHTML) - 1;
				document.querySelector(`#meme-${meme_id} .upvote_arrow`).src = "img/upvote.png"
			}
		})
	}
	
	return (
		<main>
			{/* Images */}
			<nav className="meme_gallery">
				{memesArray.map((meme, key) => {
					return (
						<div id={`meme-${meme.id}`} key={key} className="meme_container">
							<ul className="image_boxes">
								<li className="meme_item">
									<p className="title">{meme.title}</p>
									<img src={meme.image_base64} alt="" className="meme" />
									<div className="votes">
										<img onClick={() => {upvoteMeme (meme.id)}} src={meme.liked ? "img/upvoted.png" : "img/upvote.png"} alt="" className="upvote_arrow" />
										<p className="upvote_cnt">{meme.upvotes}</p>
										<img src="img/share1.jpg" alt="" className="share" />
									</div>
								</li>
							</ul>
						</div>
					)
				})}
			</nav>
		</main>
	)
}

export default MyMemes
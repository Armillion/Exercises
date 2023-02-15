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
	
	return (
		<main>
			{/* Images */}
			<nav className="meme_gallery">
				{memesArray.map((meme, key) => {
					return (
						<div key={key} className="meme_container">
							<ul className="image_boxes">
								<li className="meme_item">
									<p className="title">{meme.title}</p>
									<img src={meme.image_base64} alt="" className="meme" />
									<div className="votes">
										<img src="img/upvote.jpg" alt="" className="upvote_arrow" />
										<p className="upvote_cnt">{meme.upvotes.length}</p>
										<img src="img/share1.jpg" alt="" className="share" />
									</div>
								</li>
							</ul>
						</div>
					)
				})}
			</nav>

			{/* Ads */}
			<nav className="ads">
				<div className="ad_1">
					<img src="img/ad.jpg" alt="" className="ad_img" />
				</div>
				<div className="ad_2">
					<img src="img/as2.png" alt="" className="ad_img" />
				</div>
			</nav>
		</main>
	)
}

export default MyMemes
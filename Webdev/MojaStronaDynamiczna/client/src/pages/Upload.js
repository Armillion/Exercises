import React from 'react'
import axios from 'axios'
import { Formik, Form, Field, ErrorMessage } from 'formik'
import * as Yup from 'yup'
import { useNavigate } from 'react-router-dom'

function Upload() {
	
	let navigate = useNavigate()
	
	let user_id = sessionStorage.getItem('jwt').user_id
	
	function getBase64(file) {
		var reader = new FileReader()
		reader.readAsDataURL(file)
		reader.onload = function () {
			document.getElementById('memePreview').src = reader.result
		}
	}
	
	const initialValues = {
		title: "",
		image: "",
	}
	
	const onSubmit = (memeData) => {
		
		alert ("onSubmit")
		memeData.image_base64 = document.getElementById('memePreview').src
		memeData.upvotes = 0
		memeData.author_id = user_id
		
		axios.post('http://localhost:3001/memes/upload', memeData).then((response) => {
			if (!response.data.error) {
				console.log("meme sent")
			}
		})
	}
	
	const validationSchema = Yup.object().shape({
		title: Yup.string().required("Title is required!"),
	})
	
	return (
		<main>
			<div>
				<h2>Upload own meme!</h2>
			</div>
			<div>
				<Formik
					initialValues={ initialValues }
					onSubmit={ onSubmit }
					validationSchema={ validationSchema }
				>
					<Form>
						<nav className="meme_gallery">
							<div className="meme_container">
								<ul className="image_boxes">
									<li className="meme_item">
										<ErrorMessage name='title' component='span' />
										<Field id='inputTitle' name='title' placeholder='Enter meme title here...' className='title'></Field>
										<ErrorMessage name='image' component='span' />
										<Field onChange={() => { getBase64(document.getElementById('inputImage').files[0]) }} id='inputImage' name='image' type='file'></Field>
										<img id='memePreview' alt='memePreview' className='meme' />
										<button type='submit'>Upload meme!</button>
									</li>
								</ul>
							</div>
						</nav>
					</Form>
				</Formik>
				
			</div>
		</main>
	)
}

export default Upload
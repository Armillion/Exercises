import React from 'react'
import axios from 'axios'
import { Formik, Form, Field, ErrorMessage } from 'formik'
import * as Yup from 'yup'
import { useNavigate } from 'react-router-dom'

function Upload() {
	
	let navigate = useNavigate()
	
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
		
		memeData.image_base64 = document.getElementById('memePreview').src
		
		axios.post('http://localhost:3001/memes/upload', memeData, {headers: { access_token: sessionStorage.getItem("jwt") }}).then((response) => {
			if (!response.data.error) {
				navigate('/uploaded')
			}
		})
	}
	
	const validationSchema = Yup.object().shape({
		title: Yup.string().required("Title is required!"),
	})
	
	return (
		<main>
			
			<Formik
				initialValues={ initialValues }
				onSubmit={ onSubmit }
				validationSchema={ validationSchema }
			>
				<Form>
					<nav className="meme_gallery">
						<div className="meme_container">
							<ul className="image_boxes">
								<li className="meme_item upload_meme">
									<h2 className='upload_title'>Upload own meme!</h2>
									<ErrorMessage name='title' component='span' />
									<Field id='inputTitle' name='title' placeholder='Enter meme title here...' className='title'></Field>
									<ErrorMessage name='image' component='span' />
									<label className='input_file' for='inputImage'>Choose image</label>
									<Field onChange={() => { getBase64(document.getElementById('inputImage').files[0]) }} id='inputImage' name='image' type='file'></Field>
									<img id='memePreview' alt='' className='meme' />
									<button type='submit'>Upload meme!</button>
								</li>
							</ul>
						</div>
					</nav>
				</Form>
			</Formik>
		</main>
	)
}

export default Upload
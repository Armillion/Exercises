import React from 'react'
import { Formik, Form, Field, ErrorMessage } from 'formik'
import * as Yup from 'yup'
import { useNavigate } from 'react-router-dom'
import axios from 'axios'

function SignUp() {
	
	let navigate = useNavigate()
	
	const initialValues = {
		username: "",
		email: "",
		password: ""
	}
	
	const onSubmit = (login_data) => {
		
		if (document.getElementById ('inputPassword').value !== document.getElementById ('inputPassword2').value) {
			document.getElementById('errorPasswd2').innerHTML = "Passwords doesn't match!"
			return
		}
		
		axios.post('http://localhost:3001/users/register', login_data).then((response) => {
			if (!response.data.error) {
				navigate('/registered')
			}
		})
	}
	
	const validationSchema = Yup.object().shape({
		email: Yup.string().email().required("Email field cannot be empty!"),
		username: Yup.string().required("Username field cannot be empty!"),
		password: Yup.string().required("Password field cannot be empty!"),
		password2: Yup.string().required("Password field cannot be empty!")
	})
	
	return (
		<main>
			<div className='wrapper-login'>
				<div className='login_container'>
					<div className='login_panel'>
						<h2>Register new account</h2>
						<Formik
							initialValues={ initialValues }
							onSubmit={ onSubmit }
							validationSchema={ validationSchema }
						>
							<Form>
								<label>Email:</label>
								<ErrorMessage name='email' component='span' />
								<Field id='inputEmail' name='email' placeholder='example@example.com'></Field>
								<label>Username:</label>
								<ErrorMessage name='username' component='span' />
								<Field id='inputUsername' name='username'></Field>
								<label>Password:</label>
								<ErrorMessage name='password' component='span' />
								<Field id='inputPassword' name='password' type='password' placeholder='********'></Field>
								<label>Repeat password:</label>
								<ErrorMessage name='password2' component='span' />
								<span id='errorPasswd2'></span>
								<Field id='inputPassword2' name='password2' type='password' placeholder='********'></Field>
								<button type='submit' className='button-login-submit'>Sign up</button>
							</Form>
						</Formik>
					</div>
				</div>
			</div>
		</main>
	)
}

export default SignUp

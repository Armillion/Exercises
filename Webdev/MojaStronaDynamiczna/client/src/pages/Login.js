import React from 'react'
import { Formik, Form, Field, ErrorMessage } from 'formik'
import * as Yup from 'yup'
import { useNavigate } from 'react-router-dom'
import axios from 'axios'

function Login() {
	
	let navigate = useNavigate()
	
	const initialValues = {
		username: "",
		password: ""
	}
	
	const onSubmit = (login_data) => {
		
		axios.post('http://localhost:3001/users/login', login_data).then((response) => {
			if (!response.data.error) {
				window.sessionStorage.setItem('jwt', response.data.jwt)
				navigate('/')
				window.location.reload()
			}
		})
		
	}
	
	const validationSchema = Yup.object().shape({
		username: Yup.string().required("Username field cannot be empty!"),
		password: Yup.string().required("Password field cannot be empty!")
	})
	
	return (
		<main>
			<div className='wrapper-login'>
				<div className='login_container'>
					<div className='login_panel'>
						<h2>Login panel</h2>
						<Formik
							initialValues={ initialValues }
							onSubmit={ onSubmit }
							validationSchema={ validationSchema }
						>
							<Form>
								<label>Username:</label>
								<ErrorMessage name='username' component='span' />
								<Field id='inputUsername' name='username'></Field>
								<label>Password:</label>
								<ErrorMessage name='password' component='span' />
								<Field id='inputPassword' name='password' type='password' placeholder='********'></Field>
								<button type='submit' className='button-login-submit'>Sign in</button>
							</Form>
						</Formik>
					</div>
				</div>
			</div>
		</main>
	)
}

export default Login

import React from 'react'
import { Formik, Form, Field, ErrorMessage } from 'formik'
import * as Yup from 'yup'
import { Container, Row } from 'react-bootstrap'
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
			<Container className='wrapper-login'>
				<Row>
					<h2>Panel logowania</h2>
				</Row>
				<Row>
					<Formik
						initialValues={ initialValues }
						onSubmit={ onSubmit }
						validationSchema={ validationSchema }
					>
						<Form>
							<label>Username:</label>
							<ErrorMessage name='username' component='span' />
							<Field id='inputUsername' name='username' placeholder='example@example.com'></Field>
							<label>Password:</label>
							<ErrorMessage name='password' component='span' />
							<Field id='inputPassword' name='password' type='password' placeholder='********'></Field>
							<button type='submit' className='button-login-submit'>Sign in</button>
						</Form>
					</Formik>
				</Row>
			</Container>
		</main>
	)
}

export default Login

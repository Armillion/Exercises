import React from 'react'
import axios from 'axios'
import { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'

function LogOut() {
	
	let navigate = useNavigate()
	
	sessionStorage.removeItem('jwt')
	setTimeout(() => {
		navigate('/')
		window.location.reload()
	}, "1000")
	
	return (
		<main>
			<p className='message'>You're succesfully logged out.</p>
		</main>
	)
}

export default LogOut
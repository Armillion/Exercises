import React from 'react'
import axios from 'axios'
import { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'

function LogOut() {
	
	sessionStorage.removeItem('jwt')
	
	return (
		<main>
			<p className='message'>You're succesfully logged out.</p>
		</main>
	)
}

export default LogOut
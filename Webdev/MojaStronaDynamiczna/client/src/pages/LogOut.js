import React from 'react'
import axios from 'axios'
import { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'

function LogOut() {
	
	sessionStorage.removeItem('jwt')
	window.location.href = '/'
	
	return (
		<main>
			You're succesfully logged out.
		</main>
	)
}

export default LogOut
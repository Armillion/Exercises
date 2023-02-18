import './App.css';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom'
import Home from './pages/Home'
import Upload from './pages/Upload'
import MyMemes from './pages/MyMemes'
import LogOut from './pages/LogOut'
import Login from './pages/Login'
import SignUp from './pages/SignUp'
import Registered from './pages/Registered'
import Uploaded from './pages/Uploaded'

function App() {
	
	let isUserLoggedIn = sessionStorage.getItem('jwt') ? true : false
	
	return (
		<div className='root'>
			<Router>
				<nav className="navmenu">
					<div className="menu_container">
						<Link to='/' id='manu__logo'>Meme Page</Link>
						<div className="nav__menu" id="mobile_menu">
							<span className="bar"></span>
							<span className="bar"></span>
							<span className="bar"></span>
						</div>
						{ isUserLoggedIn ? (
							<ul className="nar__menu_proper">
								<li className="menu__item">
									<Link to='upload' className="menu__links" id="upload">Upload</Link>
								</li>
								<li className="menu__item">
									<Link to='my-memes' className="menu__links" id="my-memes">My Memes</Link>
								</li>
								<li className="menu__item">
								<Link to='log-out' className="menu__links" id="log-out">Log out</Link>
								</li>
							</ul>
						) : (
							<ul className="nar__menu_proper">
								<li className="menu__item">
									<Link to='sign-up' className="menu__links" id="signup">Sign up</Link>
								</li>
								<li className="menu__item">
									<Link to='login' className="menu__links" id="login">Log in</Link>
								</li>
							</ul>
						)}	
					</div>
				</nav>
				<Routes>
					<Route path='/' exact element={<Home />} />
					<Route path='/sign-up' exact element={<SignUp />} />
					<Route path='/login' exact element={<Login />} />
					<Route path='/upload' exact element={<Upload />} />
					<Route path='/my-memes' exact element={<MyMemes />} />
					<Route path='/log-out' exact element={<LogOut />} />
					<Route path='/registered' exact element={<Registered />} />
					<Route path='/uploaded' exact element={<Uploaded />} />
				</Routes>
			</Router>
			{/* Footer */}
			<div className="footer__container">
				<div className="footer__links">
					<div className="footer__link_wrapper">
						<div className="footer__link_item">
							<h2>About Us</h2>
							<a href="/">How it works</a>
							<a href="/">Terms of Service</a>
							<a href="/">Careers</a>
							<a href="/">Testimonials</a>
						</div>
						<div className="footer__link_item">
							<h2>Contact Us</h2>
							<a href="/">Contact</a>
							<a href="/">Destinations</a>
						</div>
						<div className="footer__link_item">
							<h2>Made by:</h2>
							<a href="/">Patryk Wałaszek</a>
							<a href="/">Jagiellonian University</a>
							<a href="/">WWW Technics</a>
							<a href="/">ALL RIGHTS RESERVED</a>
						</div>
					</div>
				</div>
			</div>
		</div>
	)
}

export default App;

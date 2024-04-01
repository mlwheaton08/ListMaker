import { useEffect, useState } from 'react'
import './App.css'
import { Outlet, Route, Routes, useLocation } from 'react-router-dom'
import { Nav } from './components/nav/Nav'
import { Home } from './components/home/Home'
import { Items } from './components/items/Items'
import { Recipes } from './components/recipes/Recipes'
import { Dashboard } from './components/dashboard/Dashboard'
import { Dashboard2 } from './components/dashboard/Dashboard2'

export default function App() {

	// const [screenSize, setScreenSize] = useState({
	// 	width: window.innerWidth,
	// 	device: "desktop"
	// })
	const [navState, setNavState] = useState({
		scrollY: 0,
		currentRoute: ""
	})

	const location = useLocation()

	// const updateScreenSize = () => {
	// 	const copy = {...screenSize}
	// 	const width = window.innerWidth
	// 	copy.width = width
	// 	if (width < 600){
	// 		copy.device = "mobile"
	// 	} else if (width > 600 && width < 970) {
	// 		copy.device = "tablet"
	// 	} else {
	// 		copy.device = "desktop"
	// 	}
	// 	setScreenSize(copy)
	// }

	useEffect(() => {
		const copy = {...navState}
		copy.currentRoute = location.pathname
		setNavState(copy)
	},[location])

	// useEffect(() => {
	// 	updateScreenSize()
	// },[])

	// window.addEventListener("resize", (e) => {
	// 	console.log(window.innerWidth)
	// })


	return (
		<Routes>
			<Route path="/" element={
				<>
					<Nav
						navState={navState}
						setNavState={setNavState}
					/>
					<Outlet />
				</>
			}>

				<Route path="/" element={ <Home /> } />
				<Route path="/recipes" element={ <Recipes /> } />
				<Route path="/items" element={ <Items /> } />
				<Route path="/dashboard" element={ <Dashboard2 /> } />

			</Route>
		</Routes>
	)
}
import { useEffect, useState } from 'react'
import './App.css'
import { Outlet, Route, Routes, useLocation } from 'react-router-dom'
import { Nav } from './components/nav/Nav'
import { Home } from './components/home/Home'
import { Items } from './components/items/Items'
import { Recipes } from './components/recipes/Recipes'

export default function App() {

	const location = useLocation()

	const [navState, setNavState] = useState({
		scrollY: 0,
		currentRoute: ""
	})

	useEffect(() => {
		const copy = {...navState}
		copy.currentRoute = location.pathname
		setNavState(copy)
	},[location])

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
				<Route path="/items" element={ <Items /> } />
				<Route path="/recipes" element={ <Recipes /> } />

			</Route>
		</Routes>
	)
}
import { useState } from 'react'
import './App.css'
import { Outlet, Route, Routes } from 'react-router-dom'
import { Nav } from './components/nav/Nav'
import { Home } from './components/home/Home'

export default function App() {

	return (
		<Routes>
			<Route path="/" element={
				<>
					<Nav/>
					<Outlet />
				</>
			}>

				<Route path="/" element={ <Home /> } />

			</Route>
		</Routes>
	)
}
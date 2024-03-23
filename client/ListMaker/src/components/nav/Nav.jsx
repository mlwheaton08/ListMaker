import { Link, useNavigate } from "react-router-dom"
import "./Nav.css"
import { useState } from "react"
import { SearchBar } from "./SearchBar.jsx"
import { AccountNavItem } from "./AccountNavItem.jsx"
import { MobileNav } from "./MobileNav.jsx"
import { DesktopNav } from "./DesktopNev.jsx"

export function Nav({ navState, setNavState }) {

    const navItems = {
        main: [
            {text: "Items", navigateTo: "/items"},
            {text: "Recipes", navigateTo: "/recipes"},
            {text: "Grocery Lists", navigateTo: "/groceryLists"}
        ],
        account: [
            {text: "My Lists", navigateTo: "/ml"},
            {text: "My Recipes", navigateTo: "/mr"},
            {text: "My Items", navigateTo: "/mi"},
            {text: "Settings", navigateTo: "/s"},
            {text: "Sign Out", navigateTo: "/so"}
        ]
    }

    const [search, setSearch] = useState("")

    const navigate = useNavigate()

    // it's nice to always have the scroll position set in state as it could prove useful down the road, but if it affects performance then maybe refactor to:
        // navState object has "scrolled" boolean property instead of "scrollY", and the event listener only sets it to true when the scrollY is > 0
    document.addEventListener("scroll", (event) => {
		const scrollY = window.scrollY
		const copy = {...navState}
		copy.scrollY = scrollY
		setNavState(copy)
	})

    return (
        <div
            id="nav-bar"
            className={`${navState.scrollY > 0 ? "bg-clr-background-2" : ""} transition-all duration-500`}
        >
            {/* Left side */}
            <div className="navSection">

                {/* Logo and title */}
                <div
                    onClick={() => navigate("/")}
                    className="flex flex-nowrap items-center gap-2 hover:cursor-pointer"
                >
                    <img
                        src="../../../public/listMaker.svg"
                        alt="List Maker logo"
                        className="h-8 min-w-8"
                    />
                    <h1 id="nav-logo-text" className="truncate w-fit min-w-fit font-semibold">List Maker</h1>
                </div>

                {/* Search bar */}
                <SearchBar />

            </div>

            {/* Right side */}
            <DesktopNav navState={navState} navItems={navItems} />
            <MobileNav navState={navState} navItems={navItems} />

        </div>
    )
}
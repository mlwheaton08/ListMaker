import { Link, useNavigate } from "react-router-dom"
import "./Nav.css"
import { useState } from "react"
import { SearchBar } from "./SearchBar.jsx"
import { AccountNavItem } from "./AccountNavItem.jsx"

export function Nav({ navState, setNavState }) {

    const navItems = [
        {text: "Items", navigateTo: "/items"},
        {text: "Recipes", navigateTo: "/recipes"},
        {text: "Grocery Lists", navigateTo: "/groceryLists"}
    ]

    const navigate = useNavigate()

    const [search, setSearch] = useState("")

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
                        className="h-8"
                    />
                    <h1 className="truncate w-fit min-w-fit font-semibold">List Maker</h1>
                </div>

                {/* Search bar */}
                <SearchBar />

            </div>

            {/* Right side */}
            <div className="navSection">

                {/* Nav items */}
                <nav className="flex flex-nowrap items-center gap-8">
                    {
                        navItems.map((item, index) => {
                            return (
                                <Link
                                    key={`navItem-${index}`}
                                    to={item.navigateTo}
                                    className={`min-w-fit hover:text-clr-primary transition-all duration-200
                                        ${navState.currentRoute === item.navigateTo ? "text-clr-primary" : ""}`}
                                >
                                    {item.text}
                                </Link>
                            )
                        })
                    }
                </nav>

                {/* Account */}
                <AccountNavItem
                    navState={navState}
                />

            </div>
        </div>
    )
}
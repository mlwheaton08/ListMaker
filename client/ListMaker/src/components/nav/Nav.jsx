import { Link, useNavigate } from "react-router-dom"
import "./Nav.css"
import { useState } from "react"
import { SearchBar } from "./SearchBar.jsx"
import { AccountNav } from "./AccountNav.jsx"
import { MobileNav } from "./MobileNav.jsx"

export function Nav({ navState, setNavState }) {

    const navItems = [
        {text: "Items", navigateTo: "/items"},
        {text: "Recipes", navigateTo: "/recipes"},
        {text: "Grocery Lists", navigateTo: "/groceryLists"}
    ]

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
            <div id="nav-logo-title" className="navSection">

                {/* Logo and title */}
                <div
                    onClick={() => navigate("/")}
                    className="h-full flex flex-nowrap items-center gap-2 hover:cursor-pointer"
                >
                    <img
                        src="../../../public/listMaker.svg"
                        alt="List Maker logo"
                        className="h-1/2"
                    />
                    <h1 id="nav-logo-text" className="truncate w-fit min-w-fit font-semibold">List Maker</h1>
                </div>
            </div>

            {/* Search bar */}
            <SearchBar />

            {/* Right side */}
            <div className="navSection navMain desktop">
                {/* Nav items */}
                <nav className="flex flex-nowrap items-center gap-8">
                    {
                        navItems.map((item, index) => {
                            return (
                                <Link
                                    key={`navItem-${index}`}
                                    to={item.navigateTo}
                                    className="min-w-fit hover:text-clr-primary transition-all duration-200"
                                >
                                    {item.text}
                                </Link>
                            )
                        })
                    }
                </nav>
            </div>

            <MobileNav navItems={navItems} />
            <AccountNav />

        </div>
    )
}
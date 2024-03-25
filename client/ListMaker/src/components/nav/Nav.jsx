import { Link, useNavigate } from "react-router-dom"
import "./Nav.css"
import { useState } from "react"
import { SearchBar } from "./SearchBar.jsx"
import { NavDropdown } from "./NavDropdown.jsx"

export function Nav({ navState, setNavState }) {

    const mobileNav = {
        id:"mobile-nav",
        className: "navSection navMain mobile",
        clickOrHover: "hover",
        navItems: [
            {text: "Items", navigateTo: "/items"},
            {text: "Recipes", navigateTo: "/recipes"},
            {text: "Grocery Lists", navigateTo: "/groceryLists"}
        ],
        icon: {
            type: "bars",
            id: "mobile-nav-icon",
            className: "relative h-1/2 top-1/2 -translate-y-1/2 hover:cursor-pointer transition-all duration-300",
            classNameActive: "fill-clr-primary",
            classNameInactive: "fill-clr-foreground"
        },
        spacer: {
            className: "h-1/2"
        },
        dropdown: {
            id: "mobile-nav-dropdown",
            children: {
                className: "dropdownNavItem hover:text-clr-primary"
            }
        }
    }

    const accountNav = {
        id:"account-nav",
        className: "navSection",
        clickOrHover: "hover",
        navItems: [
            {text: "My Lists", navigateTo: "/ml"},
            {text: "My Recipes", navigateTo: "/mr"},
            {text: "My Items", navigateTo: "/mi"},
            {text: "Settings", navigateTo: "/s"},
            {text: "Sign Out", navigateTo: "/so"}
        ],
        icon: {
            type: "profile",
            id: "account-nav-icon",
            className: "relative h-3/5 p-px top-1/2 -translate-y-1/2 rounded-full border-2 fill-clr-accent hover:cursor-pointer transition-all duration-300",
            classNameActive: "border-clr-accent",
            classNameInactive: "border-clr-foreground"
        },
        spacer: {
            className: "h-2/5"
        },
        dropdown: {
            id: "account-nav-dropdown",
            children: {
                className: "dropdownNavItem hover:text-clr-accent"
            }
        }
    }

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

            <NavDropdown properties={mobileNav} />
            <NavDropdown properties={accountNav} />

        </div>
    )
}
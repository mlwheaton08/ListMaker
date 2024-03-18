import { Link, useNavigate } from "react-router-dom"
import "./Nav.css"
import { magnifyingGlassIcon } from "../../icons.jsx"
import { useState } from "react"
import { profileIcon } from "../../icons.jsx"

export function Nav() {

    const navItems = [
        {text: "Items", navigateTo: "/items"},
        {text: "Recipes", navigateTo: "/recipes"},
        {text: "Grocery Lists", navigateTo: "/groceryLists"}
    ]

    const navigate = useNavigate()

    const [search, setSearch] = useState("")
    const [searchBarIsActive, setSearchBarIsActive] = useState(false)

    document.body.addEventListener("click", (event) => {
        if (document.activeElement.id === "search-input") {
            setSearchBarIsActive(true)
        } else {
            setSearchBarIsActive(false)
        }
    })

    return (
        <div id="nav-bar">
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
                    <h1 className="font-semibold">List Maker</h1>
                </div>

                {/* Search bar */}
                <div className={`flex flex-nowrap items-center gap-2 px-2 py-0.5 rounded-md bg-white bg-opacity-10 ${searchBarIsActive ? "border border-clr-accent" : ""}`}>
                    {magnifyingGlassIcon(`h-5 ${searchBarIsActive ? "fill-clr-accent" : "fill-clr-background"}`)}
                    <input
                        id="search-input"
                        autoComplete="off"
                    />
                </div>
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
                                    className="hover:text-clr-primary"
                                >
                                    {item.text}
                                </Link>
                            )
                        })
                    }
                </nav>

                {/* Account */}
                {profileIcon("w-8 h-8 p-px rounded-full fill-clr-primary border-2 border-clr-foreground hover:cursor-pointer hover:border-clr-accent")}
            </div>
        </div>
    )
}
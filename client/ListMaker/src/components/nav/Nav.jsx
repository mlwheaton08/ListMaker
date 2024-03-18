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
                    <h1 className="w-fit min-w-fit font-semibold">List Maker</h1>
                </div>

                {/* Search bar */}
                <div>
                    <label
                        htmlFor="search-input"
                        className="relative"
                    >
                        {magnifyingGlassIcon("absolute top-1/2 -translate-y-1/2 h-5 left-1.5 fill-clr-background")}
                    </label>
                    <input
                        id="search-input"
                        name="search-input"
                        autoComplete="off"
                        className="pl-9 pr-2 py-0.5 rounded-md bg-white bg-opacity-10 focus:outline focus:outline-1 focus:outline-clr-accent"
                    />
                </div>

                {/* </div> */}
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
                                    className="min-w-fit hover:text-clr-primary"
                                >
                                    {item.text}
                                </Link>
                            )
                        })
                    }
                </nav>

                {/* Account */}
                {profileIcon("w-8 min-w-8 h-8 p-px rounded-full fill-clr-primary border-2 border-clr-foreground hover:cursor-pointer hover:border-clr-accent")}
            </div>
        </div>
    )
}
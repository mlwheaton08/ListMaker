import { useState } from "react"
import { Link } from "react-router-dom"

export function MobileNav({ navState, navItems }) {

    const [showDropdown, setShowDropdown] = useState(false)

    document.body.addEventListener("click", (e) => {
        if (showDropdown && e.target.id !== "mobile-nav-icon") {
            setShowDropdown(false)
        }
    })


    return (
        <div id="mobile-nav" className="navSection">
            <div className="relative h-1/2">
                <svg
                    id="mobile-nav-icon"
                    xmlns="http://www.w3.org/2000/svg"
                    viewBox="0 0 448 512"
                    onClick={() => setShowDropdown(!showDropdown)}
                    className={`${showDropdown ? "fill-clr-primary" : "fill-clr-foreground"} h-full hover:cursor-pointer transition-all duration-300`}
                >
                    <path d="M0 96C0 78.3 14.3 64 32 64H416c17.7 0 32 14.3 32 32s-14.3 32-32 32H32C14.3 128 0 113.7 0 96zM0 256c0-17.7 14.3-32 32-32H416c17.7 0 32 14.3 32 32s-14.3 32-32 32H32c-17.7 0-32-14.3-32-32zM448 416c0 17.7-14.3 32-32 32H32c-17.7 0-32-14.3-32-32s14.3-32 32-32H416c17.7 0 32 14.3 32 32z"/>
                </svg>

                <nav
                    className={`${showDropdown ? "block" : "hidden"} py-2 absolute right-0 flex flex-col flex-nowrap items-end rounded bg-clr-background-3 transition-all duration-200`}
                >
                    {
                        navItems.main.map((item, index) => {
                            return (
                                <Link
                                    key={`navItem-${index}`}
                                    to={item.navigateTo}
                                    className={`truncate w-full px-5 py-1 text-right hover:text-clr-primary hover:bg-clr-background transition-all duration-200
                                        ${navState.currentRoute === item.navigateTo ? "text-clr-primary" : ""}`}
                                >
                                    {item.text}
                                </Link>
                            )
                        })
                    }
                </nav>
            </div>
        </div>
    )
}
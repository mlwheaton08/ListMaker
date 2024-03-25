import { useState } from "react"
import { Link } from "react-router-dom"

export function MobileNav({ navState, navItems }) {

    const [showDropdown, setShowDropdown] = useState(true)

    // document.body.addEventListener("click", (e) => {
    //     if (showDropdown && e.target.id !== "mobile-nav-icon") {
    //         setShowDropdown(false)
    //     }
    // })


    return (
        <div className="navSection navMain mobile">
            <div className="relative h-full">
                <svg
                    id="mobile-nav-icon"
                    xmlns="http://www.w3.org/2000/svg"
                    viewBox="0 0 448 512"
                    onClick={() => setShowDropdown(!showDropdown)}
                    className={`${showDropdown ? "fill-clr-primary" : "fill-clr-foreground"} h-1/2 py-1/2 relative top-1/2 -translate-y-1/2 hover:cursor-pointer transition-all duration-300`}
                >
                    <path d="M0 96C0 78.3 14.3 64 32 64H416c17.7 0 32 14.3 32 32s-14.3 32-32 32H32C14.3 128 0 113.7 0 96zM0 256c0-17.7 14.3-32 32-32H416c17.7 0 32 14.3 32 32s-14.3 32-32 32H32c-17.7 0-32-14.3-32-32zM448 416c0 17.7-14.3 32-32 32H32c-17.7 0-32-14.3-32-32s14.3-32 32-32H416c17.7 0 32 14.3 32 32z"/>
                </svg>

                {/* Spacer */}
                <div className="h-1/2"></div>
                
                {
                    !showDropdown
                        ? ""
                        : <nav
                            id="mobile-nav-dropdown"
                            className={!showDropdown ? "hidden" : ""}
                        >
                            {
                                navItems.main.map((item, index) => {
                                    return (
                                        <Link
                                            key={`navItem-${index}`}
                                            to={item.navigateTo}
                                            className={navState.currentRoute === item.navigateTo ? "text-clr-primary" : ""}
                                        >
                                            {item.text}
                                        </Link>
                                    )
                                })
                            }
                        </nav>
                }
                
            </div>
        </div>
    )
}
import { useState } from "react"
import { Link } from "react-router-dom"

export function AccountNav({ navState, accountNavItems }) {

    const [showDropdown, setShowDropdown] = useState(false)

    return (
        <div
            id="nav-account"
            onMouseOver={() => setShowDropdown(true)}
            onMouseOut={() => setShowDropdown(false)}
            className="navSection"
        >
            <div className="relative">
                <div className="flex items-center gap-1 hover:cursor-pointer">
                    {/* Profile icon */}
                    <svg
                        xmlns="http://www.w3.org/2000/svg"
                        viewBox="0 0 448 512"
                        className={`w-8 min-w-8 h-8 p-px rounded-full fill-clr-primary border-2 transition-all duration-200
                        ${showDropdown ? "border-clr-accent" : "border-clr-foreground"}`}
                    >
                        <path d="M304 128a80 80 0 1 0 -160 0 80 80 0 1 0 160 0zM96 128a128 128 0 1 1 256 0A128 128 0 1 1 96 128zM49.3 464H398.7c-8.9-63.3-63.3-112-129-112H178.3c-65.7 0-120.1 48.7-129 112zM0 482.3C0 383.8 79.8 304 178.3 304h91.4C368.2 304 448 383.8 448 482.3c0 16.4-13.3 29.7-29.7 29.7H29.7C13.3 512 0 498.7 0 482.3z"/>
                    </svg>
                    {/* Arrow icon */}
                    <svg
                        xmlns="http://www.w3.org/2000/svg"
                        height="1em"
                        viewBox="0 0 512 512"
                        className={`h-2 transition-all duration-200 ${showDropdown ? "fill-clr-accent" : "fill-clr-foreground"}`}
                    >
                        <path d="M233.4 406.6c12.5 12.5 32.8 12.5 45.3 0l192-192c12.5-12.5 12.5-32.8 0-45.3s-32.8-12.5-45.3 0L256 338.7 86.6 169.4c-12.5-12.5-32.8-12.5-45.3 0s-12.5 32.8 0 45.3l192 192z"/>
                    </svg>
                </div>

                {/* Dropdown */}
                {
                    !showDropdown
                        ? ""
                        : <nav
                            onMouseOver={() => setShowDropdown(true)}
                            onMouseOut={() => setShowDropdown(false)}
                            className="absolute right-0 py-2 flex flex-col flex-nowrap items-end rounded bg-clr-background-3"
                        >
                            {
                                accountNavItems.map((item, index) => {
                                    return (
                                        <Link
                                            key={`navItem-${index}`}
                                            to={item.navigateTo}
                                            className={`truncate w-full px-5 py-1 text-right hover:text-clr-accent hover:bg-clr-background transition-all duration-200
                                                ${navState.currentRoute === item.navigateTo ? "text-clr-accent" : ""}`}
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
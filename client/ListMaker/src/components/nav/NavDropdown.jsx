import { useState } from "react"
import { Link } from "react-router-dom"

export function NavDropdown({ properties }) {

    const [showDropdown, setShowDropdown] = useState(false)

    const iconOptions = [
        {
            type: "bars",
            element: <svg
                id={properties.icon.id}
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 448 512"
                className={`${properties.icon.className} ${showDropdown ? properties.icon.classNameActive : properties.icon.classNameInactive}`}
            >
                <path d="M0 96C0 78.3 14.3 64 32 64H416c17.7 0 32 14.3 32 32s-14.3 32-32 32H32C14.3 128 0 113.7 0 96zM0 256c0-17.7 14.3-32 32-32H416c17.7 0 32 14.3 32 32s-14.3 32-32 32H32c-17.7 0-32-14.3-32-32zM448 416c0 17.7-14.3 32-32 32H32c-17.7 0-32-14.3-32-32s14.3-32 32-32H416c17.7 0 32 14.3 32 32z"/>
            </svg>
        },
        {
            type: "profile",
            element: <svg
                id={properties.icon.id}
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 448 512"
                className={`${properties.icon.className} ${showDropdown ? properties.icon.classNameActive : properties.icon.classNameInactive}`}
            >
                <path d="M304 128a80 80 0 1 0 -160 0 80 80 0 1 0 160 0zM96 128a128 128 0 1 1 256 0A128 128 0 1 1 96 128zM49.3 464H398.7c-8.9-63.3-63.3-112-129-112H178.3c-65.7 0-120.1 48.7-129 112zM0 482.3C0 383.8 79.8 304 178.3 304h91.4C368.2 304 448 383.8 448 482.3c0 16.4-13.3 29.7-29.7 29.7H29.7C13.3 512 0 498.7 0 482.3z"/>
            </svg>
        }
    ]

    const icon = iconOptions.find((icon) => icon.type === properties.icon.type)


    return (
        <div
            id={properties.id}
            onClick={properties.clickOrHover === "click" ? () => setShowDropdown(!showDropdown) : undefined}
            onMouseEnter={properties.clickOrHover === "hover" ? () => setShowDropdown(true) : undefined}
            onMouseLeave={properties.clickOrHover === "hover" ? () => setShowDropdown(false) : undefined}
            className={properties.className}
        >
            <div className="relative h-full">

                {/* Icon */}
                {icon.element}

                {/* Spacer */}
                <div className={properties.spacer.className}></div>
                
                <nav
                    id={properties.dropdown.id}
                    className={`navDropdown ${!showDropdown ? "hide" : ""}`}
                >
                    {
                        properties.navItems.map((item, index) => {
                            return (
                                <Link
                                    key={`navItem-${index}`}
                                    to={item.navigateTo}
                                    className={properties.dropdown.children.className}
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
import { Link, useNavigate } from "react-router-dom"
import { AccountNavItem } from "./AccountNavItem"

export function DesktopNav({ navState, navItems }) {

    const navigate = useNavigate()

    return (
        <div id="desktop-nav" className="navSection ml-auto">

            {/* Nav items */}
            <nav className="flex flex-nowrap items-center gap-8">
                {
                    navItems.main.map((item, index) => {
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
                accountNavItems={navItems.account}
            />

        </div>
    )
}
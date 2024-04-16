import { Link } from "react-router-dom"
import styles from "./DashboardNav.module.css"

export function DashboardNav() {

    const navItems = [
        {text: "Lists", navigateTo: "/dashboard/lists"},
        {text: "Recipes", navigateTo: "/dashboard/recipes"},
        {text: "Items", navigateTo: "/dashboard/items"}
    ]


    return (
        <aside className={styles.main}>
            <h2 className="mb-4 text-2xl">
                Dashboard
            </h2>
            <nav className={styles.nav}>
                {
                    navItems.map((item, index) => {
                        return (
                            <Link
                                key={`dashboard-nav-item-${index}`}
                                to={item.navigateTo}
                                className={`hover:cursor-pointer`}
                            >
                                {item.text}
                            </Link>
                        )
                    })
                }
            </nav>
        </aside>
    )
}
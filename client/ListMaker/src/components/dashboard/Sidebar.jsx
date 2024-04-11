import styles from "./Dashboard2.module.css"

export function Sidebar({ sidebarItems, view }) {

    return (
        <aside className={styles.sidebar}>
            <h2 className="mb-4 text-2xl">
                Dashboard
            </h2>
            <nav className={styles.sideBarNav}>
                {
                    sidebarItems.map((item, index) => {
                        return (
                            <h3
                                key={`dashboard-nav-item-${index}`}
                                onClick={item.onClick}
                                className={`hover:cursor-pointer ${view.text === item.text ? "underline" : ""}`}
                            >
                                {item.text}
                            </h3>
                        )
                    })
                }
            </nav>
        </aside>
    )
}
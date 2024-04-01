import styles from "./Dashboard2.module.css"

export function Sidebar({ sidebarItems, view }) {

    return (
        <aside className={styles.sidebar}>
            {
                sidebarItems.map((item, index) => {
                    return (
                        <h2
                            key={`dashboard-nav-item-${index}`}
                            onClick={item.onClick}
                            className={`hover:cursor-pointer ${view === item.text ? "underline" : ""}`}
                        >
                            {item.text}
                        </h2>
                    )
                })
            }
        </aside>
    )
}
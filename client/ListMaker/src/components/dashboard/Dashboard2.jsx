import { useState } from "react"
import styles from "./Dashboard2.module.css"
import { DashboardLists } from "./DashboardLists"
import { DashboardRecipes } from "./DashboardRecipes"
import { DashboardItems } from "./DashboardItems"
import { Sidebar } from "./Sidebar"

export function Dashboard2() {

    const sidebarItems = [
        {text: "Lists", onClick: () => setView(<DashboardLists />)},
        {text: "Recipes", onClick: () => setView(<DashboardRecipes />)},
        {text: "Items", onClick: () => setView(<DashboardItems />)}
    ]

    const [view, setView] = useState(<DashboardRecipes />)


    return (
        <div className={styles.main}>
            
            <Sidebar
                sidebarItems={sidebarItems}
                view={view}
            />

            {view}

        </div>
    )
}
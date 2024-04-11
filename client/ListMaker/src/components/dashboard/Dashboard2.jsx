import { useState } from "react"
import styles from "./Dashboard2.module.css"
import { DashboardLists } from "./DashboardLists"
import { DashboardRecipes } from "./DashboardRecipes"
import { DashboardItems } from "./DashboardItems"
import { Sidebar } from "./Sidebar"

export function Dashboard2() {

    const sidebarItems = [
        {text: "Lists", onClick: () => setView({text: "Lists", component: <DashboardLists />})},
        {text: "Recipes", onClick: () => setView({text: "Recipes", component: <DashboardRecipes />})},
        {text: "Items", onClick: () => setView({text: "Items", component: <DashboardItems />})}
    ]

    const [view, setView] = useState({
        text: "Recipes",
        component: <DashboardRecipes />
    })


    return (
        <div className={styles.main}>
            
            <Sidebar
                sidebarItems={sidebarItems}
                view={view}
            />

            {view.component}

        </div>
    )
}
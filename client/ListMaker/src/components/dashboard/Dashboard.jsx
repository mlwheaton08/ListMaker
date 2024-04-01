import { useState } from "react"
import "./Dashboard.css"
import { DashboardLists } from "./DashboardLists"
import { DashboardRecipes } from "./DashboardRecipes"
import { DashboardItems } from "./DashboardItems"

export function Dashboard() {

    const navItems = [
        {text: "Lists", onClick: () => setView("Lists")},
        {text: "Recipes", onClick: () => setView("Recipes")},
        {text: "Items", onClick: () => setView("Items")}
    ]
    const [view, setView] = useState("Lists")


    return (
        <div id="dashboard">
            <div id="dashboard-container">
                <h1 className="container">Dashboard</h1>
                <nav className="container">
                    {/* <h2>Lists</h2>
                    <h2>Recipes</h2>
                    <h2>Items</h2> */}
                    {
                        navItems.map((item, index) => {
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
                </nav>

                {
                    view === "Lists"
                        ? <DashboardLists />
                        : ""
                }
                {
                    view === "Recipes"
                        ? <DashboardRecipes />
                        : ""
                }
                {
                    view === "Items"
                        ? <DashboardItems />
                        : ""
                }

            </div>
        </div>
    )
}
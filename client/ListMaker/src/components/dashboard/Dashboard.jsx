import "./Dashboard.css"
import { DashboardLists } from "./dashboardContainers/DashboardLists"

export function Dashboard() {

    return (
        <div id="dashboard">
            <div id="dashboard-container">
                <h1 className="container left top">Dashboard</h1>
                <nav className="container right top">
                    <h2>Lists</h2>
                    <h2>Recipes</h2>
                    <h2>Items</h2>
                </nav>

                <DashboardLists />
            </div>
        </div>
    )
}
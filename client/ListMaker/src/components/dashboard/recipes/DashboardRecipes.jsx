import { useState } from "react"
import styles from "./DashboardRecipes.module.css"
import { useNavigate } from "react-router-dom"

export function DashboardRecipes() {

    const navigate = useNavigate()

    const [recipes, setRecipes] = useState([
        {
            id: 0,
            name: "Quick Trip",
            notes: "Short list for a lazy Sunday shoppisdfasdfassdfsfsdfsdfdfasdfasdfasdfasdfng trip",
            dateCreated: "4/15/24"
        },
        {
            id: 1,
            name: "Quick Trip",
            notes: "Short list for a lazy Sunday shoppisdfasdfassdfsfsdfsdfdfasdfasdfasdfasdfng trip",
            dateCreated: "4/15/24"
        },
        {
            id: 2,
            name: "Quick Trip",
            notes: "Short list for a lazy Sunday shoppisdfasdfassdfsfsdfsdfdfasdfasdfasdfasdfng trip",
            dateCreated: "4/15/24"
        },
        {
            id: 3,
            name: "Quick Trip",
            notes: "Short list for a lazy Sunday shoppisdfasdfassdfsfsdfsdfdfasdfasdfasdfasdfng trip",
            dateCreated: "4/15/24"
        },
        {
            id: 4,
            name: "Quick Trip",
            notes: "Short list for a lazy Sunday shoppisdfasdfassdfsfsdfsdfdfasdfasdfasdfasdfng trip",
            dateCreated: "4/15/24"
        }
    ])


    return (
        <section className={styles.main}>
            <div>
                <h1 className="mb-2 text-xl">Recipes</h1>
                <div className={styles.searchCriteriaContainer}>
                    <input placeholder="Search..." />
                    <button>
                        Filter
                    </button>
                    <button>
                        Sort
                    </button>
                    <button>
                        Create New
                    </button>
                </div>
            </div>
            
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Notes</th>
                        <th>Created</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {
                        recipes.map((recipe) => {
                            return (
                                <tr
                                    key={`dashboard-recipe-${recipe.id}`}
                                    onClick={() => navigate(`/dashboard/recipes/${recipe.id}`)}
                                    className="rounded hover:cursor-pointer hover:bg-clr-background-3 transition-all duration-150"
                                >
                                    <td>{recipe.name}</td>
                                    <td>{recipe.notes}</td>
                                    <td>{recipe.dateCreated}</td>
                                    <td>||</td>
                                </tr>
                            )
                        })
                    }
                </tbody>
            </table>
        </section>
    )
}
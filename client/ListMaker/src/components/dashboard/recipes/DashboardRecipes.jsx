import { useEffect, useState } from "react"
import styles from "./DashboardRecipes.module.css"
import { useNavigate } from "react-router-dom"
import { fetchRecipes } from "../../../APIMethods"

export function DashboardRecipes() {

    const navigate = useNavigate()

    const [recipes, setRecipes] = useState([])

    const getRecipes = async () => {
        const recipesArray = await fetchRecipes(1, false)
        setRecipes(recipesArray)
    }

    useEffect(() => {
        getRecipes()
    }, [])


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
            
            <table className={styles.table}>
                <thead>
                    <tr className={styles.tr}>
                        <th className={styles.th}>Name</th>
                        <th className={styles.th}>Notes</th>
                        <th className={styles.th}>Created</th>
                        <th className={styles.th}></th>
                    </tr>
                </thead>
                <tbody>
                    {
                        recipes.map((recipe) => {
                            return (
                                <tr
                                    key={`dashboard-recipe-${recipe.id}`}
                                    onClick={() => navigate(`/dashboard/recipes/${recipe.id}`)}
                                    className={`${styles.tr} rounded hover:cursor-pointer hover:bg-clr-background-3 transition-all duration-150`}
                                >
                                    <td className={styles.td}>{recipe.name}</td>
                                    <td className={styles.td}>{recipe.notes}</td>
                                    <td className={styles.td}>{recipe.dateCreated}</td>
                                    <td className={styles.td}>||</td>
                                </tr>
                            )
                        })
                    }
                </tbody>
            </table>
        </section>
    )
}
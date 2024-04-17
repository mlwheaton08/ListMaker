import { useParams } from "react-router-dom"
import styles from "./DashboardRecipeDetails.module.css"
import { fetchRecipe } from "../../../APIMethods"
import { useEffect, useState } from "react"

export function DashboardRecipeDetails() {

    const {id} = useParams()

    const [recipe, setRecipe] = useState({})
    const [recipeItems, setRecipeItems] = useState([])

    const getRecipe = async () => {
        const recipeObj = await fetchRecipe(id)
        setRecipe(recipeObj)
    }

    useEffect(() => {
        getRecipe()
    }, [])

    useEffect(() => {
        if (recipe) setRecipeItems(recipe.recipeItems)
    }, [recipe])


    return (
        <div className={styles.main}>
            <h1>{recipe.name}</h1>
            <h6>{recipe.dateCreated}</h6>

            <table>
                <thead>
                    <tr>
                        <th>Item</th>
                        <th>Notes</th>
                        <th>Quantity</th>
                        <th>Store Section</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {
                        !recipeItems
                            ? <tr><td>no data</td></tr>
                            : recipeItems.map((recipeItem, index) => {
                                return (
                                    <tr
                                        key={`dashboard-recipeItem-${recipeItem.id}`}
                                    >
                                        <td>{recipeItem.item.name}</td>
                                        <td>{recipeItem.item.notes}</td>
                                        <td>
                                            <div>
                                                <input
                                                    type="number"
                                                    min={1}
                                                    max={50}
                                                    value={recipeItems[index].quantity}
                                                    onChange={(e) => {
                                                        const copy = [...recipeItems]
                                                        copy[index].quantity = parseInt(e.target.value)
                                                        setRecipeItems(copy)
                                                    }}
                                                />
                                                <span>{`${recipeItem.unitMeas ? recipeItem.unitMeas : ""}`}</span>
                                            </div>
                                        </td>
                                        <td>{recipeItem.item.storeSection.name}</td>
                                        <td>||</td>
                                    </tr>
                                )
                            })
                    }
                </tbody>
            </table>

            {
                !recipe.notes
                    ? ""
                    : <footer>Notes: {recipe.notes}</footer>
            }
        </div>
    )
}
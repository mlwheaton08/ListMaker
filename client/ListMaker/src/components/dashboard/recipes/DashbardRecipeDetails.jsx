import { useParams } from "react-router-dom"

export function DashboardRecipeDetails() {

    const {id} = useParams()


    return (
        <h1 className="mt-nav-height">Recipe Details, recipe: {id}</h1>
    )
}
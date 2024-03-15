using ListMaker.Models;

namespace ListMaker.Respositories
{
    public interface IRecipeItemRepository
    {
        RecipeItem GetById(int id);
        void Add(RecipeItem recipeItem);
        void Update(RecipeItem recipeItem);
        void Delete(int id);
    }
}
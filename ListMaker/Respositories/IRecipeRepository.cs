using ListMaker.Models;

namespace ListMaker.Respositories
{
    public interface IRecipeRepository
    {
        List<Recipe> GetAll(int? userId, bool listItems = false);
        Recipe GetById(int id);
    }
}
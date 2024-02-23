using ListMaker.Models;

namespace ListMaker.Respositories
{
    public interface IGroceryListRepository
    {
        List<GroceryList> GetAll(int userId, bool? open);
    }
}
using ListMaker.Models;

namespace ListMaker.Respositories
{
    public interface IGroceryListRepository
    {
        List<GroceryList> GetAll(int? userId, bool? listItems, bool? open);
        GroceryList GetById(int id);
    }
}
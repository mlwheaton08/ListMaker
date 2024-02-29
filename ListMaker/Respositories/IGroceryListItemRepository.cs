using ListMaker.Models;

namespace ListMaker.Respositories
{
    public interface IGroceryListItemRepository
    {
        GroceryListItem GetById(int id);
        void Add(GroceryListItem groceryListItem);
        void Update(GroceryListItem groceryListItem);
        void Delete(int id);
    }
}
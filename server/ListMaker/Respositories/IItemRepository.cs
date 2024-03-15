using ListMaker.Models;

namespace ListMaker.Respositories
{
    public interface IItemRepository
    {
        List<Item> GetAll(int? userId);
        Item GetById(int id);
        void Add(Item item);
        void Update(Item item);
        void Delete(int id);
    }
}
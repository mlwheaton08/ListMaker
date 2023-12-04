using ListMaker.Models;

namespace ListMaker.Respositories
{
    public interface IItemRepository
    {
        List<Item> GetAllByUserId(int userId);
    }
}
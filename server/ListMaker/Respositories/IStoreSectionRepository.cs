using ListMaker.Models;

namespace ListMaker.Respositories
{
    public interface IStoreSectionRepository
    {
        List<StoreSection> GetAll();
    }
}
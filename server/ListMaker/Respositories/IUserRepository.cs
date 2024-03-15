using ListMaker.Models;

namespace ListMaker.Respositories
{
    public interface IUserRepository
    {
        User GetByFirebaseId(string firebaseId);
    }
}
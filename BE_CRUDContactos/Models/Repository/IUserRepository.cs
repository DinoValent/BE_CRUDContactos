using BE_CRUDContactos.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BE_CRUDContactos.Models.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetListUsers();
        Task<User> GetUser(int id);
        Task DeleteUser(User user);

        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
    }
}
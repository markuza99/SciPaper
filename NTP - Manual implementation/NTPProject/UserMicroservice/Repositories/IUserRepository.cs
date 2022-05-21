using System.Collections.Generic;
using UserMicroservice.Models;

namespace UserMicroservice.Repositories
{
    public interface IUserRepository
    {
        bool SaveChanges();

        IEnumerable<User> GetAllUsers();
        User GetUserById(string id);
        void RegisterUser(User user);
        User GetUserByUsernameAndPassword(string username, string password);
    }
}

using System.Collections.Generic;
using UserMicroservice.Models;

namespace UserMicroservice.Services
{
    public interface IUserService
    {

        IEnumerable<User> GetAllUsers();
        User GetUserById(string id);
        void RegisterUser(User user);

        string login(string username, string password);

    }
}

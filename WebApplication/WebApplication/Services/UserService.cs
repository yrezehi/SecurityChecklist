using Application.Models;

namespace Application.Services
{
    public class UserService
    {
        public UserService() { }

        public User GetById(int id) => new User();

        public User Update(User user) => user;
    }
}

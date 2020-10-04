using System.Collections.Generic;

namespace Utilities
{
    internal class UserRepository : IUserRepository
    {
        public UserRepository()
        {
        }

        public User Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetUserByUsername(int userId)
        {
            throw new System.NotImplementedException();
        }

        public void Save(User entity)
        {
            System.Console.WriteLine($"User {entity.Username} is being saved!");
        }
    }
}
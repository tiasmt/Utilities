using System.Collections.Generic;

namespace Utilities
{
    public interface IUserRepository : IRepository<int, User>
    {
        IEnumerable<User> GetUserByUsername(int userId);
    }
}

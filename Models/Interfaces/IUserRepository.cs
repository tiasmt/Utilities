using System.Collections.Generic;

namespace Utilities
{
    public interface IUserRepository : IRepository<int, User>
    {
        User GetUserByUsername(string username);
    }
}

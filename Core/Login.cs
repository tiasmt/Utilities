using System;

namespace Utilities
{
    public class Login : ILogin
    {
        private readonly IUserRepository _userRepository;
    
        public Login(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Process()
        {

            return false;
        }
    }
}

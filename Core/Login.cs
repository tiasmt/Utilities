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
            return true;
        }

        public void RequestUsernameAndPassword()
        {
            var currentUser = new User();
            System.Console.WriteLine("Username: ");
            currentUser.Username = Console.ReadLine();
            System.Console.WriteLine("Password: ");
            var password = Console.ReadLine();
        }
    }
}

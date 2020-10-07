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
            RequestUsernameAndPassword();
            return true;
        }

        public void RequestUsernameAndPassword()
        {
            var currentUser = new User();
            System.Console.WriteLine("Username: ");
            currentUser.Username = Console.ReadLine();
            System.Console.WriteLine("Password: ");
            var password = Console.ReadLine();
            var existingUser = _userRepository.GetUserByUsername(currentUser.Username);
            if(existingUser != null)
            {
                var hashedPassword = Utils.HashPassword(existingUser.Salt, password);
                if(hashedPassword == existingUser.HashedPassword)
                {
                    System.Console.WriteLine($"{currentUser.Username} logged in!");
                }
                else
                {
                    System.Console.WriteLine($"Wrong username or password");
                }
            }
        }
    }
}

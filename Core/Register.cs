using System;
using System.Security.Cryptography;

namespace Utilities
{
    public class Register : IRegister
    {
        private readonly IUserRepository _userRepository;
        public Register(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Process()
        {
            var user = RequestInformation();
            _userRepository.Save(user);
            return false;
        }

        private User RequestInformation()
        {
            var isInputValid = false;
            var newUser = new User();
            byte[] salt = new byte[16];
            do
            {
                Console.Clear();
                Console.WriteLine("What is your preferred username?");
                newUser.Username = Console.ReadLine();
                Console.WriteLine("Please insert your password: ");
                var password = Console.ReadLine();
                if(Validate(newUser))
                {
                    //Create the salt value with a cryptographic PRNG:
                    new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
                    newUser.Salt = salt;
                    newUser.HashedPassword = Utils.HashPassword(salt, password);
                    isInputValid = true;
                }
                
            } while (!isInputValid);

            return newUser;
        }

        private bool Validate(User user)
        {
            var existingUser = _userRepository.GetUserByUsername(user.Username);
            if(existingUser != null)
            {
                System.Console.WriteLine($"Username {user.Username} is not available");
                Console.ReadLine();
                return false;
            }
            return true;
        }
    }
}

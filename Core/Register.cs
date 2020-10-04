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
            do
            {
                Console.Clear();
                Console.WriteLine("What is your preferred username?");
                newUser.Username = Console.ReadLine();
                Console.WriteLine("Please insert your password: ");
                var password = Console.ReadLine();
                if(Validate(newUser))
                {
                    HashPassword(newUser, password);
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

        private User HashPassword(User user, string password)
        {
            //Create the salt value with a cryptographic PRNG:
            new RNGCryptoServiceProvider().GetBytes(user.Salt = new byte[16]);
            //Create the Rfc2898DeriveBytes and get the hash value:
            var pbkdf2 = new Rfc2898DeriveBytes(password, user.Salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            //Combine the salt and password bytes for later use:
            byte[] hashBytes = new byte[36];
            Array.Copy(user.Salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            //Return combined salt+hash into a string for storage
            user.HashedPassword = Convert.ToBase64String(hashBytes);
            return user;
        }
    }
}

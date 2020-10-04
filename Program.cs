using System;
using System.Collections.Generic;

namespace Utilities
{
    class Program
    {
        
        static void Main(string[] args)
        {
            IUserRepository repository = new UserRepository();
            ILogin login = new Login(repository);
            IRegister register = new Register(repository);
            Menu menu = new Menu(login, register);
            Console.ReadKey();
        }

    }
}

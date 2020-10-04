using System;
using System.Collections.Generic;

namespace Utilities
{
    //should be a singleton
    public class Menu
    {
        public static List<MenuItem> MenuItems;
        private readonly ILogin _login;
        private readonly IRegister _register;
        public Menu(ILogin Login, IRegister Register)
        {
            _login = Login;
            _register = Register;
            CreateMenuItems();
            DisplayMenu();
        }
        private void CreateMenuItems()
        {
            MenuItems = new List<MenuItem>
            {
                new MenuItem{Description = "Login", Execute = _login.Process},
                new MenuItem{Description = "Register", Execute = _register.Process},
                new MenuItem{Description = "Exit", Execute = Exit}
            };
        }

        private void DisplayMenu()
        {
            for (var i = 0; i < MenuItems.Count; i++)
            {
                Console.WriteLine($"{i + 1} . {MenuItems[i].Description}");
            }

            int userInput;

            // Get the user input
            do
            {
                Console.Write($"Enter a choice (1 - {MenuItems.Count}): ");
            } while (!int.TryParse(Console.ReadLine(), out userInput) ||
                     userInput < 1 || userInput > MenuItems.Count);

            // Execute the menu item function
            MenuItems[userInput - 1].Execute();
        }

        private bool Exit()
        {
            
            return true;
        }
    }
}

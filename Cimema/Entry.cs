using System;
using System.IO;

namespace Cimema
{
    public class Entry
    {
        private bool pressedExit = false;
        
        public void Registration()
        {
            Console.Clear();
            Console.WriteLine("Enter login");
            var login = Console.ReadLine();
            Console.WriteLine("Enter password");
            var password = Console.ReadLine();
            if (Item.ChooseItem(new[] {"Yes", "No"}) == "Yes")
            {
                if (CheckLogin(login))
                {
                    Console.Clear();
                    Console.WriteLine("Your registration was successful");
                    File.AppendAllLines("../../../Data/Logins.txt", new[]{login + ";" + password});
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("This login already exists");
                }
            }
            else 
            {
                Console.Clear();
                Registration();
            }
        }

        private bool CheckLogin(string login)
        {
            var logins = File.ReadAllLines("../../../Data/Logins.txt");

            for (var i = 0; i < logins.Length; i++)
            {
                if (login == logins[i].Split(';')[0])
                    return false;
            }

            return true;
        }

        public void Authorization()
        {
            Console.Clear();
            Console.WriteLine("Enter your login");
            var login = Console.ReadLine();
            Console.WriteLine("Enter your password");
            var password = Console.ReadLine();
            if (!CheckLogin(login))
            {
                Console.WriteLine("User with this login does not exist");
                Console.ReadKey();
            }
            else if (CheckPassword(login, password))
            {
                Console.WriteLine("Wrong password\n" + "Try again?");
                if (Item.ChooseItem(new[] {"Yes", "No"}) == "Yes")
                {
                    Console.Clear();
                    Authorization();
                }
                else
                {
                    Console.Clear();
                    Console.ReadKey();
                }
            }
            
        }

        private bool CheckPassword(string login, string password)
        {
            var logins = File.ReadAllLines("../../../Data/Logins.txt");

            for (var i = 0; i < logins.Length; i++)
            {
                var currentLogin = logins[i].Split(';');
                if (login == currentLogin[0] && password != currentLogin[1])
                    return false;
            }

            return true;
        }

        
    }
}
using System;
using System.IO;

namespace Cimema
{
    public static class Entry
    {
        public static bool Registration()
        {
            Console.Clear();
            Console.WriteLine("Enter login");
            var login = Console.ReadLine();
            Console.WriteLine("Enter password");
            var password = Console.ReadLine();
            if (login == "" || password == "")
            {
                Console.WriteLine("Can not be empty");
                Console.ReadKey();
                return false;
            }
            if (CheckLogin(login))
            {
                Console.Clear();
                Console.WriteLine("This login already exists");
                Console.ReadKey();
                return false;
            }
            Console.Clear();
            Console.WriteLine("Your registration was successful");
            File.AppendAllLines("../../../Data/Logins.txt", new[]{login + ";" + password + ";user"});
            Console.ReadKey();
            return true;
        }

        private static bool CheckLogin(string login)
        {
            var logins = File.ReadAllLines("../../../Data/Logins.txt");

            for (var i = 0; i < logins.Length; i++)
            {
                if (login == logins[i].Split(';')[0])
                    return true;
            }

            return false;
        }

        private static Module GetModule(string login)
        {
            Module module = null;
            var logins = File.ReadAllLines("../../../Data/Logins.txt");
            for (var i = 0; i < logins.Length; i++)
            {
                if (login == logins[i].Split(';')[0])
                {
                    switch (logins[i].Split(';')[2])
                    {
                        case "admin":
                            module = new Administrator();
                            break;
                        case "cashier":
                            module = new Cashier();
                            break;
                        case "user":
                            module = new Poster();
                            break;
                    }
                }
            }

            return module ?? throw new Exception("Error");
        }

        public static Person Authorization()
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
            else if (!CheckPassword(login, password))
            {
                Console.WriteLine("Wrong password\n");
                Console.ReadKey();
                return null;
            }

            return new Person(GetModule(login), login);
        }

        private static bool CheckPassword(string login, string password)
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
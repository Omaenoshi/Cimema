using System;
using System.IO;

namespace Cimema
{
    public static class Entry
    {
        public static void Registration()
        {
            Console.WriteLine("Enter your login");
            var login = Console.ReadLine();
            Console.WriteLine("Enter your password");
            var password = Console.ReadLine();
            if (Title.ChooseTitle(new[] {"Yes", "No"}) == "Yes")
            {
                if (CheckLogin(login))
                {
                    Console.Clear();
                    Console.WriteLine("Your registration was successful");
                    File.AppendAllLines("../../../Logins.txt", new[]{login + ";" + password});
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

        private static bool CheckLogin(string login)
        {
            var logins = File.ReadAllLines("../../../Logins.txt");

            for (var i = 0; i < logins.Length; i++)
            {
                if (login == logins[i].Split(';')[0])
                    return false;
            }

            return true;
        }
    }
}
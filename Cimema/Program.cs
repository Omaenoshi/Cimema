using System;
using System.IO;

namespace Cimema
{
    class Program
    {

        private static readonly string[] Asks = new[] {"Yes", "No"};
        private static int selectedIndex;
        
        static void Main(string[] args)
        {
            selectedIndex = 0;
            Authorization();
        }

        static void Authorization()
        {
            Console.WriteLine("Enter your login");
            var login = Console.ReadLine();
            Console.WriteLine("Enter your password");
            var password = Console.ReadLine();
            if (Confirm())
            {
                Console.WriteLine("Your authorization was successful");
                File.AppendAllLines("../../../Authentication.txt", new[]{login + ";" + password});
            }
            else
            {
                Console.Clear();
                Authorization();
            }
        }

        static bool Confirm()
        {
            ConsoleKey keyPressed;
            Console.CursorVisible = false;
            do
            {
                Console.Write(new string(' ', Console.BufferWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                PrintAsk();
                keyPressed = Console.ReadKey().Key;

                if (keyPressed == ConsoleKey.LeftArrow)
                {
                    selectedIndex--;
                    if (selectedIndex == -1)
                        selectedIndex = Asks.Length - 1;
                }
                else if (keyPressed == ConsoleKey.RightArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == Asks.Length)
                        selectedIndex = 0;
                }
            } while (keyPressed != ConsoleKey.Enter);
            Console.CursorVisible = true;
            
            return selectedIndex == Array.IndexOf(Asks, "Yes") ? true : false;
        }

        static void PrintAsk()
        {
            for (var i = 0; i < Asks.Length; i++)
            {
                var currentAsk = Asks[i];

                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                
                Console.Write($"{currentAsk} ");
                Console.ResetColor();
            }
        }
    }
}
using System;

namespace CimemaApp
{
    public static class Item
    {
        private static int selectedIndex = 0;

        public static string ChooseItem(string[] title)
        {
            ConsoleKey keyPressed;
            Console.CursorVisible = false;
            do
            {
                Console.Write(new string(' ', Console.BufferWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                PrintItems(title);
                keyPressed = Console.ReadKey().Key;

                if (keyPressed == ConsoleKey.LeftArrow || keyPressed == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex == -1)
                        selectedIndex = title.Length - 1;
                }
                else if (keyPressed == ConsoleKey.RightArrow || keyPressed == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == title.Length)
                        selectedIndex = 0;
                }
            } while (keyPressed != ConsoleKey.Enter);
            Console.CursorVisible = true;

            return title[selectedIndex];
        }

        public static void PrintItems(string[] title)
        {
            for (var i = 0; i < title.Length; i++)
            {
                var currentAsk = title[i];

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
using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading.Channels;

namespace CimemaApp
{
    public abstract class Module
    {
        protected string[] items;
        
        public bool pressedExit { get; set; }

        public abstract void RunModule();
    }

    public class Administrator : Module
    {
        public Administrator()
        {
            items = new[] {"Create a cinema", "Exit"};
        }

        public override void RunModule()
        {
            if (Item.ChooseItem(items) == items[0])
            {
                var cinema = new Cinema();
                Console.WriteLine("Enter the number of halls");
                cinema.HallCount = int.Parse(Console.ReadLine() ?? throw new FormatException());
                for (var i = 0; i < cinema.HallCount; i++)
                {
                    Console.WriteLine($"Enter the number of {i+1} hall");
                    var hallNumber = int.Parse(Console.ReadLine() ?? throw new FormatException());
                    Console.WriteLine("Enter the dimension of this hall");
                    var dimension = int.Parse(Console.ReadLine() ?? throw new FormatException());
                    cinema.Halls.Add(new Hall(hallNumber, dimension));
                }
            }

            pressedExit = true;
        }
    }

    public class Cashier : Module
    {
        public Cashier()
        {
            items = new[] {"Choose a movie", "Exit"};
        }

        public override void RunModule()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Poster : Module
    {
        public Poster()
        {
            items = new[] {"The movies", "Exit"};
        }

        public override void RunModule()
        {
            throw new System.NotImplementedException();
        }
    }
}
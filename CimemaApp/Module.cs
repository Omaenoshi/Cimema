using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Threading.Channels;

namespace CimemaApp
{
    public abstract class Module
    {
        protected string[] Items;

        public bool PressedExit { get; set; }

        public abstract void RunModule();
    }

    public class Administrator : Module
    {
        private Cinema _currentCinema;

        public Administrator()
        {
            Items = new[] {"Create a cinema", "Exit"};
        }

        public override void RunModule()
        {
            _currentCinema = new Cinema();
            Console.Clear();
            while (PressedExit == false)
            {
                if (Item.ChooseItem(Items) == Items[0])
                    CreateCinema();
                else
                {
                    PressedExit = true;
                    var json = JsonSerializer.Serialize<Cinema>(_currentCinema);
                    File.AppendAllLines("../../../Data/Cinemas.txt", new [] {json});
                    break;
                }
            }
        }

        private void CreateCinema()
        {
            Console.Clear();
            var items = new[] {"Fill in the details of the cinema", "Add the movies", "Add the session", "Exit"};
            switch (Item.ChooseItem(items))
            {
                case "Fill in the details of the cinema":
                    FillCinema();
                    break;
                case "Add the movies":
                    AddMovie();
                    break;
                case "Add the session":
                    AddSession();
                    break;
                case "Exit":
                    break;
            }
        }

        private void AddSession()
        {
            Console.Clear();
            Console.WriteLine("Enter the count of the sessions");
            var count = int.Parse(Console.ReadLine() ?? throw new FormatException());
            for (var i = 0; i < count; i++)
            {
                Console.WriteLine($"Enter the id of the movie");
                var id = int.Parse(Console.ReadLine() ?? throw new FormatException());
                Console.WriteLine("Enter the date of this session");
                var date = Console.ReadLine();
                Console.WriteLine("Enter the time of this session");
                var time = Console.ReadLine();
                Console.WriteLine("Enter the hall of this session");
                var hall = int.Parse(Console.ReadLine() ?? throw new FormatException());
                Console.WriteLine("Enter the cost of this film");
                var cost = double.Parse(Console.ReadLine() ?? throw new FormatException());

                _currentCinema.Session.Add(new Session(_currentCinema.Movies[id], date, time,
                    _currentCinema.Halls[hall], cost));
            }
            CreateCinema();
        }

        private void AddMovie()
        {
            Console.Clear();
            Console.WriteLine("Enter the count of the movies");
            var count = int.Parse(Console.ReadLine() ?? throw new FormatException());
            for (var i = 0; i < count; i++)
            {
                Console.WriteLine($"Enter the name of the {i} movie");
                var name = Console.ReadLine();
                Console.WriteLine("Enter the genre of this movie");
                var genre = Console.ReadLine();
                Console.WriteLine("Enter the duration of this movie");
                var duration = double.Parse(Console.ReadLine() ?? throw new FormatException());
                Console.WriteLine("Enter the actors of this movie");
                var actors = Console.ReadLine();
                Console.WriteLine("Enter the ID of this film");
                var id = int.Parse(Console.ReadLine() ?? throw new FormatException());
                _currentCinema.Movies.Add(id, new Movie(id, name, genre, duration, actors));
            }
            CreateCinema();
        }

        private void FillCinema()
        {
            Console.Clear();
            Console.WriteLine("Enter the number of halls");
            _currentCinema.HallCount = int.Parse(Console.ReadLine() ?? throw new FormatException());
            for (var i = 0; i < _currentCinema.HallCount; i++)
            {
                Console.WriteLine($"Enter the number of {i + 1} hall");
                var hallNumber = int.Parse(Console.ReadLine() ?? throw new FormatException());
                Console.WriteLine("Enter the dimension of this hall");
                var dimension = int.Parse(Console.ReadLine() ?? throw new FormatException());
                _currentCinema.Halls.Add(hallNumber, new Hall(hallNumber, dimension));
            }
            CreateCinema();
        }
    }

    public class Cashier : Module
    {
        public Cashier()
        {
            Items = new[] {"Choose a movie", "Exit"};
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
            Items = new[] {"The movies", "Exit"};
        }

        public override void RunModule()
        {
            throw new System.NotImplementedException();
        }
    }
}
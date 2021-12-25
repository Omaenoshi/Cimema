using System;

namespace CimemaApp
{
    public class Session
    {
        public Movie CurrentMovie { get; }
        
        public string Date { get; }
        
        public string Time { get; }

        public Hall CurrentHall { get; }
        
        public double Cost { get; }

        public Session(Movie movie, string date, string time, Hall hall, double cost)
        {
            CurrentMovie = movie;
            Date = date;
            Time = time;
            CurrentHall = hall;
            Cost = cost;
        }
    }
}
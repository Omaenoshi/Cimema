using System;

namespace CimemaApp
{
    public class Session
    {
        public Movie CurrentMovie { get; }
        
        public DateTime Date { get; }
        
        public DateTime Time { get; }

        public Hall CurrentHall { get; }
        
        public double Cost { get; }

        public Session(Movie movie, DateTime date, DateTime time, Hall hall, double cost)
        {
            CurrentMovie = movie;
            Date = date;
            Time = time;
            CurrentHall = hall;
            Cost = cost;
        }
    }
}
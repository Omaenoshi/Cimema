using System;
using System.Collections.Generic;

namespace CimemaApp
{
    public class Cinema
    {
        public int HallCount { get; set; }
        
        public List<Hall> Halls { get; set; }
        
        public List<Movie> Movies { get; set; }

        public Cinema()
        {
            Halls = new List<Hall>();
            Movies = new List<Movie>();
        }
    }
}
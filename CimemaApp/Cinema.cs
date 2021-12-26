using System;
using System.Collections.Generic;
using System.IO;

namespace CimemaApp
{
    public class Cinema
    {
        public int HallCount { get; set; }
        
        public Dictionary<int, Hall> Halls { get; set; }
        
        public List<Session> Session { get; set; }
        
        public Dictionary<int, Movie> Movies { get; set; }

        public Cinema()
        {
            Halls = new Dictionary<int, Hall>();
            Session = new List<Session>();
            Movies = new Dictionary<int, Movie>();
        }
        
        public void WriteInFile()
        {
            for(var i = 0; i < HallCount; i++)
            {
                File.AppendAllLines("../../../Data/Cinemas.txt", new []
                {
                    HallCount + ";", 
                    Halls[i].HallNumber + ";", 
                    Halls[i].Dimension + ";"
                });
            }
        }
    }
}
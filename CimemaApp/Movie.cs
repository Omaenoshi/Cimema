namespace CimemaApp
{
    public class Movie
    {
        public string Name { get; }
        
        public string Genre { get; }
        
        public double Duration { get; }
        
        public string Actors { get; set; }
        
        public int Id { get; }

        public Movie(int id, string name, string genre, double duration, string actors)
        {
            Id = id;
            Name = name;
            Genre = genre;
            Duration = duration;
            Actors = actors;
        }
    }
}
namespace CimemaApp
{
    public class Movie
    {
        public string Name { get; }
        
        public string Genre { get; }
        
        public int Duration { get; }
        
        public int Id { get; }

        public Movie(int id, string name, string genre, int duration)
        {
            Id = id;
            Name = name;
            Genre = genre;
            Duration = duration;
        }
    }
}
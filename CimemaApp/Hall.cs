namespace CimemaApp
{
    public class Hall
    {
        public int HallNumber { get; }
        
        public int Dimension { get; }

        public Hall(int hallNumber, int dimension)
        {
            HallNumber = hallNumber;
            Dimension = dimension;
        }
    }
}
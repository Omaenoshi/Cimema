using System.ComponentModel;
using System.Threading.Channels;

namespace CimemaApp
{
    public abstract class Module
    {
        protected string[] items;

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
            throw new System.NotImplementedException();
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
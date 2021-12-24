namespace Cimema
{
    public class Person
    {
        public Module Module { get; }
        
        public string Login { get; }

        public Person(Module module, string login)
        {
            Module = module;
            Login = login;
        }
    }
}
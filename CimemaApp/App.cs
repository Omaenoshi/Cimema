using System;

namespace CimemaApp
{
    public class App
    {
        private Person currentPerson;
        private Module currentModule;
        private string[] menu = new[] {"Authorization", "Registration"};

        public void Run()
        {
            TryEntry();
            Console.WriteLine("You successfully completed");
        }

        private void TryEntry()
        {
            var completedRegistration = false;
            do
            {
                Console.Clear();
                if (Item.ChooseItem(new[] {"Authorization", "Registration"}) == "Authorization")
                {
                    currentPerson = Entry.Authorization();
                    currentModule = currentPerson.Module;
                }
                else
                {
                    completedRegistration = Entry.Registration();
                }
            } while (currentPerson == null && completedRegistration == false);
        }
    }
}
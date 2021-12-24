using System;
using System.ComponentModel.Design;

namespace CimemaApp
{
    public class App
    {
        private Person currentPerson;
        private Module currentModule;
        private string[] menu = new[] {"Authorization", "Registration", "Exit"};
        private bool pressedExit = false;

        public void Run()
        {
            while (pressedExit == false)
            {
                Console.Clear();
                ResetAuthentication();
                TryEntry();
                TryRunModule();
            }
        }

        private void TryRunModule()
        {
            do
            {
                Console.Clear();
                currentModule?.RunModule();
            } while (currentModule is {pressedExit: false});
        }

        private void ResetAuthentication()
        {
            currentModule = null;
            currentPerson = null;
        }

        private void TryEntry()
        {
            var completedRegistration = false;
            do
            {
                Console.Clear();
                switch (Item.ChooseItem(menu))
                {
                    case "Authorization":
                        currentPerson = Entry.Authorization();
                        if (currentPerson != null)
                            currentModule = currentPerson.Module;
                        break;
                    case "Registration":
                        completedRegistration = Entry.Registration();
                        break;
                    case "Exit":
                        pressedExit = true;
                        break;
                }
            } while (currentPerson == null && completedRegistration == false && pressedExit == false);
        }
    }
}
using System;

namespace readus_keesha_finalProject
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Clear();
            //I displayed my welcome message
            UI.Header("welcome");
            //I called the display method
            Menu.DisplayMenu();
        }
        //I created an exit method
        public static void Exit()
        {
            UI.Footer();
            //I displayed a message signalling the end of the program
            Console.WriteLine("Thank you for playing!");
            Menu.DisplayMenu();

        }

   // End Class
    }
}

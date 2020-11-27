using System;
namespace readus_keesha_finalProject
{
    public class UI
    {


        public static void Header(string h)
        {
            Console.WriteLine("==================================");
            Console.WriteLine($"{h.ToUpper()}");
            Console.WriteLine("==================================");
        }

        public static void Seperator ()
            {
            Console.WriteLine("-------------------------");
            }

        public static void Footer()
        {
            
            Console.WriteLine("==================================");
           
        }


        // End Class
    }
}

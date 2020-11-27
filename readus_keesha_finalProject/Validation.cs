using System;
namespace readus_keesha_finalProject
{
    public class Validation
    {
        // I created a validation method that reurns an int and that I could use to ask the question and repeat the question to reduce code
        public static int GetInt(string message = "Enter Maximum Number: ")
        {// I created an int variable to return the valudated int in
            int validatedInt;
            //I ctreated a string to accept the users response
            string input = null;
            // I used the do while loop so my message would be displayed atleast once so I could ask for the users response
            do
            {
                //The console.write displays the message with the params of my method
                Console.Write(message);
                //this is where the users response is being accepted
                input = Console.ReadLine();
                //I used a try parse to validate the int
            } while (!Int32.TryParse(input, out validatedInt));
            //I returned the validated int
            return validatedInt;


        }
        //This is an overload of my int validation method. I use this when I want to validate a range of numbers
        public static int GetInt(int min, int max, string message = "Enter a valid number from 1 to 20: ")
        {
            int validatedInt;
            string input = null;

            do
            {

                Console.Write(message);
                input = Console.ReadLine();
                // I use a trypare to validate the int as well as a number range
            } while (!(Int32.TryParse(input, out validatedInt) && (validatedInt >= min && validatedInt <= max)));

            return validatedInt;
        }
        public static string GetString(string message = " Please enter a valid response!:  ")
        {

            string input = null;

            do
            {

                Console.Write(message);
                input = Console.ReadLine().ToUpper();

                //I used a isnullorwhitespace to validate that the users input was not empty
            } while ((string.IsNullOrWhiteSpace(input)) && ( input != "YES" || input != "NO"));
            return input;

        }
        
        // End Class
    }
}
using System;
namespace readus_keesha_finalProject
{
    public class Menu
    {
     

        

        public static void DisplayMenu()
        {//I cleared the console
          
            //I created a string array with my menu options
            string[] menuItems = { "Black Jack", "Poker",  };
            //i used a for loop to iterate through the array to display my menu
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"[{i + 1}]: {menuItems[i]}");
            }
            Console.WriteLine("");
            //I used a console .writeline to display the option to exit
            Console.WriteLine("[0]: Exit");

            UI.Seperator();
            int selection = Validation.GetInt(0, 2, $"Please enter your selection:   ");
            MenuSelection(selection);
        }

        private static void MenuSelection(int selection)
        {// I cleared the console
            Console.Clear();


            // I used the switch statement to display the message to the user depending on what integer was passed through 
            switch (selection)
            {
                case 1:
                    UI.Header("black jack");
                    BlackJack blackJack = new BlackJack();
                    while (blackJack.PlayerMoney > 0)
                    {
                       



                        blackJack.Bet();
                        blackJack.Deal();
                        blackJack.DisplayHand();
                        
                            blackJack.Choice();
                        

                    }
                    Continue();
                    break;
                case 2:
                    UI.Header("poker");
                    Continue();
                    break;
               
                  
                case 0:
                    Program.Exit();
                    break;
                default:
                    //I only used the default out of good practice my validation method should have caught everything else
                    Console.WriteLine("Please enter a valid choice");
                    break;

            }
            

        }
        //I created a method that would return the user back to the main method
        private static void Continue()
        {
            Console.WriteLine("");
            UI.Seperator();
            Console.Write("Press any key to return to the menu: ");
            Console.ReadKey();
            //I called the display menue to return the user back to the display method. i assumed it was the main method in the instructions because the main method from program is not accessible
            DisplayMenu();
        }
        public void YesOrNo(string answer)
        {
            //answer = Validation.GetString("Would you like to  continue playing (Yes) or (No)?:  ");

            if(answer == "YES")
            {
                Continue(); 
            }
            else if (answer == "NO")
            {
                Console.WriteLine("Thank you for playing Black Jack! GoodBye.");
                Program.Exit();
            }
        }
        
    }
}
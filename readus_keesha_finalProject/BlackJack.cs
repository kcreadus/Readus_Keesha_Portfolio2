using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace readus_keesha_finalProject
{
    class BlackJack : Game, IGame 
    {

        Deck playingDeck { get; set; }


        Hand playerHand { get; set; }
        Hand dealerHand { get; set; }
        Menu option { get; set; }
         decimal playerMoney = 150;



        int dealerCard { get; set; }
        int dealerHandTotal { get; set; }
        int dealerTotal { get; set; }
        int playerCard { get; set; }
        int playerHandTotal;
        int playerTotal { get; set; }


        decimal bet { get; set; }
        public decimal PlayerMoney
        {
            get
            {
                return playerMoney;
            }
            set
            {
                playerMoney = value;
            }
        }
        
        public int PlayerTotal
        {
            get
            {
                return playerHandTotal;
            }
            set
            {
                playerHandTotal = value;
            }
        }
        public BlackJack()
        {
            Console.WriteLine("Welcome to Black Jack! \n");
            playingDeck = new Deck();

            playingDeck.Shuffle();
            playerHand = new Hand();
            dealerHand = new Hand();
            option = new Menu();
        }




        public void Deal()
        {
            //Start dealing 
            //Player gets two cards
            playingDeck.Draw(playerHand);
            playingDeck.Draw(playerHand);

            //Dealer gets two cards
            playingDeck.Draw(dealerHand);
            playingDeck.Draw(dealerHand);

            playerCard = playerHand.AddValue(0, playerHand.CardHand[0]);
            playerHandTotal = playerHand.AddValue(playerCard, playerHand.CardHand[1]);

            dealerCard = dealerHand.AddValue(0, dealerHand.CardHand[0]);
            dealerHandTotal = dealerHand.AddValue(dealerCard, dealerHand.CardHand[1]);


        }

        public void InstantWinner()
        {
            string answer;
            if (playerHandTotal == 21)
            {
                Console.WriteLine("Player is an instant winner " + playerHandTotal);
                playerHand = new Hand();
                dealerHand = new Hand();
                answer = Validation.GetString("Would you like to continue playing (Yes) or (No)?:  ");
                option.YesOrNo(answer);
                
            }
            else if (dealerHandTotal == 21)
            {
                Console.WriteLine("Dealer is an instant winner " + dealerHandTotal);
                playerHand = new Hand();
                dealerHand = new Hand();
                answer = Validation.GetString("Would you like to continue playing (Yes) or (No)?:  ");
                option.YesOrNo(answer);


            }

        }

        public void DisplayHand()
        {




            //StartGame Hand
            Console.WriteLine("Your Hand");
            Console.WriteLine(playerHand.CardHand[0].ToString() + "\n" + playerHand.CardHand[1].ToString());
            InstantWinner();
            //write code to exit program in instant winner if true
            Console.WriteLine("Your hand is valued at:  " + playerHandTotal);
            //StartGame Dealers hand
            Console.WriteLine("Dealer Hand: " + dealerHand.CardHand[0].ToString() + " and [cardhidden]");
            DealerPlayDecision();
        }
        public void Choice()
        {
            if (playerHandTotal > 0 && dealerTotal < 21)
            {
                
                decimal response = Validation.GetInt(1, 2, "Would you like to (1) Hit or (2) Stand?:  ");

                switch (response)
                {
                    case 1:

                        playingDeck.Draw(playerHand);
                        playerTotal = playerHand.AddValue(playerHandTotal, playerHand.CardHand[2]);

                        Console.WriteLine("Your draw  is a: " + playerHand.CardHand[2].ToString());

                        Hit();


                        break;
                    case 2:
                        Stand();

                        break;
                    default:
                        break;

                }

                playerHand = new Hand();
                dealerHand = new Hand();
            }
            else
            {

                playerHand = new Hand();
                dealerHand = new Hand();
                Program.Exit();
            }
        }
        public void Hit()
        {
         
            if (playerTotal > 21)
            {
                
                Console.WriteLine("Busted!... " + playerTotal);
                Console.WriteLine("Dealer wins!!: "); DealerTotalCheck();
                playerMoney -= bet;
                Console.WriteLine("Your total is " + playerTotal + " Your current payout is $" + playerMoney);
                

                Console.WriteLine("Press enter to continue playing");
                Console.ReadKey();
                Console.Clear();
            }



            else if (dealerTotal > playerTotal && dealerTotal <= 21 || dealerHandTotal > playerTotal && dealerHandTotal <= 21)
            {
                Console.WriteLine("Dealer wins!!: "); DealerTotalCheck();
                Console.WriteLine("Player loses...." + playerTotal);
                playerMoney -= bet;
                Console.WriteLine("Your total is " + playerTotal + " Your current payout is $" + playerMoney);
                Console.WriteLine("Press enter to continue playing");

                Console.ReadKey();
                Console.Clear();

            }
            else if (dealerTotal < playerTotal || dealerHandTotal < playerTotal)
            {
                Console.WriteLine("Player wins!!: " + playerTotal);
                Console.WriteLine("Dealer loses...."); DealerTotalCheck();
                playerMoney += bet;
                Console.WriteLine("Your current payout is $" + playerMoney);
                Console.WriteLine("Press enter to continue playing");

                Console.ReadKey();
                Console.Clear();
            }

        }
        public void Stand()
        {
            if (dealerTotal > 21)
            {
                Console.WriteLine(" Dealer Busted!... "); DealerTotalCheck();
                playerMoney += bet;
                Console.WriteLine("Your total is " + playerHandTotal + " Your current payout is $" + playerMoney);
                Console.WriteLine("Press enter to continue playing");

                Console.ReadKey();
                Console.Clear();
            }

            else if (dealerTotal > playerHandTotal && dealerTotal <= 21 || dealerHandTotal > playerHandTotal && dealerHandTotal <= 21)
            {
                Console.WriteLine("Dealer wins!!: "); DealerTotalCheck();
                Console.WriteLine("Player loses...." + playerHandTotal);
                playerMoney -= bet;
                Console.WriteLine(" Your current payout is $" + playerMoney);
                Console.WriteLine("Press enter to continue playing");

                Console.ReadKey();
                Console.Clear();
            }
            else if (dealerTotal < playerHandTotal && playerHandTotal <= 21 || dealerHandTotal < playerHandTotal && playerHandTotal <= 21)
            {
                Console.WriteLine("Player wins!!: " + playerHandTotal);
                Console.WriteLine("Dealer loses...."); DealerTotalCheck();
                playerMoney += bet;
                Console.WriteLine(" Your current payout is $" + playerMoney);
                Console.WriteLine("Press enter to continue playing");

                Console.ReadKey();
                Console.Clear();
            }
        }
        public void DealerPlayDecision()
        {
            if (dealerHandTotal < 17)
            {
                playingDeck.Draw(dealerHand);
                dealerTotal = dealerHand.AddValue(dealerHandTotal, dealerHand.CardHand[2]);
                if (dealerTotal > 21)
                {
                    Console.WriteLine(" Dealer Busted!... "); DealerTotalCheck();
                    playerMoney += bet;
                    Console.WriteLine("Your total is " + playerHandTotal + " Your current payout is $" + playerMoney);
                    Console.WriteLine("Press enter to continue playing");
                    playerHand = new Hand();
                    dealerHand = new Hand();
                    Console.ReadKey();
                    Console.Clear();

                }
                else if (dealerTotal == 21)
                {
                    Console.WriteLine("Dealer wins!!: "); DealerTotalCheck();
                    Console.WriteLine("Player loses...." + playerHandTotal);
                    playerMoney -= bet;
                    Console.WriteLine(" Your current payout is $" + playerMoney);
                    Console.WriteLine("Press enter to continue playing");
                    playerHand = new Hand();
                    dealerHand = new Hand();
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        public void DealerTotalCheck()
        {
            if (dealerTotal > 16)
            {
                Console.WriteLine("Dealer total is " + dealerTotal);
            }
            else if ((dealerTotal <= 16))
            {
                Console.WriteLine("Dealer total is " + dealerHandTotal);
            }



        }
        
        public override void Bet()
        {



            if (playerMoney > 0)

            {


                bet = Validation.GetInt("You have $" + playerMoney + ", how much would you like to bet?:  ");
            }
             if (bet > playerMoney)
            { 
                Console.WriteLine("Your bet exceeded your holdings. You lose!");
                //Console.ReadKey();
                Program.Exit();
                
            }
            else if (playerMoney <= 0)
            {
                Console.WriteLine(" Game Over");
               // Console.ReadKey();
                Program.Exit();
            }
        }
        }


        }

   

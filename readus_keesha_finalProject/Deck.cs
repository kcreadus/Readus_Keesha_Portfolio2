using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace readus_keesha_finalProject
{
    class Deck
    {

        private readonly List<Cards> cards;
        private Random random = new Random();
        int deckSize;

        public Deck()
        {

            cards = new List<Cards>();
            //Added Below
            CreateDeck();
            Shuffle();
            deckSize = cards.Count();
        }



        public void CreateDeck()
        {//I created a nest for loop to match the nums to represent each card
            for (int suit = 1; suit <= 4; suit++)

                for (int value = 1; value <= 13; value++)
                    //I saved the results of the loop into the list of cards
                    cards.Add(new Cards((Cards.CardSuits)suit, (Cards.CardValues)value));


        }
        public void Shuffle()
        {
            Cards tempDeck;



            for (int shuffleTimes = 0; shuffleTimes < 40; shuffleTimes++)
            {
                for (int i = 1; i < deckSize; i++)
                {
                    int secondCardNumber = random.Next(13);
                    tempDeck = cards[i];
                    cards[i] = cards[secondCardNumber];
                    cards[secondCardNumber] = tempDeck;
                }
            }
        }



        public void Draw(Hand hand)
        {

            //Shuffle();
            Cards cardDrawn = cards[cards.Count - 1];

            hand.CardHand.Add(cardDrawn);
            cards.Remove(cardDrawn);
        }


        public override string ToString()
        {
            string output = "";

            foreach (Cards card in cards)
            {
                output += "\n" + card.ToString();

            }
            return output;


        }
    }
}

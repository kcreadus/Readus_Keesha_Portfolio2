using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace readus_keesha_finalProject
{
    class Hand
    {
        private List<Cards> _hand;

        public Hand()
        {
            _hand = new List<Cards>();
        }

        public List<Cards> CardHand
        {
            get
            {
                return _hand;
            }
            set
            {
                _hand = value;
            }

        }

        public int AddValue(int currentSum, Cards drawn)
        {
            if (drawn.Value == Cards.CardValues.Ace)
            {
                if (currentSum <= 10)
                {
                    currentSum += 11;

                }
                else
                {
                    currentSum += 1;
                }
            }
            else if (drawn.Value == Cards.CardValues.Jack || drawn.Value == Cards.CardValues.Queen || drawn.Value == Cards.CardValues.King)
            {
                currentSum += 10;
            }
            else
            {
                currentSum += (int)drawn.Value;


            }
            return currentSum;
        }
        public override string ToString()
        {
            string output = "";

            foreach (Cards card in CardHand)
            {
                output += "\n" + card.ToString();

            }
            return output;


        }
    }
}


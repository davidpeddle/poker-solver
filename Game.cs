using System.Collections.Generic;
using System.Linq;

namespace Poker {
    public class Game{
        public List<Hand> Winners {get;}

        public Game(){
            Winners = new List<Hand>();
        }

        public void AddHand(Hand hand){
            if (!Winners.Any()){
                Winners.Add(hand);
                return;
            }
            
            int handComparisonResult = hand.CompareTo(Winners[0]);
            if (handComparisonResult < 0){
                return;
            }
            else if (handComparisonResult > 0){
                Winners.Clear();
            }

            Winners.Add(hand);
        }
    }
}
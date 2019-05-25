using System.Collections.Generic;
using System.Linq;

namespace Poker{
    public class Flush : Hand{
        public Flush(string name, IEnumerable<Card> cards) : base(name){
            PrimaryQueue = cards.Select(card => card.Rank).ToList();
            HandTypePrecedence = HandTypePrecedence.Flush;
        }

        public static bool CheckIfFlush(IEnumerable<Card> cards){
            Suit suit = cards.First().Suit;
            foreach (Card card in cards.Skip(1)){
                if (card.Suit != suit){
                    return false;
                }
            }
            return true;
        }
    }
}
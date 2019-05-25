using System.Collections.Generic;
using System.Linq;

namespace Poker {
    public class HighCard : Hand{
        public HighCard(string name, IEnumerable<Card> cards) : base(name){ 
            PrimaryQueue = cards.Select(card => card.Rank).OrderByDescending(rank => rank).ToList();
            HandTypePrecedence = HandTypePrecedence.HighCard;
        }
    }
}
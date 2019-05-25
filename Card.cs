using System;

namespace Poker {
    public class Card{
        public Suit Suit {get;}
        public Rank Rank {get;}
        public Card(string cardCode){
            Rank = Ranks.GetByCode(cardCode.Substring(0, cardCode.Length - 1));
            Suit = Suits.GetByChar(cardCode[cardCode.Length - 1]);
        }
    }
}
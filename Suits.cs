using System;

namespace Poker {
    public enum Suit {Diamonds, Hearts, Clubs, Spades};

    public class Suits{
        public static Suit GetByChar(char suitChar){
            switch(Char.ToUpper(suitChar)){
                case 'D':
                    return Suit.Diamonds;
                case 'H':
                    return Suit.Hearts;
                case 'C':
                    return Suit.Clubs;
                case 'S':
                    return Suit.Spades;
                default:
                    throw new Exception();
            }
        }
    }
}
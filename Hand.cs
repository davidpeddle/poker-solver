using System.Collections.Generic;

namespace Poker{
    public class Hand{
        public string Name {get;}
        public IEnumerable<string> Cards {get;}
        public Hand(string name, IEnumerable<string> cards){
            Name = name;
            Cards = cards;
        }
        public static Hand CreateFromLines(string nameLine, string cardsLine){
            return new Hand(nameLine, cardsLine.Split(','));
        }
    }
}
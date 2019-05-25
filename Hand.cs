using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker{
    public enum HandTypePrecedence{HighCard, Pair, ThreeOfAKind, Flush}

    public abstract class Hand{
        public string Name {get;}
        public List<Rank> PrimaryQueue {get; set;}
        public List<Rank> SecondaryQueue {get; set;}
        public HandTypePrecedence HandTypePrecedence {get; set;}

        public Hand(string name) => Name = name;

        public int CompareTo(Hand other){
            if (HandTypePrecedence > other.HandTypePrecedence) {
                return 1;
            }
            else if (HandTypePrecedence < other.HandTypePrecedence){
                return -1;
            }
            
            var rankQueueComparison = CompareRankQueue(PrimaryQueue, other.PrimaryQueue);
            if (rankQueueComparison == 0) {
                if (SecondaryQueue == null){
                    return 0;
                }
                return CompareRankQueue(SecondaryQueue, other.SecondaryQueue);
            }
            else {
                return rankQueueComparison;
            }
        }

        public static Hand CreateFromLines(string nameLine, string cardsLine){
            IEnumerable<Card> cards = cardsLine.Split(',')
                .Select(cardCode => new Card(cardCode));
            return CreateFromCards(nameLine, cards);
        }

        public static Hand CreateFromCards(string name, IEnumerable<Card> cards){
            Hand hand;

            if (cards.Count() != 5){
                throw new Exception();
            }

            if (Flush.CheckIfFlush(cards)){
                hand = new Flush(name, cards);
            }
            else{
                hand = new HighCard(name, cards);
            }


            return hand;
        }

        public static int CompareRankQueue(List<Rank> rankQueue, List<Rank> otherRankQueue){
            if (rankQueue.Count() != otherRankQueue.Count()){
                throw new Exception();
            }
            for (int i = 0; i < rankQueue.Count(); i++){
                if (rankQueue[i] > otherRankQueue[i]){
                    return 1;
                }
                else if (rankQueue[i] < otherRankQueue[i]){
                    return -1;
                }
            }
            return 0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Poker{
    public enum HandTypePrecedence{HighCard, Pair, ThreeOfAKind, Flush}

    public class Hand{
        public const int PRIMARY_QUEUE = 0;
        public const int SECONDARY_QUEUE = 1;

        public string Name {get;}
        public List<Rank> PrimaryQueue {get; set;}
        public List<Rank> SecondaryQueue {get; set;}
        public HandTypePrecedence HandTypePrecedence {get; set;}

        public Hand(string name, IEnumerable<Card> cards) {
            Name = name;

            if (cards.Count() != 5){
                throw new Exception();
            }

            Suit suit = cards.First().Suit;

            List<Rank>[][] candidates = Enum.GetNames(typeof(HandTypePrecedence))
                .Select(ht => new List<Rank>[]{new List<Rank>(), new List<Rank>()}).ToArray();
            int[] rankBuckets = Enum.GetNames(typeof(Rank)).Select(r => 0).ToArray();

            foreach (Card card in cards){
                if (candidates[(int)HandTypePrecedence.Flush][PRIMARY_QUEUE] != null){
                    if (suit == card.Suit){
                        candidates[(int)HandTypePrecedence.Flush][PRIMARY_QUEUE].Add(card.Rank);
                    }
                    else{
                        candidates[(int)HandTypePrecedence.Flush][PRIMARY_QUEUE] = null;
                    }
                }
                candidates[(int)HandTypePrecedence.HighCard][PRIMARY_QUEUE].Add(card.Rank);
                rankBuckets[(int)card.Rank]++;
            }

            foreach (Card card in cards){
                if(rankBuckets[(int)card.Rank] > 1){
                    if(rankBuckets[(int)card.Rank] > 2){
                        candidates[(int)HandTypePrecedence.ThreeOfAKind][PRIMARY_QUEUE].Add(card.Rank);
                    }
                    else{
                        candidates[(int)HandTypePrecedence.ThreeOfAKind][SECONDARY_QUEUE].Add(card.Rank);
                    }
                    candidates[(int)HandTypePrecedence.Pair][PRIMARY_QUEUE].Add(card.Rank);
                }
                else{
                    candidates[(int)HandTypePrecedence.Pair][SECONDARY_QUEUE].Add(card.Rank);
                    candidates[(int)HandTypePrecedence.ThreeOfAKind][SECONDARY_QUEUE].Add(card.Rank);
                }
            }

            bool initialized = false;
            for(int i = candidates.Length - 1; i >= 0 && !initialized; i--){
                if (candidates[i][PRIMARY_QUEUE] != null && candidates[i][PRIMARY_QUEUE].Count() != 0){
                    PrimaryQueue = candidates[i][PRIMARY_QUEUE].OrderBy(rank => rank).ToList();
                    SecondaryQueue = candidates[i][SECONDARY_QUEUE].OrderBy(rank => rank).ToList();
                    HandTypePrecedence = (HandTypePrecedence)i;
                    initialized = true;;
                }
            }

            if (!initialized){
                throw new Exception();
            }
        }

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
            IEnumerable<Card> cards = Regex.Replace(cardsLine, @"/s+", String.Empty).Split(',')
                .Select(cardCode => new Card(cardCode));
            return new Hand(nameLine, cards);
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
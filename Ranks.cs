using System;

namespace Poker{
    public enum Rank {Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace};

    public class Ranks{
        public static Rank GetByCode(string suitCode){
            switch(suitCode.ToUpper()){
                case "2":
                    return Rank.Two;
                case "3":
                    return Rank.Three;
                case "4":
                    return Rank.Four;
                case "5":
                    return Rank.Five;
                case "6":
                    return Rank.Six;
                case "7":
                    return Rank.Seven;
                case "8":
                    return Rank.Eight;
                case "9":
                    return Rank.Nine;
                case "10":
                    return Rank.Ten;
                case "J":
                    return Rank.Jack;
                case "Q":
                    return Rank.Queen;
                case "K":
                    return Rank.King;
                case "A":
                    return Rank.Ace;
                default:
                    throw new Exception();
            }
        }
    }
}
using System;
using System.Collections.Generic;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            try{
                var hands = ReadInput();
                ProcessAndOutputResults(hands);
            }
            catch{
                Console.WriteLine("Error");
            }
        }

        static List<Hand> ReadInput(){
            List<Hand> hands = new List<Hand>();
            string inputLine;
            string nameLine = "";
            bool isNameLine = true;
            while ((inputLine = Console.ReadLine()) != String.Empty){
                if (isNameLine){
                    nameLine = inputLine;
                }
                else{
                    hands.Add(Hand.CreateFromLines(nameLine, inputLine));
                }
                isNameLine = !isNameLine;
            }
            return hands;
        }

        static void ProcessAndOutputResults(List<Hand> hands){
            foreach(Hand hand in hands){
                Console.WriteLine(hand.Name + ": " + String.Join(" ", hand.Cards));
            }
        }
    }
}

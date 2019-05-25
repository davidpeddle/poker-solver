using System;
using System.Linq;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            try{
                var game = RunGameLoop();
                string victoryMessage = String.Join(", ", game.Winners.Select(winner => winner.Name)) + " Wins";
                Console.WriteLine(victoryMessage);
            }
            catch{
                Console.WriteLine("Error");
            }
        }

        static Game RunGameLoop(){
            Game game = new Game();
            string inputLine;
            string nameLine = "";
            bool isNameLine = true;
            while ((inputLine = Console.ReadLine()) != String.Empty){
                if (isNameLine){
                    nameLine = inputLine;
                }
                else{
                    game.AddHand(Hand.CreateFromLines(nameLine, inputLine));
                }
                isNameLine = !isNameLine;
            }
            return game;
        }
    }
}

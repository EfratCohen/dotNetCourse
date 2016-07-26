using Backgammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var ui = new BackgammonUI();
            var backgamonGame = new GameManneger();
            var humanPlayer = new HumanBackgamonPlayer();
            var comp = new ComputerBackgamonPlayer();
            var progHelp = new ProgramHelper();
            string inputMessage;
            int gameScore=0;
            Console.WriteLine("\n Wellcom to Backgammon Game! \n");
            do {
                Console.WriteLine("What do you wish?\n Please enter 'friend' to play with other user,\n 'comp' to play against the computer, \n or 'movie' to see the computer play against itself.");
                Console.WriteLine(" # in any stage, if you wish to exit , you can enter the string 'esc'.");
                inputMessage = Console.ReadLine();
                try
                {
                    switch (inputMessage)
                    {
                        case "friend":
                            gameScore= backgamonGame.Play(humanPlayer, humanPlayer, ui);
                            break;
                        case "comp":
                            gameScore = backgamonGame.Play(humanPlayer, comp, ui);
                            break;
                        case "movie":
                            gameScore = backgamonGame.Play(comp, comp, ui);
                            break;
                        case "esc":
                            break;
                        default:
                            break;
                    }
                }
                catch (ApplicationException appEx)
                {
                    if (appEx.Message == "the player pressed 'esc'")
                    {
                        Console.WriteLine("     goodbuy :)");
                        break;
                    }
                    else throw appEx;
                }
                
                if (gameScore > 0)
                {
                    Console.WriteLine($" player_1 got +{gameScore} to his game-score in this game.\n");

                }
                else if (gameScore < 0)
                {
                    Console.WriteLine($" player_2 got +{-gameScore} to his game-score in this game.\n");
                }

                if (inputMessage != "esc")
                {
                    Console.WriteLine(" # to exit the game prees 'esc', \n for another such game press any key.");
                    inputMessage = Console.ReadLine();
                }
            } while (progHelp.ToContinue(inputMessage));
        }     
    }
}

        



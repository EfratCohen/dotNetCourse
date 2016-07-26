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
        static void cMain(string[] args)
        {
            Console.WriteLine("sketch");
            ConsoleUiTools tool = new ConsoleUiTools();
            GameBoard game = new GameBoard();
            game.Player_1_FinalDestination.Add(new PlayerStone(true));
            game.Player_2_FinalDestination.Add(new PlayerStone(false));
            game.Player_2Prison.Add(new PlayerStone(false));
            tool.ConsoleBoardConfigPrint(game,null);

        }

        static void Main(string[] args)
        {
            var ui = new BackgammonUI();
            var backgamonGame = new GameManneger();
            var humanPlayer = new HumanBackgamonPlayer();
            var comp = new ComputerBackgamonPlayer();
            var progHelp = new ProgramHelper();
            string inputMessage;
            int gameScore=0;
            Console.WriteLine(" Wellcom to Backgammon Game!");
            do {
                Console.WriteLine("What do you wish? please enter 'friend' to play with other user,\n 'comp' to play against the computer \n or 'movie' to see the computer play against itself");
                Console.WriteLine(" in any stage, if you wish to exit , you can enter the string 'esc'.");
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
                        Console.WriteLine("goodbuy:)");
                        break;
                    }
                    else throw appEx;
                }
                if (gameScore > 0)
                {
                    Console.WriteLine($" player 1 wins with {gameScore} score in this game");
                }
                else if (gameScore < 0)
                {
                    Console.WriteLine($" player 2 wins with {-gameScore} score in this game");
                }
                if (inputMessage != "esc")
                {
                    Console.WriteLine("to exit the game prees 'esc', \n for another such game press any key");
                    inputMessage = Console.ReadLine();
                }
            } while (progHelp.ToContinue(inputMessage));
        }     
    }
}

        



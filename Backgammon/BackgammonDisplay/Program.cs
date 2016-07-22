using Backgammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonDisplay
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new BackgammonDisplayer();
            string inputMessage=" ";
            bool gameOver = false, wasMars = false ,finished=true;
            int player_1_wins_count = 0, player_2_wins_count = 0, playerDoneMovesNumber;
            int[] playerMovesNumber;
            var progHelp = new ProgramHelper();
            List<GameStoneMovement> nextMoveList;
            while ((inputMessage != "esc") && finished)
            {
                game.SetupGame();
                Console.WriteLine(" Wellcom to Backgammon Game!");
                Console.WriteLine(" in any stage, if you wish to exit , you can enter the string 'esc'.\n press any other key to continue");
                inputMessage = Console.ReadLine();
                while (progHelp.ToContinue(inputMessage) && !gameOver)
                {
                    //Console.WriteLine("What do you wish? please enter 'friend' to play with other user,\n 'comp' to play against the computer \n or 'movie' to see the computer play against itself");
                    //inputMessage=Console.ReadLine();
                    game.DisplayBoard();
                    if (game.IsPlayer_1_turn)
                    {
                        Console.WriteLine("this is player 1, with the red stones, turn");
                    }
                    else
                    {
                        Console.WriteLine("this is player 2, with the black stones, turn");
                    }
                    game.DiceRoll();
                    playerDoneMovesNumber = 0;
                    playerMovesNumber = game.PlayerTurnDiesValues();
                    Console.WriteLine($" we roll the dice and get the values:{game.Dice[0]},{game.Dice[1]}");
                    do
                    {


                        Console.WriteLine(" here are the option for the next legal movement :");
                        nextMoveList = game.DisplayLegalMovements(ref playerMovesNumber, playerDoneMovesNumber);
                        Console.WriteLine(" please enter your next move decision, for the stone you want to move,\n first the origion tringle number [0,24] and then the destination tringle number [0,24]");
                        Console.WriteLine(" if you want to move a stone from the beforebase stack enter '-1' as origion number,\n and if you want to bear-out stone then enter '25' as the destination number ");
                        var nextMove = new GameStoneMovement(game.IsPlayer_1_turn, 0, 0);
                        bool notLegalMove = true;
                        do
                        {
                            inputMessage = Console.ReadLine();
                            inputMessage.Trim();
                            if (inputMessage == "esc")
                            {
                                break;
                            }
                            else
                            {
                                var inputs = inputMessage.Split(' ');
                                int orig = 0, dest = 0;
                                if (inputs.Length != 2 && !(int.TryParse(inputs[0], out orig) && int.TryParse(inputs[1], out dest)))
                                {
                                    Console.WriteLine("we got wrong input. try again please");
                                    continue;
                                }
                                nextMove = new GameStoneMovement(game.IsPlayer_1_turn, dest, orig);
                                notLegalMove = !nextMoveList.Contains(nextMove);
                                if (notLegalMove)
                                {
                                    Console.WriteLine("the chosen move is not legal .try again please");
                                }
                            }
                        }
                        while (notLegalMove);
                        if (inputMessage != "esc")
                        {
                            game.MakeMove(nextMove);
                            playerDoneMovesNumber++;
                            if (game.IsVictory)
                            {
                                game.DisplayBoard();
                                string winner = (game.IsPlayer_1_turn) ? "Player_1" : "Player_2";
                                Console.WriteLine($"the game is over! the winner is {winner}");
                                if ((game.IsPlayer_1_turn && game.Player_2_destinationCont == 0) || (!game.IsPlayer_1_turn && game.Player_1_destinationCont == 0))
                                {
                                    Console.WriteLine("it was a mars!");
                                    wasMars = true;
                                }
                                if (game.IsPlayer_1_turn)
                                {
                                    player_1_wins_count++;
                                    if (wasMars)
                                    { player_1_wins_count++; }
                                }
                                else
                                {
                                    player_2_wins_count++;
                                    if (wasMars)
                                    { player_2_wins_count++; }
                                }
                                Console.WriteLine("if you wish to end the game press 'finished' if you want to play another game press 'continue'");
                                inputMessage = Console.ReadLine();
                                if (inputMessage == "finished")
                                {
                                    Console.WriteLine($"player 1 score is:{player_1_wins_count} while player 2 score is: {player_2_wins_count} \n goodbuy :)");
                                    gameOver = true;
                                    finished = true;
                                }
                                else
                                {
                                    gameOver = true;
                                }
                            }
                        }
                    }
                    while ((inputMessage != "esc") && (playerMovesNumber.Count() == playerDoneMovesNumber || nextMoveList.Count() > 0));
                }
            }
        }
       
    }
}

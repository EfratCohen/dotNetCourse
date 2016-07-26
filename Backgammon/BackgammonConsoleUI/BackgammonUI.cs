using Backgammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonConsoleUI
{
    class BackgammonUI :IBackgamonUi
    {
        ConsoleUiTools _consoleDisplayTool = new ConsoleUiTools();

        public void AfterGameBoardChange(GameBoard board)
        {
            _consoleDisplayTool.ConsoleBoardConfigPrint(board);
        }
        public void AfterDiceRoll(int die_1Value, int die_2Value)
        {
            Console.Write($"The dice's roll gave us the values: ");
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"{die_1Value}");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" , ");
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"{die_2Value}");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" \n\n");
        }
        public void StartNewPlayerTurn(bool isPlayer_1_turn)
        {
            if (isPlayer_1_turn)
            {
                Console.Write("Now it is player 1, with the ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("red ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("pieces, turn. \n\n");
            }
            else
            {
                Console.Write("Now it is player 2, with the ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("white ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("pieces, turn. \n\n");
            }
        }
        public void AfterGameVictory(bool isPlayer_1_Victory, bool isMars)
        {
            string winner = (isPlayer_1_Victory) ? "Player_1" : "Player_2";
            Console.WriteLine($"    the game is over. {winner} wins!");
            if (isMars)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("     it was a mars!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}

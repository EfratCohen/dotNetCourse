using Backgammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonConsoleUI
{
    /// <summary>
    /// Use the Console for the UI. 
    /// You can leverage properties such as ForegroundColor and BackgroundColor to display something reasonable.
    /// </summary>
    class BackgammonUI :IBackgamonUi
    {
        ConsoleUiTools _consoleDisplayTool = new ConsoleUiTools();

        public void AfterGameBoardChange(GameBoard board)
        {
            _consoleDisplayTool.ConsoleBoardConfigPrint(board, null);
        }
        public void AfterDiceRoll(int die_1Value, int die_2Value)
        {
            Console.WriteLine($" we roll the dice and get the values:{die_1Value},{die_2Value}");
        }
        public void StartNewPlayerTurn(bool isPlayer_1_turn)
        {
            if (isPlayer_1_turn)
            {
                Console.WriteLine("this is player 1, with the red stones, turn");
            }
            else
            {
                Console.WriteLine("this is player 2, with the black stones, turn");
            }
        }
        public void AfterGameVictory(bool isPlayer_1_Victory, bool isMars)
        {
            string winner = (isPlayer_1_Victory) ? "Player_1" : "Player_2";
            Console.WriteLine($"the game is over! the winner is {winner}");
            if (isMars)
            {
                Console.WriteLine("it was a mars!");
            }
        }
    }
}

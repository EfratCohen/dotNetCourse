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
    class BackgammonUI :Iplayer,IBackgamonUi
    {
        ConsoleUiTools _consoleDisplayTool = new ConsoleUiTools();
        private void DisplayMovementsList(List<GameStoneMovement> nextLegalMoves)
        {
            Console.WriteLine(" here are the option for the next legal movement :");
            Console.WriteLine("DisplayLegalMovements()");
        }
        public GameStoneMovement NextGameMoveChose(List<GameStoneMovement> nextLegalMoves ,bool isPlayer_1)
        {
            bool notLegalMove = true;
            var nextMove = new GameStoneMovement(isPlayer_1, 0, 0);
            int orig = 0, dest = 0;
            string inputMessage;
            DisplayMovementsList(nextLegalMoves);
            do
            {
                Console.WriteLine(" please enter your next move decision, for the stone you want to move,\n first the origion tringle number [0,24] and then the destination tringle number [0,24]");
                Console.WriteLine(" if you want to move a stone from the beforebase stack enter '-1' as origion number,\n and if you want to bear-out stone then enter '25' as the destination number ");
                Console.WriteLine("if you want to exit the game now you can enter 'esc'");
                inputMessage = Console.ReadLine();
                inputMessage.Trim();
                if (inputMessage == "esc")
                {
                    throw new ApplicationException("the player pressed 'esc'");
                }
                    var inputs = inputMessage.Split(' ');
                if (inputs.Length != 2 && !(int.TryParse(inputs[0], out orig) && int.TryParse(inputs[1], out dest)))
                {
                    Console.WriteLine("we got wrong input. try again please");
                    continue;
                }
                nextMove = new GameStoneMovement(isPlayer_1, dest, orig);
                notLegalMove = !nextLegalMoves.Contains(nextMove);
                if (notLegalMove)
                {
                    Console.WriteLine("the chosen move is not legal .try again please");  
                }
            }
            while (notLegalMove);
            return nextMove;
        }

        public void AfterGameBoardChange(GameBoard board)
        {
            _consoleDisplayTool.ConsoleBoardConfigPrint(board, null);
                        Console.WriteLine("DisplayBoard()");
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

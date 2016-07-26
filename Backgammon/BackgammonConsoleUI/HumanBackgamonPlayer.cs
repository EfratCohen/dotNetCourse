using Backgammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonConsoleUI
{
    class HumanBackgamonPlayer : Iplayer
    {
        ConsoleUiTools _consoleDisplayTool = new ConsoleUiTools();

        public GameStoneMovement NextGameMoveChose(List<GameStoneMovement> nextLegalMoves, bool isPlayer_1)
        {
            bool notLegalMove = true;
            var nextMove = new GameStoneMovement(isPlayer_1, 0, 0);
            int orig = 0, dest = 0;
            string inputMessage;
            DisplayMovementsList(nextLegalMoves);
            do
            {
                Console.WriteLine(" please enter your next move decision, for the stone you want to move,\n first the source tringle number [0,24] and then the destination tringle number [0,24]");
                Console.WriteLine(" if you want to move a stone from the prison stack enter '-1' as source number,\n and if you want to bear-out stone then enter '25' as the destination number ");
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
        private void DisplayMovementsList(List<GameStoneMovement> nextLegalMoves)
        {
            Console.WriteLine(" here are the option for the next legal movement :");
            foreach (var move in nextLegalMoves)
            {
                Console.WriteLine($"you can move a stone from: {move.StoneSource }  to:{ move.StoneDestination}");
            }
        }
    }
}

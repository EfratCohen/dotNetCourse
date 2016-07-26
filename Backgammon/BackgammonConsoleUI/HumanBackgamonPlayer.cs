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
            if (nextLegalMoves == null||nextLegalMoves.Count==0)//no options to chose
            {
                return null;
            }
            bool notLegalMove = true;
            var nextMove = new GameStoneMovement(isPlayer_1, 0, 0);
            int source = 0, dest = 0;
            string inputMessage;
            int prisonIndex = (isPlayer_1) ? 0 : 25;
                DisplayMovementsList(nextLegalMoves);
            do
            {
                Console.WriteLine("please enter the the move you prefer : {source} {destination}");
                Console.WriteLine($" if prison is the source enter {prisonIndex} \n if bear-out is the destination enter {25 - prisonIndex} ");
                Console.WriteLine("if you want to exit the game now you can enter 'esc'");
                inputMessage = Console.ReadLine();
                inputMessage.Trim();
                if (inputMessage == "esc")
                {
                    throw new ApplicationException("the player pressed 'esc'");
                }
                var inputs = inputMessage.Split(' ');
                if (!(inputs.Length == 2 && (int.TryParse(inputs[0], out source) && int.TryParse(inputs[1], out dest))))
                {
                    Console.WriteLine("we got wrong input. try again please");
                    continue;
                }
                notLegalMove = !nextLegalMoves.Any(move => (move.StoneDestination == dest && move.StoneSource == source&&move.IsPlayer_1_Move==isPlayer_1));
                if (notLegalMove)
                {
                    Console.WriteLine("the chosen move is not legal .try again please");
                }
                else
                {
                    nextMove.StoneSource = source;
                    nextMove.StoneDestination = dest;
                }
            }
            while (notLegalMove);
            return nextMove;
        }
        private void DisplayMovementsList(List<GameStoneMovement> nextLegalMoves)
        {
            Console.WriteLine(" here are the option for the next legal movement :");
            for(int i = 0; i < nextLegalMoves.Count; i++ )
            {
                if (i == 0)
                {
                    Console.WriteLine($"you can move a stone from: {nextLegalMoves[i].StoneSource }  to: {nextLegalMoves[i].StoneDestination}");
                }
                else
                {
                    Console.WriteLine($"                  or from:{nextLegalMoves[i].StoneSource }  to: {nextLegalMoves[i].StoneDestination}");
                }
            }
        }
    }
}

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

        public PlayPieceMovement NextGameMoveChose(List<PlayPieceMovement> nextLegalMoves, bool isPlayer_1)
        {
            if (nextLegalMoves == null||nextLegalMoves.Count==0)//no options to chose
            {
                return null;
            }
            bool notLegalMove = true;
            var nextMove = new PlayPieceMovement(isPlayer_1, 0, 0);
            int prevPoint = 0, dest = 0;
            string inputMessage;
            int prisonIndex = (isPlayer_1) ? 0 : 25;
                DisplayMovementsList(nextLegalMoves);
            do
            {
                Console.WriteLine("please enter the the move you prefer : {previous point} {destination point}.");
                Console.WriteLine($"- if the prison is your move's previous point enter {prisonIndex},\n- if bear-out your move's  destination enter {25 - prisonIndex}.");
                Console.WriteLine(" # if you want to exit the game now you can enter 'esc'.");
                inputMessage = Console.ReadLine();
                inputMessage.Trim();
                if (inputMessage == "esc")
                {
                    throw new ApplicationException("the player pressed 'esc'");
                }
                var inputs = inputMessage.Split(' ');
                if (!(inputs.Length == 2 && (int.TryParse(inputs[0], out prevPoint) && int.TryParse(inputs[1], out dest))))
                {
                    Console.WriteLine(" We got wrong input. try again please.\n");
                    continue;
                }
                notLegalMove = !nextLegalMoves.Any(move => (move.PieceDestination == dest && move.PiecePrevPoint == prevPoint&&move.IsPlayer_1_Move==isPlayer_1));
                if (notLegalMove)
                {
                    Console.WriteLine(" The chosen move is not legal. try again please.\n");
                }
                else
                {
                    nextMove.PiecePrevPoint = prevPoint;
                    nextMove.PieceDestination = dest;
                }
            }
            while (notLegalMove);
            return nextMove;
        }
        private void DisplayMovementsList(List<PlayPieceMovement> nextLegalMoves)
        {
            Console.WriteLine(" Dear player, for your next legal movement, here are the options :");
            for(int i = 0; i < nextLegalMoves.Count; i++ )
            {
                if (i == 0)
                {
                    Console.WriteLine($" you can move a stone from: {nextLegalMoves[i].PiecePrevPoint }  to: {nextLegalMoves[i].PieceDestination}");
                }
                else
                {
                    Console.WriteLine($"                   or from:{nextLegalMoves[i].PiecePrevPoint }  to: {nextLegalMoves[i].PieceDestination}");
                }
            }
        }
    }
}

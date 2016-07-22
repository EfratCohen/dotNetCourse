using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public class ComputerBackgamonPlayer : Iplayer
    {
        public GameStoneMovement NextGameMoveChose(List<GameStoneMovement> nextLegalMoves, bool isPlayer_1)
        {
            if (nextLegalMoves != null && nextLegalMoves.Count <= 0)
            {
                return null;
            }
            return nextLegalMoves.ElementAt(0);
        }
    }
}

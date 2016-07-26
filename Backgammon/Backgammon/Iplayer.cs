using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public interface Iplayer
    {
        PlayPieceMovement NextGameMoveChose(List<PlayPieceMovement> nextLegalMoves , bool isPlayer_1);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public interface Iplayer
    {
        GameStoneMovement NextGameMoveChose(List<GameStoneMovement> nextLegalMoves , bool isPlayer_1);
    }
}

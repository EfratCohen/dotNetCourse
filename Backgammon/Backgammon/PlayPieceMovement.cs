using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public class PlayPieceMovement
    {
        public bool IsPlayer_1_Move { get; set; }
        public int PieceDestination { get; set; }
        public int PiecePrevPoint { get; set; }
        public PlayPieceMovement(bool isPlayer_1, int dest, int prevPoint)
        {
            IsPlayer_1_Move = isPlayer_1;
            PieceDestination = dest;
            PiecePrevPoint = prevPoint;
        }
    }
}

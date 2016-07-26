using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public class PlayerPiece
    {
        public bool IsPlayer1Piece { get; set; }
        public PlayerPiece(bool isPlayer1Piece)
        {
            IsPlayer1Piece = isPlayer1Piece;
        }
    }
}

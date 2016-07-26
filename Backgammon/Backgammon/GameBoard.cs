using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public class GameBoard
    {
        public List<PlayerPiece>[] BoardPoints { get;  set; } = new List<PlayerPiece>[24];
        public List<PlayerPiece> Player_1_FinalDestination { get; set; } = new List<PlayerPiece>(0);
        public List<PlayerPiece> Player_2_FinalDestination { get; set; } = new List<PlayerPiece>(0);
        public List<PlayerPiece> Player_1Prison { get; set; } = new List<PlayerPiece>(0);
        public List<PlayerPiece> Player_2Prison { get;  set; } = new List<PlayerPiece>(0);  
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public class GameBoard
    {
        public List<PlayerStone>[] Boardtriangles { get;  set; } = new List<PlayerStone>[24];
        public List<PlayerStone> Player_1_FinalDestination { get; set; } = new List<PlayerStone>(0);
        public List<PlayerStone> Player_2_FinalDestination { get; set; } = new List<PlayerStone>(0);
        public List<PlayerStone> Player_1Prison { get; set; } = new List<PlayerStone>(0);
        public List<PlayerStone> Player_2Prison { get;  set; } = new List<PlayerStone>(0);  
    }

}

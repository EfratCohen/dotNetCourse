using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
   public class GameStoneMovement
    {
        public bool IsPlayer_1_Move { get; set; }
        public int StoneDestination { get; set; }
        public int StoneSource { get; set; }
        public GameStoneMovement(bool isPlayer_1,int dest, int orig)
        {
            IsPlayer_1_Move = isPlayer_1;
            StoneDestination = dest;
            StoneSource =orig;
        }
    }
}

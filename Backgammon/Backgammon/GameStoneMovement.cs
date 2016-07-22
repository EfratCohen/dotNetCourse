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
        public int StoneDestinationTringle { get; set; }
        public int StoneOriginTringle { get; set; }
        public GameStoneMovement(bool isPlayer_1,int dest, int orig)
        {
            IsPlayer_1_Move = isPlayer_1;
            StoneDestinationTringle = dest;
            StoneOriginTringle =orig;
        }
    }
}

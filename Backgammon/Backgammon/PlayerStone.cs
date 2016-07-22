using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public class PlayerStone
    {
        public bool IsPlayer1Stone { get; set; }
        public PlayerStone(bool isPlayer1Stone)
        {
            IsPlayer1Stone = isPlayer1Stone;
        }
    }
}

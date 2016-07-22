using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    class Dice
    {
        public Die[] Values { get; private set; } = new Die[2];
        public Dice()
        {
            Values[0] = new Die();
            for (int i = 0; i < 1036; i++)
            {
                Values[0].Roll();
            }
            Values[1] = new Die();

        }
        public int[] Roll()
        {
            return new int[2] { Values[0].RollAndLook(), Values[1].RollAndLook() };
        }
    }
}

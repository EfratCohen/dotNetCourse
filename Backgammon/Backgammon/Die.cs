using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public class Die
    {
        Random _randomNumber = new Random((int)DateTime.Now.Ticks);
        public int Value { get; private set; }
        public Die()
        {
            Roll();
        }
        public void Roll()
        {
            Value = _randomNumber.Next() % 6 +1;
        }
        public int RollAndLook()
        {
            Roll();
            return Value;
        }
    }
}

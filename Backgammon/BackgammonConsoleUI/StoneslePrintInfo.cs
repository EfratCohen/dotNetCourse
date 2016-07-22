using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonConsoleUI
{
    public class StoneslePrintInfo
    {
        public int Counter { get; set; } = 0;
        public int RealNuber { get; set; } = 0;
        public bool IsRed { get; set; }
        public bool IsCounterIsMoreThen5 { get; set; } = false;
        public bool IsOrig { get; set; } = false;
        public bool IsDest { get; set; } = false;

        public StoneslePrintInfo(int counter, bool isRed, bool iscounterIsMoreThen5, int realNumber)
        {
            Counter = counter;
            RealNuber = realNumber;
            IsRed = isRed;
            IsCounterIsMoreThen5 = iscounterIsMoreThen5;
        }
        public StoneslePrintInfo(int counter, bool isRed, bool iscounterIsMoreThen5, int realNumber, bool isOrig, bool isDest)
            : this(counter, isRed, iscounterIsMoreThen5, realNumber)
        {
            IsOrig = isOrig;
            IsDest = isDest;
        }
        public StoneslePrintInfo(int counter, bool isOrig, bool isDest) : this(counter, false, false, 0, isOrig, isDest) { }
        public StoneslePrintInfo()
        {
        }
    }
}

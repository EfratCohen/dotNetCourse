using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //for prevent argument null ex' / index out of range... this are the correct sizes:
            StoneslePrintInfo[][] tringleHelpers = new StoneslePrintInfo[4][];
            StoneslePrintInfo[] tringleHelper = new StoneslePrintInfo[6];
            tringleHelpers[0] = tringleHelper;
            tringleHelpers[1] = tringleHelper;
            tringleHelpers[2] = tringleHelper;
            tringleHelpers[3] = tringleHelper;
            var homesInfo = new StoneslePrintInfo[2];
            var redHomeinfo = new StoneslePrintInfo();
            redHomeinfo.IsRed = true;
            var whiteHomeinfo = new StoneslePrintInfo();
            var prisonsInfo = new StoneslePrintInfo[2];
            var redprisoninfo = new StoneslePrintInfo();
            redHomeinfo.IsRed = true;
            var whiteprisoninfo = new StoneslePrintInfo();
            //***********************Do Not Touach*********************************************


            ///examples:**************************************************************************
            int talkedTringle = 3, howmanyStones = 5, realNumber = 8;
            bool isRed = true, iscounterIsMoreThen5 = true;
            StoneslePrintInfo[] tringleHelper1 = new StoneslePrintInfo[6];
            tringleHelper1[talkedTringle] = new StoneslePrintInfo( howmanyStones, isRed, iscounterIsMoreThen5, realNumber);
            talkedTringle = 5; howmanyStones = 4; realNumber = 4;
            isRed = false; iscounterIsMoreThen5 = false;
            StoneslePrintInfo[] tringleHelper2 = new StoneslePrintInfo[6];
            tringleHelper2[talkedTringle] = new StoneslePrintInfo(howmanyStones, isRed, iscounterIsMoreThen5, realNumber,false,true);

            tringleHelpers[0] = tringleHelper1;
            tringleHelpers[1] = tringleHelper;
            tringleHelpers[2] = tringleHelper;
            tringleHelpers[3] = tringleHelper2;

            redHomeinfo.Counter = 14;
            whiteprisoninfo.Counter = 2;
            whiteprisoninfo.IsOrig = true;
            ///*************************************************************************************
            homesInfo[0] = redHomeinfo;
            homesInfo[1] = whiteHomeinfo;
            prisonsInfo[0] = whiteprisoninfo;
            prisonsInfo[1] = redprisoninfo;
            boardPrint(tringleHelpers,homesInfo,prisonsInfo);

        }
        public static void boardPrint(StoneslePrintInfo[][] tringleHelpers, StoneslePrintInfo[] homesInfo, StoneslePrintInfo[] prisonsInfo)
        {

            ///consts:***********************Do Not Touch!*******************
            var gap = String.Format($"|XXXXXXXXXXXXXXXXXXXXXXXXXXX|");
            var borderLine = String.Format($"----------------------------------");
            ///**************************************************************
            Console.WriteLine(borderLine);
            for (int i = 0; i < 5; i++) { RowPrint(tringleHelpers[0], tringleHelpers[1],homesInfo[0],prisonsInfo[0]); }
            for (int i = 0; i < 2; i++) { Console.WriteLine(gap); }
            for (int i = 0; i < 5; i++) { RowPrint(tringleHelpers[2], tringleHelpers[3],homesInfo[1], prisonsInfo[0]); }
            Console.WriteLine(borderLine);

        }
        public static void RowPrint(StoneslePrintInfo[] leftTringleInfo, StoneslePrintInfo[] rightTringleInfo,StoneslePrintInfo homeInfo, StoneslePrintInfo prisonInfo)
        { 
            ///consts:***********************Do Not Touch!*******************
            var tringleStoneCell = string.Format($"|{0}");
            var prison = "|XXX";
            var home = String.Format($"||{1}{1}{1}"); 
            var endRow = "|\n";
            ///**************************************************************
            for (int i = 0; i < 6; i++)
            {
                TringleStoneCellPrint(leftTringleInfo[i]);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            PrisonStone3CellsPrint(prisonInfo);//Console.Write(prison);
            for (int i = 0; i < 6; i++)
            {
                TringleStoneCellPrint(rightTringleInfo[i]);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            HomeStone3CellsPrint(homeInfo);//Console.Write(home);
            Console.Write(endRow);
        }
        public static void SetDefaultConsole()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static void SetStonePrintBackground(bool isOrig,bool isDest)
        {
            if (isDest)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            }
            else if (isOrig)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
            }
            else 
            {
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
        public static void TringleStoneCellPrint(StoneslePrintInfo inf)
        {
            int stone = 0;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("|");

            if (inf != null && inf.Counter > 0)
            {
                if (inf.IsRed)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (inf.Counter == 1 && inf.IsCounterIsMoreThen5)
                    { stone = inf.RealNuber - 4; }
                    inf.Counter--;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                SetStonePrintBackground(inf.IsOrig, inf.IsDest);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Black;
            }

            Console.Write($"{stone}");
            SetDefaultConsole();
        }
        public static void HomeStone3CellsPrint (StoneslePrintInfo inf)
        {
            int cell = 1;
            if (inf.Counter > 0)
            {
                Console.Write("||");
                for (int i = 0; i < 3; i++)
                {
                    if(inf.Counter > 0)
                    {
                        cell = 0;
                        Console.ForegroundColor =(inf.IsRed)? ConsoleColor.Red : ConsoleColor.White;
                        SetStonePrintBackground(false, inf.IsDest);
                        inf.Counter--;
                    }
                    else
                    {
                         cell = 1;
                         SetDefaultConsole();
                    }
                    Console.Write($"{cell}");
                    SetDefaultConsole();
                }
            }
            else
            {
                Console.Write($"||{1}{1}{1}");
            }  
        }
        public static void PrisonStone3CellsPrint(StoneslePrintInfo inf)
        {
            int cell = 8;
            if (inf.Counter > 0)
            {
                Console.Write("|");
                for (int i = 0; i < 3; i++)
                {
                    if (inf.Counter > 0)
                    {
                        cell = 0;
                        Console.ForegroundColor = (inf.IsRed) ? ConsoleColor.Red : ConsoleColor.White;
                        SetStonePrintBackground(inf.IsOrig, false);
                        inf.Counter--;
                    }
                    else
                    {
                        cell = 8;
                        SetDefaultConsole();
                    }
                    Console.Write($"{cell}");
                    SetDefaultConsole();
                }
            }
            else
            {
                Console.Write($"|{8}{8}{8}");
            }
        }
    }
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

 


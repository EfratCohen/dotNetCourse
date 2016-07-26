using Backgammon;
using BackgammonConsoleUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonConsoleUI
{
    public class ConsoleUiTools
    {
        public void ConsoleBoardConfigPrint(GameBoard board, List<GameStoneMovement> nextLegalMoves)
        {
            //setup//********************************************************
            StoneslePrintInfo[][] tringlesInfo = new StoneslePrintInfo[4][];
            var tringles13_18Info = new StoneslePrintInfo[6];
            var tringles19_24Info = new StoneslePrintInfo[6];
            var tringles12_7Info = new StoneslePrintInfo[6];
            var tringles6_1Info = new StoneslePrintInfo[6];
            var homesInfo = new StoneslePrintInfo[2];
            var redHomeinfo = new StoneslePrintInfo();
            redHomeinfo.IsRed = true;
            var whiteHomeinfo = new StoneslePrintInfo();
            var prisonsInfo = new StoneslePrintInfo[2];
            var redprisoninfo = new StoneslePrintInfo();
            redHomeinfo.IsRed = true;
            var whiteprisoninfo = new StoneslePrintInfo();
            //********************************************************************
            for(int i = 0; i < 6; i++)
            {
                tringles6_1Info[5-i]= new StoneslePrintInfo();
                invkeInfo(tringles6_1Info[5-i], board.Boardtriangles[i]);
                tringles12_7Info[5-i] = new StoneslePrintInfo();
                invkeInfo(tringles12_7Info[5 - i], board.Boardtriangles[6 + i]);
                tringles13_18Info[i] = new StoneslePrintInfo();
                invkeInfo(tringles13_18Info[i],board.Boardtriangles[12+i]);
                tringles19_24Info[i] = new StoneslePrintInfo();
                invkeInfo(tringles19_24Info[i], board.Boardtriangles[18 + i]);
            }

            //*************************************** Enter the information *****************************
            tringlesInfo[0] = tringles13_18Info;
            tringlesInfo[1] = tringles19_24Info;
            tringlesInfo[2] = tringles12_7Info;
            tringlesInfo[3] = tringles6_1Info;

            redHomeinfo.Counter = board.Player_1_FinalDestination.Count;
            whiteHomeinfo.Counter = board.Player_2_FinalDestination.Count;
            redprisoninfo.Counter = board.Player_1Prison.Count;
            whiteprisoninfo.Counter = board.Player_2Prison.Count;
            ///************************************************* Print ************************************
            homesInfo[0] = redHomeinfo;
            homesInfo[1] = whiteHomeinfo;
            prisonsInfo[0] = whiteprisoninfo;
            prisonsInfo[1] = redprisoninfo;
            boardPrint(tringlesInfo, homesInfo, prisonsInfo);

        }
        //private methods:
        void boardPrint(StoneslePrintInfo[][] tringlesInfo, StoneslePrintInfo[] homesInfo, StoneslePrintInfo[] prisonsInfo)
        {

            ///consts:***********************Do Not Touch!*******************
            var gap = String.Format($"|XXXXXXXXXXXXXXXXXXXXXXXXXXX|");
            var borderLine = String.Format($"----------------------------------");
            ///**************************************************************
            Console.WriteLine(borderLine);
            for (int i = 0; i < 5; i++) { RowPrint(tringlesInfo[0], tringlesInfo[1], homesInfo[0], prisonsInfo[0]); }
            for (int i = 0; i < 2; i++) { Console.WriteLine(gap); }
            for (int i = 0; i < 5; i++) { RowPrint(tringlesInfo[2], tringlesInfo[3], homesInfo[1], prisonsInfo[0]); }
            Console.WriteLine(borderLine);

        }
        void RowPrint(StoneslePrintInfo[] leftTringleInfo, StoneslePrintInfo[] rightTringleInfo, StoneslePrintInfo homeInfo, StoneslePrintInfo prisonInfo)
        {
            ///consts:***********************Do Not Touch!*******************
            var tringleStoneCell = string.Format($"|{0}");
            var home = string.Format($"||{1}{1}{1}");
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
        void SetDefaultConsole()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        void SetStonePrintBackground(bool isOrig, bool isDest)
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
        void TringleStoneCellPrint(StoneslePrintInfo inf)
        {
            int stone = 0;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("|");

            if (inf != null && inf.Counter > 0)
            {
                if (inf.Counter == 1 && inf.IsCounterIsMoreThen5)
                { stone = inf.RealNuber - 4; }
                inf.Counter--;
                if (inf.IsRed)
                {
                    Console.ForegroundColor = ConsoleColor.Red;                    
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
        void HomeStone3CellsPrint(StoneslePrintInfo inf)
        {
            int cell = 1;
            if (inf.Counter > 0)
            {
                Console.Write("||");
                for (int i = 0; i < 3; i++)
                {
                    if (inf.Counter > 0)
                    {
                        cell = 0;
                        Console.ForegroundColor = (inf.IsRed) ? ConsoleColor.Red : ConsoleColor.White;
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
        void PrisonStone3CellsPrint(StoneslePrintInfo inf)
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
        void invkeInfo(StoneslePrintInfo inf, List<PlayerStone> boardtriangle)
        {
            if (boardtriangle.Count > 5)
            {
                inf.IsCounterIsMoreThen5 = true;
                inf.Counter = 5;
                inf.RealNuber = boardtriangle.Count;
            }
            else
            {
                inf.Counter = boardtriangle.Count;
            }
            if (boardtriangle.Count > 0 && boardtriangle[0].IsPlayer1Stone)
            {
                inf.IsRed = true;
            }
            else
            {
                inf.IsRed = false;
            }
        }
    }
}



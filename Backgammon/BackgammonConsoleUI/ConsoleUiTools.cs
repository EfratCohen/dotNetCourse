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
        public void ConsoleBoardConfigPrint(GameBoard board)
        {
            //setup//********************************************************
            PiecesPointPrintInfo[][] tringlesInfo = new PiecesPointPrintInfo[4][];
            var tringles13_18Info = new PiecesPointPrintInfo[6];
            var tringles19_24Info = new PiecesPointPrintInfo[6];
            var tringles12_7Info = new PiecesPointPrintInfo[6];
            var tringles6_1Info = new PiecesPointPrintInfo[6];
            var homesInfo = new PiecesPointPrintInfo[2];
            var redHomeinfo = new PiecesPointPrintInfo();
            redHomeinfo.IsRed = true;
            var whiteHomeinfo = new PiecesPointPrintInfo();
            var prisonsInfo = new PiecesPointPrintInfo[2];
            var redprisoninfo = new PiecesPointPrintInfo();
            redprisoninfo.IsRed = true;
            var whiteprisoninfo = new PiecesPointPrintInfo();
            //********************************************************************
            for(int i = 0; i < 6; i++)
            {
                tringles6_1Info[5-i]= new PiecesPointPrintInfo();
                invkeInfo(tringles6_1Info[5-i], board.BoardPoints[i]);
                tringles12_7Info[5-i] = new PiecesPointPrintInfo();
                invkeInfo(tringles12_7Info[5 - i], board.BoardPoints[6 + i]);
                tringles13_18Info[i] = new PiecesPointPrintInfo();
                invkeInfo(tringles13_18Info[i],board.BoardPoints[12+i]);
                tringles19_24Info[i] = new PiecesPointPrintInfo();
                invkeInfo(tringles19_24Info[i], board.BoardPoints[18 + i]);
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

            homesInfo[0] = redHomeinfo;
            homesInfo[1] = whiteHomeinfo;
            prisonsInfo[0] = whiteprisoninfo;
            prisonsInfo[1] = redprisoninfo;
            ///************************************************* Print ************************************
            boardPrint(tringlesInfo, homesInfo, prisonsInfo);

        }
        //private methods,help-tools :
        void boardPrint(PiecesPointPrintInfo[][] tringlesInfo, PiecesPointPrintInfo[] homesInfo, PiecesPointPrintInfo[] prisonsInfo)
        {
            ///consts:*******************************************************
            var gap = String.Format($"|XXXXXXXXXXXXXXXXXXXXXXXXXXX|");
            var borderLine = String.Format($"----------------------------------");
            var index2 = String.Format($"{13}{14}{15}{16}{17}{18}| 25|{19}{20}{21}{22}{23}{24}");
            var index1 = String.Format($"{12}{11}{10} {9} {8} {7}| 0 |{6} {5} {4} {3} {2} {1}");
            ///print:********************************************************
            Console.WriteLine(borderLine);
            Console.WriteLine(index2);
            for (int i = 0; i < 5; i++) { RowPrint(tringlesInfo[0], tringlesInfo[1], homesInfo[0], prisonsInfo[0]); }
            for (int i = 0; i < 2; i++) { Console.WriteLine(gap); }
            for (int i = 0; i < 5; i++) { RowPrint(tringlesInfo[2], tringlesInfo[3], homesInfo[1], prisonsInfo[1]); }
            Console.WriteLine(index1);
            Console.WriteLine(borderLine);
        }
        void RowPrint(PiecesPointPrintInfo[] leftTringleInfo, PiecesPointPrintInfo[] rightTringleInfo, PiecesPointPrintInfo homeInfo, PiecesPointPrintInfo prisonInfo)
        {
            ///consts:*******************************************************
            var tringleStoneCell = string.Format($"| {0}");
            var home = string.Format($"||{1}{1}{1}");
            var endRow = "|\n";
            ///**************************************************************
            for (int i = 0; i < 6; i++)
            {
                PiecesPointCellPrint(leftTringleInfo[i]);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            PrisonStone3CellsPrint(prisonInfo);
            for (int i = 0; i < 6; i++)
            {
                PiecesPointCellPrint(rightTringleInfo[i]);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Home3PiecesCellsPrint(homeInfo);
            Console.Write(endRow);
        }
        void SetDefaultConsole()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        /// <summary>
        /// I didn't uses this fiture in this app beacause I Dicided it is unnecessary.
        /// actually, the param flags in all the caaling to this method are always false. 
        /// </summary>
        /// <param name="isPrevPoint"></param>
        /// <param name="isDest"></param>
        void SetPiecePrintBackground(bool isPrevPoint, bool isDest)
        {
            if (isDest)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            }
            else if (isPrevPoint)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
        void PiecesPointCellPrint(PiecesPointPrintInfo inf)
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
                SetPiecePrintBackground(inf.IsOrig, inf.IsDest);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Black;
            }

            Console.Write($"{stone}");
            SetDefaultConsole();
        }
        void Home3PiecesCellsPrint(PiecesPointPrintInfo inf)
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
                        SetPiecePrintBackground(false, inf.IsDest);
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
        void PrisonStone3CellsPrint(PiecesPointPrintInfo inf)
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
                        SetPiecePrintBackground(inf.IsOrig, false);
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
        void invkeInfo(PiecesPointPrintInfo inf, List<PlayerPiece> piecesPoint)
        {
            if (piecesPoint.Count > 5)
            {
                inf.IsCounterIsMoreThen5 = true;
                inf.Counter = 5;
                inf.RealNuber = piecesPoint.Count;
            }
            else
            {
                inf.Counter = piecesPoint.Count;
            }
            if (piecesPoint.Count > 0 && piecesPoint[0].IsPlayer1Piece)
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



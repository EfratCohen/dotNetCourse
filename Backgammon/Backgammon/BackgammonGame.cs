using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public class BackgammonGame
    {
        //properties:
        public List<List<PlayerStone>> GameBoard { get; private set; } = new List<List<PlayerStone>>(24);
        public List<PlayerStone> Player1Destination { get; private set; } = new List<PlayerStone>(0);
        public List<PlayerStone> Player2Destination { get; private set; } = new List<PlayerStone>(0);
        int[] Dies { get; set; } = new int[2];
        //methods:
        void Setup()
        {

        }
        void Movement()
        {

        }
        void DiesThrowing()
        {
        }
        void CheckIfWin()
        {
        }
        void CheckIfleagal()
        {
        }
    }

    public struct PlayerStone
    {
        public bool IsPlayer1Stone { get; set; }
    }
}

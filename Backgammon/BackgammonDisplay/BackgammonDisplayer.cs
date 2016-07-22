using Backgammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonDisplay
{
    class BackgammonDisplayer
    {
        GameManneger _backgamonManager =new GameManneger();
        public bool IsVictory { get; private set; } = false;
        public int Player_1_destinationCont { get; private set; }
        public int Player_2_destinationCont { get; private set; }
        public bool IsPlayer_1_turn
        {
            get
            {
                return _backgamonManager.IsPlayer_1turn;
            }
        }

        public void SetupGame()
        {
            _backgamonManager.Setup();
        }
        public void FlipPlayerTurn()
        {
            _backgamonManager.IsPlayer_1turn = !_backgamonManager.IsPlayer_1turn;
        }

        public int[] PlayerTurnDiesValues()
        {
            return _backgamonManager.PlayerTurnDieValues(Dice[0], Dice[1]);
        }
        public void MakeMove(GameStoneMovement legalMove)
        {
            var isGameVictoryFlag = _backgamonManager.PlayerGameMovements(legalMove);
            if (isGameVictoryFlag != GameManneger.IsGameVictory.noneWins)
            {
                IsVictory = true;
            }
        }  
    }
}

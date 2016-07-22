using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public interface IBackgamonUi
    {
         void AfterGameBoardChange(GameBoard board);
         void AfterDiceRoll(int die_1Value, int die_2Value);
         void StartNewPlayerTurn(bool isPlayer_1_turn);
         void AfterGameVictory(bool isPlayer_1_Victory, bool isMars);
    }
}

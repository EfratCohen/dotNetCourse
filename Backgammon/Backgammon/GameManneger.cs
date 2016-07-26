using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// some of the game rules
/// ***** each player move direction***** 
/// A roll of 1 allows the checker to enter on the 24-point (opponent's 1),
/// a roll of 2 on the 23-point (opponent's 2), and so forth, up to a roll of 6 allowing entry on the 19-point (opponent's 6).
/// ***** which point is legal piece destination:**** 
/// a checker may land on any point that is unoccupied or is occupied by one or more of the player's own checkers. 
/// It may also land on a point occupied by exactly one opposing checker, or "blot".
/// (In this case, the blot has been "hit", and is placed in the middle of the board on the bar that divides the two sides of the playing surface.)
/// A checker may never land on a point occupied by two or more opposing checkers; 
/// **** if there are player pieces in the base:**** 
///  Checkers placed on the bar must re-enter the game through the opponent's home board before any other move can be made.
///  A player may not move any other checkers until all checkers on the bar belonging to that player have re-entered the board.
/// **** When pieces can move to the player Finaldestination**** 
///  When all of a player's checkers are in that player's home board, that player may start removing them; 
///  this is called "bearing off".
///  A die may not be used to bear off checkers from a lower-numbered point unless there are no checkers on any higher points.
///  When bearing off, a player may also move a lower die roll before the higher even if that means the full value of the higher die is not fully utilized.
/// </summary>
namespace Backgammon
{
    /// <summary>
    /// *pieces color:*
    /// player_1 has the red pieces.
    /// player_2 has the black pieces.
    /// *player's aim:*
    /// player_1 goes from his base[0] to point no' 1->24 and his destination is [25].
    /// player_2 goes from his base[25] to point no' 24->1 and his destination is [0].
    /// </summary>
    public class GameManneger
    {
        Dice _dice = new Dice();
        GameBoard _board = new GameBoard();
        bool _isPlayer_1turn = true;
        bool _wasMars = false;
        enum IsGameVictory
        {
            noneWins = 0,
            player1wins,
            player2wins

        }
        IsGameVictory _gameOver { get; set; }

        /// <summary>
        /// The most commonly used setup. 
        /// each player begins with his fifteen checkers:
        /// two are placed on their 24-point, 
        /// three on their 8-point, 
        /// and five each on their 13-point and their 6-point. 
        /// The two players move their checkers in opposing directions, from the 24-point towards the 1-point.[2]
        /// </summary>
        private void Setup()
        {
            _isPlayer_1turn = true;
            _wasMars = false;
            _gameOver = IsGameVictory.noneWins;
            for (int i = 0; i < _board.BoardPoints.Length; i++)
            {
                _board.BoardPoints[i] = new List<PlayerPiece>();
            }
            for (int i = 0; i < 2; i++)
            {
                _board.BoardPoints[1 - 1].Add(new PlayerPiece(true));
                _board.BoardPoints[24 - 1].Add(new PlayerPiece(false));
            }
            for (int i = 0; i < 3; i++)
            {
                _board.BoardPoints[17 - 1].Add(new PlayerPiece(true));
                _board.BoardPoints[8 - 1].Add(new PlayerPiece(false));
            }
            for (int i = 0; i < 5; i++)
            {
                _board.BoardPoints[19 - 1].Add(new PlayerPiece(true));
                _board.BoardPoints[12 - 1].Add(new PlayerPiece(true));
                _board.BoardPoints[6 - 1].Add(new PlayerPiece(false));
                _board.BoardPoints[13 - 1].Add(new PlayerPiece(false));
            }
            _board.Player_1Prison = new List<PlayerPiece>(0);
            _board.Player_2Prison = new List<PlayerPiece>(0);
            _board.Player_1_FinalDestination = new List<PlayerPiece>(0);
            _board.Player_2_FinalDestination = new List<PlayerPiece>(0);
        }
        /// <summary>
        /// according to the game rules list the legal movements for given die value
        /// </summary>
        /// <param name="die1Value"></param>
        /// <param name="die2Value"></param>
        /// <returns></returns>
        private List<PlayPieceMovement> NextGameMoveSuggest(int dieValue)
        {
            int finalDestination = (_isPlayer_1turn) ? 25 : 0;
            var suggestions = new List<PlayPieceMovement>(0);
            if (_isPlayer_1turn)
            {
                if (_board.Player_1Prison.Count > 0) //the player must free piece from the base
                {
                    if ((_board.BoardPoints[dieValue - 1].Count < 2) || (_board.BoardPoints[dieValue - 1][0].IsPlayer1Piece== _isPlayer_1turn))
                    {//there is an empty point or a house where the piece can enter
                        suggestions.Add(new PlayPieceMovement(_isPlayer_1turn, dieValue, 0));
                    }
                }
                else //there is no piece in the prison.
                {
                    for (int prevPlace = 1; prevPlace + dieValue < 25; prevPlace++) //to promote a piece in the board points
                    {
                        if (((_board.BoardPoints[prevPlace - 1].Count>0 && _board.BoardPoints[prevPlace - 1][0].IsPlayer1Piece==_isPlayer_1turn))//it is relevant previous point
                        && ((_board.BoardPoints[dieValue + prevPlace - 1].Count < 2) || (_board.BoardPoints[dieValue + prevPlace - 1][0].IsPlayer1Piece == _isPlayer_1turn)))
                        {//there is an empty point or a house where the piece can enter
                            suggestions.Add(new PlayPieceMovement(_isPlayer_1turn, dieValue + prevPlace, prevPlace));
                        }
                    }
                    int piecesInDest = 0;//Check if is it the time to bear-out pieces from the board points to the destinayion
                    for (int i = 18; i < 24; i++)
                    {
                        if (_board.BoardPoints[i].Count > 0 && _board.BoardPoints[i][0].IsPlayer1Piece == _isPlayer_1turn)
                        {
                            piecesInDest += _board.BoardPoints[i].Count;
                        }
                    }
                    piecesInDest += _board.Player_1_FinalDestination.Count;
                    if (piecesInDest == 15)
                    {
                        for (int prevPlace = 19; prevPlace < 25; prevPlace++)
                        {// check if there is a piece how can beard-out with this dieValue
                            if ((prevPlace + dieValue > 24) && ((_board.BoardPoints[prevPlace - 1].Count > 0 && _board.BoardPoints[prevPlace - 1][0].IsPlayer1Piece == _isPlayer_1turn)))
                            {
                                suggestions.Add(new PlayPieceMovement(_isPlayer_1turn, 25, prevPlace));
                            }
                        }
                    }
                }
            }
            else //is player 2 turn
            {
                if (_board.Player_2Prison.Count > 0) //the player must free piece from the base
                {
                    if ((_board.BoardPoints[(25 - dieValue) - 1].Count < 2) || (_board.BoardPoints[(25 - dieValue) - 1][0].IsPlayer1Piece == _isPlayer_1turn))
                    {
                        suggestions.Add(new PlayPieceMovement(_isPlayer_1turn , (25 - dieValue), 25));
                    }
                }
                else //there is no piece in the prison.
                {
                    for (int prevPlace = 24 ; prevPlace - dieValue > 0; prevPlace--) //to promote a piece in the board points
                    {
                        if (((_board.BoardPoints[prevPlace - 1].Count > 0 && _board.BoardPoints[prevPlace - 1][0].IsPlayer1Piece == _isPlayer_1turn))
                        && ((_board.BoardPoints[prevPlace - dieValue - 1].Count < 2) || (_board.BoardPoints[prevPlace - dieValue - 1][0].IsPlayer1Piece == _isPlayer_1turn)))
                            {
                            suggestions.Add(new PlayPieceMovement(_isPlayer_1turn, prevPlace - dieValue, prevPlace));
                            } 
                    }
                    int piecesInDest = 0;//Check if is it the time to move out pieces from the board points to the destinayion
                    for (int i = 0; i < 6; i++)
                    {
                        if (_board.BoardPoints[i].Count > 0 && _board.BoardPoints[i][0].IsPlayer1Piece == _isPlayer_1turn)
                        {
                            piecesInDest += _board.BoardPoints[i].Count;
                        }
                    }
                    piecesInDest += _board.Player_2_FinalDestination.Count;
                    if (piecesInDest == 15)
                    {
                        for (int prevPlace = 6; prevPlace > 0; prevPlace--)
                        {// check if there is a piece how can beard-out with this dieValue
                            if ((prevPlace - dieValue < 1) && ((_board.BoardPoints[prevPlace - 1].Count > 0 && _board.BoardPoints[prevPlace - 1][0].IsPlayer1Piece == _isPlayer_1turn)))
                            {
                                suggestions.Add(new PlayPieceMovement(_isPlayer_1turn, 0, prevPlace));
                            }
                        }
                    }
                }
            }
            return suggestions;
        }
        /// <summary>
        /// return all the dies value this player can use in his turn
        /// in sorted array 
        /// (the higer value is earlier because If moves can be made according to either one die or the other, but not both, the higher number must be used.)
        /// something in addition:
        /// If a player rolls two of the same number, called doubles, that player must play each die twice
        /// </summary>
        /// <param name="die1Value"></param>
        /// <param name="die2Value"></param>
        /// <returns></returns>
        private int[] PlayerTurnDiceValues(int die1Value, int die2Value)
        {
            if ((die1Value < 7 && die1Value > 0) && (die2Value < 7 && die2Value > 0))
            {
                if (die1Value == die2Value)//doables!
                {
                    return new int[] { die1Value, die1Value, die1Value, die1Value };

                }
                else if (die1Value < die2Value)
                {
                    return new int[] { die2Value, die1Value };
                }
                else
                {
                    return new int[] { die1Value, die2Value };
                }
            }
            else //the dice's values are not legal
            {
                throw new ArgumentOutOfRangeException("dieValue", "die value must be in the range [1,6].");

            }
        }
        /// <summary>
        /// this method change the Board state according to the param 
        /// and output an enum that tell if the player wins in this move 
        /// </summary>
        /// <param name="playerLegalDesition">we assuming the move is legal. the check must be before.</param>
        /// <returns></returns>
        private IsGameVictory MakeMove(PlayPieceMovement playerLegalDesition)
        {
            //remove the piece sign from its previous place
            if (playerLegalDesition.PiecePrevPoint>0 && playerLegalDesition.PiecePrevPoint<25)
            {//case the previous place was rgular point
                _board.BoardPoints[playerLegalDesition.PiecePrevPoint - 1].RemoveRange(0, 1);
            }
            else
            {//case the previous place was the prison
                if (playerLegalDesition.PiecePrevPoint ==0)
                {
                    _board.Player_1Prison.RemoveRange(0,1);
                }
                else //playerLegalDesition.PieceOriginPoint==25
                {
                    _board.Player_2Prison.RemoveRange(0, 1);
                }
            }
            //add the piece sign to its destination place
            if (playerLegalDesition.PieceDestination < 25&& playerLegalDesition.PieceDestination > 0)//case the destination is a regular point
            {
                if (_board.BoardPoints[playerLegalDesition.PieceDestination - 1].Count > 0 &&
                _board.BoardPoints[playerLegalDesition.PieceDestination - 1][0].IsPlayer1Piece == !playerLegalDesition.IsPlayer_1_Move)
                {//there was a piece of the otherplayer in the destination 
                    _board.BoardPoints[playerLegalDesition.PieceDestination-1].RemoveRange(0, 1); // take this piece to the prison
                    if (playerLegalDesition.IsPlayer_1_Move)
                    {
                        _board.Player_2Prison.Add(new PlayerPiece(!playerLegalDesition.IsPlayer_1_Move));
                    }
                    else
                    {
                        _board.Player_1Prison.Add(new PlayerPiece(!playerLegalDesition.IsPlayer_1_Move));
                    }
                }
                _board.BoardPoints[playerLegalDesition.PieceDestination - 1].Add(new PlayerPiece(playerLegalDesition.IsPlayer_1_Move));
            }
            else // case the desination is the home/final detination
            {
                if (playerLegalDesition.IsPlayer_1_Move)
                {
                    _board.Player_1_FinalDestination.Add(new PlayerPiece(playerLegalDesition.IsPlayer_1_Move));
                }
                else
                {
                    _board.Player_2_FinalDestination.Add(new PlayerPiece(playerLegalDesition.IsPlayer_1_Move));
                }
            }// check and return the move resaults
            if (_isPlayer_1turn && _board.Player_1_FinalDestination.Count == 15)
            {
                return IsGameVictory.player1wins;
            }
            else if (!_isPlayer_1turn && _board.Player_2_FinalDestination.Count == 15)
            {
                return IsGameVictory.player2wins;
            }
            else
            {
                return IsGameVictory.noneWins;
            }
        }
        /// <summary>
        /// this ethod return the score of each game after the game over
        /// according to the params flag
        /// </summary>
        /// <param name="isPlayer_1Victory"></param>
        /// <param name="wasMars"></param>
        /// <returns></returns>
        private int GameScore(bool isPlayer_1Victory, bool wasMars)
        {
            if (isPlayer_1Victory)
            {
                if (wasMars)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                if (wasMars)
                {
                    return -2;
                }
                else
                {
                    return -1;
                }

            }
        }
        public int Play(Iplayer player1, Iplayer player2,IBackgamonUi ui)
        {
            int doneMovesNo;
            int[] playerTurnDiceValues;
            Setup();
            Iplayer player=player1;
            ui.AfterGameBoardChange(_board);
            while (_gameOver==IsGameVictory.noneWins)
            {
                ui.StartNewPlayerTurn(_isPlayer_1turn);
                int[] diceValues=_dice.Roll();
                ui.AfterDiceRoll(diceValues[0], diceValues[1]);
                doneMovesNo = 0;
                playerTurnDiceValues = PlayerTurnDiceValues(diceValues[0], diceValues[1]);
                do
                {
                    List<PlayPieceMovement> nextLegalMoves = NextGameMoveSuggest(playerTurnDiceValues[doneMovesNo]);
                    var nextMove = player.NextGameMoveChose(nextLegalMoves, _isPlayer_1turn);
                    if (nextMove == null)
                    {
                        Console.WriteLine(" there is no legal move to do ");
                        doneMovesNo++;
                        continue;
                    }
                    _gameOver = MakeMove(nextMove);
                    ui.AfterGameBoardChange(_board);
                    doneMovesNo++;
                    if (_gameOver != IsGameVictory.noneWins)
                    {
                        ui.AfterGameBoardChange(_board);
                        if ((_isPlayer_1turn && _board.Player_2_FinalDestination.Count == 0) || (!_isPlayer_1turn && _board.Player_1_FinalDestination.Count == 0))
                        {
                            _wasMars = true;
                        }
                        _gameOver = (_isPlayer_1turn) ? IsGameVictory.player1wins : IsGameVictory.player2wins;
                        ui.AfterGameVictory(_isPlayer_1turn, _wasMars);
                        break;
                    }
                }
                while (playerTurnDiceValues.Count() > doneMovesNo );
                _isPlayer_1turn = !_isPlayer_1turn;
                player = (_isPlayer_1turn) ?player1:player2;
            }
            bool isPlayer1_victory = (_gameOver == IsGameVictory.player1wins);
            return GameScore(isPlayer1_victory, _wasMars);
        }

    }
}


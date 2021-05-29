using CodingTestGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingTestGame.GameLogic
{
    public class GameLogic : IGameLogic
    {
        #region Private properties
        private string MessageHumanPlayerwin = "\nHuman Player is winner";
        private string MessageRandomComputerPlayerwin = "\nRandom Computer Player is winner";
        private string MessageDrawOrInvalid = "\nTie between players!";
        #endregion

        #region Game Logic methods
        /// <summary>
        /// Accept user input
        /// </summary>
        /// <param name="userPlayerInput"></param>
        /// <returns>RockPaperScissorsEnum enum</returns>
        public RockPaperScissorsEnum AcceptUserPlayerInput(string userPlayerInput)
        {
            return GetResultFromInput(userPlayerInput?.ToUpper());
        }
        /// <summary>
        /// Genearate Random Computer player input
        /// </summary>
        /// <returns></returns>
        public RockPaperScissorsEnum GenerateRandomPlayerInput()
        {
            Random random = new Random();
            return GetResultFromInput(Convert.ToString(random.Next(0, 2)));
        }
        /// <summary>
        /// Get winner.
        /// </summary>
        /// <returns>winner string result.</returns>
        /// <param name="userPlayer">PlayerDetail userPlayer.</param>
        /// <param name="randomPlayer">PlayerDetail randomPlayer.</param>
        public string GetWinner(PlayerDetail userPlayer, PlayerDetail randomPlayer)
        {
            if (GetWinnerObject(userPlayer.GameObjects).Equals(randomPlayer.GameObjects))
            {
                return MessageRandomComputerPlayerwin;
            }
            else if (GetWinnerObject(randomPlayer.GameObjects).Equals(userPlayer.GameObjects))
            {
                return MessageHumanPlayerwin;
            }
            else
            {
                return MessageDrawOrInvalid;
            }
        }
        /// <summary>
        /// Get Winner object
        /// </summary>
        /// <param name="winnerInput"></param>
        /// <returns>RockPaperScissorsEnum enum</returns>
        public RockPaperScissorsEnum GetWinnerObject(RockPaperScissorsEnum winnerInput)
        {
            switch (winnerInput)
            {
                case RockPaperScissorsEnum.Rock:
                    return RockPaperScissorsEnum.Paper;
                case RockPaperScissorsEnum.Paper:
                    return RockPaperScissorsEnum.Scissors;
                case RockPaperScissorsEnum.Scissors:
                    return RockPaperScissorsEnum.Rock;
                default:
                    return RockPaperScissorsEnum.Unknown;
            }
        }
        /// <summary>
        /// Get final result string
        /// </summary>
        /// <param name="lstResults"></param>
        /// <returns>final result string</returns>
        public string GetWinnerResultString(List<string> lstResults)
        {
            int TieCount = lstResults.Where(x => x.Contains(MessageDrawOrInvalid)).Count();
            int PlayerCount = lstResults.Where(x => x.Contains(MessageHumanPlayerwin)).Count();
            int RandomPlayerCount = lstResults.Where(x => x.Contains(MessageRandomComputerPlayerwin)).Count();
            if (TieCount == 0)
            {
                if (PlayerCount > RandomPlayerCount)
                    return MessageHumanPlayerwin;
                else if (RandomPlayerCount > PlayerCount)
                    return MessageRandomComputerPlayerwin;
                else
                    return MessageDrawOrInvalid;
            }
            else
            {
                if (TieCount == 3)
                    return MessageDrawOrInvalid;
                else if (TieCount == 2 && PlayerCount == 1)
                    return MessageHumanPlayerwin;
                else if (TieCount == 2 && RandomPlayerCount == 1)
                    return MessageRandomComputerPlayerwin;
                else if (TieCount == 1 && RandomPlayerCount == 1 && PlayerCount == 1)
                    return MessageDrawOrInvalid;
                else if (TieCount == 1 && PlayerCount == 2)
                    return MessageHumanPlayerwin;
                else if (TieCount == 1 && RandomPlayerCount == 2)
                    return MessageRandomComputerPlayerwin;
                else
                    return MessageDrawOrInvalid;
            }
        }

        /// <summary>
        /// Get result from input
        /// </summary>
        /// <param name="input"></param>
        /// <returns>RockPaperScissorsEnum enum</returns>
        private RockPaperScissorsEnum GetResultFromInput(string input)
        {
            if (input == "0" || input == "ROCK" || input == "R")
            {
                return RockPaperScissorsEnum.Rock;
            }
            else if (input == "1" || input == "PAPER" || input == "P")
            {
                return RockPaperScissorsEnum.Paper;
            }
            else if (input == "2" || input == "SCISSORS" || input == "S")
            {
                return RockPaperScissorsEnum.Scissors;
            }
            else
            {
                return RockPaperScissorsEnum.Unknown;
            }
        }
        #endregion
    }
}

using CodingTestGame.Models;
using System;
using Microsoft.Extensions.DependencyInjection;
using CodingTestGame.GameLogic;
using System.Collections.Generic;

namespace CodingTestGameConsole
{
    class Program
    {
        private static PlayerDetail humanPlayer;
        private static PlayerDetail randomComputerPlayer;
        private static string humanPlayerName = "Human Player";
        private static string randomComputerPlayerName = "Random Computer Player";
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider= SetDependencyInjection();
            StartGame(serviceProvider);
        }
        private static ServiceProvider SetDependencyInjection()
        {
           var serviceProvider = new ServiceCollection()
          .AddTransient<IPrintFormatConsole, PrintFormatConsole>()
          .AddTransient<IGameLogic, GameLogic>()
          .BuildServiceProvider();
           return serviceProvider;
        }
        private static void StartGame(ServiceProvider serviceProvider)
        {
            var consoleFormatService = serviceProvider.GetService<IPrintFormatConsole>();
            var gameLogicService = serviceProvider.GetService<IGameLogic>();
            var name = consoleFormatService.GetHeaderConsole(humanPlayerName);
            Console.WriteLine(name);
            //intitialize players
            humanPlayer = new PlayerDetail(name);
            randomComputerPlayer = new PlayerDetail(randomComputerPlayerName);
            //message
            consoleFormatService.GetPlayerName(humanPlayerName);
            int Count = 0;
            List<string> lstResults = new List<string>();
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            while (Count < 3)
            {
                //Get human player user input
                Console.WriteLine(consoleFormatService.GetGameObjectSelection());
                string input = Console.ReadLine();
                var handSign = gameLogicService.AcceptUserPlayerInput(input);
                humanPlayer.GameObjects = handSign;
                //Generate a random computer player input
                randomComputerPlayer.GameObjects = gameLogicService.GenerateRandomPlayerInput();
                Console.WriteLine(humanPlayerName + " Input :" + humanPlayer.GameObjects.GetDescription());
                Console.WriteLine(randomComputerPlayerName +" Input :" + randomComputerPlayer.GameObjects.GetDescription());
                string result = gameLogicService.GetWinner(humanPlayer, randomComputerPlayer);
                lstResults.Add(result);
                Console.WriteLine("************************************************************************************");
                Console.WriteLine(result + "\n");
                Console.WriteLine("************************************************************************************");
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Count++;
            }
            Console.WriteLine("---------------------------------------Final Result------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine(gameLogicService.GetWinnerResultString(lstResults));
            Console.WriteLine("\n-----------------------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
        }
    }
}

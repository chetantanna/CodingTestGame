namespace CodingTestGame.GameLogic
{
    public class PrintFormatConsole : IPrintFormatConsole
    {
        #region methods
        public string GetGameObjectSelection()
        {
            return "0-R-Rock (For choose Rock object you can write 0 OR R Or Rock and press enter)\n" +
                              "1-P-Paper (For choose Paper object you can write 1 OR P Or Paper and press enter)\n" +
                              "2-S-Scissors (For choose Scissors object you can write 2 OR S Or Scissors and press enter)\n" +
                              "Please select your option:";
        }
        public string GetHeaderConsole(string name)
        {
            return "Welcome to Rock, Paper, Scissors! You " + name + " against the Random Computer Player.\n\n" +
                "Below are the rules of Game.\n" +
                "Rock beats scissors.\n" +
                "Scissors beats paper.\n" +
                "Paper beats rock.\n";
        }
        public string GetPlayerName(string name)
        {
            return string.Format("{0} ,let's Play!\n", name);
        }
        #endregion
    }
}

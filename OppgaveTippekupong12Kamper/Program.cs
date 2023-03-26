using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace OppgaveTippekupong12Kamper;
class Program
{
    static void Main(string[] args)
    {
        Run();
    }
    static void Run()
    {
        Console.Write("Valid tip: \r\n - H, U, B\r\n - half guard: HU, HB, UB\r\n - full guard: HUB\r\nEnter your 12 tips with commas between: ");
        var betsText = Console.ReadLine();
        var twelveMatches = new Matches(betsText);

        while (true)
        {
            Console.Write("Write match no. 1-12 for scoring or X for all matches finished\r\nEnter command: ");
            var command = Console.ReadLine();
            if (command == "X") break;
            var matchNo = Convert.ToInt32(command);


            Console.Write($"Scoring in match {matchNo}. \r\nWrite H for home team or B for away team: ");
            var team = Console.ReadLine();

            twelveMatches.AddGoalToMatch(matchNo, team == "H");
            Console.WriteLine("THIS RUNS");

            var scores = twelveMatches.GetScores();
            var areBetsCorrect = twelveMatches.areBetsCorrect();
            var correctBetCount = twelveMatches.CountCorrectBets();

            for (var index = 0; index < scores.Length; index++)
            {
                var score = scores[index];
                var matchNumber = index + 1;
                var isBetCorrect = areBetsCorrect[index];
                var isBetCorrectText = isBetCorrect ? "riktig" : "feil";

                Console.WriteLine($"Kamp {matchNumber}: {score} - {isBetCorrectText}");
            }

            Console.WriteLine($"Du har {correctBetCount} rette.");
        }
    }
}
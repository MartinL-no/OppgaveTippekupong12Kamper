using System.Collections.Generic;

namespace OppgaveTippekupong12Kamper
{
    internal class Matches
    {
        private readonly List<Match> _matches;

        public Matches(string betsText)
        {
            _matches = new List<Match>();

            foreach (var bet in betsText.Split(','))
            {
                _matches.Add(new Match(bet));
            }
        }
        public void AddGoalToMatch(int matchNumber, bool isHomeTeam)
        {
            _matches[matchNumber - 1].AddGoal(isHomeTeam);
        }
        public string[] GetScores()
        {
            var list = new List<string>();
            foreach (var match in _matches)
            {
                list.Add(match.GetScore());
            }
            return list.ToArray();
        }
        public int CountCorrectBets()
        {
            var correctBets = areBetsCorrect().Where(bet => bet == true);

            return correctBets.Count();
        }

        public bool[] areBetsCorrect()
        {
            var areBetsCorrectList = new List<bool>();
            foreach (var match in _matches)
            {
                areBetsCorrectList.Add(match.IsBetCorrect());
            }
            return areBetsCorrectList.ToArray();
        }
    }
}
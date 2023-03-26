using System;
namespace OppgaveTippekupong12Kamper
{
    public class Match
    {
        private int _homeGoals;
        private int _awayGoals;
        private readonly string _bet;
        public bool IsRunning { get; private set; }

        public Match(string bet)
        {
            _homeGoals = 0;
            _awayGoals = 0;
            _bet = bet;
            IsRunning = true;
        }
        public void AddGoal(bool isHomeTeam)
        {
            if (isHomeTeam) _homeGoals++;
            else _awayGoals++;
        }

        public bool IsBetCorrect()
        {
            if (_bet == "U" && _homeGoals == _awayGoals)
            {
                return true;
            }
            else if (_bet == "H" && _homeGoals > _awayGoals)
            {
                return true;
            }
            else if (_bet == "B" && _awayGoals > _homeGoals)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Stop()
        {
            IsRunning = false;
        }

        public string GetScore()
        {
            return $"The score is {_homeGoals}-{_awayGoals}.";
        }
    }
}
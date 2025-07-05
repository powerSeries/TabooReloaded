using Microsoft.Extensions.Configuration;
using TabooReloaded.Shared.Model;
using TabooReloaded.Shared.Model.Event;
using TabooReloaded.Shared.Services;

namespace TabooReloaded.Services
{
    public class GameService : IGameInterface
    {
        private IDatabaseService _databaseService;
        private IConfiguration _config;

        private int _numOfPlayers;
        private int _numOfRounds;

        public GameService(IDatabaseService service, IConfiguration config)
        {
            _databaseService = service;
            _config = config;
            RoundDuration = _config.GetValue<int>("GameSettings:RoundDuration");
        }

        public int RoundDuration { get; set; }

        public TeamModel? Team1 { get; set; } = null;
        public TeamModel? Team2 { get; set; } = null;

        public List<TabooWordModel> HistoricalWords { get; set; } = new List<TabooWordModel>();

        public void SetupGame(TeamModel team1, TeamModel team2, int? numOfPlayers, int? numOfRounds)
        {
            team1.ScoreChanged += IncreaseScore;
            team2.ScoreChanged += IncreaseScore;

            if(numOfPlayers.HasValue)
            {
                _numOfPlayers = numOfPlayers.Value;
            }

            if (numOfRounds.HasValue)
            {
                _numOfRounds = numOfRounds.Value;
            }

            Team1 = team1;
            Team2 = team2;
        }

        private void IncreaseScore(object? sender, ScoreChangedEventArgs e)
        {
            if(sender is TeamModel team)
            {
                team.Score += e.Score;
            }
        }
    }
}

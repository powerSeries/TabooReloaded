using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabooReloaded.Shared.Model;

namespace TabooReloaded.Shared.Services
{
    public interface IGameInterface
    {
        TeamModel? Team1 { get; set; }
        TeamModel? Team2 { get; set; }

        List<TabooWordModel> HistoricalWords { get; set; }
        void SetupGame(TeamModel team1, TeamModel team2, int? numOfPlayers, int? numOfRounds);
    }
}

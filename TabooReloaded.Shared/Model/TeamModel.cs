using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabooReloaded.Shared.Model.Event;

namespace TabooReloaded.Shared.Model
{
    public class TeamModel
    {
        public string TeamName { get; set; } = string.Empty;
        public int Score { get; set; }

        public bool IsWinner { get;set; }
        public bool IsPlaying { get; set; }

        public List<string> History = new List<string>();

        public event EventHandler<ScoreChangedEventArgs>? ScoreChanged;
        public void OnScoreChanged(ScoreChangedEventArgs e)
        {
            ScoreChanged?.Invoke(this, e);
        }
    }
}

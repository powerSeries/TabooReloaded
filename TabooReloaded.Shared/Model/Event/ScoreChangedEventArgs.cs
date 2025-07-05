using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabooReloaded.Shared.Model.Event
{
    public class ScoreChangedEventArgs : EventArgs
    {
        public TeamModel Team { get; set; }
        public int Score { get; set; }
        public DateTime Timestamp { get; set; }
        public ScoreChangedEventArgs(int score, DateTime timestamp)
        {
            Score = score;
            Timestamp = timestamp;
        }
    }
}

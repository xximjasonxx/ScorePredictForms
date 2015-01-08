using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorePredict.Data
{
    public class WeekOverview
    {
        public DateTime WeekOf { get; set; }
        public int NumberOfGames { get; set; }
        public int NumberOfPredictions { get; set; }
        public int TotalPoints { get; set; }

    }
}

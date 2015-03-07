using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorePredict.Common.Models
{
    public class RankingModel
    {
        public int Rank { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public int Points { get; set; }
    }
}

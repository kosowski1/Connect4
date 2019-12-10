using Connect4.Models.RankingViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Connect4.Models.ManageViewModels
{
    public class Ranking
    {
        public int idTorneio { get; set; }
        public IList<JogadorRanking> Jogadores { get; set; } = new List<JogadorRanking>();



    }
}

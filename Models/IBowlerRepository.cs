using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLFun.Models
{
    public interface IBowlerRepository
    {
        IQueryable<Bowler> Bowlers { get; }
        IQueryable<Teams> Teams { get; }

        public void SaveResponse(Bowler bwl);

        public void AddResponse(Bowler bwl);

        public void DeleteResponse(Bowler bwl);

        public void EditResponse(Bowler bwl);
    }
}

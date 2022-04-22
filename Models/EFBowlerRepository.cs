using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLFun.Models
{
    public class EFBowlerRepository : IBowlerRepository
    {

        private BowlingDbContext _context { get; set; }
       
        public EFBowlerRepository (BowlingDbContext temp)
        {
            _context = temp;
        }
        public IQueryable<Bowler> Bowlers => _context.Bowlers;
        public IQueryable<Teams> Teams => _context.Teams;

        public void SaveResponse(Bowler bwl)
        {
            _context.SaveChanges();
        }

        public void AddResponse(Bowler bwl)
        {
            _context.Add(bwl);
            _context.SaveChanges();
        }

        public void EditResponse(Bowler bwl)
        {
            _context.Update(bwl);
            _context.SaveChanges();
        }
        public void DeleteResponse(Bowler bwl)
        {
            _context.Remove(bwl);
            _context.SaveChanges();
        }
    }
}

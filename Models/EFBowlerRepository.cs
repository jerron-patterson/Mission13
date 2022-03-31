using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class EFBowlerRepository : IBowlerRepository
    {
        private BowlingDbContext _context { get; set; }

        public EFBowlerRepository (BowlingDbContext temp)
        {
            _context = temp;
        }
        public IQueryable<Bowler> Bowlers => _context.Bowlers;
        public IQueryable<Team> Teams => _context.Teams;
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void AddBowler(Bowler b)
        {
            _context.Add(b);
            _context.SaveChanges();
        }
        public void DeleteBowler(Bowler b)
        {
            _context.Remove(b);
            _context.SaveChanges();
        }
    }
}

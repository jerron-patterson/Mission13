using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public interface IBowlerRepository
    {
        IQueryable<Bowler> Bowlers { get;}
        IQueryable<Team> Teams { get; }
        public void SaveChanges();
        public void AddBowler(Bowler b);
        public void DeleteBowler(Bowler b);
    }
}

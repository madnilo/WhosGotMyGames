using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhosGotMyGames.Data;
using WhosGotMyGames.Models;
using WhosGotMyGames.Models.Entities;
using WhosGotMyGames.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace WhosGotMyGames.Repositories.Concrete
{
    public class LendingsRepository : GenericRepository<Lending>, ILendingsRepository
    {
        private ApplicationDbContext _context;

        public LendingsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Lending> GetAllFromUser(string id)
        {
            return 
                _context.Lending
                .Include(l => l.Game)
                .Include(l => l.Friend)
                .Include(l => l.ApplicationUser)
                .Where(l => l.ApplicationUser.Id == id);
        }

        public Lending GetEager(int id)
        {
            return 
                _context.Lending
                .Include(l => l.Game)
                .Include(l => l.Friend)
                .Include(l => l.ApplicationUser)
                .Where(len => len.LendingId == id).FirstOrDefault();
        }
    }
}

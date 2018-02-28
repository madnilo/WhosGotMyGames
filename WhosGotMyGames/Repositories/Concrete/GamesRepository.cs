using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhosGotMyGames.Data;
using WhosGotMyGames.Models.Entities;
using WhosGotMyGames.Repositories.Abstract;

namespace WhosGotMyGames.Repositories.Concrete
{
    public class GamesRepository : GenericRepository<Game>, IGamesRepository
    {
        private ApplicationDbContext _context;

        public GamesRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

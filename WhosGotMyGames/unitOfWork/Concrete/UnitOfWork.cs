using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhosGotMyGames.Data;
using WhosGotMyGames.Models.Entities;
using WhosGotMyGames.Repositories;
using WhosGotMyGames.Repositories.Abstract;
using WhosGotMyGames.unitOfWork.Abstract;

namespace WhosGotMyGames.unitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGenericRepository<Game> _gamesRepository;


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Game> GamesRepository
        {
            get
            {
                return _gamesRepository = _gamesRepository ?? new GenericRepository<Game>(_context);
            }
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

    }
}

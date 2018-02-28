using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhosGotMyGames.Models.Entities;
using WhosGotMyGames.Repositories.Abstract;
using WhosGotMyGames.Repositories.Concrete;

namespace WhosGotMyGames.unitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        IGenericRepository<Game> GamesRepository { get; }
        ILendingsRepository LendingsRepository { get; }
        IGenericRepository<Friend> FriendsRepository { get; }

        void Complete();
    }
}

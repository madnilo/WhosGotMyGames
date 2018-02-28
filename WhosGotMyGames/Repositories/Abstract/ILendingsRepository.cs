using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhosGotMyGames.Models;
using WhosGotMyGames.Models.Entities;

namespace WhosGotMyGames.Repositories.Abstract
{
    public interface ILendingsRepository : IGenericRepository<Lending>
    {
        IEnumerable<Lending> GetAllFromUser(string id);
        Lending GetEager(int id);
    }
}

using Cuf.infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuf.infrastructure.Repositories
{
    public interface IVoterRepository
    {
        void Add(Voter voter);

        void Edit(Voter voter);

        void Remove(int Id);

        IEnumerable<Voter> GetVotersPollingStation(int Id);

        IEnumerable<Voter> GetVotersShehia(int Id);

        IEnumerable<Voter> GetVotersWord(int Id);

        IEnumerable<Voter> GetVotersConstituent(int Id);

        Voter FindById(int Id);
    }
}

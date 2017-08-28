using Cuf.infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuf.infrastructure.Repositories
{
    public class VoterRepository : IVoterRepository
    {
        public CufDBContext context = new CufDBContext();

        public void Add(Models.Voter voter)
        {
            context.Voters.Add(voter);
            context.SaveChanges();

        }

        public void Edit(Models.Voter voter)
        {
            context.Entry(voter).Entity.State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void Remove(int Id)
        {
            Voter voter = context.Voters.Find(Id);
            context.Voters.Remove(voter);
            context.SaveChanges();
        }

        // This will return IEnumerable of voters in particular polling station
        // Polling station ID is passed to retrieve the data
        public IEnumerable<Models.Voter> GetVotersPollingStation(int Id)
        {
            var results = from voter in context.Voters where voter.PollingStationId == Id select voter;

            return results;
                                             
        }

        // This will return IEnumerable of voters in particular shehia
        // Shehia ID is passed to retrieve the data
        public IEnumerable<Models.Voter> GetVotersShehia(int Id)
        {
            var results = from voter in context.Voters
                          join voter2 in context.PollingShehias
                          on voter.PollingStationId equals voter2.PollingStationId
                          where voter2.ShehiaId == Id
                          select voter;

            return results;
        }

        // This will return IEnumerable of voters in word
        // Word ID is passed to retrieve the data, here subquery is used to fetch
        // polling station ID's for the particular word 
        public IEnumerable<Models.Voter> GetVotersWord(int Id)
        {
            var results = from voter in context.Voters
                          join voter2 in context.PollingShehias
                          on voter.PollingStationId equals voter2.PollingStationId
                          where voter2.WordId == Id
                          select voter;

            return results;
        }

        // This will return IEnumerable of voters in particular constituent
        // Constituent ID is passed to retrieve the data
        public IEnumerable<Models.Voter> GetVotersConstituent(int Id)
        {
            var results = from v in context.Voters where v.ResidentialConstituencyId == Id select v;
            return results;
        }

        public Models.Voter FindById(int Id)
        {
            var result = (from v in context.Voters where v.Id == Id select v).FirstOrDefault();
            return result;
        }
    }
}

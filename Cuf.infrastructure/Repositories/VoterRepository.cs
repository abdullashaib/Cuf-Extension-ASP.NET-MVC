﻿using Cuf.infrastructure.Models;
using System;
using System.Collections;
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
            //context.Entry(voter).Entity.
            //context.SaveChanges();
        }

        public void Remove(int Id)
        {
            context.Voters.Remove(context.Voters.FirstOrDefault(v => v.Id == Id));
            context.SaveChanges();
        }

        // This will return IEnumerable of voters in particular polling station
        // Polling station ID is passed to retrieve the data
        public IEnumerable<Models.Voter> GetVotersPollingStation(int Id)
        {
            var results = from voter in context.Voters where voter.PollingStationId == Id
                          orderby voter.FirstName, voter.MiddleName, voter.LastName, voter.Gender ascending
                          select voter;

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
                          orderby voter.FirstName, voter.MiddleName, voter.LastName, voter.Gender ascending
                          select voter;

            return results;
        }

        // This will return IEnumerable of voters in word
        // Word ID is passed to retrieve the data, here subquery is used to fetch
        // polling station ID's for the particular word 
        public IEnumerable<Voter> GetVotersWord(int Id)
        {
            var results = from voter in context.Voters
                          join voter2 in context.PollingShehias on voter.PollingStationId equals voter2.PollingStationId
                          join poll in context.PollingStations on voter.PollingStationId equals poll.Id
                          where voter2.WordId == Id
                          orderby voter.FirstName, voter.MiddleName, voter.LastName, voter.Gender ascending
                          select voter;
                          

            return results;
        }

        // This will return IEnumerable of voters in particular constituent
        // Constituent ID is passed to retrieve the data
        public IEnumerable<Models.Voter> GetVotersConstituent(int Id)
        {
            var results = from voter in context.Voters where voter.ResidentialConstituencyId == Id
                          orderby voter.FirstName, voter.MiddleName, voter.LastName, voter.Gender ascending
                          select voter;
            return results;
        }

        public Models.Voter FindById(int Id)
        {
            var result = (from voter in context.Voters where voter.Id == Id select voter).FirstOrDefault();
            return result;
        }
    }
}

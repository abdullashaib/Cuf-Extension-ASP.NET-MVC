using Cuf.infrastructure.Models;
using Cuf.infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuf.Test
{
    [TestClass]
    public class VoterRepositoryTest
    {
        VoterRepository repo;

        [TestInitialize]
        public void TestSetup()
        {
            repo = new VoterRepository();
        }

        [TestMethod]
        public void IsRepositoryGetDataWord()
        {
            var results = repo.GetVotersWord(46);

            foreach (Voter voter in results)
            {
                System.Console.WriteLine(voter.FirstName + " " + voter.MiddleName + " " + voter.LastName + 
                    " " + voter.Gender + " " + voter.DateBirth + " " + voter.ResidentialAddress + 
                    " " + voter.VoterIDNumber + " " + voter.LifeStatus + "\n");
            }
        }

        [TestMethod]
        public void IsRepositoryGetDataConstituent()
        {
            var results = repo.GetVotersConstituent(50);

            foreach (Voter voter in results)
            {
                System.Console.WriteLine(voter.FirstName + " " + voter.MiddleName + " " + voter.LastName +
                    " " + voter.Gender + " " + voter.DateBirth + " " + voter.ResidentialAddress +
                    " " + voter.VoterIDNumber + " " + voter.LifeStatus + "\n");
            }

        }

        [TestMethod]
        public void IsRepositoryGetDataShehia()
        {
            var results = repo.GetVotersShehia(2);

            foreach (Voter voter in results)
            {
                System.Console.WriteLine(voter.FirstName + " " + voter.MiddleName + " " + voter.LastName +
                    " " + voter.Gender + " " + voter.DateBirth + " " + voter.ResidentialAddress +
                    " " + voter.VoterIDNumber + " " + voter.LifeStatus + "\n");
            }
        }

        [TestMethod]
        public void IsRepositoryGetDataPollingStation()
        {
            var results = repo.GetVotersPollingStation(1);

            foreach (Voter voter in results)
            {
                System.Console.WriteLine(voter.FirstName + " " + voter.MiddleName + " " + voter.LastName +
                    " " + voter.Gender + " " + voter.DateBirth + " " + voter.ResidentialAddress +
                    " " + voter.VoterIDNumber + " " + voter.LifeStatus + "\n");
            }
        }

        [TestMethod]
        public void IsRepositoryAddData()
        {
            Voter voter = new Voter
            {
                FirstName = "John",
                MiddleName = "Sammuel",
                LastName = "Sita",
                Gender = "Male",
                DateBirth = "30/4/1942",
                ResidentialAddress = "Machui",
                PollingStationId = 1,
                ResidentialConstituencyId = 1,
                VotingConstituencyId = 1,
                VoterIDNumber = 999999999,
                LifeStatus = "Is Live"

            };

            repo.Add(voter);  
        }

        [TestMethod]
        public void IsRepositoryDeleteData()
        {
            repo.Remove(4);
        }
    }
}

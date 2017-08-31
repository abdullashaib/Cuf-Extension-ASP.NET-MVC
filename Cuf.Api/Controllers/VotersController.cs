using Cuf.infrastructure.Models;
using Cuf.infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cuf.Api.Controllers
{
    public class VotersController : ApiController
    {
        private VoterRepository db = new VoterRepository();

        // GET: api/Voters
        public IEnumerable<Voter> Get()
        {
            return db.GetVotersConstituent(50);
        }

        // GET: api/Voters/5
        public IHttpActionResult Get(int id)
        {
            var result = db.FindById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET: api/Voters/VotersInWords/5
        [HttpGet]
        public IHttpActionResult VotersInWords(int id)
        {
            var results = db.GetVotersWord(id);

            if (results == null)
            {
                return NotFound();
            }

            return Ok(results);

        }

        // GET: api/Voters/VotersInWords/5
        [HttpGet]
        public IHttpActionResult VotersInShehia(int id)
        {
            var results = db.GetVotersShehia(id);

            if (results == null)
            {
                return NotFound();
            }

            return Ok(results);
        }


        // GET: api/Voters/VotersInPollingStation/5
        [HttpGet]
        public IHttpActionResult VotersInPollingStation(int id)
        {
            var results = db.GetVotersPollingStation(id);

            if (results == null)
            {
                return NotFound();
            }

            return Ok(results);
        }


        // POST: api/Voters
        public HttpResponseMessage Post([FromBody] Voter voter)
        {
            try
            {
                db.Add(voter);

                var message = Request.CreateResponse(HttpStatusCode.Created, voter);
                message.Headers.Location = new Uri(Request.RequestUri + voter.Id.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        // PUT: api/Voters/5
        public HttpResponseMessage Put(int id, [FromBody] Voter voter)
        {
            try
            {
                db.Add(voter);
                return Request.CreateResponse(HttpStatusCode.OK, voter);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE: api/Voters/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                db.Remove(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}

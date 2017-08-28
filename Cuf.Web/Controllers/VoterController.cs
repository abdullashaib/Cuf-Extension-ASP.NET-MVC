using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cuf.infrastructure.Models;
using Cuf.infrastructure.Repositories;

namespace Cuf.Web.Controllers
{
    public class VoterController : Controller
    {
        public VoterRepository db = new VoterRepository();

        // GET: Voter
        public ActionResult Index()
        {
            return View(db.GetVotersConstituent(Convert.ToInt32(50)));
        }

        // GET: Voter/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Voter voter = db.FindById(Convert.ToInt32(id));

            if (voter == null)
            {
                return HttpNotFound();
            }

            return View(voter);
        }

        // GET: Voter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Voter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,MiddleName,LastName,DateBirth,Gender,ResidentialAddress,PollingStationId,ResidentialConstituencyId,VotingConstituencyId,VoterIDNumber,LifeStatus")] Voter voter)
        {
            if (ModelState.IsValid)
            {
                db.Add(voter);
                
                return RedirectToAction("Index");
            }

            return View(voter);
        }

        // GET: Voter/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Voter voter = db.FindById(Convert.ToInt32(id));

            if (voter == null)
            {
                return HttpNotFound();
            }
            return View(voter);
        }

        // POST: Voter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,MiddleName,LastName,DateBirth,Gender,ResidentialAddress,PollingStationId,ResidentialConstituencyId,VotingConstituencyId,VoterIDNumber,LifeStatus")] Voter voter)
        {
            if (ModelState.IsValid)
            {
                db.Edit(voter);

                return RedirectToAction("Index");
            }
            return View(voter);
        }

        // GET: Voter/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Voter voter = db.FindById( Convert.ToInt32(id));

            if (voter == null)
            {
                return HttpNotFound();
            }
            return View(voter);
        }

        // POST: Voter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Remove(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CharityProject;

namespace CharityProjectUI.Controllers
{
    public class CharityProgramsController : Controller
    {
        private FoundationModel db = new FoundationModel();

        // GET: CharityPrograms
        public ActionResult Index()
        {
            return View(Foundation.GetallCharityPrograms());
        }

        public ActionResult ProcessDonation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharityProgram charityProgram = db.CharityPrograms.Find(id);
            return View(charityProgram);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProcessDonation(FormCollection controls)
        {
            var Id = Convert.ToInt32(controls["Id"]);
            var amount=Convert.ToDecimal(controls["Amount"]);
            Foundation.ProcessDonation(Id, amount);
            return RedirectToAction("Index");
        }
        

        public ActionResult Donations(int?id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var donations = Foundation.GetAllDonationsByCharityProgram(id.Value);
            return View(donations);
        }

        // GET: CharityPrograms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharityProgram charityProgram = db.CharityPrograms.Find(id);
            if (charityProgram == null)
            {
                return HttpNotFound();
            }
            return View(charityProgram);
        }

        // GET: CharityPrograms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CharityPrograms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Name,MoneyGoal,BankAccountNumber,MoneyAlreadyGot,EmergencyLevel")] CharityProgram charityProgram)
        {
            if (ModelState.IsValid)
            {
                Foundation.CreateCharityProgram(charityProgram.Name,charityProgram.MoneyGoal ,charityProgram. EmergencyLevel);
                return RedirectToAction("Index");
            }

            return View(charityProgram);
        }

        // GET: CharityPrograms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharityProgram charityProgram = Foundation.GetCharityProgramByID(id.Value );
            if (charityProgram == null)
            {
                return HttpNotFound();
            }
            return View(charityProgram);
        }

        // POST: CharityPrograms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Name,MoneyGoal,BankAccountNumber,MoneyAlreadyGot,EmergencyLevel")] CharityProgram charityProgram)
        {
            if (ModelState.IsValid)
            {
                Foundation.EditCharityProgram(charityProgram);
                return RedirectToAction("Index");
            }
            return View(charityProgram);
        }

        // GET: CharityPrograms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharityProgram charityProgram = Foundation.GetCharityProgramByID(id.Value);
            if (charityProgram == null)
            {
                return HttpNotFound();
            }
            return View(charityProgram);
        }

        // POST: CharityPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Foundation.DeleteCharityProgram(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

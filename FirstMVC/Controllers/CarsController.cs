﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FirstMVC.Models;

namespace FirstMVC.Controllers
{
    public class CarsController : Controller
    {
        private Cars4DB db = new Cars4DB();

        // GET: Cars
        public ActionResult Index()
        {
            return View(db.Cars.ToList());
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Make,Model,Price")] Cars cars)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(cars);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cars);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            return View(cars);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Make,Model,Price")] Cars cars)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cars).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cars);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            return View(cars);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cars cars = db.Cars.Find(id);
            db.Cars.Remove(cars);
            db.SaveChanges();
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

using FirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Controllers
{
    public class ReviewsController : Controller
    {

        Cars4DB _db = new Cars4DB();


        //GET: Reviews
        public ActionResult Index([Bind (Prefix ="id")]int carId)
        {
            var car = _db.Cars.Find(carId);
            if (car != null)
            {
                return View(car);
            }
            return HttpNotFound();

        }

        [HttpGet]
        public ActionResult Create(int CarsId)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _db.Reviews.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Exclude ="CarId")]CarReviews review)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(review).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.CarsId });
            }
            return View(review);
        }
        [HttpPost]
        public ActionResult Create(CarReviews review)
        {
            if (ModelState.IsValid)
            {
                _db.Reviews.Add(review);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.CarsId });
            }
            return View(review);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}

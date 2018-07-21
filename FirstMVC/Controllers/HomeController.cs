using FirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Controllers
{
    public class HomeController : Controller
    {

        Cars4DB _db = new Cars4DB();

        public ActionResult Autocomplete(string term)
        {
            var model = _db.Cars
                .Where(r => r.Make.StartsWith(term))
                .Take(10)
                .Select(r => new
                {
                    label = r.Make
                });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(string searchTerm = null)
        {
            //var model = from r in _db.Cars
            //            orderby r.Reviews.Average(review => review.Rating) descending
            //            select new CarListViewModel
            //            {
            //                Id = r.Id,
            //                Model = r.Model,
            //                Make = r.Make,
            //                Price = r.Price,
            //                CountOfReviews = r.Reviews.Count()
            //            };

            var model = _db.Cars.OrderBy(r => r.Reviews.Average(review => review.Rating))
                .Where(r => searchTerm == null || r.Make.StartsWith(searchTerm))
                .Select(r => new CarListViewModel
                {
                    Id = r.Id,
                    Model = r.Model,
                    Make = r.Make,
                    Price = r.Price,
                    CountOfReviews = r.Reviews.Count()
                }
                );

            if(Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants", model);
            }

            return View(model);

        }

        public ActionResult About()
        {
            var model = new AboutModel();
            model.Name = "James";
            model.Location  = "Sunderland, UK";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {

            if (_db !=null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
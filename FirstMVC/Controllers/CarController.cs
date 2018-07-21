using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        //[Authorize]
        public ActionResult Search(String name = "ford")
        {
            throw new Exception("Something bad");
            //var message = Server.HtmlEncode(name);

            //return Content(message);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RiggenPoker.Controllers
{
    public class TournamentsController : Controller
    {
        // GET: Tournaments
        public ActionResult Index()
        {
            return View();
        }
    }
}
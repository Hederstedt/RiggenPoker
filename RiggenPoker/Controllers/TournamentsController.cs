using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/// <summary>
///  Here is the controller for are different tournaments   
/// </summary>
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
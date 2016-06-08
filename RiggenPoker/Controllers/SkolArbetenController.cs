using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/// <summary>
/// Simple controller to display some school work 
/// </summary>
namespace RiggenPoker.Controllers
{
    public class SkolArbetenController : Controller
    {
        // GET: SkolArbeten
        public ActionResult Index()
        {
            return View();
        }
    }
}
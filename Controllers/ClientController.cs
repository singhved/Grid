using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace Grid.Controllers
{
    public class ClientController : Controller
    {
        Context db = new Context();
        // GET: Client
        public ActionResult Index()
        { 
            return View();
        }
        public PartialViewResult GetSearchData(string Data)
        {
            ViewBag.Data = Data;
            return PartialView();
        }
    }
}
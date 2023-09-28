using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Grid.Models;

namespace Grid.Controllers
{
    public class HomeController : Controller
    {
        Context db = new Context();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Grid(int? no)
        {
            ViewBag.no = no;
            return PartialView();
        }

        public ActionResult Save(CourseStudents cs)
        {
            db.CourseStudents.Add(cs);
            db.SaveChanges();

            int CsId = cs.Id;

            string[] Course = Request["Course"].Split(',').ToArray();
            string[] Branch = Request["Branch"].Split(',').ToArray();
            DateTime[] Date = Request["Date"].Split(',').Select(x=>Convert.ToDateTime(x)).ToArray();

            List<CourseData> cd = new List<CourseData>();
            for (int i = 0; i < Course.Length; i++)
            {
                CourseData course = new CourseData
                {
                    CSId = CsId,
                    Course = Course[i],
                    Branch = Branch[i],
                    Date = Date[i]
                };
                cd.Add(course);
            }

            db.CourseData.AddRange(cd);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Test()
        {
            return View();
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
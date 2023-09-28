using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Grid.Models;

namespace Grid.Controllers
{
    public class CourseController : Controller
    {
        Context db = new Context();
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult CourseGrid(int? num)
        {
            ViewBag.num = num;
            return PartialView();
        }
        public ActionResult SaveCourse(CourseStudents cs)
        {
            db.CourseStudents.Add(cs);
            db.SaveChanges();

            
            int CsId = cs.Id;
            string[] Course = Request["Course"].Split(',').ToArray();
            string[] Branch = Request["Branch"].Split(',').ToArray();
            DateTime[] Date = Request["Date"].Split(',').Select(x => Convert.ToDateTime(x)).ToArray();

            List<CourseData> cd = new List<CourseData>();
            for (int i = 0; i < Course.Length; i++)
            {
                CourseData course = new CourseData
                {
                    CSId = cs.Id,
                    Course = Course[i],
                    Branch = Branch[i],
                    Date = Date[i]
                };
                cd.Add(course);
            }
            db.CourseData.AddRange(cd);
            db.SaveChanges();
            return RedirectToAction("Index" , "Course");
        }
       
        public ActionResult EditCourse()
        {
            return View();
        }

        public PartialViewResult StudentBody(int? id)
        {
            ViewBag.id = id;
            return PartialView();
        }
        public ActionResult Edit(CourseStudents cs)
        {
            db.Entry(cs).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EditCourse", "Course");
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


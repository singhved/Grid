using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Grid.Models;
using System.Data.Entity;

namespace Grid.Controllers
{
    public class DeptController : Controller
    {
        Context db = new Context();
        // GET: Dept
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Grid(int? no)
        {
            ViewBag.no = no;
            return PartialView();
        }
        public ActionResult Save(Dept dp)
        {
            db.Dept.Add(dp);
            db.SaveChanges();

            int Did = dp.Id;
            string[] faculty = Request["FName"].Split(',').ToArray();

            List<Faculty> fc = new List<Faculty>();
            for (int i = 0; i < faculty.Length; i++)
            {
                Faculty fac = new Faculty
                {
                    DId = Did,
                    Name = faculty[i]
                };
                fc.Add(fac);
            }
            db.Faculty.AddRange(fc);
            db.SaveChanges();
            return RedirectToAction("List", "Dept");
        }
        public ActionResult list()
        {
            return View();
        }
        public ActionResult Delete(int Id)
        {
            string res = Procs.DeptDel(Id);
            if (res == "-1")
            {
                TempData["Msg"] = "Data not deleted.";
            }
            return RedirectToAction("list", "Dept");
        }
        public ActionResult Read(int Id)
        {

            ViewBag.id = Id;
            return View();
        }
        public ActionResult Read2(int Id)
        {

            ViewBag.id = Id;
            return View();
        }

        public ActionResult Edit(int Id)
        {
            ViewBag.id = Id;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Dept d)
        {
            db.Entry(d).State = EntityState.Modified;
            db.SaveChanges();

            int Did = d.Id;
            int[] Fid = Request["FId"].Split(',').Select(x => Convert.ToInt32(x)).ToArray();
            string[] faculty = Request["FName"].Split(',').ToArray();

            Faculty fc = new Faculty();

            for (int i = 0; i < faculty.Length; i++)
            {
                if (Fid[i] == 0)
                {
                    Faculty fac = new Faculty();
                    fac.DId = Did;
                    fac.Name = faculty[i];
                    db.Faculty.Add(fac);
                    db.SaveChanges();
                }
                else
                {
                    Faculty fac = new Faculty();
                    fac.Id = Fid[i];
                    fac.DId = Did;
                    fac.Name = faculty[i];
                    db.Entry(fac).State = EntityState.Modified;
                    db.SaveChanges();
                }
                
            }

            db.Entry(d).State = EntityState.Modified;
            return RedirectToAction("list", "Dept");
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
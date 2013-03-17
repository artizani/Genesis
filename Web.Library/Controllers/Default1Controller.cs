using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SqlServer;

namespace Web.Library.Controllers
{ 
    public class Default1Controller : Controller
    {
        private DevOnlyEntities db = new DevOnlyEntities();

        //
        // GET: /Default1/

        public ViewResult Index()
        {
            return View(db.Members.ToList());
        }

        //
        // GET: /Default1/Details/5

        public ViewResult Details(string id)
        {
            Member member = db.Members.Find(id);
            return View(member);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            return View();
        } 
        //
        // POST: /Default1/Create

        [HttpPost]
        public ActionResult Create(Member member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(member);
        }
        
        //
        // GET: /Default1/Edit/5
 
        public ActionResult Edit(string id)
        {
            Member member = db.Members.Find(id);
            return View(member);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        //
        // GET: /Default1/Delete/5
 
        public ActionResult Delete(string id)
        {
            Member member = db.Members.Find(id);
            return View(member);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {            
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
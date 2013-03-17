using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using SqlServer;

namespace Web.Library.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /Test/

        private TestService db;

        public UserController()
        {
         db = new TestService();
        }
       [Authorize(Roles= "managers")]
        public ActionResult Index()
        {

            return View(db.Repository.Members.OrderBy(r=> r.Role));
        }

        public ActionResult Create()
        {

            return View(new Member());
        }

        [HttpPost]
        public ActionResult Create(Member member)
        {
            var _member = member;
            if (_member == null) throw new ArgumentNullException("member");
            _member.Id = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                db.Repository.Members.Add(_member);
                db.Repository.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        public ActionResult Delete(Guid id)
        {
            var member = db.Repository.Members.Find(id);
            if (ModelState.IsValid)
            {
                db.Repository.Members.Remove(member);
                db.Repository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        public ActionResult Details(Guid id)
        {
            var member = db.Repository.Members.Find(id);
          
            return View(member);
        }

     

        public ActionResult Edit(Guid id)
        {
            if (id == null) throw new ArgumentNullException("id");
            
            if (db.Repository.Members != null)
            {

                var member = db.Repository.Members.FirstOrDefault(r=> r.Id == id);
                return View(member);
            }

            return RedirectToAction("Index");
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection formCollection)
        {
        
            if (id == null) throw new ArgumentNullException("id");
            var member = db.Repository.Members.Find(id);

           if(TryUpdateModel(member))
            if (ModelState.IsValid)
            {
                db.Repository.Entry(member).State = EntityState.Modified;
                db.Repository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }


        public ActionResult Welcome(string name, int numTimes = 10)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;

            return View();
        }
    }
}

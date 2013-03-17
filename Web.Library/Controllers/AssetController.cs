using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SqlServer;

namespace Web.Library.Controllers
{
    public class AssetController : Controller
    {
        //
        // GET: /Asset/
       private readonly TestService _dataService = new TestService();

  

        public ActionResult Index()
        {
            return View(_dataService.Repository.Assets.OrderBy(r => r.Id).AsEnumerable());
        }

        public ActionResult Create()
        {

            return View(new Asset());
        }

        [HttpPost]
        public ActionResult Create(Asset asset)
        {
            var _asset = asset;
            if (_asset == null) throw new ArgumentNullException("asset");
            
            if (ModelState.IsValid)
            {
                try
                {
                    _asset.AssetId = Convert.ToString(Guid.NewGuid());
                _dataService.Repository.Assets.Add(_asset);
                _dataService.Repository.SaveChanges();

                }
        catch (DbEntityValidationException dbEx)
        {
            foreach (var validationErrors in dbEx.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                   Console.WriteLine("property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    Console.ReadLine();
                }
            }
        }
                return RedirectToAction("Index");
            }

            return View(asset);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null) throw new ArgumentNullException("id");

            if (_dataService.Repository.Members != null)
            {

                var asset = _dataService.Repository.Assets.FirstOrDefault(r => r.Id == id);
                return View(asset);
            }

            return RedirectToAction("Index");
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(Asset asset)
        {

            if (asset == null) throw new ArgumentNullException("asset");
       

            if (TryUpdateModel(asset))
                if (ModelState.IsValid)
                {
                    _dataService.Repository.Entry(asset).State = EntityState.Modified;
                    _dataService.Repository.SaveChanges();
                    return RedirectToAction("Index");
                }
            return View(asset);
        }


        public ActionResult Details(int? id)
        {
            var asset = _dataService.Repository.Assets.FirstOrDefault(r => r.Id == id);
            return View(asset);
        }


    }
}

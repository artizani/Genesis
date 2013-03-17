using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using System.Web.Mvc;
using SqlServer;
using Web.Library.BusinessLayer.Loan;
using Web.Library.Business_Object;
using Web.Library.Models;

namespace Web.Library.Controllers
{
    public class LoanController : Controller
    {
        //
        // GET: /Loan/
        private readonly TestService _dataService = new TestService();

  
        public ActionResult Index()
        {
           
            return View(_dataService.Repository.Loans.OrderBy(r => r.ReturnDate).Where(x=>x.ReturnIds=="24"));
        }

        //
        // GET: /Loan/Details/5

        public ActionResult Details(string id)
        {
            if (id == null) throw new ArgumentNullException("id");

            var firstOrDefault = _dataService.Repository.Loans.FirstOrDefault(r => r.LoanId == id);
            if (firstOrDefault != null)
            {
               var loanedListId = firstOrDefault.LoanedId;
              
                var orDefault = _dataService.Repository.Loaneds.FirstOrDefault(r => r.LoanedId == loanedListId);
                if (orDefault != null)
                {
                    var loanedList = orDefault.AssetIdList;
                    var detail = new LoanDetail(loanedList.Split(','));
                    return View(detail.Book);
                }
            }
            return RedirectToAction("Index");
        }

  
        
        //
        // GET: /Loan/Edit/5
 
        public ActionResult Edit(string id)
        {
            if (id == null) throw new ArgumentNullException("id");


            var firstOrDefault = _dataService.Repository.Loans.FirstOrDefault(r => r.LoanId == id);
            if (firstOrDefault != null)
            {
                var loanedListId = firstOrDefault.LoanedId;
                var orDefault = _dataService.Repository.Loaneds.FirstOrDefault(r => r.LoanedId == loanedListId);
                if (orDefault != null)
                {
                    var loanedList = orDefault.AssetIdList;
                    var detail = new LoanDetail(loanedList.Split(',')).Book;
                  
                    return View(detail);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(string[] selected, string id)
        {
         
            try
            {
                var x = selected;


                if (TryUpdateModel(x))
                    if (ModelState.IsValid)
                    {
                        var modifyLoan = new Returns(_dataService);
                        modifyLoan.PartClose(id,x.AsEnumerable());
                        return RedirectToAction("Index");
                    }
            }
        

    catch(Exception error)
                {
                throw new Exception(error.InnerException.Message);
                }
            
            return View();
        }

      


    }

    //public class LoanDetail
    //{
    //    private readonly TestService _dataService = new TestService();

    //    public LoanDetail(string [] list)
    //    {
    //        AssetList(list);
    //    }
    //    public IList<Asset> Book;
    //    public IEnumerable<Asset> AssetList(string[] detail)
    //    {
    //        Book = new List<Asset>();
    //        foreach (var id in detail)
    //        {
    //            int? y = Int32.Parse(id);
    //            if (_dataService.Repository != null)
    //                Book.Add(_dataService.Repository.Assets.Where(r => r.Id == y).FirstOrDefault());
    //        }
           
    //        return Book;
    //    }
    //}
}

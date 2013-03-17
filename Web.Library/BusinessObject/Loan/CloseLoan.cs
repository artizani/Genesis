using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SqlServer;

namespace Web.Library.Business_Object
{
    public class CloseLoan
    {
         public Loan Loan { get; set; }
         public Loaned Loaned { get; set; }
         private readonly TestService _dataService;

           public CloseLoan(Loan loan, Loaned loaned)
        {

            Loan = loan;
            Loaned = loaned;
            _dataService = new TestService();
        }

        private void UpdateAsset(IEnumerable<string> assetIds)
        {
            foreach (var i in assetIds)
            {
               _dataService.Repository.Assets.Find(i).Available = true;
                 _dataService.Repository.SaveChanges();
            }
        }

        private void Close(Guid id)
        {
            _dataService.Repository.Loans.Find(id).ReturnIds = "25";
            _dataService.Repository.SaveChanges();
        }

        private void PendingClosure(Guid id, IEnumerable<string> assetIds)
        {
           var loan = _dataService.Repository.Loans.Find(id);
           var loaned = _dataService.Repository.Loaneds.Find(loan.LoanedId);
            var loanedid = new Guid();
            var enumerable = loaned.AssetIdList.Split(',').AsEnumerable().Except<string>(assetIds).GetEnumerator();

   
            var loans = new Loan()
                            {
                                LinkedLoanId = loan.LoanId,
                                LoanId = new Guid().ToString(),
                                ReturnIds = "26",
                                LoanedId = loanedid
                                
                            };
            var loaneds = new Loaned()
                              {
                                  LoanedId = loanedid,
                                //  AssetIdList = enumerable 
                              };

            var entry = new AddToLoan(_dataService, loan, loaned);
            _dataService.Repository.SaveChanges();
        }



        public void CloseAll(Guid id)
        {
            Close(id);
        }

        public void PartClose(Guid id, IEnumerable<string> assetIds)
        {
            UpdateAsset(assetIds);
            PendingClosure(id, assetIds);
        }
    }
}
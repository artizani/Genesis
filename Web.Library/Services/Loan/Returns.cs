using System;
using System.Collections.Generic;
using System.Linq;
using SqlServer;
using Web.Library.Business_Object;

namespace Web.Library.BusinessLayer.Loan
{
    public class Returns
    {
         //public Loan Loan { get; set; }
         //public Loaned Loaned { get; set; }
         private readonly TestService _dataService;

         public Returns(TestService dataService)
        {

            //Loan = loan;
            //Loaned = loaned;
            _dataService = dataService;
        }

        private void UpdateLoanedAsset(IEnumerable<string> assetIds)
        {
            foreach (var i in assetIds)
            {
                int id = Convert.ToInt32(i);
               _dataService.Repository.Assets.Find(id).Available = true;
                 
            }
            _dataService.Repository.SaveChanges();
            
        }

        private void Close(Guid id)
        {
            var loan = _dataService.Repository.Loans.FirstOrDefault(r => r.LoanId == id.ToString());
            if (loan != null) loan.ReturnIds = "25";
            _dataService.Repository.SaveChanges();
        }

        private void PendingClosure(string id, IEnumerable<string> assetIds)
        {
           var oldloan = _dataService.Repository.Loans.FirstOrDefault(r => r.LoanId == id);    
           var oldloaned = _dataService.Repository.Loaneds.First(r => r.LoanedId == oldloan.LoanedId);
            oldloan.ReturnDate = DateTime.Now;
            var diff = oldloaned.AssetIdList.Split(',').AsEnumerable().Except(assetIds).ToArray();
            var csv = String.Join(",", diff);


            if (oldloan != null)
            {
                var loan = new SqlServer.Loan()
                               {
                                   LinkedLoanId = oldloan.LoanId,
                                   LoanId = Guid.NewGuid().ToString(),
                                   ReturnIds = "26",
                                   LoanedId = Guid.NewGuid(),
                                   From = DateTime.Now,
                                   Notes = "Part Return",
                                   MemberId = new Guid("5ED428BD-4DA3-4B02-8145-FD52C36CF6F2"),
                                   To = DateTime.Now.AddDays(7),
                                   ReturnDate = DateTime.Now

                               };

                var loaned = new Loaned()
                                 {
                                     LoanedId = Guid.NewGuid(),
                                     AssetIdList = csv
                                 };
               

                new AddToLoan(_dataService, loan, loaned).Update();
                 
            }
            // _dataService.Repository.SaveChanges();
        }



        public void CloseAll(Guid id)
        {
            Close(id);
        }

        public void PartClose(string id, IEnumerable<string> assetIds)
        {
            if (assetIds != null)
            {
                UpdateLoanedAsset(assetIds);
                PendingClosure(id, assetIds);
            }
        }
    }
}
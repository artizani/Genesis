using System;
using System.Data.Entity.Validation;
using SqlServer;

namespace Web.Library.BusinessLayer.Loan
{
    public class AddToLoan
    {
        public SqlServer.Loan Loan { get; set; }
        public Loaned Loaned { get; set; }
        private readonly TestService _dataService;

        public AddToLoan(TestService db, SqlServer.Loan loan, Loaned loaned)
        {

            Loan = loan;
            Loaned = loaned;
            _dataService = db;
        }

        public void Update()
        {
            try
            {
                Loaned.Loan.Add(Loan);
                _dataService.Repository.Loaneds.Add(Loaned);
                _dataService.Repository.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine("property: {0} Error: {1}", validationError.PropertyName,
                                          validationError.ErrorMessage);
                        Console.ReadLine();
                    }
                }
            }

        }
    
       // public void 
    
    }
}
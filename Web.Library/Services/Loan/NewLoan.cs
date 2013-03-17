using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using SqlServer;

namespace Web.Library.Business_Object
{
    public class NewLoan
    {
        public Loan Loan { get; set; }
        public Loaned Loaned { get; set; }
        private readonly TestService _dataService;

        public NewLoan(Loan loan, Loaned loaned)
        {

            Loan = loan;
            Loaned = loaned;
            _dataService = new TestService();
        }

        public void Add()
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
    }
}
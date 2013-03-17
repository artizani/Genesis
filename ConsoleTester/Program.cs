using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using SqlServer;
using Newtonsoft.Json;


namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {

            var x = new TestService();

            var parameters = new SqlParameter[] { new SqlParameter("@p_FirstName", "cHRISTIAN bOOK")};
            var result = x.Repository.Database.SqlQuery<Asset>("Exec dbo.usp_SearchAsset @p_FirstName", parameters);
            var data= result.ToList<Asset>();
            var json = JsonConvert.SerializeObject(data);
            //   
            //    var asset = new Asset()
            //                    {
            //                        AssetId = Guid.NewGuid().ToString(),
            //                        Author = "author",
            //                        ISBN = "143134",
            //                        Name = "Ken Hagin bOOK",
            //                        Title = "DVD Title",
            //                        Type = "Video Tape",
            //                        Available = true
            //                    };
            //try
            // {

            //    x.Repository.Assets.Add(asset);
            //    x.Repository.SaveChanges();
            //}
            //catch (DbEntityValidationException dbEx)
            //{
            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //    {
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //        {
            //           Console.WriteLine("property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
            //            Console.ReadLine();
            //        }
            //    }
            //}


            //var member = new Member()
            //                     {

            //                         Email = "olusal118@hotmail.com",
            //                         Secret = "password",
            //                         Id = Guid.NewGuid(),
            //                         Role = "0",
            //                         FirstName = "Dev A",
            //                         LastName = "Dev B"



            //                     };
            //try
            //{

            //    x.Repository.Members.Add(member);
            //    x.Repository.SaveChanges();
            //}
            //catch (DbEntityValidationException dbEx)
            //{
            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //    {
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //        {
            //            Console.WriteLine("property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
            //            Console.ReadLine();
            //        }
            //    }
            //}



            //var loaneds = new SqlServer.Loaned
            //                     {
            //                         AssetIdList = "1,6,8,22,7,10",
            //                         LoanedId = Guid.NewGuid()
            //                     };

            //    var loans = new SqlServer.Loan()
            //                    {
            //                        From = DateTime.Now,
            //                        To = DateTime.Now,
            //                        MemberId = Guid.Parse("a63d0fc7-b99e-4e3c-97cf-53c4979911b1"),
            //                        ReturnDate = DateTime.Now,
            //                        LinkedLoanId = "",
            //                        LoanId = Guid.NewGuid().ToString(),
            //                        //LoanId = loaneds.LoanedId.ToString(),
            //                        Notes = "no comment",
            //                        ReturnIds = "24",
            //                        Loaned = loaneds
            //                    };

            //                    try
            //                    {
            //                        loaneds.Loan.Add(loans);
            //                        x.Repository.Loaneds.Add(loaneds);
            //                        x.Repository.SaveChanges();
            //                    }
            //                        catch (DbEntityValidationException dbEx)
            //{
            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //    {
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //        {
            //           Console.WriteLine("property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
            //            Console.ReadLine();
            //        }
            //    }
            //}


            //                };
            //loaned.Loans.Add(loans);
            //data.AddToLoaneds(loaned);
            //data.SaveChanges();
            // var data = new DevOnly();
            //var member = new Member()
            //                     {

            //                         Email = "olusal5@hotmail.com",
            //                         Secret = "password",           
            //                         Id = Guid.NewGuid(),
            //                         Role= "0"



            //                     };
            //data.AddToMembers(member);
            //data.SaveChanges();

            //var asset = new Asset()
            //                {
            //                    AssetId = Guid.NewGuid().ToString("B"),
            //                    Author = "author",
            //                    ISBN = "143134",
            //                    Name = "cHRISTIAN bOOK",
            //                    Title = "gOOD bOOK",
            //                    Type = "Video Tape"
            //                };

            //  data.AddToAssets(asset);
            //data.SaveChanges();
            //var loaned = new Loaned()
            //                 {
            //                     AssetIdList = "10,16,18,22,27,87",
            //                     LoanedId = Guid.NewGuid()
            //                 };
            //var loans = new Loan()
            //                {
            //                    From = DateTime.Now,
            //                    To = DateTime.Now,
            //                    Email = "olusal3@hotmail.com",
            //                    ReturnDate = DateTime.Now,
            //                    LinkedLoanId = "wqeq",
            //                    LoanId = loaned.LoanedId.ToString(),
            //                    Notes ="no comment",
            //                    ReturnIds = "24",
            //                    //Loaned = loaned


            //                };
            //loaned.Loans.Add(loans);
            //data.AddToLoaneds(loaned);
            //data.SaveChanges();

        }


        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SqlServer;

namespace Web.Library.Models
{
    public class LoanDetail
    {

        private readonly TestService _dataService = new TestService();
        public LoanDetail()
        {
        }

        public LoanDetail(string[] list)
        {
            AssetList(list);
        }
        public IList<Asset> Book;
        public String Name { get; set; }
        public IEnumerable<Asset> AssetList(string[] detail)
        {
            Book = new List<Asset>();
            foreach (var id in detail)
            {
                int? y = Int32.Parse(id);
                if (_dataService.Repository != null)
                    Book.Add(_dataService.Repository.Assets.FirstOrDefault(x => x.Id == y));
            }

            return Book;
        }
    }
}
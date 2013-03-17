using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Library.BusinessLayer.Search;

namespace Web.Library.BusinessLayer.Search
{
    public class Criteria
    {
        public AssetType AssetType { get; set; }
        public string Term { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public By By { get; set; }

    }
}
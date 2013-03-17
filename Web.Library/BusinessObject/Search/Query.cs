using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SqlServer;

namespace Web.Library.Business_Object.Search
{
    public class Assets
    {
        private readonly Criteria criteria;

        public Assets(Criteria searchCriteria)
        {
            criteria = searchCriteria;
        }

        public IEnumerable<Asset> ByType(AssetType name)
        {
            return null;
        }

        private IEnumerable<Asset> Query()
        {
            return null;
        }
    }

    public enum AssetType
    {
        Book,
        Cd,
        Dvd,
        AudioTape,
        Vhs,
        All,
        Other
    }

    public enum By
    {
        Name,
        Author,
        ISBN,
        Description
       
    }

}
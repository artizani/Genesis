using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using SqlServer;
using Web.Library.Business_Object.Search;

namespace Web.Library.BusinessLayer.Search
{
    public class Query
    {
        private readonly Criteria _criteria;
        private readonly TestService _dataService;

        public Query(Criteria searchCriteria, TestService db)
        {
            _criteria = searchCriteria;
            _dataService = db;
        }

        public IEnumerable<Asset> ByType(AssetType name)
        {
            return null;
        }

        private IEnumerable<Asset> Asset()
        {

            var parameters = new SqlParameter[] { new SqlParameter("@p_FirstName", _criteria.Term) };
            var result = _dataService.Repository.Database.SqlQuery<Asset>("Exec dbo.usp_SearchAsset @p_FirstName", parameters);
            var data = result.ToList<Asset>();
            var json = JsonConvert.SerializeObject(data);
            return null;
        }


        public IEnumerable<Asset> JsonAsset()
        {

            var parameters = new SqlParameter[] { new SqlParameter("@p_FirstName", _criteria.Term) };
            var result = _dataService.Repository.Database.SqlQuery<Asset>("Exec dbo.usp_SearchAsset @p_FirstName", parameters);
            return result.ToList<Asset>();
            
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
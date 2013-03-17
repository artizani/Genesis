using System.Collections.Generic;
using SqlServer;

namespace Web.Library.Services
{
    interface ILoanService
    {
        void Add(IUser adminUser, IDictionary<IUser,IEnumerable<Asset>> asset);
        void Remove(IUser adminUser, IDictionary<IUser, IEnumerable<Asset>> asset);
       
    }
}

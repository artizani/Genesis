//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SqlServer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Loaned
    {
        public Loaned()
        {
            this.Loan = new HashSet<Loan>();
        }
    
        public System.Guid LoanedId { get; set; }
        public string AssetIdList { get; set; }
        public Nullable<int> First { get; set; }
    
        public virtual ICollection<Loan> Loan { get; set; }
    }
}

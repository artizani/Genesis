using System;
using System.Data.Entity;
using System.Data.Objects;
using System.Data.Entity.Infrastructure;

namespace SqlServer
{
    partial interface IDevOnlyEntities : IDisposable
    {


        IDbSet<Asset> Assets { get; }

        IDbSet<Loan> Loans { get; }

        IDbSet<Loaned> Loaneds { get; }

        IDbSet<Member> Members { get; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaxAuditCommunity.Factory.Repository
{
    public interface INFeStore<TNFe, TResult> : IStoreBase<TNFe, TResult>
        where TNFe : class
        where TResult : class
    {
        Task<TNFe> GetNFeByIdAsync(string id, CancellationToken cancellationToken);

        Task<DateTime> GetLastFileSaveedAsync(CancellationToken cancellationToken);
    }
}

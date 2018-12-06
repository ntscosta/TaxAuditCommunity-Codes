using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace TaxAuditCommunity.Factory.Repository
{
    public interface IStoreBase<TModelo, TResult> : IDisposable
        where TModelo : class
        where TResult : class
    {
        Task<List<TModelo>> GetNotReturn(CancellationToken cancellationToken); 
        Task<TResult> ImportTag(TModelo tag, CancellationToken cancellationToken);
        Task<List<TModelo>> GetAll(CancellationToken cancellationToken);
        Task<TResult> DeleteAll(CancellationToken cancellation);
        Task SaveChangesAsync(CancellationToken cancellationToken);

    }
}

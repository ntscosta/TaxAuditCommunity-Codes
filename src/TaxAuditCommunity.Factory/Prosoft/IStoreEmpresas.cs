using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaxAuditCommunity.Domain.Prosoft;

namespace TaxAuditCommunity.Factory.Prosoft
{
    public interface IStoreEmpresas : IDisposable
    {
        List<Empresas> GetEmpresas(string conn);

        Task<ProsoftResult> Syncronization(string connProsoft, CancellationToken cancellation);
    }
}

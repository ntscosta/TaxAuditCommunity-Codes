using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaxAuditCommunity.Domain.procNFe;
using TaxAuditCommunity.Factory.Repository;

namespace TaxAuditCommunity.Factory.Store
{
    public class NFeStore<TNFe, TContext> : INFeStore<TNFe, NFeResult>
        where TNFe : NFe
        where TContext : DbContext
    {
        private readonly TContext Context;

        public NFeStore(TContext context)
        {
            Context = context;
        }

        protected internal DbSet<TNFe> NFeSet { get { return Context.Set<TNFe>(); } }

        public async Task<NFeResult> ImportTag(TNFe nfe, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (nfe == null)
            {
                throw new ArgumentNullException(nameof(nfe));
            }
            try
            {
                await NFeSet.AddAsync(nfe);
                await SaveChangesAsync(cancellationToken);
                return NFeResult.Success;
            }
            catch (DbUpdateConcurrencyException e)
            {
                return NFeResult.Failed(e);
            }
            catch (DbUpdateException e)
            {
                return NFeResult.Failed(e);
            }
            catch (Exception e)
            {
                return NFeResult.Failed(e);
            }
        }

        public Task<TNFe> GetNFeByIdAsync(string Id, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            var oldQueryBehavior = Context.ChangeTracker.QueryTrackingBehavior;
            try
            {
                Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                return NFeSet.SingleOrDefaultAsync(n => n.Id == Id);
            }
            finally
            {
                Context.ChangeTracker.QueryTrackingBehavior = oldQueryBehavior;
            }
        }

        public async Task<DateTime> GetLastFileSaveedAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if ((await NFeSet.ToListAsync()).Count > 0)
                return await NFeSet.MaxAsync(n => n.XmlNFe.DhChange);
            else return new DateTime();
        }

        public async Task<List<TNFe>> GetAll(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            return await NFeSet.ToListAsync(cancellationToken);
        }

        public async Task<NFeResult> DeleteAll(CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                ThrowIfDisposed();
                NFeSet.Load();
                NFeSet.RemoveRange(NFeSet.Local);
                
                await SaveChangesAsync(cancellationToken);
                return NFeResult.Success;
            }
            catch (DbUpdateConcurrencyException e)
            {
                return NFeResult.Failed(e);
            }
            catch (DbUpdateException e)
            {
                return NFeResult.Failed(e);
            }
            catch (Exception e)
            {
                return NFeResult.Failed(e);
            }
        }

        /// <summary>
        /// Retorna todas as notas sem consulta da situação da NFe
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<TNFe>> GetNotReturn(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            return (await NFeSet.ToListAsync(cancellationToken)).FindAll(n => n.XmlNFe.retConsSitNFe == null & n.XmlNFe.DhChange.AddHours(24) < DateTime.Now);
        }

        public Task SaveChanges()
        {
            return AutoSaveChanges ? Context.SaveChangesAsync() : Task.CompletedTask;
        }
        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return AutoSaveChanges ? Context.SaveChangesAsync(cancellationToken) : Task.CompletedTask;
        }

        public bool AutoSaveChanges { get; set; } = true;

        private bool _disposed;
        public void Dispose()
        {
            _disposed = true;
        }
        protected void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }
    }
}

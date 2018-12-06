using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaxAuditCommunity.Data;
using TaxAuditCommunity.Domain.Prosoft;

namespace TaxAuditCommunity.Factory.Prosoft
{
    public class StoreEmpresas : StoreEmpresas<Empresas, NFeDbContext>
    {
        public StoreEmpresas()
        { }
        public StoreEmpresas(NFeDbContext context) : base(context)
        {
        }
    }
    public class StoreEmpresas<TEmpresas, TContext> : IStoreEmpresas
        where TEmpresas : Empresas
        where TContext : DbContext
    {
        public StoreEmpresas()
        { }
        public StoreEmpresas(TContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            Context = context;
        }
        private readonly TContext Context;
        public List<Empresas> GetEmpresas(string conn)
        {

            PervasiveClient pervasiveClient = new PervasiveClient(conn);
            pervasiveClient.LoadCadastro();
            return pervasiveClient.Empresas;
        }

        protected internal DbSet<TEmpresas> EmpresasSet { get { return Context.Set<TEmpresas>(); } }

        public async Task<ProsoftResult> Syncronization(string connProsoft, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            try
            {
                PervasiveClient pervasiveClient = new PervasiveClient(connProsoft);
                pervasiveClient.LoadCadastro();
                var empresas = pervasiveClient.Empresas;

                List<TEmpresas> empresasBanco = await EmpresasSet.ToListAsync();

                foreach (var emp in empresas)
                {
                    //Verfica se existe empresa com o codigo pesquisado
                    var empresaFound = await EmpresasSet.SingleOrDefaultAsync(e => e.Codigo == emp.Codigo);
                    if (empresaFound != null)
                    {
                        //Se existir o codigo pesquisado verifica se todos os campos são iguais. No caso de existir algum campo
                        //diferente é feita a atualização do obejto no banco
                        if (!empresaFound.Equals(emp))
                        {
                            empresaFound = (TEmpresas)emp;
                            Context.Update(empresaFound);
                            await SaveChangesAsync(cancellationToken);
                        }
                    }
                    else //Se não for encontrado no banco nenhum objeto que atenda ao criterio de pesquisa seré adicionado no banco
                    {
                        EmpresasSet.Add((TEmpresas)emp);
                        await SaveChangesAsync(cancellationToken);
                    }
                }

                foreach (var empb in empresasBanco)
                {
                    if (!empresas.Exists(e => e.Codigo == empb.Codigo))
                    {
                        empresasBanco.Remove(empb);
                        await SaveChangesAsync(cancellationToken);
                    }
                }

                return ProsoftResult.Success;
            }
            catch (DbUpdateException ex)
            {
                return ProsoftResult.Failed();
            }
            catch (Exception ex)
            {
                return ProsoftResult.Failed();
            }
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

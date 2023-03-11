using Domain.Interfaces.Generics;
using Infra.Configuracao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Infra.Repositorio.Generics
{
    public class RepositoryGenerics<T> : IDisposable, InterfaceGeneric<T> where T : class
    {
        private readonly DbContextOptions<ContextBase> _options;
        public RepositoryGenerics()
        {
            _options = new DbContextOptions<ContextBase>();
        }
        public async Task Add(T objeto)
        {
            using (var data = new ContextBase(_options))
            {
                await data.Set<T>().AddAsync(objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T objeto)
        {
            using (var data = new ContextBase(_options))
            {
                data.Set<T>().Remove(objeto);
                await data.SaveChangesAsync();
            }
        }

      

        public async Task<T> GetEntityById(int id)
        {
            using (var data = new ContextBase(_options))
            {
                return await data.Set<T>().FindAsync(id);
            }
        }

        public async Task<List<T>> List()
        {
            using (var data = new ContextBase(_options))
            {
                return await data.Set<T>().ToListAsync();
            }
        }

        public async Task Update(T objeto)
        {
           using(var data = new ContextBase(_options))
            {
                data.Set<T>().Update(objeto);
                await data.SaveChangesAsync();
            }
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    GC.SuppressFinalize(_options);
                    GC.SuppressFinalize(this);

                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

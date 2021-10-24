using ProjetoModeloDDD.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Dados.Repositorios
{
    public class RepositorioBase<T> : IDisposable, IRepositorioBase<T> where T : class
    {
        protected Contexto.Contexto contexto = new Contexto.Contexto();

        public void Adicionar(T entidade)
        {
            contexto.Set<T>().Add(entidade);
            contexto.SaveChanges();
        }

        public void Atualizar(T entidade)
        {
            contexto.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Excluir(T entidade)
        {
            contexto.Set<T>().Remove(entidade);
            contexto.SaveChanges();
        }

        public T ObterPorId(int id)
        {
            return contexto.Set<T>().Find(id);
        }

        public IEnumerable<T> ObterTodos()
        {
            return contexto.Set<T>().ToList();
        }
    }
}

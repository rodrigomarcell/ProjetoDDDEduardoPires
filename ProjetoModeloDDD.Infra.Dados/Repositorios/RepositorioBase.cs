using ProjetoModeloDDD.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ProjetoModeloDDD.Infra.Dados.Repositorios
{
    public class RepositorioBase<T> : IDisposable, IRepositorioBase<T> where T : class
    {
        protected Contexto.Contexto _contexto = new Contexto.Contexto();

        public void Adicionar(T entidade)
        {
            _contexto.Set<T>().Add(entidade);
            _contexto.SaveChanges();
        }

        public void Atualizar(T entidade)
        {
            _contexto.Entry(entidade).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

        public void Excluir(T entidade)
        {
            _contexto.Set<T>().Remove(entidade);
            _contexto.SaveChanges();
        }

        public T ObterPorId(int id)
        {
            return _contexto.Set<T>().Find(id);
        }

        public IEnumerable<T> ObterTodos()
        {
            return _contexto.Set<T>().ToList();
        }
    }
}

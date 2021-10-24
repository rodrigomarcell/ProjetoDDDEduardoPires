using ProjetoModeloDDD.Dominio.Interfaces.Repositorios;
using ProjetoModeloDDD.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Dominio.Servicos
{
    public class ServicoBase<T> : IDisposable, IServicoBase<T> where T : class
    {

        private readonly IRepositorioBase<T> _repositorio;

        public ServicoBase(IRepositorioBase<T> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Adicionar(T entidade)
        {
            _repositorio.Adicionar(entidade);
        }

        public void Atualizar(T entidade)
        {
            _repositorio.Atualizar(entidade);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
                
        }

        public void Excluir(T entidade)
        {
            _repositorio.Excluir(entidade);
        }

        public T ObterPorId(int id)
        {
            return _repositorio.ObterPorId(id);
        }

        public IEnumerable<T> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }
    }
}

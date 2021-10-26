using ProjetoModeloDDD.Dominio.Entidades;
using ProjetoModeloDDD.Dominio.Interfaces.Repositorios;
using ProjetoModeloDDD.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Dominio.Servicos
{
    public class ServicoProduto : ServicoBase<Produto>, IServicoProduto
    {
        private readonly IRepositorioProduto _produtoRepositorio;
        public ServicoProduto(IRepositorioProduto produtoRepositorio) : base(produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _produtoRepositorio.BuscarPorNome(nome);
        }
    }
}

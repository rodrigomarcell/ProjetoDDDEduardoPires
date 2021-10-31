using ProjetoModeloDDD.Dominio.Entidades;
using ProjetoModeloDDD.Dominio.Interfaces.Repositorios;
using ProjetoModeloDDD.Infra.Dados.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Dados.Repositorios
{
    public class ProdutoRepositorio : RepositorioBase<Produto>, IRepositorioProduto
    {

        protected readonly new Contexto.Contexto _contexto;

        //public IEnumerable<Produto> BuscarPorNome(string nome)
        //{
        //    return _contexto.Produtos.Where(p => p.Nome == nome);
        //}


        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _contexto.Produto.Where(p => p.Nome == nome);
        }
    }
}

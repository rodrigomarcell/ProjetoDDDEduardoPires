using ProjetoModeloDDD.Dominio.Entidades;
using ProjetoModeloDDD.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Dados.Repositorios
{
    public class ProdutoRepositorio : RepositorioBase<Produto>, IRepositorioProduto
    {
        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return contexto.Produtos.Where(p => p.Nome == nome);
        }
    }
}

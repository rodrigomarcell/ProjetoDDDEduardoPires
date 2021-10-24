using ProjetoModeloDDD.Dominio.Entidades;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioProduto : IRepositorioBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}

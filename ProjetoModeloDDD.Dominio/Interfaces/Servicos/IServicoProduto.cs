using ProjetoModeloDDD.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Dominio.Interfaces.Servicos
{
    public interface IServicoProduto : IServicoBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}

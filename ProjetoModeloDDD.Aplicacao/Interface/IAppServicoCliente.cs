using ProjetoModeloDDD.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Aplicacao.Interface
{
    public interface IAppServicoCliente : IAppServicoBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientesEspeciais();
    }
}

using ProjetoModeloDDD.Aplicacao.Interface;
using ProjetoModeloDDD.Dominio.Entidades;
using ProjetoModeloDDD.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Aplicacao
{
    public class AppServicoCliente : AppServicoBase<Cliente>, IAppServicoCliente
    {
        private readonly IServicoCliente _servicoCliente;

        public AppServicoCliente(IServicoCliente servicoCliente) : base (servicoCliente)
        {
            _servicoCliente = servicoCliente;
        }

        public IEnumerable<Cliente> ObterClientesEspeciais()
        {
            return _servicoCliente.ObterClientesEspeciais(_servicoCliente.ObterTodos());
        }
    }
}

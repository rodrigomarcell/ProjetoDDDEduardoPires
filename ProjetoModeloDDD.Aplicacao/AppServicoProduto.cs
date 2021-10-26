using ProjetoModeloDDD.Aplicacao.Interface;
using ProjetoModeloDDD.Dominio.Entidades;
using ProjetoModeloDDD.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Aplicacao
{
    public class AppServicoProduto : AppServicoBase<Produto>, IAppServicoProduto
    {

        private readonly IServicoProduto _servicoProduto;

        public AppServicoProduto(IServicoProduto servicoProduto) : base(servicoProduto)
        {
            _servicoProduto = servicoProduto;
        }

        public IEnumerable<Produto> BuscaPorNome(string nome)
        {
            return _servicoProduto.BuscarPorNome(nome);
        }

       
    }
}

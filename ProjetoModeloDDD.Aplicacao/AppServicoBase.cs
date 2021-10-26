using ProjetoModeloDDD.Aplicacao.Interface;
using ProjetoModeloDDD.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Aplicacao
{
    public class AppServicoBase<T> : IDisposable, IAppServicoBase<T> where T : class
    {
        private readonly IServicoBase<T> _servicoBase;

        public AppServicoBase(IServicoBase<T> servicoBase)
        {
            _servicoBase = servicoBase;
        }

        public void Adicionar(T entidade)
        {
            _servicoBase.Adicionar(entidade);
        }

        public void Atualizar(T entidade)
        {
            _servicoBase.Atualizar(entidade);
        }

        public void Dispose()
        {
            _servicoBase.Dispose();
        }

        public void Excluir(T entidade)
        {
            _servicoBase.Excluir(entidade);
        }

        public T ObterPorId(int id)
        {
            return _servicoBase.ObterPorId(id);
        }

        public IEnumerable<T> ObterTodos()
        {
            return _servicoBase.ObterTodos();
        }
    }
}

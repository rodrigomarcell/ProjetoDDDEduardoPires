using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Aplicacao.Interface
{
    public interface IAppServicoBase<T> where T : class
    {
        void Adicionar(T entidade);

        T ObterPorId(int id);

        IEnumerable<T> ObterTodos();

        void Atualizar(T entidade);

        void Excluir(T entidade);

        void Dispose();
    }
}

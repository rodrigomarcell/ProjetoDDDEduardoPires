using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<T> where T : class
    {
        void Adicionar(T entidade);

        T ObterPorId(int id);

        IEnumerable<T> ObterTodos();

        void Atualizar(T entidade);

        void Excluir(T entidade);

        void Dispose();
    }
}

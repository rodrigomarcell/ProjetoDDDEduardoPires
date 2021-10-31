namespace ProjetoModeloDDD.Dominio.Entidades
{
    public class Produto
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public bool Disponivel { get; set; }

        public int ClienteID { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}

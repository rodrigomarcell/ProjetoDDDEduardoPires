//using ProjetoModeloDDD.Dominio.Entidades;
//using System.Data.Entity.ModelConfiguration;

//namespace ProjetoModeloDDD.Infra.Dados.ConfiguracaoEntity
//{
//    public class ClienteConfiguracao : EntityTypeConfiguration<Cliente>
//    {
//        public ClienteConfiguracao()
//        {
//            HasKey(c => c.ID);

//            Property(c => c.Nome)
//                .IsRequired()
//                .HasMaxLength(150);

//            Property(c => c.SobreNome)
//                .IsRequired()
//                .HasMaxLength(150);


//            Property(c => c.Email)
//                .IsRequired();
//        }

//    }
//}

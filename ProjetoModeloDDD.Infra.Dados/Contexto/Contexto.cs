using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ProjetoModeloDDD.Dominio.Entidades;
using System.Linq;
using System;

namespace ProjetoModeloDDD.Infra.Dados.Contexto
{
    public class Contexto : DbContext
    {
        public Contexto() : base("DBDDDEduardoPires")
        {

        }


        public DbSet<Cliente> Clientes { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {        
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));
        }

        public override int SaveChanges()
        {

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }

            }
                        
            return base.SaveChanges();
        }

    }
}

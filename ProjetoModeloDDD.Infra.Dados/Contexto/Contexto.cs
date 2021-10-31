using Microsoft.EntityFrameworkCore;
using ProjetoModeloDDD.Dominio.Entidades;
using System.Linq;
using System;
//using ProjetoModeloDDD.Infra.Dados.ConfiguracaoEntity;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ProjetoModeloDDD.Infra.Dados.Contexto
{
    public class Contexto : DbContext
    {

        public Contexto()
        {
            Database.Migrate();            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=HOMEPC\SQLEXPRESS;Initial Catalog=DDD;Integrated Security=False;Connect Timeout=15;Encrypt=False;Integrated Security=True");
        }      

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Produto> Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var cascadeFKs = modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()).Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }


            modelBuilder.Entity<Cliente>(etd =>
            {
                etd.ToTable("Cliente");
                etd.HasKey(c => c.ID);
                etd.Property(c => c.Nome).IsRequired().HasMaxLength(151);
                etd.Property(c => c.SobreNome).IsRequired().HasMaxLength(151);
                etd.Property(c => c.Email).IsRequired();
            });

            modelBuilder.Entity<Produto>(etd =>
            {
                etd.ToTable("Produto");
                etd.HasKey(p => p.ID);
                etd.Property(p => p.Nome).IsRequired().HasMaxLength(2510);
                etd.Property(p => p.Valor).IsRequired();
                
            });

            modelBuilder.Entity<Produto>().Navigation(c => c.Cliente).AutoInclude(true);

        }        

        public override int SaveChanges()
        {

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }

                if (entry.State == EntityState.Added)
                {                    
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;                    
                }

            }

            return base.SaveChanges();
        }

    }

   
}

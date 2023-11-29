using frossi.Models;
using Microsoft.EntityFrameworkCore;
using static frossi.Data.Seeding;

namespace frossi.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        // Agregar los modelos aqui. 
        public DbSet<Users> Users { get; set; }
        public DbSet<TiposExamenes> TiposExamenes { get; set; }
        public DbSet<TiposDoc> TiposDoc { get; set; }
        public DbSet<Solicitantes> Solicitantes { get; set; }
        public DbSet<ExaPreguntas> ExaPreguntas { get; set; }
        public DbSet<ExaOpciones> ExaOpciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Solicitantes>()
            .HasIndex(e => new { e.IdTipoDoc, e.NroDoc })
            .HasName("IX_TipoNroDoc");

            //modelBuilder.Entity<Solicitantes>()
            //.HasIndex(e => e.Id)
            //.IsUnique(true);

            //modelBuilder.Entity<MiEntidad>()
            //    .HasIndex(e => e.Codigo)
            //    .IsUnique(true);



            base.OnModelCreating(modelBuilder);

            ModelSeeding.SeedAllModels(modelBuilder);

        }

        public DbSet<frossi.Models.ExaHechos> ExaHechos { get; set; }
    }

}


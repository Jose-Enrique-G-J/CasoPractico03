namespace AutomovilesWsSoap.Modelo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModeloAutomoviles : DbContext
    {
        public ModeloAutomoviles()
            : base("name=ModeloAutomoviles")
        {
        }

        public virtual DbSet<Automovile> Automoviles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Automovile>()
                .Property(e => e.Imagen)
                .IsUnicode(false);

            modelBuilder.Entity<Automovile>()
                .Property(e => e.Marca)
                .IsUnicode(false);

            modelBuilder.Entity<Automovile>()
                .Property(e => e.Modelo)
                .IsUnicode(false);

            modelBuilder.Entity<Automovile>()
                .Property(e => e.Precio)
                .HasPrecision(19, 4);
        }
    }
}

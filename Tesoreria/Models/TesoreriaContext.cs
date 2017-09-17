namespace Tesoreria.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TesoreriaContext : DbContext
    {
        public TesoreriaContext()
            : base("name=ConexionTesoreria")
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Recibos> Recibos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Recibos)
                .WithRequired(e => e.Clientes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Recibos>()
                .Property(e => e.Monto)
                .HasPrecision(19, 4);
        }
    }
}

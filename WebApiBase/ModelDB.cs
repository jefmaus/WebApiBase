namespace WebApiBase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelDB : DbContext
    {
        public ModelDB()
            : base("name=ModelDB")
        {
            //Configuration.LazyLoadingEnabled = true; // deshabilita modo perezoso
        }

        public virtual DbSet<perfil> perfil { get; set; }
        public virtual DbSet<persona> persona { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<perfil>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            /*modelBuilder.Entity<perfil>()
                .HasMany(e => e.persona)
                .WithRequired(e => e.perfil)
                .WillCascadeOnDelete(false);*/

            modelBuilder.Entity<persona>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<persona>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<persona>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<persona>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<persona>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<persona>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<persona>()
                .Property(e => e.clave)
                .IsUnicode(false);

            modelBuilder.Entity<persona>()
                .Property(e => e.estado)
                .IsUnicode(false);
        }
    }
}

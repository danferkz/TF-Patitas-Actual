using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PATITAS.Models;
using System.Reflection.Emit;

namespace PATITAS.Datos
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
         
        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Mascota> Mascota { get; set; }

        public DbSet<Descripcion> Descripcion { get; set; }

        public DbSet<Trabajador> Trabajador { get; set; }

        public DbSet<Cita> Cita { get; set; }   

        public DbSet<Diagnostico> Diagnostico { get; set; }

        public DbSet<Producto> Producto { get; set; }

        public DbSet<Venta> Venta { get; set; }

        public DbSet<AppTrabajador> AppTrabajador { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VentaProducto>().HasKey(vp => new { vp.Venta_Id, vp.Producto_Id });

            base.OnModelCreating(modelBuilder);
        }

    }
}


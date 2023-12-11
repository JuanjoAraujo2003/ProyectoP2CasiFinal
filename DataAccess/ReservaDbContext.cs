using ProyectoP2Final;
using ProyectoP2Final.Utilidades;
using Microsoft.EntityFrameworkCore;
using ProyectoP2Final.Models;

namespace ProyectoP2Final.DataAccess
{
    public class ReservaDbContext:DbContext
    {
        public DbSet<Reserva> Reservas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conexionDB = $"Filename={ConexionDB.DevolverRuta("reservas.db")}";
            optionsBuilder.UseSqlite(conexionDB);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(col => col.IdReserva);
                entity.Property(col => col.IdReserva).IsRequired().ValueGeneratedOnAdd();
            });
        }
    }
}

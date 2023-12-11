using System.ComponentModel.DataAnnotations;
namespace ProyectoP2Final.Models
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }
        public String Nombre { get; set; }
        [MaxLength(10)]
        public String Cedula { get; set; }
        public int NumeroHuespedes { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
    }
}

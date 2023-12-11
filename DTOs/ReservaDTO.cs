using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectoP2Final.DTOs
{
    public partial class ReservaDTO: ObservableObject
    {
        [ObservableProperty]
        public int idReserva;
        [ObservableProperty]
        public String nombre;
        [ObservableProperty]
        public String cedula;
        [ObservableProperty]
        public int numeroHuespedes;
        [ObservableProperty]
        public DateTime fechaEntrada;
        [ObservableProperty]
        public DateTime fechaSalida;
    }
}

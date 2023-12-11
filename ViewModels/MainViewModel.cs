using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using ProyectoP2Final.DataAccess;
using ProyectoP2Final.DTOs;
using ProyectoP2Final.Utilidades;
using ProyectoP2Final.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using ProyectoP2Final.Views;

namespace ProyectoP2Final.ViewModels
{
    public partial class MainViewModel:ObservableObject
    {
        private readonly ReservaDbContext _dbContext;
        [ObservableProperty]
        private ObservableCollection<ReservaDTO>listaReserva=new ObservableCollection<ReservaDTO>();

        public MainViewModel(ReservaDbContext context)
        {
            _dbContext = context;

            MainThread.BeginInvokeOnMainThread(new Action(async () => await Obtener()));
            WeakReferenceMessenger.Default.Register<ReservaMensajeria>(this, (r,m) =>
            {
                ReservaMensajeRecibido(m.Value);
            });
        }

        public async Task Obtener()
        {
            var lista= await _dbContext.Reservas.ToListAsync();
            if(lista.Any())
            {
                foreach(var item in lista)
                {
                    ListaReserva.Add(new ReservaDTO
                    {
                        IdReserva=item.IdReserva,
                        Nombre=item.Nombre,
                        Cedula=item.Cedula,
                        NumeroHuespedes=item.NumeroHuespedes,
                        FechaEntrada=item.FechaEntrada,
                        FechaSalida=item.FechaSalida,   
                    });
                }
            }
        }

        private void ReservaMensajeRecibido(ReservaMensaje reservaMensaje)
        {
            var reservaDto = reservaMensaje.ReservaDto;
            if (reservaMensaje.EsCrear)
            {
                ListaReserva.Add(reservaDto);
            }
            else
            {
                var encontrado = ListaReserva.First(e=>e.IdReserva == reservaDto.IdReserva);

                encontrado.Nombre = reservaDto.Nombre;
                encontrado.Cedula = reservaDto.Cedula;
                encontrado.NumeroHuespedes= reservaDto.NumeroHuespedes;
                encontrado.FechaEntrada= reservaDto.FechaEntrada;
                encontrado.FechaSalida= reservaDto.FechaSalida;

            }
        }

        [RelayCommand]
        private async Task Crear()
        {
            var uri = $"{nameof(ReservaPage)}?id=0";
            await Shell.Current.GoToAsync(uri);
        }

        [RelayCommand]
        private async Task Editar(ReservaDTO reservaDto)
        {
            var uri = $"{nameof(ReservaPage)}?id={reservaDto.IdReserva}";
            await Shell.Current.GoToAsync(uri);
        }
        [RelayCommand]
        private async Task Eliminar(ReservaDTO reservaDto)
        {
            bool respuesta = await Shell.Current.DisplayAlert("Mensaje", "Desea eliminar la Reserva?", "Si", "No");
            if (respuesta)
            {
                var encontrado = await _dbContext.Reservas.FirstAsync(e=>e.IdReserva== reservaDto.IdReserva);

                _dbContext.Reservas.Remove(encontrado);
                await _dbContext.SaveChangesAsync();
                ListaReserva.Remove(reservaDto);

            }
        }
    }
}

using CommunityToolkit.Mvvm.Messaging.Messages;

namespace ProyectoP2Final.Utilidades
{
    public class ReservaMensajeria:ValueChangedMessage<ReservaMensaje>
    {
        public ReservaMensajeria(ReservaMensaje value):base(value)
        {
            
        }
    }
}

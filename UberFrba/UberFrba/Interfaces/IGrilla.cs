using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Interface que contiene la firma (mensajes), que debe entender y suscribir todo formulario que necesite utilizar
 * al formulario de grilla.
 */
namespace UberFrba
{
    public interface IGrilla
    {
        void completarFormularioConDatosDeUsuarioSeleccionado(DataRowView filaDeDatos);
        void mensajeNoHayDatosParaGrilla();
        void cerrar();
    }
}

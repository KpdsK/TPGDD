using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba
{
    public interface IGrilla
    {
        void completarFormularioConDatosDeUsuarioSeleccionado(DataRowView filaDeDatos);
        void mensajeNoHayDatosParaGrilla();
        void cerrar();
    }
}

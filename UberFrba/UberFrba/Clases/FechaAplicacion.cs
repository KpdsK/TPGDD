using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Clases
{
    public static class FechaAplicacion
    {
        public static DateTime obtenerFechaAplicacion()
        {
            return Convert.ToDateTime(ConfigurationSettings.AppSettings["fechaDiaAplicacion"]);
        }
    }
}

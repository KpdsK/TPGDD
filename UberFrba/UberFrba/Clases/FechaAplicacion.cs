using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Esta clase provee de la fecha de la aplicacion, la toma del archivo App.config
 * <appSettings>
 *  <add key="fechaDiaAplicacion" value="05/01/2016" />
 * </appSettings>
 */
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UberFrba
{
    public static class Validaciones
    {
        public static Boolean validarCampoAlfanumericoConEspacio(String cadenaAValidar)
        {
            return evaluarCadenaConExpresion(cadenaAValidar, @"^[áéíóúÁÉÍÓÚÜüñÑa-zA-Z0-9][áéíóúÁÉÍÓÚÜüñÑ'a-zA-Z0-9\s]*$");
        }

        public static Boolean validarCampoAlfanumerico(String cadenaAValidar)
        {
            return evaluarCadenaConExpresion(cadenaAValidar, @"^[áéíóúÁÉÍÓÚÜüñÑa-zA-Z0-9][áéíóúÁÉÍÓÚÜüñÑ'a-zA-Z0-9]*$");
        }

        public static Boolean validarCampoClave(String cadenaAValidar)
        {
            return evaluarCadenaConExpresion(cadenaAValidar, @"[a-zA-Z0-9\!\#\$\%\._-]+$");
        }

        public static Boolean validarCampoNumericoConVacio(String cadenaAValidar)
        {
            return evaluarCadenaConExpresion(cadenaAValidar, @"^[0-9]*$");
        }

        public static Boolean validarCampoNumerico(String cadenaAValidar)
        {
            return evaluarCadenaConExpresion(cadenaAValidar, @"^[0-9]+$");
        }

        public static Boolean validarCampoAlfabeticoPermiteVacio(String cadenaAValidar)
        {
            return evaluarCadenaConExpresion(cadenaAValidar, @"^[áéíóúÁÉÍÓÚüÜñÑ'a-zA-Z0-9\s]*$");
        }

        public static Boolean validarCampoAlfabeticoConEspacio(String cadenaAValidar)
        {
            return evaluarCadenaConExpresion(cadenaAValidar, @"^[áéíóúÁÉÍÓÚÜüñÑa-zA-Z0-9][áéíóúÁÉÍÓÚüÜñÑ'a-zA-Z0-9\s]*$");
        }

        public static Boolean validarCampoAlfabetico(String cadenaAValidar)
        {
            return evaluarCadenaConExpresion(cadenaAValidar, @"^[áéíóúÁÉÍÓÚÜüñÑa-zA-Z0-9]+$");
        }

        public static Boolean validarCodigoPostal(String cadenaAValidar)
        {
            return evaluarCadenaConExpresion(cadenaAValidar, @"^[a-zA-Z][0-9]{4}[a-zA-Z]{3}$");
        }

        public static Boolean validarCorreoElectronico(String correoElectronico)
        {
            Boolean resultado;
            try
            {
                if (correoElectronico.Length > 0)
                {
                    String address = new MailAddress(correoElectronico).Address;
                }
                resultado = true;
            }
            catch (FormatException)
            {
                resultado = false;
            }
            return resultado;
        }

        public static Boolean validarPatente(String cadenaAValidar)
        {
            return evaluarCadenaConExpresion(cadenaAValidar,
                @"^[a-zA-Z]{2}[0-9]{3}[a-zA-Z]{2}|[a-zA-Z]{3}[0-9]{3}$");
        }

        public static Boolean validarCampoHorario(String cadenaAValidar)
        {
            return evaluarCadenaConExpresion(cadenaAValidar, @"2[0-4]|[0-1]{0,1}[0-9]");
        }

        public static Boolean validarCampoNumericoCon2Decimales(String cadenaAValidar)
        {
            return evaluarCadenaConExpresion(cadenaAValidar, @"\d+(?:,d{1,2})?");
        }

        private static bool evaluarCadenaConExpresion(String cadenaAValidar, String expresionRegular)
        {
            Match match = Regex.Match(cadenaAValidar, expresionRegular);
            return match.Success;
        }

        public static Boolean validarCampoDNI(string cadenaDNI)
        {
            Boolean resultado;
            if (validarCampoNumerico(cadenaDNI))
            {
                resultado = !MetodosGlobales.esDuplicadoDNI(cadenaDNI);
            }
            else
            {
                resultado = true;
            }
            return resultado;
        }

        public static bool validarCampoTelefono(string cadenaTelefono)
        {
            return validarCampoNumerico(cadenaTelefono) && !MetodosGlobales.esDuplicadoTelefono(cadenaTelefono);
        }

        public static bool validarRangoHorario(int horaInicio, int horaFin)
        {
            return (horaInicio != 23) ? horaInicio < horaFin :
                horaFin == 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba
{
    public static class MetodosGlobales
    {
        public static Boolean armarComboSeleccionSegunRol(DataTable tablaDatos, ComboBox comboChofer)
        {
            if (tablaDatos.Rows.Count > 0)
            {
                var diccionarioDatosChofer = new Dictionary<int, String>();
                foreach (DataRow fila in tablaDatos.Rows)
                {
                    diccionarioDatosChofer.Add((int)fila["idEnTablaSegunRol"], ((string)fila["apellido"]) + " " + ((string)fila["nombre"]));
                }

                comboChofer.DataSource = new BindingSource(diccionarioDatosChofer, null);
                comboChofer.DisplayMember = "Value";
                comboChofer.ValueMember = "Key";
            }
            return tablaDatos.Rows.Count > 0;
        }

        public static Boolean mensajeAlertaAntesDeAccion(String rol, String funcion)
        {
            DialogResult resultado = MessageBox.Show(Mensajes.mensajeAlertaAntesDeAccionInicio + funcion
                        + Mensajes.mensajeAlertaAntesDeAccionFin + rol
                        , funcion + " " + rol
                        , MessageBoxButtons.YesNo
                        , MessageBoxIcon.Question
                        , MessageBoxDefaultButton.Button2);
            return (resultado == DialogResult.Yes);
        }

        public static void mansajeErrorValidacion()
        {
            MessageBox.Show(Mensajes.mensajeErrorEnValidacionDatosDeFormulario
                        , Mensajes.mensajeErrorEnValidacionDatosDeFormularioTitulo
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Error);
        }

        public static void permitirSoloIngresoNumerico(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static void permitirSoloIngresoAlfanumerico(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !esSimboloEspecial(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private static bool esSimboloEspecial(char caracter)
        {
            return (new HashSet<string> { "'" })
                .Any(v => (new KeysConverter()).ConvertToString(caracter).Equals(v));
        }

        public static void permitirSoloIngresoCorreoElectronico(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !esSimboloPermitido(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private static bool esSimboloPermitido(char caracter)
        {
            return (new HashSet<string> { "@", ".", "-", "_" }).Any(v => (new KeysConverter()).ConvertToString(caracter).Equals(v));
        }

        public static void permitirSoloIngresoAlfanumericoConBlancos(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !esSimboloEspecial(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static void permitirSoloIngresoAlfabeticoConBlancos(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static void permitirSoloIngresoAlfabetico(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        public static void permitirSoloIngresoHorario(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !esSeparadorPermitido(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static Boolean construirComboChofer(Form formulario, String tipo, String titulo)
        {
            GD1C2017DataSetTableAdapters.PRC_BUSCAR_CHOFER_HABILITADOTableAdapter adaptador
                    = new GD1C2017DataSetTableAdapters.PRC_BUSCAR_CHOFER_HABILITADOTableAdapter();
            DataTable tblChofer = adaptador.obtenerListadoChoferesHabilitados();
            ComboBox frmRendirViajeComboChofer = (ComboBox)formulario.Controls["comboChofer"];
            if (!MetodosGlobales.armarComboSeleccionSegunRol(tblChofer, frmRendirViajeComboChofer))
            {
                dispararMensajeYCancelarAccion(tipo, titulo);
                formulario.Close();
                return false;
            }
            return true;
        }

        public static void dispararMensajeYCancelarAccion(String Tipo, String titulo)
        {
            DialogResult resultado = MessageBox.Show("No hay " + Tipo + " habilitados.", titulo,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private static bool esSeparadorPermitido(char caracter)
        {
            return (new KeysConverter()).ConvertToString(caracter).Equals(":");
        }

        public static void permitirSoloIngresoCon2Decimales(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !esPuntoDecimalPermitido(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private static bool esPuntoDecimalPermitido(char caracter)
        {
            return (new KeysConverter()).ConvertToString(caracter).Equals(",");
        }

        public static Boolean esDuplicadoDNI(string cadenaDNI)
        {
            GD1C2017DataSetTableAdapters.QueriesTableAdapter adaptador =
                new GD1C2017DataSetTableAdapters.QueriesTableAdapter();
            if ((Boolean)adaptador.existeDNI(Convert.ToInt64(cadenaDNI)))
            {
                throw new DNIDuplicadoException();
            }
            return false;
        }

        public static bool validarExistenciaDeRango(int horarioInicio, int horarioFin)
        {
            GD1C2017DataSetTableAdapters.QueriesTableAdapter adaptador =
                new GD1C2017DataSetTableAdapters.QueriesTableAdapter();
            Boolean resultado = (Boolean)adaptador.rangoInterceptaAlgunoExistente(
                horarioInicio,
                horarioFin);
            if (!resultado)
            {
                throw new RangoHorarioDuplicadoException();
            }
            return resultado;
        }

        public static class Mensajes
        {
            public static String mensajeDatosNulos
            {
                get
                {
                    return "Verifique que todos los campos requeridos, contengan datos y el formato de los mismos.";
                }
            }
            public static String mensajeTituloVentanaDatosNulos
            {
                get
                {
                    return "Datos requeridos"; ;
                }
            }
            public static String mensajeDatosNulosAltaClienteChofer
            {
                get
                {
                    return "El correo electronico es el unico dato opcional, el resto son obligatorios";
                }
            }
            public static String mensajeAlertaAntesDeAccionInicio
            {
                get
                {
                    return "¿Esta segura/o de ";
                }
            }
            public static String mensajeAlertaAntesDeAccionFin
            {
                get
                {
                    return " este nuevo ";
                }
            }
            public static String mensajeErrorEnValidacionDatosDeFormulario
            {
                get
                {
                    return "Error en validacion de datos. Revise los mismos y reintente.";
                }
            }
            public static String mensajeErrorEnValidacionDatosDeFormularioTitulo
            {
                get
                {
                    return "Error Validacion";
                }
            }
        }


        public static bool esDuplicadoTelefono(string cadenaTelefono)
        {
            GD1C2017DataSetTableAdapters.QueriesTableAdapter adaptador =
                new GD1C2017DataSetTableAdapters.QueriesTableAdapter();
            Boolean resultado = (Boolean)adaptador.existeTelefono(Convert.ToDecimal(cadenaTelefono));
            if (resultado)
            {
                throw new TelefonoDuplicadoException();
            }
            return resultado;
        }

        internal static bool existePatente(string cadenaAValidar)
        {
            GD1C2017DataSetTableAdapters.QueriesTableAdapter adaptador =
                new GD1C2017DataSetTableAdapters.QueriesTableAdapter();
            Boolean resultado = (Boolean)adaptador.existePatente(cadenaAValidar);
            if (resultado)
            {
                throw new PatenteDuplicadoException();
            }
            return resultado;
        }
    }
}
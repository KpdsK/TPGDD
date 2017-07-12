using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Esta clase inicialmente tenia otro sentido, fue el ancestro de los tipos de roles. Al permitir ABM de roles,
 * se modifico para que los roles preexistentes, o creados en tiempo de ejecucion por el usuario, puedan tener 
 * dinamicamente las funciones asignadas en el formulario ABM rol. Se opto por tener una sola clase, con todas las
 * funciones del sistema, y una lista que indique cuales son las que tiene habilitadas este usuario/rol.
 */

namespace UberFrba
{
    public class FuncionalidadSegunRol
    {
        public FuncionalidadSegunRol(int idRol, int idUsuario, String nombreRol, Boolean esAdmin)
        {
            this.idRol = idRol;
            this.soyAdmin = esAdmin;
            this.idTipoRol = obtenerIdTipoRol(idRol, idUsuario); ;
            this.nombreRol = nombreRol;
            this.listaFuncionesHabilitadasSegunRol();
        }



        private void listaFuncionesHabilitadasSegunRol()
        {
            GD1C2017DataSetTableAdapters.LISTAR_FUNC_X_ROLTableAdapter adaptador =
                new GD1C2017DataSetTableAdapters.LISTAR_FUNC_X_ROLTableAdapter();
            this.listaFuncionalidades.AddRange(adaptador.listaDeFunciones(this.IdRol).AsEnumerable().Select(
                elemento => elemento.Field<String>("metodo")
                ).ToList());
        }

        private Boolean soyAdmin;
        public Boolean SoyAdmin
        {
            get { return soyAdmin; }
            set { soyAdmin = value; }
        }
        public List<String> listaFuncionalidades = new List<string>();
        private int idRol;
        public int IdRol
        {
            get { return idRol; }
            set { idRol = value; }
        }

        private int idTipoRol;
        public int IdTipoRol
        {
            get { return idTipoRol; }
            set { idTipoRol = value; }
        }

        private String nombreRol;
        public String NombreRol
        {
            get { return nombreRol; }
            set { nombreRol = value; }
        }

        private int obtenerIdTipoRol(int idRol, int idUsuario)
        {
            return (int)(new GD1C2017DataSetTableAdapters.PRC_OBTENER_ID_CLIENTE_O_CHOFERTableAdapter())
                .obtenerIdEnTablaClienteOChofer(idUsuario, IdRol);
        }

        public Boolean soyAdministrador()
        {
            return this.SoyAdmin;
        }

        public void agregarCliente()
        {
            agregarClienteChofer("Cliente");
        }

        public void eliminarCliente()
        {
            eliminarClienteChofer("Cliente");
        }

        public void modificarCliente()
        {
            modificarClienteChofer("Cliente");
        }

        public void agregarChofer()
        {
            agregarClienteChofer("Chofer");
        }

        public void eliminarChofer()
        {
            eliminarClienteChofer("Chofer");
        }

        public void modificarChofer()
        {
            modificarClienteChofer("Chofer");
        }

        public void ejecutarFuncion(string nombreMetodo)
        {
            if (this.listaFuncionalidades.Contains(nombreMetodo))
            {
                MethodInfo methodInfo = this.GetType().GetMethod(nombreMetodo);
                methodInfo.Invoke(this, new object[] { });
            }
            else
            {
                mensajeFuncionNoValidaParaElRol(this.NombreRol);
            }
        }

        public void facturarCliente()
        {
            facturarACliente();
        }
        public void rendicionChofer()
        {
            rendicionAChofer();
        }

        public void listados()
        {
            (new frmListados()).construite();
        }

        public void eliminarTurno()
        {
            construirFormularioTurno(new frmTurnoEliminar());
        }

        public void modificarTurno()
        {
            construirFormularioTurno(new frmTurnoModificar());
        }

        public void agregarRol()
        {
            construirFormularioRol(new frmRolAgregar());
        }

        public void agregarClienteChofer(String cadena)
        {
            construirFormularioClienteChofer(new frmClienteChoferAgregar(), cadena);
        }

        public void eliminarClienteChofer(String cadena)
        {
            construirFormularioClienteChofer(new frmClienteChoferEliminar(), cadena);
        }

        public void modificarClienteChofer(String cadena)
        {
            construirFormularioClienteChofer(new frmClienteChoferModificar(), cadena);
        }

        public void agregarAutomovil()
        {
            construirFormularioAutomovil(new frmAutomovilAgregar());
        }

        public void accionBotonAutomovil(object sender, EventArgs e, frmAutomovil formulario, string funcion, string rol, object datos)
        {
            if (formulario.verificarDatosDeFormulario())
            {
                if (MetodosGlobales.mensajeAlertaAntesDeAccion(rol, funcion))
                {
                    ejecutarMetodoDeAccionConParametros(
                        obtenerNombreMetodo(funcion, rol),
                        new object[] { 
                            datos
                            ,obtenerAdaptadorBD() });
                    formulario.Close();
                }
            }
            else
            {
                MessageBox.Show(MetodosGlobales.Mensajes.mensajeDatosNulos,
                     MetodosGlobales.Mensajes.mensajeTituloVentanaDatosNulos,
                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void accionBotonTurno(object sender, EventArgs e, frmABMTurno formulario, string funcion, string rol, object datos)
        {
            try
            {
                if (formulario.verificarDatosDeFormulario())
                {
                    if (MetodosGlobales.mensajeAlertaAntesDeAccion(rol, funcion))
                    {
                        ejecutarMetodoDeAccionConParametros(
                            obtenerNombreMetodo(funcion, rol),
                            new object[] { 
                                datos
                                ,obtenerAdaptadorBD() });
                        formulario.Close();
                    }
                }
                else
                {
                    MessageBox.Show(MetodosGlobales.Mensajes.mensajeDatosNulos,
                         MetodosGlobales.Mensajes.mensajeTituloVentanaDatosNulos,
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (RangoHorarioDuplicadoException ex)
            {
                MessageBox.Show("El Rango horario no puede interceptar a otros.", "Error Rango Horario",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void eliminarAutomovil()
        {
            construirFormularioAutomovil(new frmAutomovilEliminar());
        }

        private static void construirFormularioAutomovil(frmAutomovil frmAutomovil)
        {
            if (frmAutomovil.construite())
            {
                frmAutomovil.Show();
            }
        }

        public void modificarAutomovil()
        {
            construirFormularioAutomovil(new frmAutomovilModificar());
        }

        public void agregarAutomovilEnBD(Control.ControlCollection c, GD1C2017DataSetTableAdapters.QueriesTableAdapter adaptador)
        {
            try
            {
                adaptador.agregarAutomovil
                            (Convert.ToInt32(((ComboBox)c["comboMarca"]).SelectedValue),
                            Convert.ToInt32(((ComboBox)c["comboModelo"]).SelectedValue),
                            c["txtPatente"].Text,
                            Convert.ToInt32(((ComboBox)c["comboTurno"]).SelectedValue),
                            Convert.ToInt32(((ComboBox)c["comboChofer"]).SelectedValue));
            }
            catch (SqlException e)
            {
                mensajeErrorEnDB();
            }
        }

        public void eliminarAutomovilEnBD(int idAuto, GD1C2017DataSetTableAdapters.QueriesTableAdapter adaptador)
        {
            try
            {
                adaptador.eliminarAutomovil
                            (idAuto);
            }
            catch (SqlException e)
            {
                mensajeErrorEnDB();
            }
        }

        public void modificarAutomovilEnBD(Control.ControlCollection c, GD1C2017DataSetTableAdapters.QueriesTableAdapter adaptador)
        {
            try
            {
                adaptador.modificarAutomovil
                            (Convert.ToInt32(((Label)(c["lblIdAuto"])).Text),
                            Convert.ToInt32(((ComboBox)c["comboMarca"]).SelectedValue),
                            Convert.ToInt32(((ComboBox)c["comboModelo"]).SelectedValue),
                            c["txtPatente"].Text,
                            Convert.ToInt32(((ComboBox)c["comboTurno"]).SelectedValue),
                            Convert.ToInt32(((ComboBox)c["comboChofer"]).SelectedValue),
                            Convert.ToBoolean(((CheckBox)c["ccHabilitado"]).Checked));
            }
            catch (SqlException e)
            {
                mensajeErrorEnDB();
            }
        }

        public void agregarClienteEnBD(Control.ControlCollection c, GD1C2017DataSetTableAdapters.QueriesTableAdapter adaptador)
        {
            try
            {
                String Usu_Nombre_Usuario = Convert.ToString(adaptador.agregarCliente
                            (Convert.ToInt64(c["txtDNI"].Text), c["txtNombre"].Text,
                            c["txtApellido"].Text, c["txtCalle"].Text,
                            Convert.ToInt16(c["txtPisoManzana"].Text),
                            c["txtDeptoLote"].Text, c["txtLocalidad"].Text, c["txtCodigoPostal"].Text,
                            Convert.ToInt64(c["txtTelefono"].Text), c["txtCorreo"].Text,
                            Convert.ToDateTime(((DateTimePicker)c["selectorFechaNacimiento"]).Value)));
                mensajeCreacionDeUsuario(Usu_Nombre_Usuario);
            }
            catch (SqlException e)
            {
                mensajeErrorEnDB();
            }
        }

        public void agregarChoferEnBD(Control.ControlCollection c, GD1C2017DataSetTableAdapters.QueriesTableAdapter adaptador)
        {
            try
            {
                String Usu_Nombre_Usuario = Convert.ToString(adaptador.agregarChofer
                            (Convert.ToInt64(c["txtDNI"].Text), c["txtNombre"].Text, c["txtApellido"].Text,
                            c["txtCalle"].Text, Convert.ToInt16(c["txtPisoManzana"].Text), c["txtDeptoLote"].Text,
                            c["txtLocalidad"].Text, c["txtCodigoPostal"].Text, Convert.ToInt64(c["txtTelefono"].Text),
                            c["txtCorreo"].Text,
                            Convert.ToDateTime(((DateTimePicker)c["selectorFechaNacimiento"]).Value)));
                mensajeCreacionDeUsuario(Usu_Nombre_Usuario);
            }
            catch (SqlException e)
            {
                mensajeErrorEnDB();
            }
        }

        public void agregarTurnoEnBD(Control.ControlCollection c, GD1C2017DataSetTableAdapters.QueriesTableAdapter adaptador)
        {
            try
            {
                adaptador.agregarTurno
                            (Convert.ToInt16(((NumericUpDown)c["selectorHoraInicio"]).Value),
                            Convert.ToInt16(((NumericUpDown)c["selectorHoraFin"]).Value),
                            c["txtDescripcion"].Text,
                            Convert.ToDecimal(c["txtValorKilometro"].Text),
                             Convert.ToDecimal(c["txtPrecioBase"].Text),
                            Convert.ToBoolean(((CheckBox)c["ccHabilitado"]).Checked));
            }
            catch (SqlException e)
            {
                mensajeErrorEnDB();
            }
        }

        public void eliminarTurnoEnBD(int idTurno, GD1C2017DataSetTableAdapters.QueriesTableAdapter adaptador)
        {
            try
            {
                adaptador.eliminarTurno
                            (idTurno);
            }
            catch (SqlException e)
            {
                mensajeErrorEnDB();
            }
        }

        public void modificarTurnoEnBD(Control.ControlCollection c, GD1C2017DataSetTableAdapters.QueriesTableAdapter adaptador)
        {
            try
            {
                adaptador.modificarTurno
                            (Convert.ToInt32(c["lblIdTurno"].Text),
                            Convert.ToInt16(((NumericUpDown)c["selectorHoraInicio"]).Value),
                            Convert.ToInt16(((NumericUpDown)c["selectorHoraFin"]).Value),
                            c["txtDescripcion"].Text,
                            Convert.ToDecimal(c["txtValorKilometro"].Text),
                            Convert.ToDecimal(c["txtPrecioBase"].Text),
                            Convert.ToBoolean(((CheckBox)c["ccHabilitado"]).Checked));
            }
            catch (SqlException e)
            {
                mensajeErrorEnDB();
            }
        }

        public void mensajeCreacionDeUsuario(String nombreUsuario)
        {
            //FIXME: evitar overflow al utilizar substring, agregar consulta a db para traer el nuevo usuario y mostrarlo. Acciona como validacion
            MessageBox.Show("Se ha creado el usuario \"" + nombreUsuario + "\" con clave \"Inicio2017\"", "Se ha creado Usuario",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void agregarTurno()
        {
            construirFormularioTurno(new frmTurnoAgregar());
        }

        private static void construirFormularioTurno(frmABMTurno frmTurno)
        {
            if (frmTurno.construite())
            {
                frmTurno.Show();
            }
        }

        private static void construirFormularioRol(frmRolAgregar frmRol)
        {
            if (frmRol.construite())
            {
                frmRol.Show();
            }
        }

        public void eliminarRol()
        {
            construirFormularioRol(new frmRolEliminar());
        }

        private static void construirFormularioRol(frmRolEliminar frmRol)
        {
            if (frmRol.construite())
            {
                frmRol.Show();
            }
        }

        public void modificarRol()
        {
            construirFormularioRol(new frmRolModificar());
        }

        private static void construirFormularioRol(frmRolModificar frmRol)
        {
            if (frmRol.construite())
            {
                frmRol.Show();
            }
        }

        public void registroViajes()
        {
            frmRegistroViaje formularioRegistroViaje = new frmRegistroViaje();
            if (formularioRegistroViaje.construite())
            {
                formularioRegistroViaje.Show();
            }
        }

        public void rendicionAChofer()
        {
            frmRendirViaje formularioRendirViaje = new frmRendirViaje();
            if (formularioRendirViaje.construite())
            {
                formularioRendirViaje.Show();
            }
        }

        public void facturarACliente()
        {
            frmFacturarViaje formularioFacturarViaje = new frmFacturarViaje();
            if (formularioFacturarViaje.construite())
            {
                formularioFacturarViaje.Show();
            }
        }

        public void accionBotonClienteChofer(object sender, EventArgs e, frmABM formulario, string funcion, string rol, object datos)
        {
            try
            {
                if (formulario.verificarDatosDeFormulario())
                {
                    if (MetodosGlobales.mensajeAlertaAntesDeAccion(rol, funcion))
                    {
                        ejecutarMetodoDeAccionConParametros(
                            obtenerNombreMetodo(funcion, rol),
                            new object[] { 
                                datos
                                ,obtenerAdaptadorBD() });
                        formulario.Close();
                        mensajeAutoeliminacion(formulario);
                    }
                }
                else
                {
                    MessageBox.Show(MetodosGlobales.Mensajes.mensajeDatosNulos,
                         MetodosGlobales.Mensajes.mensajeTituloVentanaDatosNulos,
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (DNIDuplicadoException ex)
            {
                MessageBox.Show("El DNI no puede ser duplicado.", "Error DNI Duplicado",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TelefonoDuplicadoException ex)
            {
                MessageBox.Show("El telefono no puede ser duplicado.", "Error Telefono Duplicado",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual void mensajeAutoeliminacion(frmABM formulario)
        {
        }

        public void eliminarClienteEnBD(int idTipoRol, GD1C2017DataSetTableAdapters.QueriesTableAdapter adaptador)
        {
            try
            {
                adaptador.eliminarCliente(idTipoRol);
            }
            catch (SqlException e)
            {
                mensajeErrorEnDB();
            }
        }

        public void eliminarChoferEnBD(int idTipoRol, GD1C2017DataSetTableAdapters.QueriesTableAdapter adaptador)
        {
            try
            {
                adaptador.eliminarChofer(idTipoRol);
            }
            catch (SqlException e)
            {
                mensajeErrorEnDB();
            }
        }

        public void modificarClienteEnBD(Control.ControlCollection c, GD1C2017DataSetTableAdapters.QueriesTableAdapter adaptador)
        {
            try
            {
                adaptador.modificarCliente
                            (Convert.ToInt32(c["lblIdPersona"].Text), Convert.ToInt32(c["txtDNI"].Text), c["txtNombre"].Text, c["txtApellido"].Text, c["txtCalle"].Text
                            , Convert.ToInt16(c["txtPisoManzana"].Text), c["txtDeptoLote"].Text, c["txtLocalidad"].Text, c["txtCodigoPostal"].Text
                            , Convert.ToInt32(c["txtTelefono"].Text), c["txtCorreo"].Text, ((DateTimePicker)c["selectorFechaNacimiento"]).Value
                            , Convert.ToBoolean(((CheckBox)c["ccHabilitado"]).Checked));
            }
            catch (SqlException e)
            {
                mensajeErrorEnDB();
            }
        }

        public void modificarChoferEnBD(Control.ControlCollection c, GD1C2017DataSetTableAdapters.QueriesTableAdapter adaptador)
        {
            try
            {
                adaptador.modificarChofer
                            (Convert.ToInt32(c["lblIdPersona"].Text), Convert.ToInt32(c["txtDNI"].Text), c["txtNombre"].Text, c["txtApellido"].Text, c["txtCalle"].Text
                            , Convert.ToInt16(c["txtPisoManzana"].Text), c["txtDeptoLote"].Text, c["txtLocalidad"].Text, c["txtCodigoPostal"].Text
                            , Convert.ToInt32(c["txtTelefono"].Text), c["txtCorreo"].Text, ((DateTimePicker)c["selectorFechaNacimiento"]).Value,
                            Convert.ToBoolean(((CheckBox)c["ccHabilitado"]).Checked));
            }
            catch (SqlException e)
            {
                mensajeErrorEnDB();
            }
        }

        protected void construirFormularioClienteChofer(frmABM frmClienteChofer, String rolParaAlta)
        {
            if (frmClienteChofer.construite(rolParaAlta))
            {
                frmClienteChofer.Show();
            }
        }

        private void mensajeFuncionNoValidaParaElRol(String rol)
        {
            MessageBox.Show("Funcion no permitida para un " + rol, "Funcion no permitida",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void mensajeErrorEnDB()
        {
            MessageBox.Show("Error al operar en la BD", "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected Control.ControlCollection obtenerGrupoControlesDeFormularioABM(frmABM formulario, String grupoControles)
        {
            return (formulario.Controls[grupoControles]).Controls;
        }

        protected GD1C2017DataSetTableAdapters.QueriesTableAdapter obtenerAdaptadorBD()
        {
            return new GD1C2017DataSetTableAdapters.QueriesTableAdapter();
        }

        protected void ejecutarMetodoDeAccionConParametros(MethodInfo methodInfo, object[] objParametros)
        {
            methodInfo.Invoke(this, objParametros);
        }

        protected MethodInfo obtenerNombreMetodo(string funcion, string rol)
        {
            return this.GetType().GetMethod(funcion.ToLower() + rol + "EnBD");
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace UberFrba
{
    public partial class frmIngreso : Form
    {
        static string sha256(string clave)
        {
            System.Security.Cryptography.SHA256Managed encriptador
                = new System.Security.Cryptography.SHA256Managed();
            System.Text.StringBuilder hash = new System.Text.StringBuilder();
            byte[] claveEncriptada
                = encriptador.ComputeHash(Encoding.UTF8.GetBytes(clave), 0, Encoding.UTF8.GetByteCount(clave));
            foreach (byte unByte in claveEncriptada)
            {
                hash.Append(unByte.ToString("x2"));
            }
            return hash.ToString();
        }

        class Usuario
        {
            private int idUsuario;
            private List<Tuple<int, String>> roles;

            public int obtenerIdUsuario()
            {
                return idUsuario;
            }

            public void setearIdUsuario(int usuario)
            {
                idUsuario = usuario;
            }

            public void agregarRol(int idRol, String rol)
            {
                roles.Add(new Tuple<int, String>(idRol, rol));
            }

            public List<Tuple<int, String>> obtenerRoles()
            {
                return roles;
            }
        }

        public frmIngreso()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (validarDatosDelFormulario())
            {
                GD1C2017DataSetTableAdapters.PRC_VALIDAR_USUARIOTableAdapter adaptador
                        = new GD1C2017DataSetTableAdapters.PRC_VALIDAR_USUARIOTableAdapter();
                DataTable tblUsuarioYRoles = adaptador.validarUsuario(textoUsuario.Text, sha256(textoClave.Text));
                List<Tuple<String, String>> roles = new List<Tuple<string, string>>();
                
                int codigoUsuario = tblUsuarioYRoles.Rows[0].Field<int>("UserId");
                String nombreUsuario = tblUsuarioYRoles.Rows[0].Field<String>("Nombre");
                String apellidoUsuario = tblUsuarioYRoles.Rows[0].Field<String>("Apellido");
                int idPersona = tblUsuarioYRoles.Rows[0].Field<int>("idPersona");

                switch (codigoUsuario)
                {
                    case -1:
                        MessageBox.Show("Usuario no existe.");
                        break;
                    case -2:
                        MessageBox.Show("Usuario/Rol Bloqueado o inhabilitado.");
                        break;
                    case -3:
                        MessageBox.Show("Usuario o Clave Incorrecta.");
                        break;
                    default:
                        this.Hide();
                        SingletonDatosUsuario datosUsuario = new SingletonDatosUsuario(codigoUsuario, textoUsuario.Text, nombreUsuario, apellidoUsuario, idPersona);
                        frmRoles fmRoles = new frmRoles();
                        ((ComboBox)fmRoles.Controls["comboRol"]).Focus();
                        ComboBox frmRolComboRol = (ComboBox)fmRoles.Controls["comboRol"];
                        frmRolComboRol.DataSource = tblUsuarioYRoles;
                        frmRolComboRol.DisplayMember = "Rol_Nombre";
                        frmRolComboRol.ValueMember = "Rol_Id";
                        fmRoles.Show();
                        break;
                }
            } else {
                MetodosGlobales.mansajeErrorValidacion();
            }
        }

        

        private bool validarDatosDelFormulario()
        {
            return (Validaciones.validarCampoAlfanumerico(textoUsuario.Text) 
                && Validaciones.validarCampoClave(textoClave.Text));
        }
    }

    public class SingletonDatosUsuario
    {
        public class DatosUsuario
        {
            private int idPersona;
            public int IdPersona
            {
                get { return idPersona; }
                set { idPersona = value; }
            }
            private int idUsuario;
            public int IdUsuario
            {
                get { return idUsuario; }
                set { idUsuario = value; }
            }
            private int rolId;
            public int RolId
            {
                get { return rolId; }
                set { rolId = value; }
            }
            private int idTipoRol;
            public int IdTipoRol
            {
                get { return idTipoRol; }
                set { idTipoRol = value; }
            }
            private String nombreUsuario;
            public String NombreUsuario
            {
                get { return nombreUsuario; }
                set { nombreUsuario = value; }
            }
            private String nombre;
            public String Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }
            private String apellido;
            public String Apellido
            {
                get { return apellido; }
                set { apellido = value; }
            }
        }
        private static SingletonDatosUsuario instance;
        private DatosUsuario datosUsuario;
        public FuncionalidadSegunRol rol { set; get; }

        public SingletonDatosUsuario() { }
        public SingletonDatosUsuario(int id, String nombreUsuario, String nombre, String apellido, int idPersona)
        {
            datosUsuario = new DatosUsuario();
            this.datosUsuario.IdUsuario = id;
            this.datosUsuario.NombreUsuario = nombreUsuario;
            this.datosUsuario.Nombre = nombre;
            this.datosUsuario.Apellido = apellido;
            this.datosUsuario.IdPersona = idPersona;
            instance = this;
        }

        public void configurarRol(int idRol, String nombreRol, Boolean esAdmin)
        {
            rol = new FuncionalidadSegunRol(idRol, this.datosUsuario.IdUsuario, nombreRol, esAdmin);
        }

        public bool soyRolAdministrador(string nombreRol)
        {
            return this.rol.soyAdministrador();
        }

        public int obtenerIdUsuario()
        {
            return this.datosUsuario.IdUsuario;
        }

        public int obtenerIdTipoRol()
        {
            return this.datosUsuario.IdTipoRol;
        }

        public int obtenerIdRol()
        {
            return this.datosUsuario.RolId;
        }

        public void setearIdPersona(int idPersona)
        {
            this.datosUsuario.IdPersona = idPersona;
        }

        public int obtenerIdPersona()
        {
            return this.datosUsuario.IdPersona;
        }

        public void setearRolId(int rolId)
        {
            this.datosUsuario.RolId = rolId;
        }

        public void setearIdTipoRol(int idTipoRol)
        {
            this.datosUsuario.IdTipoRol = idTipoRol;
        }

        public static SingletonDatosUsuario Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonDatosUsuario();
                }
                return instance;
            }
        }
    }

    //public interface IFuncionalidadRoles
    //{
    //    Boolean soyAdministrador();
    //    void agregarAutomovil();
    //    void eliminarAutomovil();
    //    void modificarAutomovil();
    //    void agregarTurno();
    //    void eliminarTurno();
    //    void modificarTurno();
    //    void agregarRol();
    //    void eliminarRol();
    //    void modificarRol();
    //    void accionBotonAutomovil(object sender, EventArgs e, frmAutomovil formulario, String funcion, String rol, object datos);
    //    void accionBotonTurno(object sender, EventArgs e, frmABMTurno formulario, string funcion, string rol, object datos);
    //    void accionBotonClienteChofer(object sender, EventArgs e, frmABM formulario, string funcion, string rol, object datos);
    //    void rendicionAChofer();
    //    void facturarACliente();

    //    void ejecutarFuncion(string nombreMetodo);
    //}

    public class FuncionalidadSegunRol //: IFuncionalidadRoles
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
                            (Convert.ToInt32(((ComboBox)c["comboMarca"]).SelectedValue),
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
                            (Convert.ToInt16(c["txtHoraInicio"].Text),
                            Convert.ToInt16(c["txtHoraFin"].Text),
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
                            Convert.ToInt16(((NumericUpDown)c["selectorHoraFin"])   .Value),
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

    public class ArgumentosParaEventoBotonAgregar : EventArgs
    {
        public frmABM formulario { set; get; }
    }
    
    public static class VariablesGlobales
    {
        public const string NOMBRE_ROL_ADMINISTRADOR = "ADMINISTRATIVO";
    }

    interface IGrilla
    {
        void completarFormularioConDatosDeUsuarioSeleccionado(DataRowView filaDeDatos);
    }

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
            return (new KeysConverter()).ConvertToString(caracter).Equals(".");
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
            if (resultado)
            {
                throw new RangoHorarioDuplicadoException();
            }
            return resultado;
        }

        public static class Mensajes
        {
            public static String mensajeDatosNulos{
                get {
                    return "Verifique que todos los campos requeridos, contengan datos y el formato de los mismos.";
                }}
            public static String mensajeTituloVentanaDatosNulos
            {
                get {
                    return "Datos requeridos";;
                }}
            public static String mensajeDatosNulosAltaClienteChofer
            {
                get {
                    return "El correo electronico es el unico dato opcional, el resto son obligatorios";
                }}
            public static String mensajeAlertaAntesDeAccionInicio
            {
                get {
                    return "¿Esta segura/o de ";
                }}
            public static String mensajeAlertaAntesDeAccionFin
            {
                get {
                    return " este nuevo ";
                }}
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
            return evaluarCadenaConExpresion(cadenaAValidar, @"([0-1][0-9]|2[0-3])[0-5][0-9]|[0-1][0-9]|2[0-3]$");
        }

        public static Boolean validarCampoNumericoCon2Decimales(String cadenaAValidar)
        {
            return evaluarCadenaConExpresion(cadenaAValidar, @"\d+(?:.\d{1,2})?");
        }

        private static bool evaluarCadenaConExpresion(String cadenaAValidar, String expresionRegular)
        {
            Match match = Regex.Match(cadenaAValidar, expresionRegular);
            return match.Success;
        }

        public static Boolean validarCampoDNI(string cadenaDNI)
        {
            Boolean resultado;
            if(validarCampoNumerico(cadenaDNI))
            {
                resultado = !MetodosGlobales.esDuplicadoDNI(cadenaDNI);
            }
            else{
                resultado = true;
            }
            return resultado;
        }

        public static bool validarCampoTelefono(string cadenaTelefono)
        {
            //Boolean resultado;
            //if (validarCampoNumerico(cadenaTelefono))
            //{
            //    if (!MetodosGlobales.esDuplicadoTelefono(cadenaTelefono))
            //    {
            //        resultado = true;
            //    }
            //    else
            //    {
            //        throw new DNIDuplicadoException();
            //    }
            //}
            //else
            //{
            //    resultado = true;
            //}
            //return resultado;
            return validarCampoNumerico(cadenaTelefono) && !MetodosGlobales.esDuplicadoTelefono(cadenaTelefono);
        }

        public static bool validarRangoHorario(int horaInicio, int horaFin)
        {
            return (horaInicio != 23) ? horaInicio < horaFin: 
                horaFin==0;
        }
    }
    public class DNIDuplicadoException : Exception
    {
        public DNIDuplicadoException()
            : base(){}
    }

    public class TelefonoDuplicadoException : Exception
    {
        public TelefonoDuplicadoException()
            : base() { }
    }

    public class PatenteDuplicadoException : Exception
    {
        public PatenteDuplicadoException()
            : base() { }
    }
    public class RangoHorarioDuplicadoException : Exception
    {
        public RangoHorarioDuplicadoException()
            : base() { }
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Clases;
/*
 * Se utiliza como en todos los ABM herencia para reutilizar codigo. Diferenciando la funcionalidad segun la accion
 * a realizar (Alta, Baja o Modificacion).
 * 
 */
namespace UberFrba
{
    public partial class frmABM : Form, IGrilla
    {
        public String tipoUsuario {set;get;}
        public String tipoFuncion { set; get; }
        public int idTipoRol { set; get; }
        public int idPersona { set; get; }

        public frmABM()
        {
            InitializeComponent();
            this.selectorFechaNacimiento.MaxDate = (FechaAplicacion.obtenerFechaAplicacion()).AddYears(-18);
            this.selectorFechaNacimiento.Value = (FechaAplicacion.obtenerFechaAplicacion()).AddYears(-18);
            this.selectorFechaNacimiento.Format = DateTimePickerFormat.Custom;
            this.selectorFechaNacimiento.CustomFormat = "dd 'de' MMMM 'de' yyyy";
        }

        public virtual void accionesAdicionales()
        {
        }

        public virtual Boolean construite(String rolParaAlta)
        { return false; }

        public virtual void construirBotonAccion(String rolParaAlta)
        {
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (validarDatosParaBusqueda())
            {
                DataTable tblDatosResultadoBusquedaUsuarios = obtenerTablaDeDatosDeUsuario();
                MethodInfo metodoAEjecutar = this.GetType().GetMethod("configuracionesAdicionalesGrillaABMClienteChofer", BindingFlags.NonPublic | BindingFlags.Instance);
                ArmadoGrilla.construirGrillaSiHayResultados(tblDatosResultadoBusquedaUsuarios, metodoAEjecutar, this, true);
            } else {
                MetodosGlobales.mansajeErrorValidacion();
            }
        }

        public void mensajeNoHayDatosParaGrilla()
        {
            MessageBox.Show("No Existe " + this.tipoUsuario + " coincidente con los parametros de busqueda");
        }

        protected void configuracionesAdicionalesGrillaABMClienteChofer(frmGrilla formularioGrilla)
        {
            formularioGrilla.Controls["btnSeleccionar"].Text = "Seleccionar " + this.tipoUsuario;
            formularioGrilla.Show();
        }

        protected virtual DataTable obtenerTablaDeDatosDeUsuario()
        {
            GD1C2017DataSetTableAdapters.PRC_OBTENER_DATOS_USUARIOSTableAdapter adaptador
            = new GD1C2017DataSetTableAdapters.PRC_OBTENER_DATOS_USUARIOSTableAdapter();
            return (esVacioONuloDNI()) ?
                adaptador.obtenerDatosUsuario(this.tipoUsuario, this.txtBusquedaNombre.Text, this.txtBusquedaApellido.Text, null, true, false)
                : adaptador.obtenerDatosUsuario(this.tipoUsuario, this.txtBusquedaNombre.Text, this.txtBusquedaApellido.Text, int.Parse(this.txtBusquedaDNI.Text), true, false);
        }

        protected bool esVacioONuloDNI()
        {
            return string.IsNullOrEmpty(this.txtBusquedaDNI.Text);
        }

        private Boolean validarDatosParaBusqueda()
        {
            return (Validaciones.validarCampoAlfabeticoPermiteVacio(txtBusquedaNombre.Text)
                && Validaciones.validarCampoAlfabeticoPermiteVacio(txtBusquedaApellido.Text)
                && Validaciones.validarCampoNumericoConVacio(txtBusquedaDNI.Text));
        }

        public virtual void mensajeAutoEliminacionYSalidaDeAplicacion()
        {
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void cerrar()
        {
            this.Close();
        }

        public void completarFormularioConDatosDeUsuarioSeleccionado(DataRowView filadeDatos)
        {
            ((TextBox)(this.Controls["grupoDatosPersona"]).Controls["txtNombre"]).Text = filadeDatos.Row["Persona_Nombre"].ToString();
            ((TextBox)(this.Controls["grupoDatosPersona"]).Controls["txtApellido"]).Text = filadeDatos.Row["Persona_Apellido"].ToString();
            ((TextBox)(this.Controls["grupoDatosPersona"]).Controls["txtDNI"]).Text = filadeDatos.Row["Persona_Dni"].ToString();
            ((TextBox)(this.Controls["grupoDatosPersona"]).Controls["txtCorreo"]).Text = filadeDatos.Row["Persona_Mail"].ToString();
            ((TextBox)(this.Controls["grupoDatosPersona"]).Controls["txtTelefono"]).Text = filadeDatos.Row["Persona_Telefono"].ToString();
            ((TextBox)(this.Controls["grupoDatosPersona"]).Controls["txtLocalidad"]).Text = filadeDatos.Row["Persona_Localidad"].ToString();
            ((TextBox)(this.Controls["grupoDatosPersona"]).Controls["txtCodigoPostal"]).Text = filadeDatos.Row["Persona_Cod_Postal"].ToString();
            ((TextBox)(this.Controls["grupoDatosPersona"]).Controls["txtCalle"]).Text = filadeDatos.Row["Persona_Direccion"].ToString();
            ((TextBox)(this.Controls["grupoDatosPersona"]).Controls["txtDeptoLote"]).Text = filadeDatos.Row["Persona_Departamento"].ToString();
            ((TextBox)(this.Controls["grupoDatosPersona"]).Controls["txtPisoManzana"]).Text = filadeDatos.Row["Persona_Piso"].ToString();
            ((DateTimePicker)(this.Controls["grupoDatosPersona"]).Controls["selectorFechaNacimiento"]).Value = Convert.ToDateTime(filadeDatos.Row["Persona_Fecha_Nac"].ToString());
            ((CheckBox)(this.Controls["grupoDatosPersona"]).Controls["ccHabilitado"]).Checked = (Boolean)filadeDatos.Row["habilitado"];
            this.idTipoRol = (int)filadeDatos.Row["idTipoRol"];
            this.idPersona = (int)filadeDatos.Row["Persona_Id"];
            ((Label)(this.Controls["grupoDatosPersona"]).Controls["lblIdPersona"]).Text = filadeDatos.Row["Persona_Id"].ToString();
            accionesAdicionales();
        }

        private void txtBusquedaNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosGlobales.permitirSoloIngresoAlfabeticoConBlancos(e);
        }

        private void txtBusquedaApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosGlobales.permitirSoloIngresoAlfabeticoConBlancos(e);
        }

        private void txtBusquedaDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosGlobales.permitirSoloIngresoNumerico(e);
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosGlobales.permitirSoloIngresoNumerico(e);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosGlobales.permitirSoloIngresoAlfabeticoConBlancos(e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosGlobales.permitirSoloIngresoAlfabeticoConBlancos(e);
        }

        private void txtCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosGlobales.permitirSoloIngresoAlfanumericoConBlancos(e);
        }

        private void txtDeptoLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosGlobales.permitirSoloIngresoAlfanumerico(e);
        }

        private void txtLocalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosGlobales.permitirSoloIngresoAlfanumericoConBlancos(e);
        }

        private void txtPisoManzana_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosGlobales.permitirSoloIngresoAlfanumerico(e);
        }

        private void txtCodigoPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosGlobales.permitirSoloIngresoAlfanumerico(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosGlobales.permitirSoloIngresoNumerico(e);
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosGlobales.permitirSoloIngresoCorreoElectronico(e);
        }

        protected void prepararFormularioSegunRol(String textoFuncion, String textoTipo)
        {
            if (SingletonDatosUsuario.Instance.rol.soyAdministrador())
            {
                prepararRolAdministrador(textoTipo, textoFuncion);
            }
            else
            {
                prepararRolGenerico(textoTipo);
            }
            this.Text = textoFuncion + " " + textoTipo;
            ((TextBox)(this.Controls["grupoDatosPersona"]).Controls["txtNombre"]).Focus();
            ((Button)(this.Controls["grupoDatosPersona"]).Controls["btnAceptar"]).Text = textoFuncion + " " + textoTipo;
        }

        protected void prepararRolGenerico(String tipoRol)
        {
            this.Controls["grupoBusquedaABM"].Visible = false;
            cargarDatosEnFormulario(tipoRol);
        }

        private void cargarDatosEnFormulario(String tipoRol)
        {
            completarFormularioConDatosDeUsuarioSeleccionado(buscarDatos(tipoRol));
        }

        private DataRowView buscarDatos(String tipoRol)
        {
            GD1C2017DataSetTableAdapters.PRC_BUSCAR_CHOFERTableAdapter adaptador =
                new GD1C2017DataSetTableAdapters.PRC_BUSCAR_CHOFERTableAdapter();
            return (tipoRol.ToLower().Equals("chofer")) ? adaptador.buscarDatosDeChofer(
                SingletonDatosUsuario.Instance.obtenerIdPersona()).DefaultView[0]
                : adaptador.buscarDatosDeCliente(
                SingletonDatosUsuario.Instance.obtenerIdPersona()).DefaultView[0];
        }

        protected void prepararRolAdministrador(String textoTipo, String textoFuncion)
        {
            this.Controls["grupoDatosPersona"].Visible = false;
            (((GroupBox)this.Controls["grupoBusquedaABM"]).Controls["btnBuscar"]).Text = "Buscar " + textoTipo;
            this.tipoUsuario = textoTipo;
            this.tipoFuncion = textoFuncion;
        }


        protected void construirNombreBotonAceptar(String nombre)
        {
            ((Button)(obtenerControlesDeGrupo("grupoDatosPersona").
                Controls["btnAceptar"])).Text = nombre;
        }

        public Control.ControlCollection obtenerGrupoControlesDelFormulario(String nombreGrupoDeControles)
        {
            return (Controls[nombreGrupoDeControles]).Controls;
        }

        protected GroupBox obtenerControlesDeGrupo(String nombreGrupo)
        {
            return (GroupBox)this.Controls[nombreGrupo];
        }

        public virtual bool verificarDatosDeFormulario()
        {
            return 
            Validaciones.validarCampoAlfabeticoConEspacio(this.Controls["grupoDatosPersona"].Controls["txtNombre"].Text) &&
            Validaciones.validarCampoAlfabeticoConEspacio(this.Controls["grupoDatosPersona"].Controls["txtApellido"].Text) &&
            Validaciones.validarCorreoElectronico(this.Controls["grupoDatosPersona"].Controls["txtCorreo"].Text) &&
            Validaciones.validarCampoAlfanumericoConEspacio(this.Controls["grupoDatosPersona"].Controls["txtLocalidad"].Text) &&
            Validaciones.validarCodigoPostal(this.Controls["grupoDatosPersona"].Controls["txtCodigoPostal"].Text) &&
            Validaciones.validarCampoAlfanumericoConEspacio(this.Controls["grupoDatosPersona"].Controls["txtCalle"].Text) &&
            Validaciones.validarCampoAlfanumerico(this.Controls["grupoDatosPersona"].Controls["txtDeptoLote"].Text) &&
            Validaciones.validarCampoAlfanumerico(this.Controls["grupoDatosPersona"].Controls["txtPisoManzana"].Text) &&
            validacionesSegunFuncion();
        }

        protected virtual Boolean validacionesSegunFuncion()
        {
            return Validaciones.validarCampoNumerico(this.txtTelefono.Text) &&
                    Validaciones.validarCampoNumerico(this.txtDNI.Text);
        }
    }

    public partial class frmClienteChoferAgregar : frmABM
    {
        public override Boolean construite(String rolParaAlta)
        {
            this.Controls["grupoBusquedaABM"].Visible = false;
            this.Text = "Agregar " + rolParaAlta;
            ((TextBox)(this.Controls["grupoDatosPersona"]).Controls["txtNombre"]).Focus();
            ((Button)(this.Controls["grupoDatosPersona"]).Controls["btnAceptar"]).Text = this.Text;
            construirBotonAccion(rolParaAlta);
            return true;
        }
        
        public override void construirBotonAccion(String rolParaAlta)
        {
            construirNombreBotonAceptar("Agregar " + rolParaAlta);
            (this.Controls["grupoDatosPersona"]).Controls["btnAceptar"].Click += (sender, e) =>
                SingletonDatosUsuario.Instance.rol.accionBotonClienteChofer(
                sender, e, this, "Agregar", rolParaAlta,
                obtenerGrupoControlesDelFormulario("grupoDatosPersona")
            );
        }

        protected override Boolean validacionesSegunFuncion()
        {
            return Validaciones.validarCampoDNI(this.txtDNI.Text)
                    && Validaciones.validarCampoTelefono(this.txtTelefono.Text);
        }

        public override void mensajeAutoEliminacionYSalidaDeAplicacion()
        {
            
        }
    }

    public partial class frmClienteChoferModificar : frmABM
    {
        public override Boolean construite(String rolParaAlta)
        {
            prepararFormularioSegunRol("Modificar", rolParaAlta);
            construirBotonAccion(rolParaAlta);
            return true;
        }
    
        public override void construirBotonAccion(String rolParaAlta)
        {
            construirNombreBotonAceptar("Modificar " + rolParaAlta);
            (this.Controls["grupoDatosPersona"]).Controls["btnAceptar"].Click += (sender, e) =>
                SingletonDatosUsuario.Instance.rol.accionBotonClienteChofer(
                sender, e, this, "Modificar", rolParaAlta,
                obtenerGrupoControlesDelFormulario("grupoDatosPersona")
            );
        }

        public override void accionesAdicionales()
        {
            this.Controls["grupoDatosPersona"].Visible = true;
        }

    }

    public partial class frmClienteChoferEliminar : frmABM
    {
        public override Boolean construite(String rolParaAlta)
        {
            prepararFormularioSegunRol("Eliminar", rolParaAlta);
            construirBotonAccion(rolParaAlta);
            return true;
        }

        public override void construirBotonAccion(String rolParaAlta)
        {
            construirNombreBotonAceptar("Eliminar " + rolParaAlta);
            (this.Controls["grupoDatosPersona"]).Controls["btnAceptar"].Click += (sender, e) =>
                SingletonDatosUsuario.Instance.rol.accionBotonClienteChofer(
                sender, e, this, "Eliminar", rolParaAlta,
                this.idTipoRol
            );
        }

        public override bool verificarDatosDeFormulario()
        {
            return true;
        }

        public override void accionesAdicionales()
        {
            inhabilitarControles();
            this.Controls["grupoDatosPersona"].Visible = true;
        }

        private void inhabilitarControles()
        {
            ((TextBox)(this.Controls["grupoDatosPersona"]).Controls["txtNombre"]).ReadOnly = true;
            ((TextBox)(this.Controls["grupoDatosPersona"]).Controls["txtApellido"]).ReadOnly = true;
            ((TextBox)(this.Controls["grupoDatosPersona"]).Controls["txtDNI"]).ReadOnly = true;
            ((TextBox)(this.Controls["grupoDatosPersona"]).Controls["txtCalle"]).ReadOnly = true;
            ((TextBox)(this.Controls["grupoDatosPersona"]).Controls["txtDeptoLote"]).ReadOnly = true;
            ((TextBox)(this.Controls["grupoDatosPersona"]).Controls["txtLocalidad"]).ReadOnly = true;
            ((TextBox)(this.Controls["grupoDatosPersona"]).Controls["txtCorreo"]).ReadOnly = true;
            ((TextBox)(this.Controls["grupoDatosPersona"]).Controls["txtTelefono"]).ReadOnly = true;
            ((TextBox)(this.Controls["grupoDatosPersona"]).Controls["txtPisoManzana"]).ReadOnly = true;
            ((TextBox)(this.Controls["grupoDatosPersona"]).Controls["txtCodigoPostal"]).ReadOnly = true;
            ((DateTimePicker)(this.Controls["grupoDatosPersona"]).Controls["selectorFechaNacimiento"]).Enabled = false; 
            ((CheckBox)(this.Controls["grupoDatosPersona"]).Controls["ccHabilitado"]).Enabled = false;
        }

        public override void mensajeAutoEliminacionYSalidaDeAplicacion()
        {
            DialogResult resultado = MessageBox.Show("¿Esta segura/o de eliminar este rol?", "Eliminar Rol",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show(
                    "La aplicacion se cerrara, debido a que usted dio de baja su rol si posee otro rol,"
                    + " debera iniciar e ingresar nuevamente al sistema con otro rol.", "Salida de la aplicacion",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }
        }

        protected override DataTable obtenerTablaDeDatosDeUsuario()
        {
            GD1C2017DataSetTableAdapters.PRC_OBTENER_DATOS_USUARIOSTableAdapter adaptador
            = new GD1C2017DataSetTableAdapters.PRC_OBTENER_DATOS_USUARIOSTableAdapter();
            return (esVacioONuloDNI()) ?
                adaptador.obtenerDatosUsuario(this.tipoUsuario, this.txtBusquedaNombre.Text, this.txtBusquedaApellido.Text, null, true, true)
                : adaptador.obtenerDatosUsuario(this.tipoUsuario, this.txtBusquedaNombre.Text, this.txtBusquedaApellido.Text, int.Parse(this.txtBusquedaDNI.Text), true, true);
        }
    }
}
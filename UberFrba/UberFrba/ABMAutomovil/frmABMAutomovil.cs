﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
    public partial class frmAutomovil : Form, IGrilla
    {

        public int idAutomovil { set; get; }

        public virtual void configurarEstadoFormulario()
        {
        }

        public frmAutomovil()
        {
            InitializeComponent();
        }
        
        public Control.ControlCollection obtenerGrupoControlesDeDatosDeAutomovil(String nombreGrupoDeControles)
        {
            return (Controls[nombreGrupoDeControles]).Controls;
        }

        public virtual Boolean construite()
        { return false; }

        protected void desabilitarGrupoControlesDeBusqueda()
        {
            ((GroupBox)(obtenerControlesDeGrupo("grupoBusquedaABM")
                )).Enabled = false;
            ((GroupBox)(obtenerControlesDeGrupo("grupoBusquedaABM")
                )).Visible = false;
                
        }

        protected void construirNombreBotonAceptar(String nombre)
        {
            ((Button)(obtenerControlesDeGrupo("grupoDatosAutomovil").
                Controls["btnAceptar"])).Text = nombre;
        }

        protected void asociarModeloASeleccionDeMarca()
        {
            ((ComboBox)(obtenerControlesDeGrupo("grupoDatosAutomovil")
                .Controls["comboMarca"])).SelectedIndexChanged += (sender, e) => comboMarcaSelectedIndexChanged(sender, e);
        }

        protected void habilitarGrupoDatosAutomovil()
        {
            actualizarEstadoHabilitacionGrupoDatosAutomovil(true);
        }

        protected void actualizarEstadoHabilitacionGrupoDatosAutomovil(Boolean estado)
        {
            obtenerControlesDeGrupo("grupoDatosAutomovil").Enabled = estado;
        }

        protected void construirComboTurno()
        {
            GD1C2017DataSetTableAdapters.PRC_LISTADO_TURNOS_DISPONIBLESTableAdapter adaptador
                    = new GD1C2017DataSetTableAdapters.PRC_LISTADO_TURNOS_DISPONIBLESTableAdapter();
            DataTable tblTurnosDisponibles = adaptador.obtenerTurnosDisponibles("%");
            ComboBox frmAutomovilComboTurno = (ComboBox)obtenerControlesDeGrupo("grupoDatosAutomovil").Controls["comboTurno"];
            frmAutomovilComboTurno.DataSource = tblTurnosDisponibles;
            frmAutomovilComboTurno.DisplayMember = "Turno_Descripcion";
            frmAutomovilComboTurno.ValueMember = "Turno_Id";
        }

        protected GroupBox obtenerControlesDeGrupo(String nombreGrupo)
        {
            return (GroupBox)this.Controls[nombreGrupo];
        }

        protected void construirComboMarca(String grupo, String combo)
        {
            GD1C2017DataSetTableAdapters.PRC_LISTA_MARCATableAdapter adaptador
                    = new GD1C2017DataSetTableAdapters.PRC_LISTA_MARCATableAdapter();
            DataTable tblMarcas = adaptador.obtenerListadoMarcasAutomovil();
            ComboBox frmAutomovilComboMarca = (ComboBox)this.Controls[grupo].Controls[combo];
            frmAutomovilComboMarca.DataSource = tblMarcas;
            frmAutomovilComboMarca.DisplayMember = "Marca_Nombre";
            frmAutomovilComboMarca.ValueMember = "Marca_Id";
        }

        protected void construirComboModelo()
        {
            GD1C2017DataSetTableAdapters.PRC_LISTA_MODELO_X_MARCATableAdapter adaptador
                    = new GD1C2017DataSetTableAdapters.PRC_LISTA_MODELO_X_MARCATableAdapter();
            int idMarca = (int)((ComboBox)obtenerControlesDeGrupo(
                "grupoDatosAutomovil").Controls["comboMarca"]).SelectedValue;
            DataTable tblModelos = adaptador.obtenerModeloSegunMarca(Convert.ToInt32(idMarca));
            ComboBox frmAutomovilComboModelo = (ComboBox)this.Controls["grupoDatosAutomovil"].Controls["comboModelo"];
            frmAutomovilComboModelo.DataSource = tblModelos;
            frmAutomovilComboModelo.DisplayMember = "Modelo_Nombre";
            frmAutomovilComboModelo.ValueMember = "Modelo_Id";
        }

        protected Boolean construirComboChofer(int idAuto)
        {
            ComboBox frmAutomovilComboChofer = (ComboBox)this.Controls["grupoDatosAutomovil"].Controls["comboChofer"];
            if (!MetodosGlobales.armarComboSeleccionSegunRol(obtenerAdaptadorParaConsulta(idAuto), frmAutomovilComboChofer))
            {
                dispararMensajeYCancelarAccion();
                this.Close();
                return false;
            }
            return true;
        }

        protected virtual DataTable obtenerAdaptadorParaConsulta(int idAuto)
        {
            GD1C2017DataSetTableAdapters.PRC_LISTA_CHOFERES_POSIBLESTableAdapter adaptador =
            new GD1C2017DataSetTableAdapters.PRC_LISTA_CHOFERES_POSIBLESTableAdapter();
            return adaptador.obtenerChoferesHabilitados(idAuto);
        }

        public void dispararMensajeYCancelarAccion()
        {           
            DialogResult resultado = MessageBox.Show("No hay choferes disponibles para asociar.", "Agregar Automovil",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected void comboMarcaSelectedIndexChanged(object sender, EventArgs e)
        {
            construirComboModelo();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable tblListadoAutomoviles = obtenerTablaDeDatos();
            MethodInfo metodoAEjecutar = this.GetType().GetMethod("configuracionesAdicionalesGrillaABMAutomovil", BindingFlags.NonPublic | BindingFlags.Instance);
            ArmadoGrilla.construirGrillaSiHayResultados(tblListadoAutomoviles, metodoAEjecutar, this, true);
        }

        protected void configuracionesAdicionalesGrillaABMAutomovil(frmGrilla formularioGrilla)
        {
            formularioGrilla.Controls["btnSeleccionar"].Text = "Seleccionar Automovil";
            formularioGrilla.Show();
        }

        public void cerrar()
        {
            this.Close();
        }

        public void mensajeNoHayDatosParaGrilla()
        {
            MessageBox.Show("No Existe Automovil habilitado, coincidente con los parametros de busqueda.",
                    "Automovil No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public virtual DataTable obtenerTablaDeDatos()
        {
            return new DataTable();
        }


        public void completarFormularioConDatosDeUsuarioSeleccionado(DataRowView filaDeDatos)
        {
            construirComboChofer((int)filaDeDatos.Row["Auto_id"]);
            habilitarGrupoDatosAutomovil();
            construirComboTurno();
            construirComboMarca("grupoDatosAutomovil", "comboMarca");
            construirComboModelo();
            asociarModeloASeleccionDeMarca();
            construirBotonAccion();
            poblarDatosDelFormulario(filaDeDatos);
            configurarEstadoFormulario();
        }

        public virtual void construirBotonAccion()
        {
        }

        protected void poblarDatosDelFormulario(DataRowView filaDeDatos)
        {
            ((ComboBox)(this.Controls["grupoDatosAutomovil"]).Controls["comboMarca"]).Text
                = (String)filaDeDatos.Row["Marca_Nombre"];
            ((ComboBox)(this.Controls["grupoDatosAutomovil"]).Controls["comboTurno"]).Text
                = (String)filaDeDatos.Row["Turno_Descripcion"];
            ((ComboBox)(this.Controls["grupoDatosAutomovil"]).Controls["comboModelo"]).Text
                = (String)filaDeDatos.Row["Modelo_Nombre"];
            ((ComboBox)(this.Controls["grupoDatosAutomovil"]).Controls["comboChofer"]).Text
                = (String)filaDeDatos.Row["Persona_Apellido"] + " " + (String)filaDeDatos.Row["Persona_Nombre"];
            ((TextBox)(this.Controls["grupoDatosAutomovil"]).Controls["txtPatente"]).Text
                = (String)filaDeDatos.Row["Auto_Patente"];
            ((CheckBox)(this.Controls["grupoDatosAutomovil"]).Controls["ccHabilitado"]).Checked
                = (Boolean)filaDeDatos.Row["Auto_Habilitado"];

            this.idAutomovil = (int)filaDeDatos.Row["Auto_id"];
            this.lblIdAuto.Text = Convert.ToString(this.idAutomovil);
            asociarModeloASeleccionDeMarca();
        }

        public virtual bool verificarDatosDeFormulario()
        {
            return
            Validaciones.validarPatente(this.Controls["grupoDatosAutomovil"].Controls["txtPatente"].Text)
            && validacionesAdicionales();
        }

        protected virtual bool validacionesAdicionales()
        {
            return true;
        }

        private void txtBusquedaPatente_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosGlobales.permitirSoloIngresoAlfanumerico(e);
        }

        private void txtBusquedaModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosGlobales.permitirSoloIngresoAlfanumericoConBlancos(e);
        }

        private void txtBusquedaNombreChofer_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosGlobales.permitirSoloIngresoAlfabeticoConBlancos(e);
        }

        private void txtBusquedaApellidoChofer_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosGlobales.permitirSoloIngresoAlfabeticoConBlancos(e);
        }

        private void txtPatente_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosGlobales.permitirSoloIngresoAlfanumerico(e);
        }
    }

    public partial class frmAutomovilEliminar:frmAutomovil
    {

        public override Boolean construite()
        {
            this.Text = "Eliminar Automovil";
            try
            {
                actualizarEstadoHabilitacionGrupoDatosAutomovil(false);
                construirComboMarca("grupoBusquedaABM", "comboMarcaBusqueda");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("No fue posible ejecutar el formulario.",
                    "Error en formulario ABM Automovil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        
        public override void construirBotonAccion()
        {
            construirNombreBotonAceptar("Eliminar Automovil");
            (this.Controls["grupoDatosAutomovil"]).Controls["btnAceptar"].Click += (sender, e) =>
               SingletonDatosUsuario.Instance.rol.accionBotonAutomovil(sender, e, this, "Eliminar", "Automovil",
               this.idAutomovil);
        }

        public override bool verificarDatosDeFormulario()
        {
            return true;
        }

        public override void configurarEstadoFormulario()
        {
            (this.Controls["grupoDatosAutomovil"].Controls["comboMarca"]).Enabled = false;
            (this.Controls["grupoDatosAutomovil"].Controls["comboModelo"]).Enabled = false;
            (this.Controls["grupoDatosAutomovil"].Controls["comboTurno"]).Enabled = false;
            (this.Controls["grupoDatosAutomovil"].Controls["comboChofer"]).Enabled = false;
            ((TextBox)this.Controls["grupoDatosAutomovil"].Controls["txtPatente"]).ReadOnly = true;
            (this.Controls["grupoDatosAutomovil"].Controls["ccHabilitado"]).Enabled = false;
        }

        public override DataTable obtenerTablaDeDatos()
        {
            GD1C2017DataSetTableAdapters.PRC_LISTADO_AUTOS_SIN_CONDITableAdapter adaptador =
                new GD1C2017DataSetTableAdapters.PRC_LISTADO_AUTOS_SIN_CONDITableAdapter();
            return adaptador.obtenerListadoAutos(
                 this.Controls["grupoBusquedaABM"].Controls["comboMarcaBusqueda"].Text
                , this.Controls["grupoBusquedaABM"].Controls["txtBusquedaModelo"].Text
                , this.Controls["grupoBusquedaABM"].Controls["txtBusquedaPatente"].Text
                , this.Controls["grupoBusquedaABM"].Controls["txtBusquedaNombreChofer"].Text
                , this.Controls["grupoBusquedaABM"].Controls["txtBusquedaApellidoChofer"].Text);
        }
    }

    public partial class frmAutomovilAgregar:frmAutomovil
    {
        public override Boolean construite()
        {
            this.Text = "Agregar Automovil";
            Boolean continua = construirComboChofer(0);
            if (continua)
            {
                desabilitarGrupoControlesDeBusqueda();
                construirComboTurno();
                construirComboMarca("grupoDatosAutomovil", "comboMarca");
                construirComboModelo();
                asociarModeloASeleccionDeMarca();
                construirBotonAccion();
            }
            return continua;
        }

        public override void construirBotonAccion()
        {
            construirNombreBotonAceptar("Agregar Automovil");
            (this.Controls["grupoDatosAutomovil"]).Controls["btnAceptar"].Click += (sender, e) =>
                SingletonDatosUsuario.Instance.rol.accionBotonAutomovil(sender, e, this, "Agregar", "Automovil",
                obtenerGrupoControlesDeDatosDeAutomovil("grupoDatosAutomovil"));
        }

        protected override bool validacionesAdicionales()
        {
           Boolean resultado = false;
            try
            {
                resultado = !MetodosGlobales.existePatente(this.txtPatente.Text);
            }
            catch (PatenteDuplicadoException e)
            {
                MessageBox.Show("La Patente no puede ser duplicado.", "Error Patente Duplicado",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        protected override DataTable obtenerAdaptadorParaConsulta(int datoNoUtilizado)
        {
            GD1C2017DataSetTableAdapters.PRC_LISTA_CHOFERES_NO_ASIGTableAdapter adaptador =
            new GD1C2017DataSetTableAdapters.PRC_LISTA_CHOFERES_NO_ASIGTableAdapter();
            return adaptador.obtenerChoferesHabilitados();
        }
    }

    public partial class frmAutomovilModificar:frmAutomovil
    {
        public override Boolean construite()
        {
            this.Text = "Modificar Automovil";
            try
            {
                actualizarEstadoHabilitacionGrupoDatosAutomovil(false);
                construirComboMarca("grupoBusquedaABM", "comboMarcaBusqueda");
                return true;
            }
            catch (Exception e)
            {
                //TODO: mensaje aviso
                return false;
            }
        }

        public override void construirBotonAccion()
        {
            construirNombreBotonAceptar("Modificar Automovil");
            (this.Controls["grupoDatosAutomovil"]).Controls["btnAceptar"].Click += (sender, e) =>
                SingletonDatosUsuario.Instance.rol.accionBotonAutomovil(
                sender, e, this, "Modificar", "Automovil",
                obtenerGrupoControlesDeDatosDeAutomovil("grupoDatosAutomovil")
                );
        }

        public override DataTable obtenerTablaDeDatos()
        {
            GD1C2017DataSetTableAdapters.PRC_LISTADO_AUTOS_SIN_CONDI_PARA_MODIFICACIONTableAdapter adaptador =
                new GD1C2017DataSetTableAdapters.PRC_LISTADO_AUTOS_SIN_CONDI_PARA_MODIFICACIONTableAdapter();
            return adaptador.obtenerListadoAutosSegunDatosBusqueda(
                 this.Controls["grupoBusquedaABM"].Controls["comboMarcaBusqueda"].Text
                , this.Controls["grupoBusquedaABM"].Controls["txtBusquedaModelo"].Text
                , this.Controls["grupoBusquedaABM"].Controls["txtBusquedaPatente"].Text
                , this.Controls["grupoBusquedaABM"].Controls["txtBusquedaNombreChofer"].Text
                , this.Controls["grupoBusquedaABM"].Controls["txtBusquedaApellidoChofer"].Text);
        }

        public override void configurarEstadoFormulario()
        {

        }
    }
}

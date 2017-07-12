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
using UberFrba.Clases;

namespace UberFrba
{
    public partial class frmRendirViaje : Form, IGrilla
    {
        public frmRendirViaje()
        {
            InitializeComponent();
            this.selectorDiaRendicionAChofer.MaxDate = FechaAplicacion.obtenerFechaAplicacion();
        }

        public Boolean construite()
        {
            Boolean continuar = MetodosGlobales.construirComboChofer(this, "Choferes", "Rendir Viajes de Chofer");
            if (continuar)
            {
                construirComboTurno();
                ((ComboBox)this.Controls["comboChofer"]).SelectedIndexChanged += (sender, e) =>
                comboChoferModificacionEnSeleccion(sender, e);
            }
            return continuar;
        }

        private void comboChoferModificacionEnSeleccion(object sender, EventArgs e)
        {
            GD1C2017DataSetTableAdapters.PRC_LISTADO_UNI_DISPONIBLE_X_CHOTableAdapter adaptador
                    = new GD1C2017DataSetTableAdapters.PRC_LISTADO_UNI_DISPONIBLE_X_CHOTableAdapter();
            DataTable tblTurnosDisponibles = adaptador.obtenerListadoTurnosYAutomovilesSegunChofer((int)((ComboBox)this.Controls["comboChofer"]).SelectedValue);
            if (tblTurnosDisponibles.Rows.Count > 0)
            {
                ComboBox frmAutomovilComboTurno = (ComboBox)this.Controls["comboTurno"];
                frmAutomovilComboTurno.DataSource = tblTurnosDisponibles;
                frmAutomovilComboTurno.DisplayMember = "Turno_Descripcion";
                frmAutomovilComboTurno.ValueMember = "Turno_Id";
            }
            else
            {
                MessageBox.Show("No hay turno asociado al Automovil"
                        , "Datos Vacios"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Information);
            }
        }

        private void construirComboTurno()
        {
            GD1C2017DataSetTableAdapters.PRC_LISTADO_UNI_DISPONIBLE_X_CHOTableAdapter adaptador
                    = new GD1C2017DataSetTableAdapters.PRC_LISTADO_UNI_DISPONIBLE_X_CHOTableAdapter();
            DataTable tblTurnosDisponibles = adaptador.obtenerListadoTurnosYAutomovilesSegunChofer((int)((ComboBox)this.Controls["comboChofer"]).SelectedValue);
            ComboBox frmRendirViajeComboTurno = (ComboBox)this.Controls["comboTurno"];
            frmRendirViajeComboTurno.DataSource = tblTurnosDisponibles;
            frmRendirViajeComboTurno.DisplayMember = "Turno_Descripcion";
            frmRendirViajeComboTurno.ValueMember = "Turno_Id";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DataTable tblViajesARendir = obtenerTablaDatosCabeceraRendicion();
            MethodInfo metodoAEjecutar = this.GetType().GetMethod("configuracionesAdicionalesGrillaCabeceraRendicion", BindingFlags.NonPublic | BindingFlags.Instance);
            ArmadoGrilla.construirGrillaSiHayResultados(tblViajesARendir, metodoAEjecutar, this, false);
        }

        private void configuracionesAdicionalesGrillaCabeceraRendicion(frmGrilla formularioGrilla)
        {
            formularioGrilla.Controls["btnVerDetalles"].Visible = true;
            formularioGrilla.Controls["btnVerDetalles"].Click += (sender, e) =>
                verDetalleViajes(sender, e, formularioGrilla);
            formularioGrilla.Controls["btnSeleccionar"].Text = "Rendir Viajes";
            formularioGrilla.Controls["btnSeleccionar"].Click += (senders, es) =>
            rendirViajes(senders, es, formularioGrilla);
            formularioGrilla.Show();
        }

        private DataTable obtenerTablaDatosCabeceraRendicion()
        {
            GD1C2017DataSetTableAdapters.PRC_REGISTRO_VIAJETableAdapter adaptador =
                new GD1C2017DataSetTableAdapters.PRC_REGISTRO_VIAJETableAdapter();
            DataTable tblViajesARendir = adaptador.listadoEncabezadoRendiciones((int)this.comboChofer.SelectedValue,
                Convert.ToDateTime(this.selectorDiaRendicionAChofer.Value.ToString("dd/MM/yyyy")),
                (int)this.comboTurno.SelectedValue);
            return tblViajesARendir;
        }

        public void mensajeNoHayDatosParaGrilla()
        {
            MessageBox.Show("No hay Viajes a Rendir"
                        , "Datos Vacios"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Information);
        }

        public void cerrar()
        {
            this.Close();
        }

        private void verDetalleViajes(object sender, EventArgs e, frmGrilla formularioGrilla)
        {
            DataRowView fila = ((DataRowView)(((DataGridView)formularioGrilla.Controls["grillaDatos"]).CurrentRow).DataBoundItem);
            completarFormularioConDatosDeUsuarioSeleccionado(fila);
        }

        private void rendirViajes(object sender, EventArgs e, frmGrilla formulario)
        {
            GD1C2017DataSetTableAdapters.QueriesTableAdapter adaptador =
               new GD1C2017DataSetTableAdapters.QueriesTableAdapter();
            object resultado = adaptador.insertarRendicion(
                (int)this.comboChofer.SelectedValue, this.selectorDiaRendicionAChofer.Value,
            (int)this.comboTurno.SelectedValue
            );
            formulario.Close();
        }

        public void completarFormularioConDatosDeUsuarioSeleccionado(DataRowView filaDeDatos)
        {
            DataTable tblViajesARendir = obtenerTablaDatosDetalleRendicionViajes();
            MethodInfo metodoAEjecutar = this.GetType().GetMethod("configuracionesAdicionalesGrillaDetalleRendicion", BindingFlags.NonPublic | BindingFlags.Instance);
            ArmadoGrilla.construirGrillaSiHayResultados(tblViajesARendir, metodoAEjecutar, this, false);
        }

        private void configuracionesAdicionalesGrillaDetalleRendicion(frmGrilla formularioGrillaDetalleViajesRendir)
        {
            formularioGrillaDetalleViajesRendir.Controls["btnSeleccionar"].Visible = false;
            formularioGrillaDetalleViajesRendir.Controls["btnCancelar"].Text = "Volver";
            formularioGrillaDetalleViajesRendir.Show();
        }

        private DataTable obtenerTablaDatosDetalleRendicionViajes()
        {
            GD1C2017DataSetTableAdapters.FN_VIAJES_A_RENDIRTableAdapter adaptador =
                new GD1C2017DataSetTableAdapters.FN_VIAJES_A_RENDIRTableAdapter();
            DataTable tblViajesARendir = adaptador.viajesARendir((int)this.comboChofer.SelectedValue,
                this.selectorDiaRendicionAChofer.Value.ToString("dd/MM/yyyy"),
                (int)this.comboTurno.SelectedValue);
            return tblViajesARendir;
        }
    }
}
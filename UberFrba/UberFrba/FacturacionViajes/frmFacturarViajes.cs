using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Clases;

namespace UberFrba
{
    public partial class frmFacturarViaje : Form, IGrilla
    {
        public frmFacturarViaje()
        {
            InitializeComponent();
            this.selectorFechaFacturacionHasta.MinDate = new DateTime((FechaAplicacion.obtenerFechaAplicacion()).Year, (FechaAplicacion.obtenerFechaAplicacion()).Month, 1);
            this.selectorFechaFacturacionHasta.MaxDate = FechaAplicacion.obtenerFechaAplicacion();
        }

        public Boolean construite()
        {
            return construirComboCliente();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GD1C2017DataSetTableAdapters.PRC_FACTURAR_A_CLIENTETableAdapter adaptador =
                new GD1C2017DataSetTableAdapters.PRC_FACTURAR_A_CLIENTETableAdapter();
            //GD1C2017DataSetTableAdapters.FN_VIAJES_A_FACTURARTableAdapter adaptador =
                    //new GD1C2017DataSetTableAdapters.FN_VIAJES_A_FACTURARTableAdapter();
            //DataTable tblViajesAFacturar = adaptador.viajesAFacturar((int)this.comboCliente.SelectedValue,
            DataTable tblViajesAFacturar = adaptador.listaCabecerasFactura((int)this.comboCliente.SelectedValue,
                Convert.ToDateTime(this.selectorFechaFacturacionHasta.Value.ToString("dd/MM/yyyy")));
            if (tblViajesAFacturar.Rows.Count > 0)
            {
                frmGrilla formularioGrilla = new frmGrilla();
                DataGridView grillaInformacionFacturacion = (DataGridView)formularioGrilla.Controls["grillaDatos"];
                grillaInformacionFacturacion.DataSource = tblViajesAFacturar;
                grillaInformacionFacturacion.ReadOnly = true;
                grillaInformacionFacturacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                grillaInformacionFacturacion.AutoGenerateColumns = true;
                formularioGrilla.formulario = this;
                formularioGrilla.Controls["btnVerDetalles"].Visible = true;
                formularioGrilla.Controls["btnVerDetalles"].Click += (senders, es) =>
                    verDetalleViajes(sender, e, formularioGrilla);
                formularioGrilla.Controls["btnSeleccionar"].Text = "Facturar Viajes";
                formularioGrilla.Controls["btnSeleccionar"].Click += (senders, es) =>
                    facturarViajes(sender, e, formularioGrilla);
                formularioGrilla.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("No hay Viajes a Facturar"
                        , "Datos Vacios"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Information);
            }
        }

        private void verDetalleViajes(object sender, EventArgs e, frmGrilla formularioGrilla)
        {
            DataRowView fila = ((DataRowView)(((DataGridView)formularioGrilla.Controls["grillaDatos"]).CurrentRow).DataBoundItem);
            completarFormularioConDatosDeUsuarioSeleccionado(fila);
        }

        private void facturarViajes(object sender, EventArgs e, frmGrilla formularioResultadoBusqueda)
        {
            GD1C2017DataSetTableAdapters.QueriesTableAdapter adaptador =
               new GD1C2017DataSetTableAdapters.QueriesTableAdapter();
            adaptador.insertarFactura(
                (int)this.comboCliente.SelectedValue,
                this.selectorFechaFacturacionHasta.Value);
            formularioResultadoBusqueda.Close();
        }

        private Boolean construirComboCliente()
        {
            GD1C2017DataSetTableAdapters.PRC_BUSCAR_CLIENTE_HABILITADOTableAdapter adaptador
                   = new GD1C2017DataSetTableAdapters.PRC_BUSCAR_CLIENTE_HABILITADOTableAdapter();
            DataTable tblCliente = adaptador.obtenerListadoClientesHabilitados();
            ComboBox frmFacturarViajeComboCliente = (ComboBox)this.Controls["comboCliente"];
            if (!MetodosGlobales.armarComboSeleccionSegunRol(tblCliente, frmFacturarViajeComboCliente))
            {
                MetodosGlobales.dispararMensajeYCancelarAccion("Clientes", "Factura Viajes");
                this.Close();
                return false;
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void completarFormularioConDatosDeUsuarioSeleccionado(DataRowView filaDeDatos)
        {
             GD1C2017DataSetTableAdapters.FN_VIAJES_A_FACTURARTableAdapter adaptador =
                    new GD1C2017DataSetTableAdapters.FN_VIAJES_A_FACTURARTableAdapter();
            DataTable tblDetalleViajes = adaptador.viajesAFacturar((int)this.comboCliente.SelectedValue,
                this.selectorFechaFacturacionHasta.Value.ToString("dd/MM/yyyy"));
            if (tblDetalleViajes.Rows.Count > 0)
            {
                frmGrilla formularioGrillaDetalleViajes = new frmGrilla();
                DataGridView grillaDetalleViajes = (DataGridView)formularioGrillaDetalleViajes.Controls["grillaDatos"];
                grillaDetalleViajes.DataSource = tblDetalleViajes;
                grillaDetalleViajes.ReadOnly = true;
                grillaDetalleViajes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                grillaDetalleViajes.AutoGenerateColumns = true;
                formularioGrillaDetalleViajes.formulario = this;
                formularioGrillaDetalleViajes.Controls["btnSeleccionar"].Visible = false;
                formularioGrillaDetalleViajes.Controls["btnCancelar"].Text = "Volver";
                
                formularioGrillaDetalleViajes.Show();
                this.Close();
            }
        }
    }
}
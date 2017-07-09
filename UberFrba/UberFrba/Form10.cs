using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba
{
    public partial class frmFacturarViaje : Form
    {
        public frmFacturarViaje()
        {
            InitializeComponent();
            this.selectorFechaFacturacionHasta.MinDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); 
            this.selectorFechaFacturacionHasta.MaxDate = DateTime.Now;
        }

        public Boolean construite()
        {
            return construirComboCliente();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            GD1C2017DataSetTableAdapters.FN_VIAJES_A_FACTURARTableAdapter adaptador =
                new GD1C2017DataSetTableAdapters.FN_VIAJES_A_FACTURARTableAdapter();
            DataTable tblViajesAFacturar = adaptador.viajesAFacturar((int)this.comboCliente.SelectedValue,
                Convert.ToString(this.selectorFechaFacturacionHasta.Value.ToShortDateString()));
            frmResultadoBusquedaUsuarioABM formularioResultadoBusqueda = new frmResultadoBusquedaUsuarioABM();
            DataGridView grillaBusquedaUsuarios = (DataGridView)formularioResultadoBusqueda.Controls["grillaDatosResultadoBusqueda"];
            grillaBusquedaUsuarios.DataSource = tblViajesAFacturar;
            grillaBusquedaUsuarios.ReadOnly = true;
            grillaBusquedaUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grillaBusquedaUsuarios.AutoGenerateColumns = true;
            formularioResultadoBusqueda.Controls["btnSeleccionar"].Text = "Facturar Viajes";
            formularioResultadoBusqueda.Controls["btnSeleccionar"].Click += (senders, es) =>
                facturarViajes(sender, e, formularioResultadoBusqueda);
            formularioResultadoBusqueda.Show();
        }

        private void facturarViajes(object sender, EventArgs e, frmResultadoBusquedaUsuarioABM formularioResultadoBusqueda)
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
    }
}
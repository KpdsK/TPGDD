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

namespace UberFrba
{
    public partial class frmListados : Form
    {
        public frmListados()
        {
            InitializeComponent();
            this.selectorAnio.MaxDate = DateTime.Now;
            armarComboListados();
        }

        private void armarComboListados()
        {
            var diccionarioDatosListado = new Dictionary<String, String>();
            diccionarioDatosListado.Add("listadoChoferConMayorRecaudacion",
                "Chóferes con mayor recaudación");
            diccionarioDatosListado.Add("listadoChoferConViajeMasLargoRealizado",
                "Choferes con el viaje más largo realizado");
            diccionarioDatosListado.Add("listadoClienteConMayorConsumo",
                "Clientes con mayor consumo");
            diccionarioDatosListado.Add("listadoClienteUtilizoMasVecesElMismoAuto",
                "Cliente que utilizo más veces mismo automóvil");
            this.comboListados.DataSource = new BindingSource(diccionarioDatosListado, null);
            this.comboListados.DisplayMember = "Value";
            this.comboListados.ValueMember = "Key";
        }

        public void construite()
        {
            this.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            MethodInfo methodInfo = this.GetType().GetMethod((String)this.comboListados.SelectedValue, BindingFlags.NonPublic | BindingFlags.Instance);
            methodInfo.Invoke(this, new object[] {});
        }

        private void listadoChoferConMayorRecaudacion()
        {
            GD1C2017DataSetTableAdapters.CHOFERES_MAYOR_RECAUDACIONTableAdapter adaptador =
                new GD1C2017DataSetTableAdapters.CHOFERES_MAYOR_RECAUDACIONTableAdapter();
            DataTable tblListadoChoferesMayorRecaudacion = 
                adaptador.listadoChoferesConMayorRecaudacion(
                (int)(this.selectorTrimestre.Value),
                (int)this.selectorAnio.Value.Year);

            construirFormularioGrilla(tblListadoChoferesMayorRecaudacion);
        }

        private void construirFormularioGrilla(DataTable tblListadoChoferesMayorRecaudacion)
        {
            frmResultadoBusquedaUsuarioABM formularioListado = new frmResultadoBusquedaUsuarioABM();
            DataGridView grillaListados = (DataGridView)formularioListado.Controls["grillaDatosResultadoBusqueda"];
            grillaListados.DataSource = tblListadoChoferesMayorRecaudacion;
            grillaListados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grillaListados.AutoGenerateColumns = true;
            formularioListado.Controls["btnSeleccionar"].Visible = false;
            formularioListado.Controls["btnCancelar"].Text = "Salir";
            formularioListado.Controls["btnCancelar"].Left =
                (this.ClientSize.Width -
                formularioListado.Controls["btnCancelar"].Width) / 2;
            this.Close();
            formularioListado.Show();
        }

        private void listadoChoferConViajeMasLargoRealizado()
        {
            GD1C2017DataSetTableAdapters.CHOFERES_VIAJE_MAS_LARGOTableAdapter adaptador =
                new GD1C2017DataSetTableAdapters.CHOFERES_VIAJE_MAS_LARGOTableAdapter();
            DataTable tblListadoChoferesConViajeMasLargo =
                adaptador.listadoChoferesViajeMasLargo(
                (int)(this.selectorTrimestre.Value),
                (int)this.selectorAnio.Value.Year);

            construirFormularioGrilla(tblListadoChoferesConViajeMasLargo);
        }

        private void listadoClienteConMayorConsumo()
        {
            GD1C2017DataSetTableAdapters.CLIENTES_MAYOR_CONSUMOTableAdapter adaptador =
                new GD1C2017DataSetTableAdapters.CLIENTES_MAYOR_CONSUMOTableAdapter();
            DataTable tblListadoChoferesConViajeMasLargo =
                adaptador.listadoClientesConMayorConsumo(
                (int)(this.selectorTrimestre.Value),
                (int)this.selectorAnio.Value.Year);

            construirFormularioGrilla(tblListadoChoferesConViajeMasLargo);
        }

        private void listadoClienteUtilizoMasVecesElMismoAuto()
        {
            GD1C2017DataSetTableAdapters.CLIENTES_MAS_VECES_MISMO_AUTOTableAdapter adaptador =
                new GD1C2017DataSetTableAdapters.CLIENTES_MAS_VECES_MISMO_AUTOTableAdapter();
            DataTable tblListadoChoferesMayorRecaudacion =
                adaptador.listadoClienteConMayorCantidadDeVecesUtilizoMismaUnidad(
                (int)(this.selectorTrimestre.Value),
                (int)this.selectorAnio.Value.Year);

            construirFormularioGrilla(tblListadoChoferesMayorRecaudacion);
        }
    }
}
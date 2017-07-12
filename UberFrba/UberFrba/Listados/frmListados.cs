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
    public partial class frmListados : Form, IGrilla
    {
        public frmListados()
        {
            InitializeComponent();
            this.selectorAnio.MaxDate = FechaAplicacion.obtenerFechaAplicacion();
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

        public void mensajeNoHayDatosParaGrilla()
        {
            MessageBox.Show("No hay turno asociado al Automovil"
                        , "Datos Vacios"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Information);
        }

        public void cerrar()
        {
            this.Close();
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

        private void construirFormularioGrilla(DataTable tablaConDatosListados)
        {
            MethodInfo metodoAEjecutar = this.GetType().GetMethod("configuracionesAdicionalesGrillaListados", BindingFlags.NonPublic | BindingFlags.Instance);
            ArmadoGrilla.construirGrillaSiHayResultados(tablaConDatosListados, metodoAEjecutar, this, false);
        }

        private void configuracionesAdicionalesGrillaListados(frmGrilla formularioGrilla)
        {
            formularioGrilla.Controls["btnSeleccionar"].Visible = false;
            ((DataGridView)formularioGrilla.Controls["grillaDatos"]).ReadOnly = true;
            formularioGrilla.Controls["btnCancelar"].Text = "Salir";
            formularioGrilla.Controls["btnCancelar"].Left =
                (this.ClientSize.Width -
                formularioGrilla.Controls["btnCancelar"].Width) / 2;
            this.Close();
            formularioGrilla.Show();
        }

        public void completarFormularioConDatosDeUsuarioSeleccionado(DataRowView filaDeDatos)
        {
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
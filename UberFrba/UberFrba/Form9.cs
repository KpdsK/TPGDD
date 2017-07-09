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
    public partial class frmRendirViaje : Form
    {
        public frmRendirViaje()
        {
            InitializeComponent();
            this.selectorDiaRendicionAChofer.MaxDate = DateTime.Now;
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
            GD1C2017DataSetTableAdapters.FN_VIAJES_A_RENDIRTableAdapter adaptador =
                new GD1C2017DataSetTableAdapters.FN_VIAJES_A_RENDIRTableAdapter();
            DataTable tblViajesARendir = adaptador.viajesARendir((int)this.comboChofer.SelectedValue,
                Convert.ToString(this.selectorDiaRendicionAChofer.Value.ToShortDateString()),
                (int)this.comboTurno.SelectedValue);
            frmResultadoBusquedaUsuarioABM formularioResultadoBusqueda = new frmResultadoBusquedaUsuarioABM();
            DataGridView grillaBusquedaUsuarios = (DataGridView)formularioResultadoBusqueda.Controls["grillaDatosResultadoBusqueda"];
            grillaBusquedaUsuarios.DataSource = tblViajesARendir;
            grillaBusquedaUsuarios.ReadOnly = true;
            grillaBusquedaUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grillaBusquedaUsuarios.AutoGenerateColumns = true;
            formularioResultadoBusqueda.Controls["btnSeleccionar"].Text = "Rendir Viajes";
            formularioResultadoBusqueda.Controls["btnSeleccionar"].Click += (senders, es) => 
                rendirViajes(sender, e, formularioResultadoBusqueda);
            formularioResultadoBusqueda.Show();
        }

        private void rendirViajes(object sender, EventArgs e, frmResultadoBusquedaUsuarioABM formulario)
        {
            GD1C2017DataSetTableAdapters.QueriesTableAdapter adaptador =
               new GD1C2017DataSetTableAdapters.QueriesTableAdapter();
            object resultado = adaptador.insertarRendicion(
                (int)this.comboChofer.SelectedValue, this.selectorDiaRendicionAChofer.Value,
            (int)this.comboTurno.SelectedValue
            );
            formulario.Close();
        }
    }
}
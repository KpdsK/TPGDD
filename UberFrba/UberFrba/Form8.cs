using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba
{
    public partial class frmRegistroViaje : Form
    {

        public string idAuto { get; set; }
        public frmRegistroViaje()
        {
            InitializeComponent();
        }

        public Boolean construite()
        {
            Boolean continua = MetodosGlobales.construirComboChofer(this, "Choferes", "Registrar Viaje") && construirComboCliente();
            if (continua)
            {
                construirComboTurno();
                ((ComboBox)this.Controls["comboChofer"]).SelectedIndexChanged += (sender, e) =>
                comboChoferModificacionEnSeleccion(sender, e);
            }
            return continua;
        }

        private Boolean construirComboCliente()
        {
            GD1C2017DataSetTableAdapters.PRC_BUSCAR_CLIENTE_HABILITADOTableAdapter adaptador
                   = new GD1C2017DataSetTableAdapters.PRC_BUSCAR_CLIENTE_HABILITADOTableAdapter();
            DataTable tblCliente = adaptador.obtenerListadoClientesHabilitados();
            ComboBox frmRendirViajeComboCliente = (ComboBox)this.Controls["comboCliente"];
            if (!MetodosGlobales.armarComboSeleccionSegunRol(tblCliente, frmRendirViajeComboCliente))
            {
                MetodosGlobales.dispararMensajeYCancelarAccion("Clientes", "Registrar Viaje");
                this.Close();
                return false;
            }
            return true;
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
                this.Controls["txtAutomovil"].Text = Convert.ToString(((DataRowView)frmAutomovilComboTurno.SelectedItem)["Auto_Detalle"]);
                this.idAuto = Convert.ToString(((DataRowView)frmAutomovilComboTurno.SelectedItem)["Auto_Id"]);
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
            ComboBox frmAutomovilComboTurno = (ComboBox)this.Controls["comboTurno"];
            frmAutomovilComboTurno.DataSource = tblTurnosDisponibles;
            frmAutomovilComboTurno.DisplayMember = "Turno_Descripcion";
            frmAutomovilComboTurno.ValueMember = "Turno_Id";
            this.Controls["txtAutomovil"].Text = Convert.ToString(((DataRowView)frmAutomovilComboTurno.SelectedItem)["Auto_Detalle"]);
            this.idAuto = Convert.ToString(((DataRowView)frmAutomovilComboTurno.SelectedItem)["Auto_Id"]);
        }

        private void comboTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox frmAutomovilComboTurno = (ComboBox)this.Controls["comboTurno"];
            this.Controls["txtAutomovil"].Text = Convert.ToString(((DataRowView)frmAutomovilComboTurno.SelectedItem)["Auto_Detalle"]);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                GD1C2017DataSetTableAdapters.QueriesTableAdapter adaptador =
                    new GD1C2017DataSetTableAdapters.QueriesTableAdapter();
                adaptador.registrarViaje(
                    (int)this.comboChofer.SelectedValue, (int)this.comboCliente.SelectedValue,
                        Convert.ToInt32(this.idAuto), (int)this.comboTurno.SelectedValue,
                        Convert.ToDecimal(this.txtCantidadKilometros.Text), (DateTime)this.selectorDiaHoraInicio.Value,
                        (DateTime)this.selectorDiaHoraFin.Value
                    );
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la creacion del viaje. Probablemente este duplicado."
                        , "Error Creacion de viaje"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Error);
            }

        }

        public virtual bool verificarDatosDeFormulario()
        {
            return
            Validaciones.validarCampoNumerico(this.txtCantidadKilometros.Text);
        }

        private void txtCantidadKilometros_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosGlobales.permitirSoloIngresoNumerico(e);
        }

        
    }
}
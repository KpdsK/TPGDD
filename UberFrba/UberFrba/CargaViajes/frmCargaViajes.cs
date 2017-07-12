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
            configurarLimitesDeHorarios(frmAutomovilComboTurno);
            this.txtAutomovil.Text = Convert.ToString(((DataRowView)frmAutomovilComboTurno.SelectedItem)["Auto_Detalle"]);
            this.idAuto = Convert.ToString(((DataRowView)frmAutomovilComboTurno.SelectedItem)["Auto_Id"]);
        }

        private void configurarLimitesDeHorarios(ComboBox frmAutomovilComboTurno)
        {
            String horaInicio = Convert.ToString(((DataRowView)frmAutomovilComboTurno.SelectedItem)["Turno_Hora_Inicio"]);
            String horaFin = Convert.ToString(((DataRowView)frmAutomovilComboTurno.SelectedItem)["Turno_Hora_Fin"]);
            limpiarLimites(this.selectorDiaHoraInicio);
            limpiarLimites(this.selectorDiaHoraFin);
            this.selectorDiaHoraInicio.MinDate = obtenerFechaHora(horaInicio);
            this.selectorDiaHoraInicio.MaxDate = obtenerFechaHora(horaFin);
            this.selectorDiaHoraFin.MinDate = obtenerFechaHora(horaInicio);
            this.selectorDiaHoraFin.MaxDate = obtenerFechaHora(horaFin);
        }

        private void limpiarLimites(DateTimePicker selectorHorario)
        {
            selectorHorario.MinDate = obtenerFechaHora("00");
            selectorHorario.MaxDate = obtenerFechaHora("24");
        }

        private static DateTime obtenerFechaHora(String hora)
        {
            return DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy ") + (!hora.Equals("24") ? hora + ":00:00" : "23:59:59"));
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (verificarDatosDeFormulario())
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
            else
            {
                MessageBox.Show("El horario de inicio y fin del viaje debe ser distinto."
                            , "Error Rango Horario"
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Information);
            }
        }

        public virtual bool verificarDatosDeFormulario()
        {
            return
            Validaciones.validarCampoNumerico(this.txtCantidadKilometros.Text)
            && DateTime.Compare(this.selectorDiaHoraInicio.Value, this.selectorDiaHoraFin.Value) < 0;
        }

        private void txtCantidadKilometros_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosGlobales.permitirSoloIngresoNumerico(e);
        }

        private void comboTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox frmAutomovilComboTurno = (ComboBox)this.Controls["comboTurno"];
            this.Controls["txtAutomovil"].Text = Convert.ToString(((DataRowView)frmAutomovilComboTurno.SelectedItem)["Auto_Detalle"]);
            configurarLimitesDeHorarios(frmAutomovilComboTurno);
        }
    }
}
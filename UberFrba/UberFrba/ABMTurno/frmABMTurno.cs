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
    public partial class frmABMTurno : Form, IGrilla
    {
        public frmABMTurno()
        {
            InitializeComponent();
            this.selectorHoraFin.Value = 23;
            this.selectorHoraInicio.Value = 0;
        }

        public virtual Boolean construite()
        { return false; }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable tblListadoTurnos = obtenerTablaDeDatos();
            MethodInfo metodoAEjecutar = this.GetType().GetMethod("configuracionesAdicionalesGrillaABMTurnos", BindingFlags.NonPublic | BindingFlags.Instance);
            ArmadoGrilla.construirGrillaSiHayResultados(tblListadoTurnos, metodoAEjecutar, this, true);
        }

        public void mensajeNoHayDatosParaGrilla()
        {
            MessageBox.Show("No Existe Turno habilitado, coincidente con los parametros de busqueda.",
                    "Automovil No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected void configuracionesAdicionalesGrillaABMTurnos(frmGrilla formularioGrilla)
        {
            formularioGrilla.Controls["btnSeleccionar"].Text = "Seleccionar Turno";
            formularioGrilla.Show();
        }

        public virtual DataTable obtenerTablaDeDatos()
        {
            return new DataTable();
        }

        public void completarFormularioConDatosDeUsuarioSeleccionado(DataRowView filaDeDatos)
        {
            limpiarSelectoresHorario();
            this.selectorHoraInicio.Value = Convert.ToInt16(filaDeDatos.Row["Turno_Hora_Inicio"].ToString());
            this.selectorHoraFin.Value = Convert.ToInt16(filaDeDatos.Row["Turno_Hora_Fin"].ToString());
            this.txtValorKilometro.Text = filaDeDatos.Row["Turno_Valor_Kilometro"].ToString();
            this.txtPrecioBase.Text = filaDeDatos.Row["Turno_Precio_Base"].ToString();
            this.txtDescripcion.Text = filaDeDatos.Row["Turno_Descripcion"].ToString();
            this.lblIdTurno.Text = filaDeDatos.Row["Turno_Id"].ToString();
            this.ccHabilitado.Checked = (Boolean)filaDeDatos.Row["Turno_Habilitado"];
            accionesAdicionales();
        }

        private void limpiarSelectoresHorario()
        {
            this.selectorHoraInicio.Minimum = 0;
            this.selectorHoraInicio.Maximum = 23;
            this.selectorHoraFin.Minimum = 1;
            this.selectorHoraFin.Maximum = 24;
        }

        public void cerrar()
        {
            this.Close();
        }

        public virtual void construirBotonAccion()
        {
        }

        public virtual void accionesAdicionales()
        {
        }

        protected void construirNombreBotonAceptar(String nombre)
        {
            ((Button)(obtenerControlesDeGrupo("grupoDatosTurno").
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual Boolean verificarDatosDeFormulario()
        {
            return
            Validaciones.validarCampoNumericoCon2Decimales(this.txtValorKilometro.Text) &&
            Validaciones.validarCampoNumericoCon2Decimales(this.txtPrecioBase.Text) &&
            Validaciones.validarCampoAlfanumericoConEspacio(this.txtDescripcion.Text) &&
            validacionesSegunFuncion();
        }

        protected virtual Boolean validacionesSegunFuncion()
        {
            return Validaciones.validarCampoHorario(Convert.ToString(this.selectorHoraInicio.Value)) &&
            Validaciones.validarCampoHorario(Convert.ToString(this.selectorHoraFin.Value)) &&
            Validaciones.validarRangoHorario(Convert.ToInt16(this.selectorHoraInicio.Value),
                Convert.ToInt16(this.selectorHoraFin.Value));
        }

        private void txtBusquedaDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosGlobales.permitirSoloIngresoAlfanumerico(e);
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosGlobales.permitirSoloIngresoAlfanumerico(e);
        }

        private void txtValorKilometro_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosGlobales.permitirSoloIngresoCon2Decimales(e);
        }

        private void txtPrecioBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetodosGlobales.permitirSoloIngresoCon2Decimales(e);
        }

        private void selectorHoraInicio_ValueChanged(object sender, EventArgs e)
        {
            this.selectorHoraFin.Minimum = this.selectorHoraInicio.Value + 1;
        }

        private void selectorHoraFin_ValueChanged(object sender, EventArgs e)
        {
            this.selectorHoraInicio.Maximum = this.selectorHoraFin.Value - 1;
        }
    }

    public partial class frmTurnoAgregar : frmABMTurno
    {
        public override Boolean construite()
        {
            this.Text = "Agregar Turno";
            this.Controls["grupoBusquedaTurno"].Visible = false;
            construirBotonAccion();
            return true;
        }

        public override void construirBotonAccion()
        {
            construirNombreBotonAceptar("Agregar Turno");
            (this.Controls["grupoDatosTurno"]).Controls["btnAceptar"].Click += (sender, e) =>
                SingletonDatosUsuario.Instance.rol.accionBotonTurno(
                sender, e, this, "Agregar", "Turno",
                obtenerGrupoControlesDelFormulario("grupoDatosTurno")
            );
        }

        protected override Boolean validacionesSegunFuncion()
        {
            Boolean resultado = false;
            try
            {
                resultado = MetodosGlobales.validarExistenciaDeRango(
                Convert.ToInt16(this.selectorHoraInicio.Value),
                Convert.ToInt16(this.selectorHoraFin.Value));
            } catch (TelefonoDuplicadoException e)
            {
                MessageBox.Show("El Rango tiene coincidencias con los existentes.", "Error Rango",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }
    }

    public partial class frmTurnoEliminar : frmABMTurno
    {
        public override Boolean construite()
        {
            this.Text = "Eliminar Turno";
            this.Controls["grupoDatosTurno"].Visible = false;
            construirBotonAccion();
            return true;
        }

        public override void construirBotonAccion()
        {
            construirNombreBotonAceptar("Eliminar Turno");
            (this.Controls["grupoDatosTurno"]).Controls["btnAceptar"].Click += (sender, e) =>
                SingletonDatosUsuario.Instance.rol.accionBotonTurno(
                sender, e, this, "Eliminar", "Turno",
                Convert.ToInt32(obtenerGrupoControlesDelFormulario("grupoDatosTurno")["lblIdTurno"].Text)
            );
        }

        public override bool verificarDatosDeFormulario()
        {
            return true;
        }

        public override void accionesAdicionales()
        {
            inhabilitarControles();
            this.grupoDatosTurno.Visible = true;
        }

        private void inhabilitarControles()
        {
            ((NumericUpDown)(this.selectorHoraInicio)).ReadOnly = true;
            ((NumericUpDown)(this.selectorHoraFin)).ReadOnly = true;
            this.txtValorKilometro.ReadOnly = true;
            this.txtPrecioBase.ReadOnly = true;
            this.txtDescripcion.ReadOnly = true;
            this.ccHabilitado.Enabled=false;
        }

        public override DataTable obtenerTablaDeDatos()
        {
            GD1C2017DataSetTableAdapters.PRC_LISTADO_TURNOS_DISPONIBLESTableAdapter adaptador =
                new GD1C2017DataSetTableAdapters.PRC_LISTADO_TURNOS_DISPONIBLESTableAdapter();
            return adaptador.obtenerTurnosDisponibles(
                this.Controls["grupoBusquedaTurno"].Controls["txtBusquedaDescripcion"].Text);
        }
    }
    
    public partial class frmTurnoModificar : frmABMTurno
    {
        public override Boolean construite()
        {
            this.Text = "Modificar Turno";
            this.Controls["grupoDatosTurno"].Visible = false;
            construirBotonAccion();
            return true;
        }

        public override void construirBotonAccion()
        {
            construirNombreBotonAceptar("Modificar Turno");
            (this.Controls["grupoDatosTurno"]).Controls["btnAceptar"].Click += (sender, e) =>
                SingletonDatosUsuario.Instance.rol.accionBotonTurno(
                sender, e, this, "Modificar", "Turno",
                obtenerGrupoControlesDelFormulario("grupoDatosTurno")
            );
        }

        public override void accionesAdicionales()
        {
            this.Controls["grupoDatosTurno"].Visible = true;
            this.Controls["grupoDatosTurno"].Enabled = true;
        }
        
        public override DataTable obtenerTablaDeDatos()
        {
            GD1C2017DataSetTableAdapters.PRC_LISTADO_TURNOS_COMPLETOTableAdapter adaptador =
                new GD1C2017DataSetTableAdapters.PRC_LISTADO_TURNOS_COMPLETOTableAdapter();
            return adaptador.obtenerListadoTurnosCompleto(
                this.Controls["grupoBusquedaTurno"].Controls["txtBusquedaDescripcion"].Text);
        }
    }
}
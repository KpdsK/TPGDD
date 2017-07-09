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
    public partial class frmResultadoBusquedaUsuarioABM : Form
    {
        public frmABM formularioABM { set; get; }
        public frmAutomovil frmAutomovil { set; get; }
        public frmABMTurno frmTurno { set; get; }

        public frmResultadoBusquedaUsuarioABM()
        {
            InitializeComponent();
        }

        private void grillaDatosResultadoBusqueda_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            completarFormularioABMConDatosDeUsuarioSeleccionado();
        }

        private void completarFormularioABMConDatosDeUsuarioSeleccionado()
        {
            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            DataRowView row = ((DataRowView)(this.grillaDatosResultadoBusqueda.CurrentRow).DataBoundItem);

            obtenerFormulario().completarFormularioConDatosDeUsuarioSeleccionado(row);

            this.Close();
        }

        private IGrilla obtenerFormulario()
        {
            Form formulario;
            if (formularioABM != null)
            {
                formulario = formularioABM;
            }
            else
            {
                if (frmAutomovil != null)
                {
                    formulario = frmAutomovil;
                }
                else
                {
                    formulario = frmTurno;
                }
            }
            return (IGrilla)formulario;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            completarFormularioABMConDatosDeUsuarioSeleccionado();
        }

        private void frmResultadoBusquedaUsuarioABM_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
    }
}
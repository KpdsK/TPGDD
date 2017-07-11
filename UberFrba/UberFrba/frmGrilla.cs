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
    public partial class frmGrilla : Form
    {
        public IGrilla formulario { set; get; }

        public frmGrilla()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            ejecutarEventoSeleccionDeFila();
        }

        public virtual void ejecutarEventoSeleccionDeFila()
        {
        }

        private void frmResultadoBusquedaUsuarioABM_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void grillaDatos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ejecutarEventoSeleccionDeFila();
        }
    }

    public partial class frmGrillaParaBusquedaConSeleccionDeFilas : frmGrilla
    {
        public override void ejecutarEventoSeleccionDeFila()
        {
            DataRowView row = ((DataRowView)(this.grillaDatos.CurrentRow).DataBoundItem);
            this.formulario.completarFormularioConDatosDeUsuarioSeleccionado(row);
            this.Close();
        }

    }
}
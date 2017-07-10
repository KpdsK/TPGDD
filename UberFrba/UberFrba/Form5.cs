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
        //public frmABM formularioABM { set; get; }
        //public frmAutomovil frmAutomovil { set; get; }
        //public frmABMTurno frmTurno { set; get; }
        //public frmListados frmListados { set; get; }

        public IGrilla formulario { set; get; }

        public frmGrilla()
        {
            InitializeComponent();
        }

        //private void completarFormularioABMConDatosDeUsuarioSeleccionado()
        //{
        //    ////System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
        //    //DataRowView row = ((DataRowView)(this.grillaDatosResultadoBusqueda.CurrentRow).DataBoundItem);

        //    //obtenerFormulario().completarFormularioConDatosDeUsuarioSeleccionado(row);

        //    //this.Close();
        //}

        //private IGrilla obtenerFormulario()
        //{
        //    Form formulario;
        //    if (formularioABM != null)
        //    {
        //        formulario = formularioABM;
        //    }
        //    else
        //    {
        //        if (frmAutomovil != null)
        //        {
        //            formulario = frmAutomovil;
        //        }
        //        else
        //        {
        //            if (frmTurno != null)
        //            {
        //                formulario = frmTurno;
        //            }
        //            else
        //            {
        //                formulario = frmListados;
        //            }
        //        }
        //    }
        //    return (IGrilla)formulario;
        //}

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            //completarFormularioABMConDatosDeUsuarioSeleccionado();
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

    //public partial class frmGrillaParaVisualizarInformacionSinSeleccion : frmGrilla
    //{

    //}
}
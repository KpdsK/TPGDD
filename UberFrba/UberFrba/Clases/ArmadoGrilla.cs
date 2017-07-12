using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Clases
{
    static class ArmadoGrilla
    {
        public static void construirGrillaSiHayResultados(DataTable tablaDatos, MethodInfo metodo, IGrilla formulario)
        {
            if (tablaDatos.Rows.Count > 0)
            {
                frmGrilla formularioGrilla = construirFormularioGrilla(tablaDatos, formulario);
                metodo.Invoke(formulario, new object[] { formularioGrilla });
                formulario.cerrar();
            }
            else
            {
                formulario.mensajeNoHayDatosParaGrilla();
            }
        }

        public static frmGrilla construirFormularioGrilla(DataTable tablaDatos, IGrilla formulario)
        {
            frmGrilla formularioGrilla = new frmGrilla();
            DataGridView grillaInformacion = (DataGridView)formularioGrilla.Controls["grillaDatos"];
            grillaInformacion.DataSource = tablaDatos;
            grillaInformacion.ReadOnly = true;
            grillaInformacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grillaInformacion.AutoGenerateColumns = true;
            formularioGrilla.formulario = formulario;
            return formularioGrilla;
        }
    }
}

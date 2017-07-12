﻿using System;
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
        public static void construirGrillaSiHayResultados(DataTable tablaDatos, MethodInfo metodo, IGrilla formulario, Boolean conSeleccionDeFilas)
        {

            if (tablaDatos != null && tablaDatos.Rows.Count > 0)
            {
                object formularioGrilla;
                if (conSeleccionDeFilas)
                {
                    formularioGrilla = (frmGrillaParaBusquedaConSeleccionDeFilas)
                        construirFormularioGrillaConSeleccion(tablaDatos, formulario);
                }
                else
                {
                    formularioGrilla = (frmGrilla) construirFormularioGrilla(tablaDatos, formulario);
                }
                metodo.Invoke(formulario, new object[] { formularioGrilla });
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
            formulario.cerrar();
            return formularioGrilla;
        }

        public static frmGrillaParaBusquedaConSeleccionDeFilas construirFormularioGrillaConSeleccion(DataTable tablaDatos, IGrilla formulario)
        {
            frmGrillaParaBusquedaConSeleccionDeFilas formularioGrilla = new frmGrillaParaBusquedaConSeleccionDeFilas();
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba
{
    public partial class frmRoles : Form
    {
        public frmRoles()
        {
            InitializeComponent();
        }

        private ToolStripMenuItem dameUnItemDeMenu(string nombre)
        {
            return new ToolStripMenuItem(nombre);
        }

        private ToolStripMenuItem dameUnItemDeFuncion(string nombre, string nombreMetodo)
        {
            EventHandler handler = (sender, e) => ejecutarFuncion(sender, e, nombreMetodo);
            return new ToolStripMenuItem(nombre, null, handler, null);
        }

        private void ejecutarFuncion(object sender, EventArgs e, string nombreMetodo)
        {
            this.Hide();
            SingletonDatosUsuario.Instance.rol.ejecutarFuncion(nombreMetodo);
        }
        public class datosRol
        {
            public int id { set; get; }
            public String nombre { set; get; }
            public Boolean esAdmin { set; get; }

            public datosRol(int id, String nombre, Boolean esAdmin)
            {
                this.id = id;
                this.nombre = nombre;
                this.esAdmin = esAdmin;
            }
        }

        public static datosRol obtenerDatosDeRol(DataRowView itemRol)
        {
            return new datosRol(Convert.ToInt32(itemRol["Rol_Id"]),
                (String)itemRol["Rol_Nombre"],
                (Boolean)itemRol["esAdmin"]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            datosRol datosRol = obtenerDatosDeRol((DataRowView)this.comboRol.SelectedItem);
            this.Hide();
            SingletonDatosUsuario.Instance.configurarRol(datosRol.id, datosRol.nombre, datosRol.esAdmin);
            
            GD1C2017DataSetTableAdapters.PRC_OBTENER_MENU_X_ROLTableAdapter adaptador
                    = new GD1C2017DataSetTableAdapters.PRC_OBTENER_MENU_X_ROLTableAdapter();
            DataTable tblMenuSegunRol = adaptador.menuSegunRol(datosRol.id);

            frmPrincipal fmPrincipal = new frmPrincipal();
            MenuStrip fmPrincipalMenu = (MenuStrip)fmPrincipal.Controls["mnuPrincipal"];
            ToolStripMenuItem mnuAuxiliar=null, subMenuAuxiliar=null;

            foreach (DataRow fila in tblMenuSegunRol.Rows)
            {
                if (fila.Field<int>("Ascendente") == 0)
                {
                    if (fila.Field<string>("Metodo") == null)
                    {
                        if (mnuAuxiliar != null)
                        {
                            if (subMenuAuxiliar != null)
                            {
                                mnuAuxiliar.DropDownItems.Add(subMenuAuxiliar);
                                subMenuAuxiliar = null;
                            }
                            fmPrincipalMenu.Items.Add(mnuAuxiliar);
                            mnuAuxiliar = dameUnItemDeMenu(fila.Field<string>("Nombre"));
                        }
                        else
                        {
                            mnuAuxiliar = dameUnItemDeMenu(fila.Field<string>("Nombre"));
                        }
                    }
                    else
                    {
                        fmPrincipalMenu.Items.Add(dameUnItemDeFuncion(fila.Field<string>("Nombre"), fila.Field<string>("Metodo")));
                    }
                }
                else
                {
                    if (fila.Field<string>("Metodo") == null)
                    {
                        if (subMenuAuxiliar != null)
                        {
                            mnuAuxiliar.DropDownItems.Add(subMenuAuxiliar);
                            subMenuAuxiliar = dameUnItemDeMenu(fila.Field<string>("Nombre"));
                        }
                        else
                        {
                            subMenuAuxiliar = dameUnItemDeMenu(fila.Field<string>("Nombre"));
                        }
                    }
                    else
                    {
                        if (subMenuAuxiliar != null)
                        {
                            subMenuAuxiliar.DropDownItems.Add(dameUnItemDeFuncion(fila.Field<string>("Nombre"), fila.Field<string>("Metodo")));
                        }
                        else
                        {
                            mnuAuxiliar.DropDownItems.Add(dameUnItemDeFuncion(fila.Field<string>("Nombre"), fila.Field<string>("Metodo")));
                        }
                    }

                }
            }
            if (subMenuAuxiliar != null)
            {
                mnuAuxiliar.DropDownItems.Add(subMenuAuxiliar);
            }
            if (mnuAuxiliar != null)
            {
                fmPrincipalMenu.Items.Add(mnuAuxiliar);
            }
            EventHandler salida = new EventHandler(salirAplicacion);
            fmPrincipalMenu.Items.Add(new ToolStripMenuItem("Salir", null, salida, null));
            fmPrincipal.Show();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void salirAplicacion(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
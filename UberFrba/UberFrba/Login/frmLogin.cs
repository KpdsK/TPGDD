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
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace UberFrba
{
    public partial class frmIngreso : Form
    {
        static string sha256(string clave)
        {
            System.Security.Cryptography.SHA256Managed encriptador
                = new System.Security.Cryptography.SHA256Managed();
            System.Text.StringBuilder hash = new System.Text.StringBuilder();
            byte[] claveEncriptada
                = encriptador.ComputeHash(Encoding.UTF8.GetBytes(clave), 0, Encoding.UTF8.GetByteCount(clave));
            foreach (byte unByte in claveEncriptada)
            {
                hash.Append(unByte.ToString("x2"));
            }
            return hash.ToString();
        }

        class Usuario
        {
            private int idUsuario;
            private List<Tuple<int, String>> roles;

            public int obtenerIdUsuario()
            {
                return idUsuario;
            }

            public void setearIdUsuario(int usuario)
            {
                idUsuario = usuario;
            }

            public void agregarRol(int idRol, String rol)
            {
                roles.Add(new Tuple<int, String>(idRol, rol));
            }

            public List<Tuple<int, String>> obtenerRoles()
            {
                return roles;
            }
        }

        public frmIngreso()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (validarDatosDelFormulario())
            {
                GD1C2017DataSetTableAdapters.PRC_VALIDAR_USUARIOTableAdapter adaptador
                        = new GD1C2017DataSetTableAdapters.PRC_VALIDAR_USUARIOTableAdapter();
                DataTable tblUsuarioYRoles = adaptador.validarUsuario(textoUsuario.Text, sha256(textoClave.Text));
                List<Tuple<String, String>> roles = new List<Tuple<string, string>>();
                
                int codigoUsuario = tblUsuarioYRoles.Rows[0].Field<int>("UserId");
                String nombreUsuario = tblUsuarioYRoles.Rows[0].Field<String>("Nombre");
                String apellidoUsuario = tblUsuarioYRoles.Rows[0].Field<String>("Apellido");
                int idPersona = tblUsuarioYRoles.Rows[0].Field<int>("idPersona");

                switch (codigoUsuario)
                {
                    case -1:
                        MessageBox.Show("Usuario no existe.");
                        break;
                    case -2:
                        MessageBox.Show("Usuario/Rol Bloqueado o inhabilitado.");
                        break;
                    case -3:
                        MessageBox.Show("Usuario o Clave Incorrecta.");
                        break;
                    default:
                        this.Hide();
                        SingletonDatosUsuario datosUsuario = new SingletonDatosUsuario(codigoUsuario, textoUsuario.Text, nombreUsuario, apellidoUsuario, idPersona);
                        frmRoles fmRoles = new frmRoles();
                        ((ComboBox)fmRoles.Controls["comboRol"]).Focus();
                        ComboBox frmRolComboRol = (ComboBox)fmRoles.Controls["comboRol"];
                        frmRolComboRol.DataSource = tblUsuarioYRoles;
                        frmRolComboRol.DisplayMember = "Rol_Nombre";
                        frmRolComboRol.ValueMember = "Rol_Id";
                        fmRoles.Show();
                        break;
                }
            } else {
                MetodosGlobales.mansajeErrorValidacion();
            }
        }

        

        private bool validarDatosDelFormulario()
        {
            return (Validaciones.validarCampoAlfanumerico(textoUsuario.Text) 
                && Validaciones.validarCampoClave(textoClave.Text));
        }
    }
}
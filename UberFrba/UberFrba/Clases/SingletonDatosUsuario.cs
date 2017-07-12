using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba
{
    public class SingletonDatosUsuario
    {
        public class DatosUsuario
        {
            private int idPersona;
            public int IdPersona
            {
                get { return idPersona; }
                set { idPersona = value; }
            }
            private int idUsuario;
            public int IdUsuario
            {
                get { return idUsuario; }
                set { idUsuario = value; }
            }
            private int rolId;
            public int RolId
            {
                get { return rolId; }
                set { rolId = value; }
            }
            private int idTipoRol;
            public int IdTipoRol
            {
                get { return idTipoRol; }
                set { idTipoRol = value; }
            }
            private String nombreUsuario;
            public String NombreUsuario
            {
                get { return nombreUsuario; }
                set { nombreUsuario = value; }
            }
            private String nombre;
            public String Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }
            private String apellido;
            public String Apellido
            {
                get { return apellido; }
                set { apellido = value; }
            }
        }
        private static SingletonDatosUsuario instance;
        private DatosUsuario datosUsuario;
        public FuncionalidadSegunRol rol { set; get; }

        public SingletonDatosUsuario() { }
        public SingletonDatosUsuario(int id, String nombreUsuario, String nombre, String apellido, int idPersona)
        {
            datosUsuario = new DatosUsuario();
            this.datosUsuario.IdUsuario = id;
            this.datosUsuario.NombreUsuario = nombreUsuario;
            this.datosUsuario.Nombre = nombre;
            this.datosUsuario.Apellido = apellido;
            this.datosUsuario.IdPersona = idPersona;
            instance = this;
        }

        public void configurarRol(int idRol, String nombreRol, Boolean esAdmin)
        {
            rol = new FuncionalidadSegunRol(idRol, this.datosUsuario.IdUsuario, nombreRol, esAdmin);
        }

        public bool soyRolAdministrador(string nombreRol)
        {
            return this.rol.soyAdministrador();
        }

        public int obtenerIdUsuario()
        {
            return this.datosUsuario.IdUsuario;
        }

        public int obtenerIdTipoRol()
        {
            return this.datosUsuario.IdTipoRol;
        }

        public int obtenerIdRol()
        {
            return this.datosUsuario.RolId;
        }

        public void setearIdPersona(int idPersona)
        {
            this.datosUsuario.IdPersona = idPersona;
        }

        public int obtenerIdPersona()
        {
            return this.datosUsuario.IdPersona;
        }

        public void setearRolId(int rolId)
        {
            this.datosUsuario.RolId = rolId;
        }

        public void setearIdTipoRol(int idTipoRol)
        {
            this.datosUsuario.IdTipoRol = idTipoRol;
        }

        public static SingletonDatosUsuario Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonDatosUsuario();
                }
                return instance;
            }
        }
    }
}

namespace UberFrba
{
    partial class frmIngreso
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnIngresar = new System.Windows.Forms.Button();
            this.usuario = new System.Windows.Forms.Label();
            this.clave = new System.Windows.Forms.Label();
            this.textoClave = new System.Windows.Forms.TextBox();
            this.textoUsuario = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(69, 119);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(96, 30);
            this.btnIngresar.TabIndex = 4;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // usuario
            // 
            this.usuario.AutoSize = true;
            this.usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuario.Location = new System.Drawing.Point(7, 27);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(68, 20);
            this.usuario.TabIndex = 5;
            this.usuario.Text = "Usuario:";
            // 
            // clave
            // 
            this.clave.AutoSize = true;
            this.clave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clave.Location = new System.Drawing.Point(23, 73);
            this.clave.Name = "clave";
            this.clave.Size = new System.Drawing.Size(52, 20);
            this.clave.TabIndex = 6;
            this.clave.Text = "Clave:";
            // 
            // textoClave
            // 
            this.textoClave.AcceptsTab = true;
            this.textoClave.Location = new System.Drawing.Point(91, 73);
            this.textoClave.MaxLength = 16;
            this.textoClave.Name = "textoClave";
            this.textoClave.PasswordChar = '*';
            this.textoClave.Size = new System.Drawing.Size(133, 20);
            this.textoClave.TabIndex = 3;
            // 
            // textoUsuario
            // 
            this.textoUsuario.AcceptsTab = true;
            this.textoUsuario.Location = new System.Drawing.Point(91, 29);
            this.textoUsuario.MaxLength = 16;
            this.textoUsuario.Name = "textoUsuario";
            this.textoUsuario.Size = new System.Drawing.Size(133, 20);
            this.textoUsuario.TabIndex = 2;
            // 
            // frmIngreso
            // 
            this.AcceptButton = this.btnIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 174);
            this.Controls.Add(this.textoUsuario);
            this.Controls.Add(this.textoClave);
            this.Controls.Add(this.clave);
            this.Controls.Add(this.usuario);
            this.Controls.Add(this.btnIngresar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIngreso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label usuario;
        private System.Windows.Forms.Label clave;
        private System.Windows.Forms.TextBox textoClave;
        private System.Windows.Forms.TextBox textoUsuario;

    }
}


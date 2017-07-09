namespace UberFrba
{
    partial class frmRol
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cajaListaFuncionesSegunRol = new System.Windows.Forms.ListBox();
            this.cajaListaFunciones = new System.Windows.Forms.ListBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblNombreRol = new System.Windows.Forms.Label();
            this.lblCajaFuncionesSegunRol = new System.Windows.Forms.Label();
            this.lblFunciones = new System.Windows.Forms.Label();
            this.comboRol = new System.Windows.Forms.ComboBox();
            this.ccHabilitado = new System.Windows.Forms.CheckBox();
            this.txtModificarNombre = new System.Windows.Forms.TextBox();
            this.lblModificarNombre = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cajaListaFuncionesSegunRol
            // 
            this.cajaListaFuncionesSegunRol.FormattingEnabled = true;
            this.cajaListaFuncionesSegunRol.Location = new System.Drawing.Point(364, 66);
            this.cajaListaFuncionesSegunRol.Name = "cajaListaFuncionesSegunRol";
            this.cajaListaFuncionesSegunRol.Size = new System.Drawing.Size(221, 199);
            this.cajaListaFuncionesSegunRol.TabIndex = 0;
            // 
            // cajaListaFunciones
            // 
            this.cajaListaFunciones.FormattingEnabled = true;
            this.cajaListaFunciones.Location = new System.Drawing.Point(12, 66);
            this.cajaListaFunciones.Name = "cajaListaFunciones";
            this.cajaListaFunciones.Size = new System.Drawing.Size(221, 199);
            this.cajaListaFunciones.TabIndex = 1;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(275, 111);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(45, 31);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = ">";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(275, 161);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(45, 31);
            this.btnQuitar.TabIndex = 3;
            this.btnQuitar.Text = "<";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAceptar.Location = new System.Drawing.Point(125, 286);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(108, 30);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(364, 286);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(108, 30);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblNombreRol
            // 
            this.lblNombreRol.AutoSize = true;
            this.lblNombreRol.Location = new System.Drawing.Point(265, 2);
            this.lblNombreRol.Name = "lblNombreRol";
            this.lblNombreRol.Size = new System.Drawing.Size(63, 13);
            this.lblNombreRol.TabIndex = 63;
            this.lblNombreRol.Text = "Nombre Rol";
            // 
            // lblCajaFuncionesSegunRol
            // 
            this.lblCajaFuncionesSegunRol.AutoSize = true;
            this.lblCajaFuncionesSegunRol.Location = new System.Drawing.Point(421, 52);
            this.lblCajaFuncionesSegunRol.Name = "lblCajaFuncionesSegunRol";
            this.lblCajaFuncionesSegunRol.Size = new System.Drawing.Size(109, 13);
            this.lblCajaFuncionesSegunRol.TabIndex = 64;
            this.lblCajaFuncionesSegunRol.Text = "Funciones Segun Rol";
            // 
            // lblFunciones
            // 
            this.lblFunciones.AutoSize = true;
            this.lblFunciones.Location = new System.Drawing.Point(85, 53);
            this.lblFunciones.Name = "lblFunciones";
            this.lblFunciones.Size = new System.Drawing.Size(56, 13);
            this.lblFunciones.TabIndex = 65;
            this.lblFunciones.Text = "Funciones";
            // 
            // comboRol
            // 
            this.comboRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRol.FormattingEnabled = true;
            this.comboRol.Location = new System.Drawing.Point(202, 18);
            this.comboRol.Name = "comboRol";
            this.comboRol.Size = new System.Drawing.Size(195, 21);
            this.comboRol.TabIndex = 66;
            this.comboRol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboRol_KeyPress);
            // 
            // ccHabilitado
            // 
            this.ccHabilitado.AutoSize = true;
            this.ccHabilitado.Location = new System.Drawing.Point(457, 18);
            this.ccHabilitado.Name = "ccHabilitado";
            this.ccHabilitado.Size = new System.Drawing.Size(73, 17);
            this.ccHabilitado.TabIndex = 67;
            this.ccHabilitado.Text = "Habilitado";
            this.ccHabilitado.UseVisualStyleBackColor = true;
            // 
            // txtModificarNombre
            // 
            this.txtModificarNombre.Location = new System.Drawing.Point(12, 19);
            this.txtModificarNombre.MaxLength = 255;
            this.txtModificarNombre.Name = "txtModificarNombre";
            this.txtModificarNombre.Size = new System.Drawing.Size(174, 20);
            this.txtModificarNombre.TabIndex = 69;
            this.txtModificarNombre.Visible = false;
            // 
            // lblModificarNombre
            // 
            this.lblModificarNombre.AutoSize = true;
            this.lblModificarNombre.Location = new System.Drawing.Point(65, 2);
            this.lblModificarNombre.Name = "lblModificarNombre";
            this.lblModificarNombre.Size = new System.Drawing.Size(90, 13);
            this.lblModificarNombre.TabIndex = 68;
            this.lblModificarNombre.Text = "Modificar Nombre";
            this.lblModificarNombre.Visible = false;
            // 
            // frmRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(601, 332);
            this.Controls.Add(this.txtModificarNombre);
            this.Controls.Add(this.lblModificarNombre);
            this.Controls.Add(this.ccHabilitado);
            this.Controls.Add(this.comboRol);
            this.Controls.Add(this.lblFunciones);
            this.Controls.Add(this.lblCajaFuncionesSegunRol);
            this.Controls.Add(this.lblNombreRol);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.cajaListaFunciones);
            this.Controls.Add(this.cajaListaFuncionesSegunRol);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.ListBox cajaListaFuncionesSegunRol;
        protected System.Windows.Forms.ListBox cajaListaFunciones;
        protected System.Windows.Forms.Button btnAgregar;
        protected System.Windows.Forms.Button btnQuitar;
        protected System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        protected System.Windows.Forms.Label lblNombreRol;
        protected System.Windows.Forms.Label lblCajaFuncionesSegunRol;
        protected System.Windows.Forms.Label lblFunciones;
        protected System.Windows.Forms.ComboBox comboRol;
        protected System.Windows.Forms.CheckBox ccHabilitado;
        protected System.Windows.Forms.TextBox txtModificarNombre;
        protected System.Windows.Forms.Label lblModificarNombre;
    }
}
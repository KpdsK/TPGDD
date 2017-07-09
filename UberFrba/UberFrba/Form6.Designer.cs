namespace UberFrba
{
    partial class frmAutomovil
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
            this.grupoBusquedaABM = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBusquedaApellidoChofer = new System.Windows.Forms.TextBox();
            this.comboMarcaBusqueda = new System.Windows.Forms.ComboBox();
            this.lblNombreChofer = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBusquedaNombreChofer = new System.Windows.Forms.TextBox();
            this.lblBuscarDNI = new System.Windows.Forms.Label();
            this.lblBuscarApellido = new System.Windows.Forms.Label();
            this.lblBusquedaNombre = new System.Windows.Forms.Label();
            this.txtBusquedaModelo = new System.Windows.Forms.TextBox();
            this.txtBusquedaPatente = new System.Windows.Forms.TextBox();
            this.comboMarca = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPatente = new System.Windows.Forms.Label();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.lblTurno = new System.Windows.Forms.Label();
            this.comboTurno = new System.Windows.Forms.ComboBox();
            this.comboChofer = new System.Windows.Forms.ComboBox();
            this.lblChofer = new System.Windows.Forms.Label();
            this.grupoDatosAutomovil = new System.Windows.Forms.GroupBox();
            this.comboModelo = new System.Windows.Forms.ComboBox();
            this.ccHabilitado = new System.Windows.Forms.CheckBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.grupoBusquedaABM.SuspendLayout();
            this.grupoDatosAutomovil.SuspendLayout();
            this.SuspendLayout();
            // 
            // grupoBusquedaABM
            // 
            this.grupoBusquedaABM.Controls.Add(this.label1);
            this.grupoBusquedaABM.Controls.Add(this.txtBusquedaApellidoChofer);
            this.grupoBusquedaABM.Controls.Add(this.comboMarcaBusqueda);
            this.grupoBusquedaABM.Controls.Add(this.lblNombreChofer);
            this.grupoBusquedaABM.Controls.Add(this.btnBuscar);
            this.grupoBusquedaABM.Controls.Add(this.txtBusquedaNombreChofer);
            this.grupoBusquedaABM.Controls.Add(this.lblBuscarDNI);
            this.grupoBusquedaABM.Controls.Add(this.lblBuscarApellido);
            this.grupoBusquedaABM.Controls.Add(this.lblBusquedaNombre);
            this.grupoBusquedaABM.Controls.Add(this.txtBusquedaModelo);
            this.grupoBusquedaABM.Controls.Add(this.txtBusquedaPatente);
            this.grupoBusquedaABM.Location = new System.Drawing.Point(26, 5);
            this.grupoBusquedaABM.Name = "grupoBusquedaABM";
            this.grupoBusquedaABM.Size = new System.Drawing.Size(588, 99);
            this.grupoBusquedaABM.TabIndex = 31;
            this.grupoBusquedaABM.TabStop = false;
            this.grupoBusquedaABM.Text = "Busqueda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(469, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Chofer Apellido";
            // 
            // txtBusquedaApellidoChofer
            // 
            this.txtBusquedaApellidoChofer.Location = new System.Drawing.Point(427, 68);
            this.txtBusquedaApellidoChofer.Name = "txtBusquedaApellidoChofer";
            this.txtBusquedaApellidoChofer.Size = new System.Drawing.Size(156, 20);
            this.txtBusquedaApellidoChofer.TabIndex = 33;
            this.txtBusquedaApellidoChofer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusquedaApellidoChofer_KeyPress);
            // 
            // comboMarcaBusqueda
            // 
            this.comboMarcaBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMarcaBusqueda.FormattingEnabled = true;
            this.comboMarcaBusqueda.Location = new System.Drawing.Point(33, 26);
            this.comboMarcaBusqueda.Name = "comboMarcaBusqueda";
            this.comboMarcaBusqueda.Size = new System.Drawing.Size(174, 21);
            this.comboMarcaBusqueda.TabIndex = 32;
            // 
            // lblNombreChofer
            // 
            this.lblNombreChofer.AutoSize = true;
            this.lblNombreChofer.Location = new System.Drawing.Point(469, 11);
            this.lblNombreChofer.Name = "lblNombreChofer";
            this.lblNombreChofer.Size = new System.Drawing.Size(78, 13);
            this.lblNombreChofer.TabIndex = 30;
            this.lblNombreChofer.Text = "Chofer Nombre";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(262, 59);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(131, 29);
            this.btnBuscar.TabIndex = 27;
            this.btnBuscar.Text = "Buscar Automovil";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBusquedaNombreChofer
            // 
            this.txtBusquedaNombreChofer.Location = new System.Drawing.Point(427, 27);
            this.txtBusquedaNombreChofer.Name = "txtBusquedaNombreChofer";
            this.txtBusquedaNombreChofer.Size = new System.Drawing.Size(156, 20);
            this.txtBusquedaNombreChofer.TabIndex = 29;
            this.txtBusquedaNombreChofer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusquedaNombreChofer_KeyPress);
            // 
            // lblBuscarDNI
            // 
            this.lblBuscarDNI.AutoSize = true;
            this.lblBuscarDNI.Location = new System.Drawing.Point(101, 52);
            this.lblBuscarDNI.Name = "lblBuscarDNI";
            this.lblBuscarDNI.Size = new System.Drawing.Size(44, 13);
            this.lblBuscarDNI.TabIndex = 28;
            this.lblBuscarDNI.Text = "Patente";
            // 
            // lblBuscarApellido
            // 
            this.lblBuscarApellido.AutoSize = true;
            this.lblBuscarApellido.Location = new System.Drawing.Point(307, 10);
            this.lblBuscarApellido.Name = "lblBuscarApellido";
            this.lblBuscarApellido.Size = new System.Drawing.Size(42, 13);
            this.lblBuscarApellido.TabIndex = 27;
            this.lblBuscarApellido.Text = "Modelo";
            // 
            // lblBusquedaNombre
            // 
            this.lblBusquedaNombre.AutoSize = true;
            this.lblBusquedaNombre.Location = new System.Drawing.Point(101, 11);
            this.lblBusquedaNombre.Name = "lblBusquedaNombre";
            this.lblBusquedaNombre.Size = new System.Drawing.Size(37, 13);
            this.lblBusquedaNombre.TabIndex = 26;
            this.lblBusquedaNombre.Text = "Marca";
            // 
            // txtBusquedaModelo
            // 
            this.txtBusquedaModelo.Location = new System.Drawing.Point(236, 27);
            this.txtBusquedaModelo.Name = "txtBusquedaModelo";
            this.txtBusquedaModelo.Size = new System.Drawing.Size(174, 20);
            this.txtBusquedaModelo.TabIndex = 26;
            this.txtBusquedaModelo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusquedaModelo_KeyPress);
            // 
            // txtBusquedaPatente
            // 
            this.txtBusquedaPatente.Location = new System.Drawing.Point(33, 68);
            this.txtBusquedaPatente.Name = "txtBusquedaPatente";
            this.txtBusquedaPatente.Size = new System.Drawing.Size(174, 20);
            this.txtBusquedaPatente.TabIndex = 25;
            this.txtBusquedaPatente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusquedaPatente_KeyPress);
            // 
            // comboMarca
            // 
            this.comboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMarca.FormattingEnabled = true;
            this.comboMarca.Location = new System.Drawing.Point(31, 16);
            this.comboMarca.Name = "comboMarca";
            this.comboMarca.Size = new System.Drawing.Size(174, 21);
            this.comboMarca.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Marca";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Modelo";
            // 
            // lblPatente
            // 
            this.lblPatente.AutoSize = true;
            this.lblPatente.Location = new System.Drawing.Point(313, 0);
            this.lblPatente.Name = "lblPatente";
            this.lblPatente.Size = new System.Drawing.Size(44, 13);
            this.lblPatente.TabIndex = 36;
            this.lblPatente.Text = "Patente";
            // 
            // txtPatente
            // 
            this.txtPatente.Location = new System.Drawing.Point(245, 16);
            this.txtPatente.MaxLength = 7;
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(174, 20);
            this.txtPatente.TabIndex = 35;
            this.txtPatente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatente_KeyPress);
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Location = new System.Drawing.Point(313, 44);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(35, 13);
            this.lblTurno.TabIndex = 38;
            this.lblTurno.Text = "Turno";
            // 
            // comboTurno
            // 
            this.comboTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTurno.FormattingEnabled = true;
            this.comboTurno.Location = new System.Drawing.Point(245, 60);
            this.comboTurno.Name = "comboTurno";
            this.comboTurno.Size = new System.Drawing.Size(174, 21);
            this.comboTurno.TabIndex = 39;
            // 
            // comboChofer
            // 
            this.comboChofer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboChofer.FormattingEnabled = true;
            this.comboChofer.Location = new System.Drawing.Point(31, 106);
            this.comboChofer.Name = "comboChofer";
            this.comboChofer.Size = new System.Drawing.Size(174, 21);
            this.comboChofer.TabIndex = 41;
            // 
            // lblChofer
            // 
            this.lblChofer.AutoSize = true;
            this.lblChofer.Location = new System.Drawing.Point(99, 90);
            this.lblChofer.Name = "lblChofer";
            this.lblChofer.Size = new System.Drawing.Size(38, 13);
            this.lblChofer.TabIndex = 40;
            this.lblChofer.Text = "Chofer";
            // 
            // grupoDatosAutomovil
            // 
            this.grupoDatosAutomovil.Controls.Add(this.comboModelo);
            this.grupoDatosAutomovil.Controls.Add(this.ccHabilitado);
            this.grupoDatosAutomovil.Controls.Add(this.btnCancelar);
            this.grupoDatosAutomovil.Controls.Add(this.btnAceptar);
            this.grupoDatosAutomovil.Controls.Add(this.comboChofer);
            this.grupoDatosAutomovil.Controls.Add(this.lblChofer);
            this.grupoDatosAutomovil.Controls.Add(this.comboTurno);
            this.grupoDatosAutomovil.Controls.Add(this.lblTurno);
            this.grupoDatosAutomovil.Controls.Add(this.lblPatente);
            this.grupoDatosAutomovil.Controls.Add(this.txtPatente);
            this.grupoDatosAutomovil.Controls.Add(this.label3);
            this.grupoDatosAutomovil.Controls.Add(this.label2);
            this.grupoDatosAutomovil.Controls.Add(this.comboMarca);
            this.grupoDatosAutomovil.Location = new System.Drawing.Point(26, 110);
            this.grupoDatosAutomovil.Name = "grupoDatosAutomovil";
            this.grupoDatosAutomovil.Size = new System.Drawing.Size(612, 140);
            this.grupoDatosAutomovil.TabIndex = 42;
            this.grupoDatosAutomovil.TabStop = false;
            // 
            // comboModelo
            // 
            this.comboModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboModelo.FormattingEnabled = true;
            this.comboModelo.Location = new System.Drawing.Point(31, 60);
            this.comboModelo.Name = "comboModelo";
            this.comboModelo.Size = new System.Drawing.Size(174, 21);
            this.comboModelo.TabIndex = 44;
            // 
            // ccHabilitado
            // 
            this.ccHabilitado.AutoSize = true;
            this.ccHabilitado.Location = new System.Drawing.Point(245, 108);
            this.ccHabilitado.Name = "ccHabilitado";
            this.ccHabilitado.Size = new System.Drawing.Size(73, 17);
            this.ccHabilitado.TabIndex = 43;
            this.ccHabilitado.Text = "Habilitado";
            this.ccHabilitado.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(440, 88);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(131, 29);
            this.btnCancelar.TabIndex = 42;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(440, 28);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(131, 29);
            this.btnAceptar.TabIndex = 33;
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // frmAutomovil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(646, 261);
            this.Controls.Add(this.grupoDatosAutomovil);
            this.Controls.Add(this.grupoBusquedaABM);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAutomovil";
            this.grupoBusquedaABM.ResumeLayout(false);
            this.grupoBusquedaABM.PerformLayout();
            this.grupoDatosAutomovil.ResumeLayout(false);
            this.grupoDatosAutomovil.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grupoBusquedaABM;
        private System.Windows.Forms.ComboBox comboMarcaBusqueda;
        private System.Windows.Forms.Label lblNombreChofer;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBusquedaNombreChofer;
        private System.Windows.Forms.Label lblBuscarDNI;
        private System.Windows.Forms.Label lblBuscarApellido;
        private System.Windows.Forms.Label lblBusquedaNombre;
        private System.Windows.Forms.TextBox txtBusquedaModelo;
        private System.Windows.Forms.TextBox txtBusquedaPatente;
        private System.Windows.Forms.ComboBox comboMarca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPatente;
        protected System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.ComboBox comboTurno;
        private System.Windows.Forms.ComboBox comboChofer;
        private System.Windows.Forms.Label lblChofer;
        private System.Windows.Forms.GroupBox grupoDatosAutomovil;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox ccHabilitado;
        private System.Windows.Forms.ComboBox comboModelo;
        private System.Windows.Forms.TextBox txtBusquedaApellidoChofer;
        private System.Windows.Forms.Label label1;
    }
}
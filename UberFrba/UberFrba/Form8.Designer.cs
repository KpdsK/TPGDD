namespace UberFrba
{
    partial class frmRegistroViaje
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
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboCliente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAutomovil = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.comboChofer = new System.Windows.Forms.ComboBox();
            this.lblChofer = new System.Windows.Forms.Label();
            this.comboTurno = new System.Windows.Forms.ComboBox();
            this.lblTurno = new System.Windows.Forms.Label();
            this.lblPatente = new System.Windows.Forms.Label();
            this.txtCantidadKilometros = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.selectorDiaHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.selectorDiaHoraFin = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 63;
            this.label4.Text = "Fecha y hora de fin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 62;
            this.label2.Text = "Fecha y hora de inicio";
            // 
            // comboCliente
            // 
            this.comboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCliente.FormattingEnabled = true;
            this.comboCliente.Location = new System.Drawing.Point(234, 82);
            this.comboCliente.Name = "comboCliente";
            this.comboCliente.Size = new System.Drawing.Size(174, 21);
            this.comboCliente.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Turno";
            // 
            // txtAutomovil
            // 
            this.txtAutomovil.Location = new System.Drawing.Point(234, 39);
            this.txtAutomovil.MaxLength = 7;
            this.txtAutomovil.Name = "txtAutomovil";
            this.txtAutomovil.ReadOnly = true;
            this.txtAutomovil.Size = new System.Drawing.Size(174, 20);
            this.txtAutomovil.TabIndex = 59;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(460, 115);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(131, 29);
            this.btnCancelar.TabIndex = 58;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAceptar.Location = new System.Drawing.Point(460, 55);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(131, 29);
            this.btnAceptar.TabIndex = 50;
            this.btnAceptar.Text = "Cargar Viaje";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // comboChofer
            // 
            this.comboChofer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboChofer.FormattingEnabled = true;
            this.comboChofer.Location = new System.Drawing.Point(36, 38);
            this.comboChofer.Name = "comboChofer";
            this.comboChofer.Size = new System.Drawing.Size(174, 21);
            this.comboChofer.TabIndex = 57;
            // 
            // lblChofer
            // 
            this.lblChofer.AutoSize = true;
            this.lblChofer.Location = new System.Drawing.Point(108, 24);
            this.lblChofer.Name = "lblChofer";
            this.lblChofer.Size = new System.Drawing.Size(38, 13);
            this.lblChofer.TabIndex = 56;
            this.lblChofer.Text = "Chofer";
            // 
            // comboTurno
            // 
            this.comboTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTurno.FormattingEnabled = true;
            this.comboTurno.Location = new System.Drawing.Point(37, 82);
            this.comboTurno.Name = "comboTurno";
            this.comboTurno.Size = new System.Drawing.Size(174, 21);
            this.comboTurno.TabIndex = 55;
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Location = new System.Drawing.Point(307, 68);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(39, 13);
            this.lblTurno.TabIndex = 54;
            this.lblTurno.Text = "Cliente";
            // 
            // lblPatente
            // 
            this.lblPatente.AutoSize = true;
            this.lblPatente.Location = new System.Drawing.Point(144, 109);
            this.lblPatente.Name = "lblPatente";
            this.lblPatente.Size = new System.Drawing.Size(156, 13);
            this.lblPatente.TabIndex = 53;
            this.lblPatente.Text = "Cantidad de kilómetros del viaje";
            // 
            // txtCantidadKilometros
            // 
            this.txtCantidadKilometros.Location = new System.Drawing.Point(176, 125);
            this.txtCantidadKilometros.MaxLength = 7;
            this.txtCantidadKilometros.Name = "txtCantidadKilometros";
            this.txtCantidadKilometros.Size = new System.Drawing.Size(85, 20);
            this.txtCantidadKilometros.TabIndex = 52;
            this.txtCantidadKilometros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidadKilometros_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(297, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Automovil";
            // 
            // selectorDiaHoraInicio
            // 
            this.selectorDiaHoraInicio.CustomFormat = "HH:mm";
            this.selectorDiaHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.selectorDiaHoraInicio.Location = new System.Drawing.Point(89, 166);
            this.selectorDiaHoraInicio.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.selectorDiaHoraInicio.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.selectorDiaHoraInicio.Name = "selectorDiaHoraInicio";
            this.selectorDiaHoraInicio.ShowUpDown = true;
            this.selectorDiaHoraInicio.Size = new System.Drawing.Size(57, 20);
            this.selectorDiaHoraInicio.TabIndex = 66;
            // 
            // selectorDiaHoraFin
            // 
            this.selectorDiaHoraFin.CustomFormat = "HH:mm";
            this.selectorDiaHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.selectorDiaHoraFin.Location = new System.Drawing.Point(289, 166);
            this.selectorDiaHoraFin.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.selectorDiaHoraFin.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.selectorDiaHoraFin.Name = "selectorDiaHoraFin";
            this.selectorDiaHoraFin.ShowUpDown = true;
            this.selectorDiaHoraFin.Size = new System.Drawing.Size(57, 20);
            this.selectorDiaHoraFin.TabIndex = 67;
            // 
            // frmRegistroViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(610, 198);
            this.Controls.Add(this.selectorDiaHoraFin);
            this.Controls.Add(this.selectorDiaHoraInicio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAutomovil);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.comboChofer);
            this.Controls.Add(this.lblChofer);
            this.Controls.Add(this.comboTurno);
            this.Controls.Add(this.lblTurno);
            this.Controls.Add(this.lblPatente);
            this.Controls.Add(this.txtCantidadKilometros);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegistroViaje";
            this.Text = "Carga de Viajes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAutomovil;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox comboChofer;
        private System.Windows.Forms.Label lblChofer;
        private System.Windows.Forms.ComboBox comboTurno;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.Label lblPatente;
        private System.Windows.Forms.TextBox txtCantidadKilometros;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker selectorDiaHoraInicio;
        private System.Windows.Forms.DateTimePicker selectorDiaHoraFin;

    }
}
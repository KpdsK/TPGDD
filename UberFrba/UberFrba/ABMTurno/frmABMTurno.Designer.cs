namespace UberFrba
{
    partial class frmABMTurno
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
            this.grupoDatosTurno = new System.Windows.Forms.GroupBox();
            this.selectorHoraFin = new System.Windows.Forms.NumericUpDown();
            this.selectorHoraInicio = new System.Windows.Forms.NumericUpDown();
            this.lblIdTurno = new System.Windows.Forms.Label();
            this.ccHabilitado = new System.Windows.Forms.CheckBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtPrecioBase = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblChofer = new System.Windows.Forms.Label();
            this.lblTurno = new System.Windows.Forms.Label();
            this.lblPatente = new System.Windows.Forms.Label();
            this.txtValorKilometro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grupoBusquedaTurno = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblBuscarDNI = new System.Windows.Forms.Label();
            this.txtBusquedaDescripcion = new System.Windows.Forms.TextBox();
            this.grupoDatosTurno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectorHoraFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectorHoraInicio)).BeginInit();
            this.grupoBusquedaTurno.SuspendLayout();
            this.SuspendLayout();
            // 
            // grupoDatosTurno
            // 
            this.grupoDatosTurno.Controls.Add(this.selectorHoraFin);
            this.grupoDatosTurno.Controls.Add(this.selectorHoraInicio);
            this.grupoDatosTurno.Controls.Add(this.lblIdTurno);
            this.grupoDatosTurno.Controls.Add(this.ccHabilitado);
            this.grupoDatosTurno.Controls.Add(this.txtDescripcion);
            this.grupoDatosTurno.Controls.Add(this.txtPrecioBase);
            this.grupoDatosTurno.Controls.Add(this.btnCancelar);
            this.grupoDatosTurno.Controls.Add(this.btnAceptar);
            this.grupoDatosTurno.Controls.Add(this.lblChofer);
            this.grupoDatosTurno.Controls.Add(this.lblTurno);
            this.grupoDatosTurno.Controls.Add(this.lblPatente);
            this.grupoDatosTurno.Controls.Add(this.txtValorKilometro);
            this.grupoDatosTurno.Controls.Add(this.label3);
            this.grupoDatosTurno.Controls.Add(this.label2);
            this.grupoDatosTurno.Location = new System.Drawing.Point(12, 113);
            this.grupoDatosTurno.Name = "grupoDatosTurno";
            this.grupoDatosTurno.Size = new System.Drawing.Size(612, 140);
            this.grupoDatosTurno.TabIndex = 44;
            this.grupoDatosTurno.TabStop = false;
            // 
            // selectorHoraFin
            // 
            this.selectorHoraFin.Location = new System.Drawing.Point(133, 60);
            this.selectorHoraFin.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.selectorHoraFin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.selectorHoraFin.Name = "selectorHoraFin";
            this.selectorHoraFin.Size = new System.Drawing.Size(45, 20);
            this.selectorHoraFin.TabIndex = 53;
            this.selectorHoraFin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.selectorHoraFin.ValueChanged += new System.EventHandler(this.selectorHoraFin_ValueChanged);
            // 
            // selectorHoraInicio
            // 
            this.selectorHoraInicio.Location = new System.Drawing.Point(133, 29);
            this.selectorHoraInicio.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.selectorHoraInicio.Name = "selectorHoraInicio";
            this.selectorHoraInicio.Size = new System.Drawing.Size(45, 20);
            this.selectorHoraInicio.TabIndex = 45;
            this.selectorHoraInicio.ValueChanged += new System.EventHandler(this.selectorHoraInicio_ValueChanged);
            // 
            // lblIdTurno
            // 
            this.lblIdTurno.AutoSize = true;
            this.lblIdTurno.Location = new System.Drawing.Point(383, 108);
            this.lblIdTurno.Name = "lblIdTurno";
            this.lblIdTurno.Size = new System.Drawing.Size(0, 13);
            this.lblIdTurno.TabIndex = 52;
            this.lblIdTurno.Visible = false;
            // 
            // ccHabilitado
            // 
            this.ccHabilitado.AutoSize = true;
            this.ccHabilitado.Location = new System.Drawing.Point(282, 108);
            this.ccHabilitado.Name = "ccHabilitado";
            this.ccHabilitado.Size = new System.Drawing.Size(73, 17);
            this.ccHabilitado.TabIndex = 51;
            this.ccHabilitado.Text = "Habilitado";
            this.ccHabilitado.UseVisualStyleBackColor = true;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(47, 108);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(174, 20);
            this.txtDescripcion.TabIndex = 48;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            // 
            // txtPrecioBase
            // 
            this.txtPrecioBase.Location = new System.Drawing.Point(246, 64);
            this.txtPrecioBase.Name = "txtPrecioBase";
            this.txtPrecioBase.Size = new System.Drawing.Size(174, 20);
            this.txtPrecioBase.TabIndex = 46;
            this.txtPrecioBase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioBase_KeyPress);
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
            // lblChofer
            // 
            this.lblChofer.AutoSize = true;
            this.lblChofer.Location = new System.Drawing.Point(103, 94);
            this.lblChofer.Name = "lblChofer";
            this.lblChofer.Size = new System.Drawing.Size(63, 13);
            this.lblChofer.TabIndex = 40;
            this.lblChofer.Text = "Descripción";
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Location = new System.Drawing.Point(279, 48);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(107, 13);
            this.lblTurno.TabIndex = 38;
            this.lblTurno.Text = "Precio base del turno";
            // 
            // lblPatente
            // 
            this.lblPatente.AutoSize = true;
            this.lblPatente.Location = new System.Drawing.Point(291, 5);
            this.lblPatente.Name = "lblPatente";
            this.lblPatente.Size = new System.Drawing.Size(94, 13);
            this.lblPatente.TabIndex = 36;
            this.lblPatente.Text = "Valor del Kilometro";
            // 
            // txtValorKilometro
            // 
            this.txtValorKilometro.Location = new System.Drawing.Point(246, 21);
            this.txtValorKilometro.Name = "txtValorKilometro";
            this.txtValorKilometro.Size = new System.Drawing.Size(174, 20);
            this.txtValorKilometro.TabIndex = 35;
            this.txtValorKilometro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorKilometro_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Hora de Finalización";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Hora de inicio";
            // 
            // grupoBusquedaTurno
            // 
            this.grupoBusquedaTurno.Controls.Add(this.btnBuscar);
            this.grupoBusquedaTurno.Controls.Add(this.lblBuscarDNI);
            this.grupoBusquedaTurno.Controls.Add(this.txtBusquedaDescripcion);
            this.grupoBusquedaTurno.Location = new System.Drawing.Point(194, 8);
            this.grupoBusquedaTurno.Name = "grupoBusquedaTurno";
            this.grupoBusquedaTurno.Size = new System.Drawing.Size(257, 99);
            this.grupoBusquedaTurno.TabIndex = 43;
            this.grupoBusquedaTurno.TabStop = false;
            this.grupoBusquedaTurno.Text = "Busqueda";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(64, 58);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(131, 29);
            this.btnBuscar.TabIndex = 27;
            this.btnBuscar.Text = "Buscar Turno";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblBuscarDNI
            // 
            this.lblBuscarDNI.AutoSize = true;
            this.lblBuscarDNI.Location = new System.Drawing.Point(3, 29);
            this.lblBuscarDNI.Name = "lblBuscarDNI";
            this.lblBuscarDNI.Size = new System.Drawing.Size(63, 13);
            this.lblBuscarDNI.TabIndex = 28;
            this.lblBuscarDNI.Text = "Descripcion";
            // 
            // txtBusquedaDescripcion
            // 
            this.txtBusquedaDescripcion.Location = new System.Drawing.Point(69, 26);
            this.txtBusquedaDescripcion.Name = "txtBusquedaDescripcion";
            this.txtBusquedaDescripcion.Size = new System.Drawing.Size(174, 20);
            this.txtBusquedaDescripcion.TabIndex = 25;
            this.txtBusquedaDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusquedaDescripcion_KeyPress);
            // 
            // frmABMTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(636, 261);
            this.Controls.Add(this.grupoDatosTurno);
            this.Controls.Add(this.grupoBusquedaTurno);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmABMTurno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.grupoDatosTurno.ResumeLayout(false);
            this.grupoDatosTurno.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectorHoraFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectorHoraInicio)).EndInit();
            this.grupoBusquedaTurno.ResumeLayout(false);
            this.grupoBusquedaTurno.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grupoDatosTurno;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblChofer;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.Label lblPatente;
        private System.Windows.Forms.TextBox txtValorKilometro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grupoBusquedaTurno;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblBuscarDNI;
        private System.Windows.Forms.TextBox txtBusquedaDescripcion;
        private System.Windows.Forms.CheckBox ccHabilitado;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtPrecioBase;
        private System.Windows.Forms.Label lblIdTurno;
        protected System.Windows.Forms.NumericUpDown selectorHoraFin;
        protected System.Windows.Forms.NumericUpDown selectorHoraInicio;
    }
}
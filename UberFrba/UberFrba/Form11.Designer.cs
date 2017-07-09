namespace UberFrba
{
    partial class frmListados
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.comboListados = new System.Windows.Forms.ComboBox();
            this.lblSeleccionListado = new System.Windows.Forms.Label();
            this.selectorAnio = new System.Windows.Forms.DateTimePicker();
            this.lblAnio = new System.Windows.Forms.Label();
            this.lblTrimestre = new System.Windows.Forms.Label();
            this.selectorTrimestre = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.selectorTrimestre)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAceptar.Location = new System.Drawing.Point(254, 21);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(131, 29);
            this.btnAceptar.TabIndex = 24;
            this.btnAceptar.Text = "Generar Listado";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(254, 68);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(131, 29);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // comboListados
            // 
            this.comboListados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboListados.FormattingEnabled = true;
            this.comboListados.Location = new System.Drawing.Point(12, 26);
            this.comboListados.Name = "comboListados";
            this.comboListados.Size = new System.Drawing.Size(221, 21);
            this.comboListados.TabIndex = 63;
            // 
            // lblSeleccionListado
            // 
            this.lblSeleccionListado.AutoSize = true;
            this.lblSeleccionListado.Location = new System.Drawing.Point(53, 10);
            this.lblSeleccionListado.Name = "lblSeleccionListado";
            this.lblSeleccionListado.Size = new System.Drawing.Size(100, 13);
            this.lblSeleccionListado.TabIndex = 62;
            this.lblSeleccionListado.Text = "Seleccionar Listado";
            // 
            // selectorAnio
            // 
            this.selectorAnio.CustomFormat = "yyyy";
            this.selectorAnio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.selectorAnio.Location = new System.Drawing.Point(41, 73);
            this.selectorAnio.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.selectorAnio.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.selectorAnio.Name = "selectorAnio";
            this.selectorAnio.ShowUpDown = true;
            this.selectorAnio.Size = new System.Drawing.Size(57, 20);
            this.selectorAnio.TabIndex = 67;
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(56, 57);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(26, 13);
            this.lblAnio.TabIndex = 68;
            this.lblAnio.Text = "Año";
            // 
            // lblTrimestre
            // 
            this.lblTrimestre.Location = new System.Drawing.Point(136, 55);
            this.lblTrimestre.Name = "lblTrimestre";
            this.lblTrimestre.Size = new System.Drawing.Size(63, 24);
            this.lblTrimestre.TabIndex = 70;
            this.lblTrimestre.Text = "Trimestre";
            // 
            // selectorTrimestre
            // 
            this.selectorTrimestre.Location = new System.Drawing.Point(139, 73);
            this.selectorTrimestre.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.selectorTrimestre.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.selectorTrimestre.Name = "selectorTrimestre";
            this.selectorTrimestre.Size = new System.Drawing.Size(43, 20);
            this.selectorTrimestre.TabIndex = 71;
            this.selectorTrimestre.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // frmListados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(404, 114);
            this.Controls.Add(this.selectorTrimestre);
            this.Controls.Add(this.lblTrimestre);
            this.Controls.Add(this.lblAnio);
            this.Controls.Add(this.selectorAnio);
            this.Controls.Add(this.comboListados);
            this.Controls.Add(this.lblSeleccionListado);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListados";
            this.Text = "Listados";
            ((System.ComponentModel.ISupportInitialize)(this.selectorTrimestre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox comboListados;
        private System.Windows.Forms.Label lblSeleccionListado;
        private System.Windows.Forms.DateTimePicker selectorAnio;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.Label lblTrimestre;
        private System.Windows.Forms.NumericUpDown selectorTrimestre;
    }
}
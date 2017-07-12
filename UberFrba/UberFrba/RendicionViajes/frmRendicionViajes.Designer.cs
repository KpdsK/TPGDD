namespace UberFrba
{
    partial class frmRendirViaje
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
            this.selectorDiaRendicionAChofer = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboChofer = new System.Windows.Forms.ComboBox();
            this.lblChofer = new System.Windows.Forms.Label();
            this.comboTurno = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectorDiaRendicionAChofer
            // 
            this.selectorDiaRendicionAChofer.CustomFormat = "dd/MM/yyyy";
            this.selectorDiaRendicionAChofer.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.selectorDiaRendicionAChofer.Location = new System.Drawing.Point(183, 101);
            this.selectorDiaRendicionAChofer.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.selectorDiaRendicionAChofer.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.selectorDiaRendicionAChofer.Name = "selectorDiaRendicionAChofer";
            this.selectorDiaRendicionAChofer.Size = new System.Drawing.Size(85, 20);
            this.selectorDiaRendicionAChofer.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 71;
            this.label2.Text = "Fecha Rendicion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 70;
            this.label1.Text = "Turno";
            // 
            // comboChofer
            // 
            this.comboChofer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboChofer.FormattingEnabled = true;
            this.comboChofer.Location = new System.Drawing.Point(127, 17);
            this.comboChofer.Name = "comboChofer";
            this.comboChofer.Size = new System.Drawing.Size(141, 21);
            this.comboChofer.TabIndex = 67;
            // 
            // lblChofer
            // 
            this.lblChofer.AutoSize = true;
            this.lblChofer.Location = new System.Drawing.Point(12, 20);
            this.lblChofer.Name = "lblChofer";
            this.lblChofer.Size = new System.Drawing.Size(38, 13);
            this.lblChofer.TabIndex = 68;
            this.lblChofer.Text = "Chofer";
            // 
            // comboTurno
            // 
            this.comboTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTurno.FormattingEnabled = true;
            this.comboTurno.Location = new System.Drawing.Point(127, 55);
            this.comboTurno.Name = "comboTurno";
            this.comboTurno.Size = new System.Drawing.Size(141, 21);
            this.comboTurno.TabIndex = 68;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(310, 80);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(131, 29);
            this.btnCancelar.TabIndex = 71;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(310, 20);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(131, 29);
            this.btnAceptar.TabIndex = 70;
            this.btnAceptar.Text = "Rendir Viajes";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmRendirViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 145);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.selectorDiaRendicionAChofer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboChofer);
            this.Controls.Add(this.lblChofer);
            this.Controls.Add(this.comboTurno);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRendirViaje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rendicion de Viajes a Chofer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker selectorDiaRendicionAChofer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboChofer;
        private System.Windows.Forms.Label lblChofer;
        private System.Windows.Forms.ComboBox comboTurno;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
    }
}
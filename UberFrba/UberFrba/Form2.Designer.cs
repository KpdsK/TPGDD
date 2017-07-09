namespace UberFrba
{
    partial class frmRoles
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
            this.lblSeleccionRol = new System.Windows.Forms.Label();
            this.comboRol = new System.Windows.Forms.ComboBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSeleccionRol
            // 
            this.lblSeleccionRol.AutoSize = true;
            this.lblSeleccionRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccionRol.Location = new System.Drawing.Point(29, 9);
            this.lblSeleccionRol.Name = "lblSeleccionRol";
            this.lblSeleccionRol.Size = new System.Drawing.Size(102, 17);
            this.lblSeleccionRol.TabIndex = 0;
            this.lblSeleccionRol.Text = "Seleccione Rol";
            // 
            // comboRol
            // 
            this.comboRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRol.FormattingEnabled = true;
            this.comboRol.Location = new System.Drawing.Point(13, 36);
            this.comboRol.Name = "comboRol";
            this.comboRol.Size = new System.Drawing.Size(135, 21);
            this.comboRol.TabIndex = 1;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(31, 69);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(100, 26);
            this.btnIniciar.TabIndex = 2;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmRoles
            // 
            this.AcceptButton = this.btnIniciar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(163, 105);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.comboRol);
            this.Controls.Add(this.lblSeleccionRol);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRoles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSeleccionRol;
        private System.Windows.Forms.ComboBox comboRol;
        private System.Windows.Forms.Button btnIniciar;
    }
}
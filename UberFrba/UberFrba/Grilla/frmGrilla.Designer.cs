namespace UberFrba
{
    partial class frmGrilla
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
            this.grillaDatos = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.btnVerDetalles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grillaDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // grillaDatos
            // 
            this.grillaDatos.AllowUserToAddRows = false;
            this.grillaDatos.AllowUserToDeleteRows = false;
            this.grillaDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grillaDatos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.grillaDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaDatos.Location = new System.Drawing.Point(6, 9);
            this.grillaDatos.MultiSelect = false;
            this.grillaDatos.Name = "grillaDatos";
            this.grillaDatos.ReadOnly = true;
            this.grillaDatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.grillaDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaDatos.Size = new System.Drawing.Size(725, 234);
            this.grillaDatos.TabIndex = 0;
            this.grillaDatos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaDatos_CellContentDoubleClick);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(474, 273);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(108, 30);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(153, 273);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(108, 30);
            this.btnSeleccionar.TabIndex = 2;
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // btnVerDetalles
            // 
            this.btnVerDetalles.Location = new System.Drawing.Point(314, 273);
            this.btnVerDetalles.Name = "btnVerDetalles";
            this.btnVerDetalles.Size = new System.Drawing.Size(108, 30);
            this.btnVerDetalles.TabIndex = 3;
            this.btnVerDetalles.Text = "Ver Detalles";
            this.btnVerDetalles.UseVisualStyleBackColor = true;
            this.btnVerDetalles.Visible = false;
            // 
            // frmGrilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(737, 315);
            this.ControlBox = false;
            this.Controls.Add(this.btnVerDetalles);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grillaDatos);
            this.Name = "frmGrilla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmResultadoBusquedaUsuarioABM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.DataGridView grillaDatos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button btnVerDetalles;
    }
}
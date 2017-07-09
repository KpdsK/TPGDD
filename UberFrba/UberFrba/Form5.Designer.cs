namespace UberFrba
{
    partial class frmResultadoBusquedaUsuarioABM
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
            this.grillaDatosResultadoBusqueda = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grillaDatosResultadoBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // grillaDatosResultadoBusqueda
            // 
            this.grillaDatosResultadoBusqueda.AllowUserToAddRows = false;
            this.grillaDatosResultadoBusqueda.AllowUserToDeleteRows = false;
            this.grillaDatosResultadoBusqueda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grillaDatosResultadoBusqueda.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.grillaDatosResultadoBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaDatosResultadoBusqueda.Location = new System.Drawing.Point(6, 9);
            this.grillaDatosResultadoBusqueda.MultiSelect = false;
            this.grillaDatosResultadoBusqueda.Name = "grillaDatosResultadoBusqueda";
            this.grillaDatosResultadoBusqueda.ReadOnly = true;
            this.grillaDatosResultadoBusqueda.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.grillaDatosResultadoBusqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaDatosResultadoBusqueda.Size = new System.Drawing.Size(725, 234);
            this.grillaDatosResultadoBusqueda.TabIndex = 0;
            this.grillaDatosResultadoBusqueda.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaDatosResultadoBusqueda_CellContentDoubleClick);
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
            // frmResultadoBusquedaUsuarioABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(737, 315);
            this.ControlBox = false;
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grillaDatosResultadoBusqueda);
            this.Name = "frmResultadoBusquedaUsuarioABM";
            this.Load += new System.EventHandler(this.frmResultadoBusquedaUsuarioABM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaDatosResultadoBusqueda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grillaDatosResultadoBusqueda;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSeleccionar;
    }
}
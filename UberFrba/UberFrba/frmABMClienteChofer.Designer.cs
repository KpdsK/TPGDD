namespace UberFrba
{
    partial class frmABM
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
            this.txtBusquedaNombre = new System.Windows.Forms.TextBox();
            this.txtBusquedaApellido = new System.Windows.Forms.TextBox();
            this.txtBusquedaDNI = new System.Windows.Forms.TextBox();
            this.lblBusquedaNombre = new System.Windows.Forms.Label();
            this.lblBuscarApellido = new System.Windows.Forms.Label();
            this.lblBuscarDNI = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.grupoBusquedaABM = new System.Windows.Forms.GroupBox();
            this.etiNombre = new System.Windows.Forms.Label();
            this.etiApellido = new System.Windows.Forms.Label();
            this.etiDNI = new System.Windows.Forms.Label();
            this.etiTelefono = new System.Windows.Forms.Label();
            this.etiCalle = new System.Windows.Forms.Label();
            this.etiPisoManzana = new System.Windows.Forms.Label();
            this.etiDeptoLote = new System.Windows.Forms.Label();
            this.etiLocalidad = new System.Windows.Forms.Label();
            this.etiCorreoElectronico = new System.Windows.Forms.Label();
            this.etiCodigoPostal = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.txtPisoManzana = new System.Windows.Forms.TextBox();
            this.txtDeptoLote = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.ccHabilitado = new System.Windows.Forms.CheckBox();
            this.grupoDatosPersona = new System.Windows.Forms.GroupBox();
            this.lblIdPersona = new System.Windows.Forms.Label();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.selectorFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.grupoBusquedaABM.SuspendLayout();
            this.grupoDatosPersona.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBusquedaNombre
            // 
            this.txtBusquedaNombre.Location = new System.Drawing.Point(33, 27);
            this.txtBusquedaNombre.MaxLength = 255;
            this.txtBusquedaNombre.Name = "txtBusquedaNombre";
            this.txtBusquedaNombre.Size = new System.Drawing.Size(174, 20);
            this.txtBusquedaNombre.TabIndex = 25;
            this.txtBusquedaNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusquedaNombre_KeyPress);
            // 
            // txtBusquedaApellido
            // 
            this.txtBusquedaApellido.Location = new System.Drawing.Point(214, 27);
            this.txtBusquedaApellido.MaxLength = 255;
            this.txtBusquedaApellido.Name = "txtBusquedaApellido";
            this.txtBusquedaApellido.Size = new System.Drawing.Size(174, 20);
            this.txtBusquedaApellido.TabIndex = 26;
            this.txtBusquedaApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusquedaApellido_KeyPress);
            // 
            // txtBusquedaDNI
            // 
            this.txtBusquedaDNI.Location = new System.Drawing.Point(395, 27);
            this.txtBusquedaDNI.MaxLength = 18;
            this.txtBusquedaDNI.Name = "txtBusquedaDNI";
            this.txtBusquedaDNI.Size = new System.Drawing.Size(174, 20);
            this.txtBusquedaDNI.TabIndex = 27;
            this.txtBusquedaDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusquedaDNI_KeyPress);
            // 
            // lblBusquedaNombre
            // 
            this.lblBusquedaNombre.AutoSize = true;
            this.lblBusquedaNombre.Location = new System.Drawing.Point(79, 6);
            this.lblBusquedaNombre.Name = "lblBusquedaNombre";
            this.lblBusquedaNombre.Size = new System.Drawing.Size(88, 13);
            this.lblBusquedaNombre.TabIndex = 26;
            this.lblBusquedaNombre.Text = "Nombre a buscar";
            // 
            // lblBuscarApellido
            // 
            this.lblBuscarApellido.AutoSize = true;
            this.lblBuscarApellido.Location = new System.Drawing.Point(256, 6);
            this.lblBuscarApellido.Name = "lblBuscarApellido";
            this.lblBuscarApellido.Size = new System.Drawing.Size(88, 13);
            this.lblBuscarApellido.TabIndex = 27;
            this.lblBuscarApellido.Text = "Apellido a buscar";
            // 
            // lblBuscarDNI
            // 
            this.lblBuscarDNI.AutoSize = true;
            this.lblBuscarDNI.Location = new System.Drawing.Point(451, 6);
            this.lblBuscarDNI.Name = "lblBuscarDNI";
            this.lblBuscarDNI.Size = new System.Drawing.Size(70, 13);
            this.lblBuscarDNI.TabIndex = 28;
            this.lblBuscarDNI.Text = "DNI a buscar";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(234, 51);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(131, 29);
            this.btnBuscar.TabIndex = 28;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // grupoBusquedaABM
            // 
            this.grupoBusquedaABM.Controls.Add(this.btnBuscar);
            this.grupoBusquedaABM.Controls.Add(this.lblBuscarDNI);
            this.grupoBusquedaABM.Controls.Add(this.lblBuscarApellido);
            this.grupoBusquedaABM.Controls.Add(this.lblBusquedaNombre);
            this.grupoBusquedaABM.Controls.Add(this.txtBusquedaDNI);
            this.grupoBusquedaABM.Controls.Add(this.txtBusquedaApellido);
            this.grupoBusquedaABM.Controls.Add(this.txtBusquedaNombre);
            this.grupoBusquedaABM.Location = new System.Drawing.Point(28, 5);
            this.grupoBusquedaABM.Name = "grupoBusquedaABM";
            this.grupoBusquedaABM.Size = new System.Drawing.Size(588, 86);
            this.grupoBusquedaABM.TabIndex = 30;
            this.grupoBusquedaABM.TabStop = false;
            // 
            // etiNombre
            // 
            this.etiNombre.AutoSize = true;
            this.etiNombre.Location = new System.Drawing.Point(12, 10);
            this.etiNombre.Name = "etiNombre";
            this.etiNombre.Size = new System.Drawing.Size(47, 13);
            this.etiNombre.TabIndex = 0;
            this.etiNombre.Text = "Nombre:";
            // 
            // etiApellido
            // 
            this.etiApellido.AutoSize = true;
            this.etiApellido.Location = new System.Drawing.Point(12, 42);
            this.etiApellido.Name = "etiApellido";
            this.etiApellido.Size = new System.Drawing.Size(47, 13);
            this.etiApellido.TabIndex = 1;
            this.etiApellido.Text = "Apellido:";
            // 
            // etiDNI
            // 
            this.etiDNI.AutoSize = true;
            this.etiDNI.Location = new System.Drawing.Point(12, 74);
            this.etiDNI.Name = "etiDNI";
            this.etiDNI.Size = new System.Drawing.Size(29, 13);
            this.etiDNI.TabIndex = 2;
            this.etiDNI.Text = "DNI:";
            // 
            // etiTelefono
            // 
            this.etiTelefono.AutoSize = true;
            this.etiTelefono.Location = new System.Drawing.Point(332, 45);
            this.etiTelefono.Name = "etiTelefono";
            this.etiTelefono.Size = new System.Drawing.Size(52, 13);
            this.etiTelefono.TabIndex = 3;
            this.etiTelefono.Text = "Telefono:";
            // 
            // etiCalle
            // 
            this.etiCalle.AutoSize = true;
            this.etiCalle.Location = new System.Drawing.Point(12, 112);
            this.etiCalle.Name = "etiCalle";
            this.etiCalle.Size = new System.Drawing.Size(33, 13);
            this.etiCalle.TabIndex = 4;
            this.etiCalle.Text = "Calle:";
            // 
            // etiPisoManzana
            // 
            this.etiPisoManzana.AutoSize = true;
            this.etiPisoManzana.Location = new System.Drawing.Point(332, 140);
            this.etiPisoManzana.Name = "etiPisoManzana";
            this.etiPisoManzana.Size = new System.Drawing.Size(79, 13);
            this.etiPisoManzana.TabIndex = 6;
            this.etiPisoManzana.Text = "Piso/Manzana:";
            // 
            // etiDeptoLote
            // 
            this.etiDeptoLote.AutoSize = true;
            this.etiDeptoLote.Location = new System.Drawing.Point(12, 140);
            this.etiDeptoLote.Name = "etiDeptoLote";
            this.etiDeptoLote.Size = new System.Drawing.Size(103, 13);
            this.etiDeptoLote.TabIndex = 7;
            this.etiDeptoLote.Text = "Departamento/Lote:";
            // 
            // etiLocalidad
            // 
            this.etiLocalidad.AutoSize = true;
            this.etiLocalidad.Location = new System.Drawing.Point(13, 173);
            this.etiLocalidad.Name = "etiLocalidad";
            this.etiLocalidad.Size = new System.Drawing.Size(53, 13);
            this.etiLocalidad.TabIndex = 8;
            this.etiLocalidad.Text = "Localidad";
            // 
            // etiCorreoElectronico
            // 
            this.etiCorreoElectronico.AutoSize = true;
            this.etiCorreoElectronico.Location = new System.Drawing.Point(332, 13);
            this.etiCorreoElectronico.Name = "etiCorreoElectronico";
            this.etiCorreoElectronico.Size = new System.Drawing.Size(97, 13);
            this.etiCorreoElectronico.TabIndex = 9;
            this.etiCorreoElectronico.Text = "Correo Electronico:";
            // 
            // etiCodigoPostal
            // 
            this.etiCodigoPostal.AutoSize = true;
            this.etiCodigoPostal.Location = new System.Drawing.Point(332, 177);
            this.etiCodigoPostal.Name = "etiCodigoPostal";
            this.etiCodigoPostal.Size = new System.Drawing.Size(75, 13);
            this.etiCodigoPostal.TabIndex = 10;
            this.etiCodigoPostal.Text = "Codigo Postal:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(124, 7);
            this.txtNombre.MaxLength = 255;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(174, 20);
            this.txtNombre.TabIndex = 11;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(124, 39);
            this.txtApellido.MaxLength = 255;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(174, 20);
            this.txtApellido.TabIndex = 12;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(434, 10);
            this.txtCorreo.MaxLength = 255;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(174, 20);
            this.txtCorreo.TabIndex = 17;
            this.txtCorreo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCorreo_KeyPress);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(434, 42);
            this.txtTelefono.MaxLength = 18;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(174, 20);
            this.txtTelefono.TabIndex = 18;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(124, 105);
            this.txtCalle.MaxLength = 255;
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(174, 20);
            this.txtCalle.TabIndex = 14;
            this.txtCalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCalle_KeyPress);
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(124, 170);
            this.txtLocalidad.MaxLength = 255;
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(174, 20);
            this.txtLocalidad.TabIndex = 16;
            this.txtLocalidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLocalidad_KeyPress);
            // 
            // txtPisoManzana
            // 
            this.txtPisoManzana.Location = new System.Drawing.Point(434, 137);
            this.txtPisoManzana.MaxLength = 5;
            this.txtPisoManzana.Name = "txtPisoManzana";
            this.txtPisoManzana.Size = new System.Drawing.Size(174, 20);
            this.txtPisoManzana.TabIndex = 21;
            this.txtPisoManzana.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPisoManzana_KeyPress);
            // 
            // txtDeptoLote
            // 
            this.txtDeptoLote.Location = new System.Drawing.Point(124, 137);
            this.txtDeptoLote.MaxLength = 255;
            this.txtDeptoLote.Name = "txtDeptoLote";
            this.txtDeptoLote.Size = new System.Drawing.Size(174, 20);
            this.txtDeptoLote.TabIndex = 15;
            this.txtDeptoLote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDeptoLote_KeyPress);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(101, 212);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(131, 29);
            this.btnAceptar.TabIndex = 23;
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(391, 212);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(131, 29);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(332, 78);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(96, 13);
            this.lblFechaNacimiento.TabIndex = 31;
            this.lblFechaNacimiento.Text = "Fecha Nacimiento:";
            // 
            // ccHabilitado
            // 
            this.ccHabilitado.AutoSize = true;
            this.ccHabilitado.Location = new System.Drawing.Point(434, 108);
            this.ccHabilitado.Name = "ccHabilitado";
            this.ccHabilitado.Size = new System.Drawing.Size(73, 17);
            this.ccHabilitado.TabIndex = 20;
            this.ccHabilitado.Text = "Habilitado";
            this.ccHabilitado.UseVisualStyleBackColor = true;
            // 
            // grupoDatosPersona
            // 
            this.grupoDatosPersona.Controls.Add(this.lblIdPersona);
            this.grupoDatosPersona.Controls.Add(this.txtCodigoPostal);
            this.grupoDatosPersona.Controls.Add(this.txtDNI);
            this.grupoDatosPersona.Controls.Add(this.selectorFechaNacimiento);
            this.grupoDatosPersona.Controls.Add(this.ccHabilitado);
            this.grupoDatosPersona.Controls.Add(this.lblFechaNacimiento);
            this.grupoDatosPersona.Controls.Add(this.btnCancelar);
            this.grupoDatosPersona.Controls.Add(this.btnAceptar);
            this.grupoDatosPersona.Controls.Add(this.txtDeptoLote);
            this.grupoDatosPersona.Controls.Add(this.txtPisoManzana);
            this.grupoDatosPersona.Controls.Add(this.txtLocalidad);
            this.grupoDatosPersona.Controls.Add(this.txtCalle);
            this.grupoDatosPersona.Controls.Add(this.txtTelefono);
            this.grupoDatosPersona.Controls.Add(this.txtCorreo);
            this.grupoDatosPersona.Controls.Add(this.txtApellido);
            this.grupoDatosPersona.Controls.Add(this.txtNombre);
            this.grupoDatosPersona.Controls.Add(this.etiCodigoPostal);
            this.grupoDatosPersona.Controls.Add(this.etiCorreoElectronico);
            this.grupoDatosPersona.Controls.Add(this.etiLocalidad);
            this.grupoDatosPersona.Controls.Add(this.etiDeptoLote);
            this.grupoDatosPersona.Controls.Add(this.etiPisoManzana);
            this.grupoDatosPersona.Controls.Add(this.etiCalle);
            this.grupoDatosPersona.Controls.Add(this.etiTelefono);
            this.grupoDatosPersona.Controls.Add(this.etiDNI);
            this.grupoDatosPersona.Controls.Add(this.etiApellido);
            this.grupoDatosPersona.Controls.Add(this.etiNombre);
            this.grupoDatosPersona.Location = new System.Drawing.Point(12, 91);
            this.grupoDatosPersona.Name = "grupoDatosPersona";
            this.grupoDatosPersona.Size = new System.Drawing.Size(622, 264);
            this.grupoDatosPersona.TabIndex = 34;
            this.grupoDatosPersona.TabStop = false;
            // 
            // lblIdPersona
            // 
            this.lblIdPersona.AutoSize = true;
            this.lblIdPersona.Location = new System.Drawing.Point(559, 220);
            this.lblIdPersona.Name = "lblIdPersona";
            this.lblIdPersona.Size = new System.Drawing.Size(0, 13);
            this.lblIdPersona.TabIndex = 39;
            this.lblIdPersona.Visible = false;
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Location = new System.Drawing.Point(434, 170);
            this.txtCodigoPostal.MaxLength = 8;
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(174, 20);
            this.txtCodigoPostal.TabIndex = 22;
            this.txtCodigoPostal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoPostal_KeyPress);
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(124, 71);
            this.txtDNI.MaxLength = 18;
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(174, 20);
            this.txtDNI.TabIndex = 13;
            this.txtDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDNI_KeyPress);
            // 
            // selectorFechaNacimiento
            // 
            this.selectorFechaNacimiento.CustomFormat = "dd/MM/yyyy";
            this.selectorFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.selectorFechaNacimiento.Location = new System.Drawing.Point(434, 71);
            this.selectorFechaNacimiento.MaxDate = new System.DateTime(2017, 6, 29, 0, 0, 0, 0);
            this.selectorFechaNacimiento.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.selectorFechaNacimiento.Name = "selectorFechaNacimiento";
            this.selectorFechaNacimiento.Size = new System.Drawing.Size(103, 20);
            this.selectorFechaNacimiento.TabIndex = 19;
            this.selectorFechaNacimiento.Value = new System.DateTime(2017, 6, 29, 0, 0, 0, 0);
            // 
            // frmABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(638, 355);
            this.Controls.Add(this.grupoBusquedaABM);
            this.Controls.Add(this.grupoDatosPersona);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmABM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.grupoBusquedaABM.ResumeLayout(false);
            this.grupoBusquedaABM.PerformLayout();
            this.grupoDatosPersona.ResumeLayout(false);
            this.grupoDatosPersona.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtBusquedaNombre;
        private System.Windows.Forms.TextBox txtBusquedaApellido;
        private System.Windows.Forms.TextBox txtBusquedaDNI;
        private System.Windows.Forms.Label lblBusquedaNombre;
        private System.Windows.Forms.Label lblBuscarApellido;
        private System.Windows.Forms.Label lblBuscarDNI;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox grupoBusquedaABM;
        private System.Windows.Forms.Label etiNombre;
        private System.Windows.Forms.Label etiApellido;
        private System.Windows.Forms.Label etiDNI;
        private System.Windows.Forms.Label etiTelefono;
        private System.Windows.Forms.Label etiCalle;
        private System.Windows.Forms.Label etiPisoManzana;
        private System.Windows.Forms.Label etiDeptoLote;
        private System.Windows.Forms.Label etiLocalidad;
        private System.Windows.Forms.Label etiCorreoElectronico;
        private System.Windows.Forms.Label etiCodigoPostal;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtCorreo;
        protected System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.TextBox txtPisoManzana;
        private System.Windows.Forms.TextBox txtDeptoLote;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.CheckBox ccHabilitado;
        private System.Windows.Forms.GroupBox grupoDatosPersona;
        private System.Windows.Forms.DateTimePicker selectorFechaNacimiento;
        protected System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.Label lblIdPersona;

    }
}
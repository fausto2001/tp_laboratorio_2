
namespace AeronaveForm
{
    partial class FormAgregarModificar
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
            this.lblAeronave = new System.Windows.Forms.Label();
            this.CMBAeronave = new System.Windows.Forms.ComboBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.TXTMarca = new System.Windows.Forms.TextBox();
            this.lblModelo = new System.Windows.Forms.Label();
            this.TXTModelo = new System.Windows.Forms.TextBox();
            this.trackVelocidad = new System.Windows.Forms.TrackBar();
            this.lblVelocidad = new System.Windows.Forms.Label();
            this.trackAltura = new System.Windows.Forms.TrackBar();
            this.lblAltura = new System.Windows.Forms.Label();
            this.lblAncho = new System.Windows.Forms.Label();
            this.trackAncho = new System.Windows.Forms.TrackBar();
            this.lblLargo = new System.Windows.Forms.Label();
            this.trackLargo = new System.Windows.Forms.TrackBar();
            this.lblPeso = new System.Windows.Forms.Label();
            this.trackPeso = new System.Windows.Forms.TrackBar();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.lblAnio = new System.Windows.Forms.Label();
            this.txtRotores = new System.Windows.Forms.TextBox();
            this.lblRotores = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblMotor = new System.Windows.Forms.Label();
            this.cmbMotor = new System.Windows.Forms.ComboBox();
            this.lblTipoAvion = new System.Windows.Forms.Label();
            this.lblCapacidadAire = new System.Windows.Forms.Label();
            this.trackCapacidadAire = new System.Windows.Forms.TrackBar();
            this.lblPasajeros = new System.Windows.Forms.Label();
            this.txtPasajeros = new System.Windows.Forms.TextBox();
            this.lblTrackVelocidad = new System.Windows.Forms.Label();
            this.lblTrackAltura = new System.Windows.Forms.Label();
            this.lblTrackLargo = new System.Windows.Forms.Label();
            this.lblTrackAncho = new System.Windows.Forms.Label();
            this.lblTrackPeso = new System.Windows.Forms.Label();
            this.lblTrackCapacidadAire = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackVelocidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAltura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAncho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackLargo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPeso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackCapacidadAire)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAeronave
            // 
            this.lblAeronave.AutoSize = true;
            this.lblAeronave.Location = new System.Drawing.Point(12, 9);
            this.lblAeronave.Name = "lblAeronave";
            this.lblAeronave.Size = new System.Drawing.Size(57, 15);
            this.lblAeronave.TabIndex = 0;
            this.lblAeronave.Text = "Aeronave";
            // 
            // CMBAeronave
            // 
            this.CMBAeronave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBAeronave.Items.AddRange(new object[] {
            "Helicoptero",
            "Avion",
            "Globo"});
            this.CMBAeronave.Location = new System.Drawing.Point(12, 27);
            this.CMBAeronave.Name = "CMBAeronave";
            this.CMBAeronave.Size = new System.Drawing.Size(121, 23);
            this.CMBAeronave.TabIndex = 1;
            this.CMBAeronave.SelectedIndexChanged += new System.EventHandler(this.CMBAeronave_SelectedIndexChanged);
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(168, 9);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(40, 15);
            this.lblMarca.TabIndex = 2;
            this.lblMarca.Text = "Marca";
            // 
            // TXTMarca
            // 
            this.TXTMarca.Location = new System.Drawing.Point(168, 27);
            this.TXTMarca.Name = "TXTMarca";
            this.TXTMarca.Size = new System.Drawing.Size(127, 23);
            this.TXTMarca.TabIndex = 3;
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Location = new System.Drawing.Point(324, 9);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(48, 15);
            this.lblModelo.TabIndex = 4;
            this.lblModelo.Text = "Modelo";
            // 
            // TXTModelo
            // 
            this.TXTModelo.Location = new System.Drawing.Point(324, 27);
            this.TXTModelo.Name = "TXTModelo";
            this.TXTModelo.Size = new System.Drawing.Size(127, 23);
            this.TXTModelo.TabIndex = 5;
            // 
            // trackVelocidad
            // 
            this.trackVelocidad.Location = new System.Drawing.Point(12, 78);
            this.trackVelocidad.Name = "trackVelocidad";
            this.trackVelocidad.Size = new System.Drawing.Size(207, 45);
            this.trackVelocidad.TabIndex = 6;
            this.trackVelocidad.Scroll += new System.EventHandler(this.trackVelocidad_Scroll);
            // 
            // lblVelocidad
            // 
            this.lblVelocidad.AutoSize = true;
            this.lblVelocidad.Location = new System.Drawing.Point(12, 60);
            this.lblVelocidad.Name = "lblVelocidad";
            this.lblVelocidad.Size = new System.Drawing.Size(104, 15);
            this.lblVelocidad.TabIndex = 7;
            this.lblVelocidad.Text = "Velocidad Maxima";
            // 
            // trackAltura
            // 
            this.trackAltura.Location = new System.Drawing.Point(244, 78);
            this.trackAltura.Name = "trackAltura";
            this.trackAltura.Size = new System.Drawing.Size(207, 45);
            this.trackAltura.TabIndex = 8;
            this.trackAltura.Scroll += new System.EventHandler(this.trackAltura_Scroll);
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Location = new System.Drawing.Point(244, 60);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(85, 15);
            this.lblAltura.TabIndex = 9;
            this.lblAltura.Text = "Altura Maxima";
            // 
            // lblAncho
            // 
            this.lblAncho.AutoSize = true;
            this.lblAncho.Location = new System.Drawing.Point(244, 120);
            this.lblAncho.Name = "lblAncho";
            this.lblAncho.Size = new System.Drawing.Size(42, 15);
            this.lblAncho.TabIndex = 13;
            this.lblAncho.Text = "Ancho";
            // 
            // trackAncho
            // 
            this.trackAncho.Location = new System.Drawing.Point(244, 138);
            this.trackAncho.Name = "trackAncho";
            this.trackAncho.Size = new System.Drawing.Size(207, 45);
            this.trackAncho.TabIndex = 12;
            this.trackAncho.Scroll += new System.EventHandler(this.trackAncho_Scroll);
            // 
            // lblLargo
            // 
            this.lblLargo.AutoSize = true;
            this.lblLargo.Location = new System.Drawing.Point(12, 120);
            this.lblLargo.Name = "lblLargo";
            this.lblLargo.Size = new System.Drawing.Size(37, 15);
            this.lblLargo.TabIndex = 11;
            this.lblLargo.Text = "Largo";
            // 
            // trackLargo
            // 
            this.trackLargo.Location = new System.Drawing.Point(12, 138);
            this.trackLargo.Name = "trackLargo";
            this.trackLargo.Size = new System.Drawing.Size(207, 45);
            this.trackLargo.TabIndex = 10;
            this.trackLargo.Scroll += new System.EventHandler(this.trackLargo_Scroll);
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Location = new System.Drawing.Point(12, 181);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(32, 15);
            this.lblPeso.TabIndex = 15;
            this.lblPeso.Text = "Peso";
            // 
            // trackPeso
            // 
            this.trackPeso.Location = new System.Drawing.Point(12, 199);
            this.trackPeso.Name = "trackPeso";
            this.trackPeso.Size = new System.Drawing.Size(207, 45);
            this.trackPeso.TabIndex = 14;
            this.trackPeso.Scroll += new System.EventHandler(this.trackPeso_Scroll);
            // 
            // txtAnio
            // 
            this.txtAnio.Location = new System.Drawing.Point(251, 207);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(127, 23);
            this.txtAnio.TabIndex = 17;
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(251, 189);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(29, 15);
            this.lblAnio.TabIndex = 16;
            this.lblAnio.Text = "Año";
            // 
            // txtRotores
            // 
            this.txtRotores.Location = new System.Drawing.Point(19, 250);
            this.txtRotores.Name = "txtRotores";
            this.txtRotores.Size = new System.Drawing.Size(127, 23);
            this.txtRotores.TabIndex = 18;
            this.txtRotores.Visible = false;
            // 
            // lblRotores
            // 
            this.lblRotores.AutoSize = true;
            this.lblRotores.Location = new System.Drawing.Point(19, 232);
            this.lblRotores.Name = "lblRotores";
            this.lblRotores.Size = new System.Drawing.Size(47, 15);
            this.lblRotores.TabIndex = 19;
            this.lblRotores.Text = "Rotores";
            this.lblRotores.Visible = false;
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Items.AddRange(new object[] {
            "Militar",
            "Sanitario",
            "Civil"});
            this.cmbTipo.Location = new System.Drawing.Point(251, 253);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(121, 23);
            this.cmbTipo.TabIndex = 21;
            this.cmbTipo.Visible = false;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(250, 236);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(30, 15);
            this.lblTipo.TabIndex = 20;
            this.lblTipo.Text = "Tipo";
            this.lblTipo.Visible = false;
            // 
            // lblMotor
            // 
            this.lblMotor.AutoSize = true;
            this.lblMotor.Location = new System.Drawing.Point(19, 232);
            this.lblMotor.Name = "lblMotor";
            this.lblMotor.Size = new System.Drawing.Size(40, 15);
            this.lblMotor.TabIndex = 22;
            this.lblMotor.Text = "Motor";
            this.lblMotor.Visible = false;
            // 
            // cmbMotor
            // 
            this.cmbMotor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMotor.Items.AddRange(new object[] {
            "Propulsion",
            "DeReaccion"});
            this.cmbMotor.Location = new System.Drawing.Point(19, 250);
            this.cmbMotor.Name = "cmbMotor";
            this.cmbMotor.Size = new System.Drawing.Size(121, 23);
            this.cmbMotor.TabIndex = 23;
            this.cmbMotor.Visible = false;
            this.cmbMotor.SelectedIndexChanged += new System.EventHandler(this.cmbMotor_SelectedIndexChanged);
            // 
            // lblTipoAvion
            // 
            this.lblTipoAvion.AutoSize = true;
            this.lblTipoAvion.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTipoAvion.Location = new System.Drawing.Point(251, 254);
            this.lblTipoAvion.Name = "lblTipoAvion";
            this.lblTipoAvion.Size = new System.Drawing.Size(52, 22);
            this.lblTipoAvion.TabIndex = 24;
            this.lblTipoAvion.Text = "Tipo";
            this.lblTipoAvion.Visible = false;
            // 
            // lblCapacidadAire
            // 
            this.lblCapacidadAire.AutoSize = true;
            this.lblCapacidadAire.Location = new System.Drawing.Point(19, 229);
            this.lblCapacidadAire.Name = "lblCapacidadAire";
            this.lblCapacidadAire.Size = new System.Drawing.Size(87, 15);
            this.lblCapacidadAire.TabIndex = 25;
            this.lblCapacidadAire.Text = "Capacidad Aire";
            this.lblCapacidadAire.Visible = false;
            // 
            // trackCapacidadAire
            // 
            this.trackCapacidadAire.Location = new System.Drawing.Point(12, 247);
            this.trackCapacidadAire.Name = "trackCapacidadAire";
            this.trackCapacidadAire.Size = new System.Drawing.Size(207, 45);
            this.trackCapacidadAire.TabIndex = 26;
            this.trackCapacidadAire.Scroll += new System.EventHandler(this.trackCapacidadAire_Scroll);
            // 
            // lblPasajeros
            // 
            this.lblPasajeros.AutoSize = true;
            this.lblPasajeros.Location = new System.Drawing.Point(251, 236);
            this.lblPasajeros.Name = "lblPasajeros";
            this.lblPasajeros.Size = new System.Drawing.Size(56, 15);
            this.lblPasajeros.TabIndex = 27;
            this.lblPasajeros.Text = "Pasajeros";
            this.lblPasajeros.Visible = false;
            // 
            // txtPasajeros
            // 
            this.txtPasajeros.Location = new System.Drawing.Point(251, 254);
            this.txtPasajeros.Name = "txtPasajeros";
            this.txtPasajeros.Size = new System.Drawing.Size(127, 23);
            this.txtPasajeros.TabIndex = 28;
            // 
            // lblTrackVelocidad
            // 
            this.lblTrackVelocidad.AutoSize = true;
            this.lblTrackVelocidad.Location = new System.Drawing.Point(122, 60);
            this.lblTrackVelocidad.Name = "lblTrackVelocidad";
            this.lblTrackVelocidad.Size = new System.Drawing.Size(36, 15);
            this.lblTrackVelocidad.TabIndex = 29;
            this.lblTrackVelocidad.Text = "km/h";
            // 
            // lblTrackAltura
            // 
            this.lblTrackAltura.AutoSize = true;
            this.lblTrackAltura.Location = new System.Drawing.Point(335, 60);
            this.lblTrackAltura.Name = "lblTrackAltura";
            this.lblTrackAltura.Size = new System.Drawing.Size(18, 15);
            this.lblTrackAltura.TabIndex = 30;
            this.lblTrackAltura.Text = "m";
            // 
            // lblTrackLargo
            // 
            this.lblTrackLargo.AutoSize = true;
            this.lblTrackLargo.Location = new System.Drawing.Point(55, 120);
            this.lblTrackLargo.Name = "lblTrackLargo";
            this.lblTrackLargo.Size = new System.Drawing.Size(18, 15);
            this.lblTrackLargo.TabIndex = 31;
            this.lblTrackLargo.Text = "m";
            // 
            // lblTrackAncho
            // 
            this.lblTrackAncho.AutoSize = true;
            this.lblTrackAncho.Location = new System.Drawing.Point(292, 120);
            this.lblTrackAncho.Name = "lblTrackAncho";
            this.lblTrackAncho.Size = new System.Drawing.Size(18, 15);
            this.lblTrackAncho.TabIndex = 32;
            this.lblTrackAncho.Text = "m";
            // 
            // lblTrackPeso
            // 
            this.lblTrackPeso.AutoSize = true;
            this.lblTrackPeso.Location = new System.Drawing.Point(50, 181);
            this.lblTrackPeso.Name = "lblTrackPeso";
            this.lblTrackPeso.Size = new System.Drawing.Size(18, 15);
            this.lblTrackPeso.TabIndex = 33;
            this.lblTrackPeso.Text = "m";
            // 
            // lblTrackCapacidadAire
            // 
            this.lblTrackCapacidadAire.AutoSize = true;
            this.lblTrackCapacidadAire.Location = new System.Drawing.Point(112, 229);
            this.lblTrackCapacidadAire.Name = "lblTrackCapacidadAire";
            this.lblTrackCapacidadAire.Size = new System.Drawing.Size(20, 15);
            this.lblTrackCapacidadAire.TabIndex = 34;
            this.lblTrackCapacidadAire.Text = "kg";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(19, 309);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(127, 49);
            this.btnGuardar.TabIndex = 35;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(251, 309);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(127, 49);
            this.btnCancelar.TabIndex = 36;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormAgregarModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 450);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblTrackCapacidadAire);
            this.Controls.Add(this.lblTrackPeso);
            this.Controls.Add(this.lblTrackAncho);
            this.Controls.Add(this.lblTrackLargo);
            this.Controls.Add(this.lblTrackAltura);
            this.Controls.Add(this.lblTrackVelocidad);
            this.Controls.Add(this.txtPasajeros);
            this.Controls.Add(this.lblPasajeros);
            this.Controls.Add(this.trackCapacidadAire);
            this.Controls.Add(this.lblCapacidadAire);
            this.Controls.Add(this.lblTipoAvion);
            this.Controls.Add(this.cmbMotor);
            this.Controls.Add(this.lblMotor);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblRotores);
            this.Controls.Add(this.txtRotores);
            this.Controls.Add(this.txtAnio);
            this.Controls.Add(this.lblAnio);
            this.Controls.Add(this.lblPeso);
            this.Controls.Add(this.trackPeso);
            this.Controls.Add(this.lblAncho);
            this.Controls.Add(this.trackAncho);
            this.Controls.Add(this.lblLargo);
            this.Controls.Add(this.trackLargo);
            this.Controls.Add(this.lblAltura);
            this.Controls.Add(this.trackAltura);
            this.Controls.Add(this.lblVelocidad);
            this.Controls.Add(this.trackVelocidad);
            this.Controls.Add(this.TXTModelo);
            this.Controls.Add(this.lblModelo);
            this.Controls.Add(this.TXTMarca);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.CMBAeronave);
            this.Controls.Add(this.lblAeronave);
            this.Name = "FormAgregarModificar";
            this.Text = "FormAgregarModificar";
            this.Load += new System.EventHandler(this.FormAgregarModificar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackVelocidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAltura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAncho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackLargo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPeso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackCapacidadAire)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAeronave;
        private System.Windows.Forms.ComboBox CMBAeronave;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.TextBox TXTMarca;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.TextBox TXTModelo;
        private System.Windows.Forms.TrackBar trackVelocidad;
        private System.Windows.Forms.Label lblVelocidad;
        private System.Windows.Forms.TrackBar trackAltura;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.Label lblAncho;
        private System.Windows.Forms.TrackBar trackAncho;
        private System.Windows.Forms.Label lblLargo;
        private System.Windows.Forms.TrackBar trackLargo;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.TrackBar trackPeso;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.TextBox txtRotores;
        private System.Windows.Forms.Label lblRotores;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblMotor;
        private System.Windows.Forms.ComboBox cmbMotor;
        private System.Windows.Forms.Label lblTipoAvion;
        private System.Windows.Forms.Label lblCapacidadAire;
        private System.Windows.Forms.TrackBar trackCapacidadAire;
        private System.Windows.Forms.Label lblPasajeros;
        private System.Windows.Forms.TextBox txtPasajeros;
        private System.Windows.Forms.Label lblTrackVelocidad;
        private System.Windows.Forms.Label lblTrackAltura;
        private System.Windows.Forms.Label lblTrackLargo;
        private System.Windows.Forms.Label lblTrackAncho;
        private System.Windows.Forms.Label lblTrackPeso;
        private System.Windows.Forms.Label lblTrackCapacidadAire;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
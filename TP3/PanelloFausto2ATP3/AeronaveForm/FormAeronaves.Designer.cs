
namespace AeronaveForm
{
    partial class FormAeronaves
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LBAeronaves = new System.Windows.Forms.ListBox();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnCargar = new System.Windows.Forms.Button();
            this.BtnAnalisis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LBAeronaves
            // 
            this.LBAeronaves.FormattingEnabled = true;
            this.LBAeronaves.ItemHeight = 15;
            this.LBAeronaves.Location = new System.Drawing.Point(12, 12);
            this.LBAeronaves.Name = "LBAeronaves";
            this.LBAeronaves.Size = new System.Drawing.Size(646, 364);
            this.LBAeronaves.TabIndex = 0;
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.AutoEllipsis = true;
            this.BtnAgregar.BackColor = System.Drawing.Color.Lime;
            this.BtnAgregar.Location = new System.Drawing.Point(12, 382);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(163, 56);
            this.BtnAgregar.TabIndex = 1;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = false;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.BackColor = System.Drawing.Color.Red;
            this.BtnEliminar.Location = new System.Drawing.Point(495, 382);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(163, 56);
            this.BtnEliminar.TabIndex = 2;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = false;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnModificar
            // 
            this.BtnModificar.BackColor = System.Drawing.Color.Yellow;
            this.BtnModificar.Location = new System.Drawing.Point(258, 382);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(163, 56);
            this.BtnModificar.TabIndex = 3;
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = false;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(664, 12);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(127, 46);
            this.BtnGuardar.TabIndex = 4;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnCargar
            // 
            this.BtnCargar.Location = new System.Drawing.Point(664, 89);
            this.BtnCargar.Name = "BtnCargar";
            this.BtnCargar.Size = new System.Drawing.Size(127, 46);
            this.BtnCargar.TabIndex = 5;
            this.BtnCargar.Text = "Cargar";
            this.BtnCargar.UseVisualStyleBackColor = true;
            this.BtnCargar.Click += new System.EventHandler(this.BtnCargar_Click);
            // 
            // BtnAnalisis
            // 
            this.BtnAnalisis.Location = new System.Drawing.Point(664, 164);
            this.BtnAnalisis.Name = "BtnAnalisis";
            this.BtnAnalisis.Size = new System.Drawing.Size(127, 46);
            this.BtnAnalisis.TabIndex = 6;
            this.BtnAnalisis.Text = "Analisis";
            this.BtnAnalisis.UseVisualStyleBackColor = true;
            this.BtnAnalisis.Click += new System.EventHandler(this.BtnAnalisis_Click);
            // 
            // FormAeronaves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnAnalisis);
            this.Controls.Add(this.BtnCargar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.LBAeronaves);
            this.Name = "FormAeronaves";
            this.Text = "Aeronaves";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LBAeronaves;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnCargar;
        private System.Windows.Forms.Button BtnAnalisis;
    }
}


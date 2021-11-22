
namespace AeronaveForm
{
    partial class FormCarrera
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
            this.lblAeronave1 = new System.Windows.Forms.Label();
            this.lblAeronave2 = new System.Windows.Forms.Label();
            this.lblDistancia1 = new System.Windows.Forms.Label();
            this.lblDistancia2 = new System.Windows.Forms.Label();
            this.btnEmpezar = new System.Windows.Forms.Button();
            this.lblExplicativo = new System.Windows.Forms.Label();
            this.lblExplicativo2 = new System.Windows.Forms.Label();
            this.lblExplicativo3 = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblMs = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAeronave1
            // 
            this.lblAeronave1.AutoSize = true;
            this.lblAeronave1.Location = new System.Drawing.Point(5, 9);
            this.lblAeronave1.Name = "lblAeronave1";
            this.lblAeronave1.Size = new System.Drawing.Size(38, 15);
            this.lblAeronave1.TabIndex = 0;
            this.lblAeronave1.Text = "label1";
            this.lblAeronave1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblAeronave2
            // 
            this.lblAeronave2.AutoSize = true;
            this.lblAeronave2.Location = new System.Drawing.Point(156, 10);
            this.lblAeronave2.Name = "lblAeronave2";
            this.lblAeronave2.Size = new System.Drawing.Size(38, 15);
            this.lblAeronave2.TabIndex = 1;
            this.lblAeronave2.Text = "label2";
            // 
            // lblDistancia1
            // 
            this.lblDistancia1.AutoSize = true;
            this.lblDistancia1.Location = new System.Drawing.Point(12, 62);
            this.lblDistancia1.Name = "lblDistancia1";
            this.lblDistancia1.Size = new System.Drawing.Size(38, 15);
            this.lblDistancia1.TabIndex = 2;
            this.lblDistancia1.Text = "label3";
            // 
            // lblDistancia2
            // 
            this.lblDistancia2.AutoSize = true;
            this.lblDistancia2.Location = new System.Drawing.Point(174, 62);
            this.lblDistancia2.Name = "lblDistancia2";
            this.lblDistancia2.Size = new System.Drawing.Size(38, 15);
            this.lblDistancia2.TabIndex = 3;
            this.lblDistancia2.Text = "label4";
            // 
            // btnEmpezar
            // 
            this.btnEmpezar.Location = new System.Drawing.Point(73, 138);
            this.btnEmpezar.Name = "btnEmpezar";
            this.btnEmpezar.Size = new System.Drawing.Size(75, 23);
            this.btnEmpezar.TabIndex = 4;
            this.btnEmpezar.Text = "Empezar";
            this.btnEmpezar.UseVisualStyleBackColor = true;
            this.btnEmpezar.Click += new System.EventHandler(this.btnEmpezar_Click);
            // 
            // lblExplicativo
            // 
            this.lblExplicativo.AutoSize = true;
            this.lblExplicativo.Location = new System.Drawing.Point(8, 90);
            this.lblExplicativo.Name = "lblExplicativo";
            this.lblExplicativo.Size = new System.Drawing.Size(220, 15);
            this.lblExplicativo.TabIndex = 5;
            this.lblExplicativo.Text = "Distancia que recorren en metros las dos";
            // 
            // lblExplicativo2
            // 
            this.lblExplicativo2.AutoSize = true;
            this.lblExplicativo2.Location = new System.Drawing.Point(8, 105);
            this.lblExplicativo2.Name = "lblExplicativo2";
            this.lblExplicativo2.Size = new System.Drawing.Size(226, 15);
            this.lblExplicativo2.TabIndex = 6;
            this.lblExplicativo2.Text = "aeronaves elegidas a comparar en tiempo";
            // 
            // lblExplicativo3
            // 
            this.lblExplicativo3.AutoSize = true;
            this.lblExplicativo3.Location = new System.Drawing.Point(8, 120);
            this.lblExplicativo3.Name = "lblExplicativo3";
            this.lblExplicativo3.Size = new System.Drawing.Size(229, 15);
            this.lblExplicativo3.TabIndex = 7;
            this.lblExplicativo3.Text = "real, a velocidad maxima, en 10 segundos.";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(77, 38);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(13, 15);
            this.lblTimer.TabIndex = 8;
            this.lblTimer.Text = "0";
            // 
            // lblMs
            // 
            this.lblMs.AutoSize = true;
            this.lblMs.Location = new System.Drawing.Point(110, 38);
            this.lblMs.Name = "lblMs";
            this.lblMs.Size = new System.Drawing.Size(23, 15);
            this.lblMs.TabIndex = 9;
            this.lblMs.Text = "ms";
            // 
            // FormCarrera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 173);
            this.Controls.Add(this.lblMs);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblExplicativo3);
            this.Controls.Add(this.lblExplicativo2);
            this.Controls.Add(this.lblExplicativo);
            this.Controls.Add(this.btnEmpezar);
            this.Controls.Add(this.lblDistancia2);
            this.Controls.Add(this.lblDistancia1);
            this.Controls.Add(this.lblAeronave2);
            this.Controls.Add(this.lblAeronave1);
            this.Name = "FormCarrera";
            this.Text = "FormCarrera";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAeronave1;
        private System.Windows.Forms.Label lblAeronave2;
        private System.Windows.Forms.Label lblDistancia1;
        private System.Windows.Forms.Label lblDistancia2;
        private System.Windows.Forms.Button btnEmpezar;
        private System.Windows.Forms.Label lblExplicativo;
        private System.Windows.Forms.Label lblExplicativo2;
        private System.Windows.Forms.Label lblExplicativo3;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblMs;
    }
}
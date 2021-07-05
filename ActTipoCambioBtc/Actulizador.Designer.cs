
namespace ActTipoCambioBtc
{
    partial class Actulizador
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
            this.components = new System.ComponentModel.Container();
            this.lblPrecioActual = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblPrecioActual
            // 
            this.lblPrecioActual.AutoSize = true;
            this.lblPrecioActual.Location = new System.Drawing.Point(12, 93);
            this.lblPrecioActual.Name = "lblPrecioActual";
            this.lblPrecioActual.Size = new System.Drawing.Size(0, 15);
            this.lblPrecioActual.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Actulizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblPrecioActual);
            this.Name = "Actulizador";
            this.Text = "Actulizador";
            this.Load += new System.EventHandler(this.Actulizador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPrecioActual;
        private System.Windows.Forms.Timer timer1;
    }
}
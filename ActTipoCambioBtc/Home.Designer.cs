
namespace ActTipoCambioBtc
{
    partial class Home
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
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.btnConfiguracion = new System.Windows.Forms.Button();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.btnActulizador = new System.Windows.Forms.Button();
            this.PanelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMenu
            // 
            this.PanelMenu.Controls.Add(this.btnActulizador);
            this.PanelMenu.Controls.Add(this.btnConfiguracion);
            this.PanelMenu.Location = new System.Drawing.Point(1, 2);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(233, 447);
            this.PanelMenu.TabIndex = 0;
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.Location = new System.Drawing.Point(69, 393);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Size = new System.Drawing.Size(86, 23);
            this.btnConfiguracion.TabIndex = 0;
            this.btnConfiguracion.Text = "Configuracion";
            this.btnConfiguracion.UseVisualStyleBackColor = true;
            this.btnConfiguracion.Click += new System.EventHandler(this.btnConfiguracion_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.Location = new System.Drawing.Point(231, 2);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(574, 446);
            this.panelContenedor.TabIndex = 1;
            // 
            // btnActulizador
            // 
            this.btnActulizador.Location = new System.Drawing.Point(69, 348);
            this.btnActulizador.Name = "btnActulizador";
            this.btnActulizador.Size = new System.Drawing.Size(86, 23);
            this.btnActulizador.TabIndex = 1;
            this.btnActulizador.Text = "Actulizador";
            this.btnActulizador.UseVisualStyleBackColor = true;
            this.btnActulizador.Click += new System.EventHandler(this.btnActulizador_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.PanelMenu);
            this.Name = "Home";
            this.Text = "Form1";
            this.PanelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMenu;
        private System.Windows.Forms.Button btnConfiguracion;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Button btnActulizador;
    }
}


namespace AlquilerPeliculas
{
    partial class Factura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Factura));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Pelicula = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PrecioU = new System.Windows.Forms.Label();
            this.PrecioT = new System.Windows.Forms.Label();
            this.PrecioVT = new System.Windows.Forms.Label();
            this.PrecioNP = new System.Windows.Forms.Label();
            this.Efectivo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FechaAlquiler = new System.Windows.Forms.Label();
            this.FechaDevolucion = new System.Windows.Forms.Label();
            this.Cedula = new System.Windows.Forms.Label();
            this.Cliente = new System.Windows.Forms.Label();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::AlquilerPeliculas.Properties.Resources.FACTURAVIDEOCLUB;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(450, 674);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(450, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimirToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.imprimirToolStripMenuItem.Text = "Imprimir";
            this.imprimirToolStripMenuItem.Click += new System.EventHandler(this.imprimirToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // Pelicula
            // 
            this.Pelicula.AutoSize = true;
            this.Pelicula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pelicula.Location = new System.Drawing.Point(136, 163);
            this.Pelicula.Name = "Pelicula";
            this.Pelicula.Size = new System.Drawing.Size(103, 13);
            this.Pelicula.TabIndex = 2;
            this.Pelicula.Text = "                        ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(243, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "1";
            // 
            // PrecioU
            // 
            this.PrecioU.AutoSize = true;
            this.PrecioU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrecioU.Location = new System.Drawing.Point(320, 163);
            this.PrecioU.Name = "PrecioU";
            this.PrecioU.Size = new System.Drawing.Size(63, 13);
            this.PrecioU.TabIndex = 4;
            this.PrecioU.Text = "              ";
            // 
            // PrecioT
            // 
            this.PrecioT.AutoSize = true;
            this.PrecioT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrecioT.Location = new System.Drawing.Point(406, 163);
            this.PrecioT.Name = "PrecioT";
            this.PrecioT.Size = new System.Drawing.Size(47, 13);
            this.PrecioT.TabIndex = 5;
            this.PrecioT.Text = "          ";
            // 
            // PrecioVT
            // 
            this.PrecioVT.AutoSize = true;
            this.PrecioVT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrecioVT.Location = new System.Drawing.Point(211, 244);
            this.PrecioVT.Name = "PrecioVT";
            this.PrecioVT.Size = new System.Drawing.Size(99, 13);
            this.PrecioVT.TabIndex = 6;
            this.PrecioVT.Text = "                       ";
            this.PrecioVT.Click += new System.EventHandler(this.PrecioVT_Click);
            // 
            // PrecioNP
            // 
            this.PrecioNP.AutoSize = true;
            this.PrecioNP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrecioNP.Location = new System.Drawing.Point(226, 292);
            this.PrecioNP.Name = "PrecioNP";
            this.PrecioNP.Size = new System.Drawing.Size(103, 13);
            this.PrecioNP.TabIndex = 7;
            this.PrecioNP.Text = "                        ";
            // 
            // Efectivo
            // 
            this.Efectivo.AutoSize = true;
            this.Efectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Efectivo.Location = new System.Drawing.Point(242, 370);
            this.Efectivo.Name = "Efectivo";
            this.Efectivo.Size = new System.Drawing.Size(115, 13);
            this.Efectivo.TabIndex = 8;
            this.Efectivo.Text = "                           ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(243, 402);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "0.00";
            // 
            // FechaAlquiler
            // 
            this.FechaAlquiler.AutoSize = true;
            this.FechaAlquiler.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaAlquiler.Location = new System.Drawing.Point(230, 447);
            this.FechaAlquiler.Name = "FechaAlquiler";
            this.FechaAlquiler.Size = new System.Drawing.Size(139, 13);
            this.FechaAlquiler.TabIndex = 10;
            this.FechaAlquiler.Text = "                                 ";
            // 
            // FechaDevolucion
            // 
            this.FechaDevolucion.AutoSize = true;
            this.FechaDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaDevolucion.Location = new System.Drawing.Point(232, 463);
            this.FechaDevolucion.Name = "FechaDevolucion";
            this.FechaDevolucion.Size = new System.Drawing.Size(147, 13);
            this.FechaDevolucion.TabIndex = 11;
            this.FechaDevolucion.Text = "                                   ";
            // 
            // Cedula
            // 
            this.Cedula.AutoSize = true;
            this.Cedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cedula.Location = new System.Drawing.Point(232, 527);
            this.Cedula.Name = "Cedula";
            this.Cedula.Size = new System.Drawing.Size(59, 13);
            this.Cedula.TabIndex = 12;
            this.Cedula.Text = "             ";
            // 
            // Cliente
            // 
            this.Cliente.AutoSize = true;
            this.Cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cliente.Location = new System.Drawing.Point(258, 510);
            this.Cliente.Name = "Cliente";
            this.Cliente.Size = new System.Drawing.Size(59, 13);
            this.Cliente.TabIndex = 13;
            this.Cliente.Text = "             ";
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // Factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 698);
            this.Controls.Add(this.Cliente);
            this.Controls.Add(this.Cedula);
            this.Controls.Add(this.FechaDevolucion);
            this.Controls.Add(this.FechaAlquiler);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Efectivo);
            this.Controls.Add(this.PrecioNP);
            this.Controls.Add(this.PrecioVT);
            this.Controls.Add(this.PrecioT);
            this.Controls.Add(this.PrecioU);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pelicula);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Factura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Video Club - Factura";
            this.Load += new System.EventHandler(this.Factura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.Label Pelicula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PrecioU;
        private System.Windows.Forms.Label PrecioT;
        private System.Windows.Forms.Label PrecioVT;
        private System.Windows.Forms.Label PrecioNP;
        private System.Windows.Forms.Label Efectivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label FechaAlquiler;
        private System.Windows.Forms.Label FechaDevolucion;
        private System.Windows.Forms.Label Cedula;
        private System.Windows.Forms.Label Cliente;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}
namespace JuegosFavoritosMVC.Views
{
    partial class FrmMenuPrincipal
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
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.juegosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarJuegosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cátálogosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plataformasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.génerosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.géneroPorJuegoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calificacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calificacionDelJuegoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 66);
            this.label1.TabIndex = 20;
            this.label1.Text = "Bienvenidos a la aplicacion \r\nde calificacion de juegos";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.juegosToolStripMenuItem,
            this.cátálogosToolStripMenuItem,
            this.asignacionesToolStripMenuItem,
            this.calificacionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 464);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(473, 28);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // juegosToolStripMenuItem
            // 
            this.juegosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarJuegosToolStripMenuItem});
            this.juegosToolStripMenuItem.Name = "juegosToolStripMenuItem";
            this.juegosToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.juegosToolStripMenuItem.Text = "Juegos";
            // 
            // administrarJuegosToolStripMenuItem
            // 
            this.administrarJuegosToolStripMenuItem.Name = "administrarJuegosToolStripMenuItem";
            this.administrarJuegosToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.administrarJuegosToolStripMenuItem.Text = "Administrar Juegos";
            this.administrarJuegosToolStripMenuItem.Click += new System.EventHandler(this.administrarJuegosToolStripMenuItem_Click);
            // 
            // cátálogosToolStripMenuItem
            // 
            this.cátálogosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plataformasToolStripMenuItem,
            this.génerosToolStripMenuItem});
            this.cátálogosToolStripMenuItem.Name = "cátálogosToolStripMenuItem";
            this.cátálogosToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.cátálogosToolStripMenuItem.Text = "Cátálogos";
            // 
            // plataformasToolStripMenuItem
            // 
            this.plataformasToolStripMenuItem.Name = "plataformasToolStripMenuItem";
            this.plataformasToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.plataformasToolStripMenuItem.Text = "Plataformas";
            this.plataformasToolStripMenuItem.Click += new System.EventHandler(this.plataformasToolStripMenuItem_Click);
            // 
            // génerosToolStripMenuItem
            // 
            this.génerosToolStripMenuItem.Name = "génerosToolStripMenuItem";
            this.génerosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.génerosToolStripMenuItem.Text = "Géneros";
            this.génerosToolStripMenuItem.Click += new System.EventHandler(this.génerosToolStripMenuItem_Click);
            // 
            // asignacionesToolStripMenuItem
            // 
            this.asignacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.géneroPorJuegoToolStripMenuItem});
            this.asignacionesToolStripMenuItem.Name = "asignacionesToolStripMenuItem";
            this.asignacionesToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
            this.asignacionesToolStripMenuItem.Text = "Asignaciones";
            // 
            // géneroPorJuegoToolStripMenuItem
            // 
            this.géneroPorJuegoToolStripMenuItem.Name = "géneroPorJuegoToolStripMenuItem";
            this.géneroPorJuegoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.géneroPorJuegoToolStripMenuItem.Text = "Género por juego";
            this.géneroPorJuegoToolStripMenuItem.Click += new System.EventHandler(this.géneroPorJuegoToolStripMenuItem_Click);
            // 
            // calificacionesToolStripMenuItem
            // 
            this.calificacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calificacionDelJuegoToolStripMenuItem});
            this.calificacionesToolStripMenuItem.Name = "calificacionesToolStripMenuItem";
            this.calificacionesToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.calificacionesToolStripMenuItem.Text = "Calificaciones";
            // 
            // calificacionDelJuegoToolStripMenuItem
            // 
            this.calificacionDelJuegoToolStripMenuItem.Name = "calificacionDelJuegoToolStripMenuItem";
            this.calificacionDelJuegoToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.calificacionDelJuegoToolStripMenuItem.Text = "Calificacion del juego";
            this.calificacionDelJuegoToolStripMenuItem.Click += new System.EventHandler(this.calificacionDelJuegoToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumTurquoise;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 87);
            this.panel1.TabIndex = 21;
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(473, 492);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FrmMenuPrincipal";
            this.Text = "FrmMenuPrincipal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem juegosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarJuegosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cátálogosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plataformasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem génerosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem géneroPorJuegoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calificacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calificacionDelJuegoToolStripMenuItem;
    }
}
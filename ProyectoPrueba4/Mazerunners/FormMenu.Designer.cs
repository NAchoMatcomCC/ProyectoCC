﻿﻿﻿namespace Mazerunners
{
    partial class FormMenu
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
            btnJugar = new Button();
            btnInstrucciones = new Button();
            btnHabilidades = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // btnJugar
            // 
            btnJugar.Location = new Point(445, 126);
            btnJugar.Margin = new Padding(5, 6, 5, 6);
            btnJugar.Name = "btnJugar";
            btnJugar.Size = new Size(220, 44);
            btnJugar.TabIndex = 0;
            btnJugar.Text = "Jugar";
            btnJugar.UseVisualStyleBackColor = true;
            btnJugar.Click += btnJugar_Click;
            // 
            // btnInstrucciones
            // 
            btnInstrucciones.Location = new Point(445, 196);
            btnInstrucciones.Margin = new Padding(5, 6, 5, 6);
            btnInstrucciones.Name = "btnInstrucciones";
            btnInstrucciones.Size = new Size(220, 44);
            btnInstrucciones.TabIndex = 1;
            btnInstrucciones.Text = "Instrucciones";
            btnInstrucciones.UseVisualStyleBackColor = true;
            btnInstrucciones.Click += btnInstrucciones_Click;
            // 
            // btnHabilidades
            // 
            btnHabilidades.Location = new Point(445, 270);
            btnHabilidades.Margin = new Padding(5, 6, 5, 6);
            btnHabilidades.Name = "btnHabilidades";
            btnHabilidades.Size = new Size(220, 44);
            btnHabilidades.TabIndex = 2;
            btnHabilidades.Text = "Habilidades";
            btnHabilidades.UseVisualStyleBackColor = true;
            btnHabilidades.Click += btnHabilidades_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(445, 340);
            btnSalir.Margin = new Padding(5, 6, 5, 6);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(220, 44);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;

            
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            this.BackgroundImage = Image.FromFile("img/fondo.png");
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new Size(1166, 579);
            Controls.Add(btnSalir);
            Controls.Add(btnHabilidades);
            Controls.Add(btnInstrucciones);
            Controls.Add(btnJugar);
            Margin = new Padding(5, 6, 5, 6);
            Name = "FormMenu";
            Text = "Menú";
            Load += FormMenu_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnJugar;
        private System.Windows.Forms.Button btnInstrucciones;
        private System.Windows.Forms.Button btnHabilidades;
        private System.Windows.Forms.Button btnSalir;
    }
}
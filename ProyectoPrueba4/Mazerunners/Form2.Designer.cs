namespace Mazerunners
{
    partial class SeleccionPersonajes
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
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            btnConfirmar = new Button();
            btnAtras = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(47, 78);
            comboBox1.Margin = new Padding(5, 6, 5, 6);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(199, 33);
            comboBox1.TabIndex = 0;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(47, 165);
            comboBox2.Margin = new Padding(5, 6, 5, 6);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(199, 33);
            comboBox2.TabIndex = 1;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(47, 263);
            btnConfirmar.Margin = new Padding(5, 6, 5, 6);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(125, 44);
            btnConfirmar.TabIndex = 2;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnAtras
            // 
            btnAtras.Location = new Point(225, 263);
            btnAtras.Margin = new Padding(5, 6, 5, 6);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new Size(125, 44);
            btnAtras.TabIndex = 3;
            btnAtras.Text = "Atrás";
            btnAtras.UseVisualStyleBackColor = true;
            btnAtras.Click += btnAtras_Click;
            // 
            // SeleccionPersonajes
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Image.FromFile("img/fondo.png");
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new Size(1144, 523);
            Controls.Add(btnAtras);
            Controls.Add(btnConfirmar);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Margin = new Padding(5, 6, 5, 6);
            Name = "SeleccionPersonajes";
            Text = "SeleccionPersonajes";
            Load += SeleccionPersonajes_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnAtras;
    }
}
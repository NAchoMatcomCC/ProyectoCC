namespace Mazerunners
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 200;
            timer1.Tick += timer1_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Lime;
            label1.Location = new Point(1076, 101);
            label1.Name = "label1";
            label1.Size = new Size(124, 25);
            label1.TabIndex = 0;
            label1.Text = "Vida jugador1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.DarkGray;
            label2.Location = new Point(1076, 126);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 1;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.DarkGray;
            label3.Location = new Point(1076, 151);
            label3.Name = "label3";
            label3.Size = new Size(59, 25);
            label3.TabIndex = 2;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.DarkGray;
            label4.Location = new Point(1076, 176);
            label4.Name = "label4";
            label4.Size = new Size(59, 25);
            label4.TabIndex = 3;
            label4.Text = "label4";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.DarkGray;
            label5.Location = new Point(1076, 76);
            label5.Name = "label5";
            label5.Size = new Size(86, 25);
            label5.TabIndex = 4;
            label5.Text = "Jugador1";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.DarkGray;
            label6.Location = new Point(1076, 277);
            label6.Name = "label6";
            label6.Size = new Size(86, 25);
            label6.TabIndex = 5;
            label6.Text = "Jugador2";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Lime;
            label7.Location = new Point(1076, 302);
            label7.Name = "label7";
            label7.Size = new Size(124, 25);
            label7.TabIndex = 6;
            label7.Text = "Vida jugador2";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.DarkGray;
            label8.Location = new Point(1076, 327);
            label8.Name = "label8";
            label8.Size = new Size(59, 25);
            label8.TabIndex = 7;
            label8.Text = "label8";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.DarkGray;
            label9.Location = new Point(1076, 352);
            label9.Name = "label9";
            label9.Size = new Size(59, 25);
            label9.TabIndex = 8;
            label9.Text = "label9";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.DarkGray;
            label10.Location = new Point(1076, 377);
            label10.Name = "label10";
            label10.Size = new Size(69, 25);
            label10.TabIndex = 9;
            label10.Text = "label10";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Orange;
            label11.Location = new Point(1076, 201);
            label11.Name = "label11";
            label11.Size = new Size(69, 25);
            label11.TabIndex = 10;
            label11.Text = "label11";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Orange;
            label12.Location = new Point(1076, 402);
            label12.Name = "label12";
            label12.Size = new Size(69, 25);
            label12.TabIndex = 11;
            label12.Text = "label12";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = SystemColors.InactiveCaption;
            label13.Location = new Point(1076, 500);
            label13.Name = "label13";
            label13.Size = new Size(87, 25);
            label13.TabIndex = 12;
            label13.Text = "Turno de:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1331, 1050);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Paint += Form1_Paint;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
    }
}

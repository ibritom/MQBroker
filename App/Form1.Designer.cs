namespace App
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            richTextBox1 = new RichTextBox();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 118);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 0;
            label1.Text = "MQ Broker IP:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 164);
            label2.Name = "label2";
            label2.Size = new Size(113, 20);
            label2.TabIndex = 1;
            label2.Text = "MQ Broker Port:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(68, 214);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 2;
            label3.Text = "AppID:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(75, 267);
            label4.Name = "label4";
            label4.Size = new Size(48, 20);
            label4.TabIndex = 3;
            label4.Text = "Tema:";
            // 
            // button1
            // 
            button1.Location = new Point(68, 317);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 4;
            button1.Text = "Suscribirse";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(197, 317);
            button2.Name = "button2";
            button2.Size = new Size(108, 29);
            button2.TabIndex = 5;
            button2.Text = "Desuscribirse";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(445, 317);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 6;
            button3.Text = "Publicar";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(601, 322);
            button4.Name = "button4";
            button4.Size = new Size(143, 29);
            button4.TabIndex = 7;
            button4.Text = "Obtener Mensaje";
            button4.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(129, 115);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(176, 27);
            textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(129, 161);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(176, 27);
            textBox2.TabIndex = 9;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(129, 211);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(176, 27);
            textBox3.TabIndex = 10;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(129, 260);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(176, 27);
            textBox4.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ButtonHighlight;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39.4958F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60.5042F));
            tableLayoutPanel1.Location = new Point(557, 118);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 23.20442F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 76.79558F));
            tableLayoutPanel1.Size = new Size(238, 181);
            tableLayoutPanel1.TabIndex = 13;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(350, 118);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(189, 181);
            richTextBox1.TabIndex = 14;
            richTextBox1.Text = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(343, 81);
            label5.Name = "label5";
            label5.Size = new Size(199, 20);
            label5.TabIndex = 15;
            label5.Text = "Contenido de la publicación:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(557, 81);
            label6.Name = "label6";
            label6.Size = new Size(142, 20);
            label6.TabIndex = 16;
            label6.Text = "Mensajes Recibidos:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(richTextBox1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "App";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TableLayoutPanel tableLayoutPanel1;
        private RichTextBox richTextBox1;
        private Label label5;
        private Label label6;
    }
}

namespace Naloga3
{
    partial class Tekmovanja
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
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 46);
            label2.Name = "label2";
            label2.Size = new Size(34, 20);
            label2.TabIndex = 1;
            label2.Text = "ime";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 69);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(242, 27);
            textBox1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 99);
            label3.Name = "label3";
            label3.Size = new Size(116, 20);
            label3.TabIndex = 3;
            label3.Text = "leto tekmovanja";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 122);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(242, 27);
            textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 175);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(242, 27);
            textBox3.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 152);
            label4.Name = "label4";
            label4.Size = new Size(27, 20);
            label4.TabIndex = 6;
            label4.Text = "tip";
            // 
            // button1
            // 
            button1.Location = new Point(12, 223);
            button1.Name = "button1";
            button1.Size = new Size(242, 29);
            button1.TabIndex = 7;
            button1.Text = "Update";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 269);
            button2.Name = "button2";
            button2.Size = new Size(242, 29);
            button2.TabIndex = 8;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Tekmovanja
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(266, 349);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Tekmovanja";
            Text = "Tekmovanja";
            FormClosed += Tekmovanja_FormClosed_1;
            Load += Tekmovanja_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label4;
        private Button button1;
        private Button button2;
    }
}
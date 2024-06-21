namespace Naloga3
{
    partial class Main
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
            dataGridView1 = new DataGridView();
            comboBox1 = new ComboBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            button1 = new Button();
            checkBox1 = new CheckBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            listBox1 = new ListBox();
            textBox3 = new TextBox();
            label1 = new Label();
            button2 = new Button();
            button3 = new Button();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Location = new Point(12, 37);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(619, 401);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentDoubleClick += dataGridView1_CellContentDoubleClick;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Tekmovanja", "Rezultati" });
            comboBox1.Location = new Point(12, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(listBox1);
            groupBox1.Location = new Point(647, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(512, 349);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Uporabniki";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(checkBox1);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(textBox2);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(192, 26);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(275, 249);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dodaj uporabnika";
            // 
            // button1
            // 
            button1.Location = new Point(6, 200);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 13;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(6, 158);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(85, 24);
            checkBox1.TabIndex = 12;
            checkBox1.Text = "isAdmin";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 46);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(6, 111);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 23);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 9;
            label2.Text = "username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 88);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 10;
            label3.Text = "password";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(6, 26);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(150, 304);
            listBox1.TabIndex = 0;
            listBox1.DoubleClick += listBox1_DoubleClick;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(335, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(169, 9);
            label1.Name = "label1";
            label1.Size = new Size(160, 20);
            label1.TabIndex = 4;
            label1.Text = "Išči v izbrani kategoriji:";
            // 
            // button2
            // 
            button2.Location = new Point(466, 4);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 5;
            button2.Text = "Išči";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(647, 398);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 6;
            button3.Text = "Dodaj";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(647, 364);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 7;
            label4.Text = "Dodaj ";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1171, 450);
            Controls.Add(label4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(groupBox1);
            Controls.Add(comboBox1);
            Controls.Add(dataGridView1);
            Name = "Main";
            Text = "Main";
            Load += Main_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private GroupBox groupBox1;
        private ListBox listBox1;
        private GroupBox groupBox2;
        private Button button1;
        private CheckBox checkBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private Label label3;
        private TextBox textBox3;
        private Label label1;
        private Button button2;
        private Button button3;
        private Label label4;
    }
}
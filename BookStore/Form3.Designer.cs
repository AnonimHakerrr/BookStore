namespace BookStore
{
    partial class Form3
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
            dataGridView1 = new DataGridView();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem1 = new ToolStripMenuItem();
            addToolStripMenuItem1 = new ToolStripMenuItem();
            edetingToolStripMenuItem1 = new ToolStripMenuItem();
            seachToolStripMenuItem = new ToolStripMenuItem();
            datebaseToolStripMenuItem = new ToolStripMenuItem();
            booksToolStripMenuItem = new ToolStripMenuItem();
            authorsToolStripMenuItem = new ToolStripMenuItem();
            userToolStripMenuItem = new ToolStripMenuItem();
            button2 = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.System;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(25, 51);
            label1.Name = "label1";
            label1.Size = new Size(82, 35);
            label1.TabIndex = 6;
            label1.Text = "Books";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = SystemColors.ActiveCaption;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(25, 91);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1110, 407);
            dataGridView1.TabIndex = 5;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem1, datebaseToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 3, 0, 3);
            menuStrip1.Size = new Size(1147, 30);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
    
            // 
            // fileToolStripMenuItem1
            // 
            fileToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { addToolStripMenuItem1, edetingToolStripMenuItem1, seachToolStripMenuItem });
            fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            fileToolStripMenuItem1.Size = new Size(46, 24);
            fileToolStripMenuItem1.Text = "File";
            // 
            // addToolStripMenuItem1
            // 
            addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            addToolStripMenuItem1.Size = new Size(224, 26);
            addToolStripMenuItem1.Text = "add";
            addToolStripMenuItem1.Click += addToolStripMenuItem1_Click;
            // 
            // edetingToolStripMenuItem1
            // 
            edetingToolStripMenuItem1.Name = "edetingToolStripMenuItem1";
            edetingToolStripMenuItem1.Size = new Size(224, 26);
            edetingToolStripMenuItem1.Text = "edeting";
            edetingToolStripMenuItem1.Click += edetingToolStripMenuItem1_Click;
            // 
            // seachToolStripMenuItem
            // 
            seachToolStripMenuItem.Name = "seachToolStripMenuItem";
            seachToolStripMenuItem.Size = new Size(224, 26);
            seachToolStripMenuItem.Text = "seach";
            // 
            // datebaseToolStripMenuItem
            // 
            datebaseToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { booksToolStripMenuItem, authorsToolStripMenuItem, userToolStripMenuItem });
            datebaseToolStripMenuItem.Name = "datebaseToolStripMenuItem";
            datebaseToolStripMenuItem.Size = new Size(86, 24);
            datebaseToolStripMenuItem.Text = "Datebase";
            // 
            // booksToolStripMenuItem
            // 
            booksToolStripMenuItem.Name = "booksToolStripMenuItem";
            booksToolStripMenuItem.Size = new Size(224, 26);
            booksToolStripMenuItem.Text = "Books";
            booksToolStripMenuItem.Click += booksToolStripMenuItem_Click;
            // 
            // authorsToolStripMenuItem
            // 
            authorsToolStripMenuItem.Name = "authorsToolStripMenuItem";
            authorsToolStripMenuItem.Size = new Size(224, 26);
            authorsToolStripMenuItem.Text = "Authors";
            authorsToolStripMenuItem.Click += authorsToolStripMenuItem_Click;
            // 
            // userToolStripMenuItem
            // 
            userToolStripMenuItem.Name = "userToolStripMenuItem";
            userToolStripMenuItem.Size = new Size(224, 26);
            userToolStripMenuItem.Text = "User";
            userToolStripMenuItem.Click += userToolStripMenuItem_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Lime;
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(966, 539);
            button2.Name = "button2";
            button2.Size = new Size(149, 39);
            button2.TabIndex = 13;
            button2.Text = "ADD";
            button2.UseVisualStyleBackColor = false;
            button2.Visible = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Red;
            button3.BackgroundImageLayout = ImageLayout.None;
            button3.Font = new Font("Showcard Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Location = new Point(1054, 31);
            button3.Name = "button3";
            button3.Size = new Size(93, 33);
            button3.TabIndex = 14;
            button3.Text = "Exit";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(47, 539);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(137, 27);
            textBox1.TabIndex = 15;
            textBox1.Visible = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(189, 539);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(127, 27);
            textBox2.TabIndex = 16;
            textBox2.Visible = false;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(323, 539);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(196, 27);
            textBox3.TabIndex = 17;
            textBox3.Visible = false;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(699, 539);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(127, 27);
            textBox4.TabIndex = 18;
            textBox4.Visible = false;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(833, 539);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(127, 27);
            textBox5.TabIndex = 19;
            textBox5.Visible = false;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(525, 539);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(170, 27);
            dateTimePicker1.TabIndex = 20;
            dateTimePicker1.Visible = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(966, 539);
            button1.Name = "button1";
            button1.Size = new Size(149, 39);
            button1.TabIndex = 21;
            button1.Text = "Edit";
            button1.UseVisualStyleBackColor = false;
            button1.Visible = false;
            button1.Click += button1_Click_1;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(1147, 609);
            Controls.Add(button1);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(menuStrip1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            MainMenuStrip = menuStrip1;
            Name = "Form3";
            Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem1;
        private ToolStripMenuItem addToolStripMenuItem1;
        private ToolStripMenuItem deleteToolStripMenuItem1;
        private ToolStripMenuItem edetingToolStripMenuItem1;
        private ToolStripMenuItem seachToolStripMenuItem;
        private Button button2;
        private Button button3;
        private ToolStripMenuItem datebaseToolStripMenuItem;
        private ToolStripMenuItem booksToolStripMenuItem;
        private ToolStripMenuItem authorsToolStripMenuItem;
        private ToolStripMenuItem userToolStripMenuItem;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private DateTimePicker dateTimePicker1;
        private Button button1;
    }
}
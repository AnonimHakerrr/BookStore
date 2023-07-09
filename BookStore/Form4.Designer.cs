namespace BookStore
{
    partial class Form4
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
            button3 = new Button();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem1 = new ToolStripMenuItem();
            seachToolStripMenuItem = new ToolStripMenuItem();
            authorToolStripMenuItem = new ToolStripMenuItem();
            gerneToolStripMenuItem = new ToolStripMenuItem();
            bookNameToolStripMenuItem = new ToolStripMenuItem();
            datebaseToolStripMenuItem = new ToolStripMenuItem();
            booksToolStripMenuItem = new ToolStripMenuItem();
            authorsToolStripMenuItem = new ToolStripMenuItem();
            buyToolStripMenuItem = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            textBox3 = new TextBox();
            button1 = new Button();
            label2 = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button3
            // 
            button3.BackColor = Color.Red;
            button3.BackgroundImageLayout = ImageLayout.None;
            button3.Font = new Font("Showcard Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Location = new Point(1112, 33);
            button3.Name = "button3";
            button3.Size = new Size(93, 33);
            button3.TabIndex = 15;
            button3.Text = "Exit";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem1, datebaseToolStripMenuItem, buyToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 3, 0, 3);
            menuStrip1.Size = new Size(1217, 30);
            menuStrip1.TabIndex = 16;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            fileToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { seachToolStripMenuItem });
            fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            fileToolStripMenuItem1.Size = new Size(46, 24);
            fileToolStripMenuItem1.Text = "File";
            // 
            // seachToolStripMenuItem
            // 
            seachToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { authorToolStripMenuItem, gerneToolStripMenuItem, bookNameToolStripMenuItem });
            seachToolStripMenuItem.Name = "seachToolStripMenuItem";
            seachToolStripMenuItem.Size = new Size(129, 26);
            seachToolStripMenuItem.Text = "seach";
            // 
            // authorToolStripMenuItem
            // 
            authorToolStripMenuItem.Name = "authorToolStripMenuItem";
            authorToolStripMenuItem.Size = new Size(166, 26);
            authorToolStripMenuItem.Text = "author";
            authorToolStripMenuItem.Click += authorToolStripMenuItem_Click;
            // 
            // gerneToolStripMenuItem
            // 
            gerneToolStripMenuItem.Name = "gerneToolStripMenuItem";
            gerneToolStripMenuItem.Size = new Size(166, 26);
            gerneToolStripMenuItem.Text = "gerne";
            gerneToolStripMenuItem.Click += gerneToolStripMenuItem_Click;
            // 
            // bookNameToolStripMenuItem
            // 
            bookNameToolStripMenuItem.Name = "bookNameToolStripMenuItem";
            bookNameToolStripMenuItem.Size = new Size(166, 26);
            bookNameToolStripMenuItem.Text = "bookName";
            bookNameToolStripMenuItem.Click += bookNameToolStripMenuItem_Click;
            // 
            // datebaseToolStripMenuItem
            // 
            datebaseToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { booksToolStripMenuItem, authorsToolStripMenuItem });
            datebaseToolStripMenuItem.Name = "datebaseToolStripMenuItem";
            datebaseToolStripMenuItem.Size = new Size(86, 24);
            datebaseToolStripMenuItem.Text = "Datebase";
            // 
            // booksToolStripMenuItem
            // 
            booksToolStripMenuItem.Name = "booksToolStripMenuItem";
            booksToolStripMenuItem.Size = new Size(143, 26);
            booksToolStripMenuItem.Text = "Books";
            booksToolStripMenuItem.Click += booksToolStripMenuItem_Click;
            // 
            // authorsToolStripMenuItem
            // 
            authorsToolStripMenuItem.Name = "authorsToolStripMenuItem";
            authorsToolStripMenuItem.Size = new Size(143, 26);
            authorsToolStripMenuItem.Text = "Authors";
            authorsToolStripMenuItem.Click += authorsToolStripMenuItem_Click;
            // 
            // buyToolStripMenuItem
            // 
            buyToolStripMenuItem.Name = "buyToolStripMenuItem";
            buyToolStripMenuItem.Size = new Size(66, 24);
            buyToolStripMenuItem.Text = "Basket";
            buyToolStripMenuItem.Click += buyToolStripMenuItem_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = SystemColors.ActiveCaption;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(53, 77);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1110, 407);
            dataGridView1.TabIndex = 17;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.System;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(53, 39);
            label1.Name = "label1";
            label1.Size = new Size(82, 35);
            label1.TabIndex = 18;
            label1.Text = "Books";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(421, 522);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(196, 27);
            textBox3.TabIndex = 19;
            textBox3.Visible = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 192, 192);
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.Font = new Font("Showcard Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(640, 516);
            button1.Name = "button1";
            button1.Size = new Size(93, 33);
            button1.TabIndex = 20;
            button1.Text = "Seach";
            button1.UseVisualStyleBackColor = false;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.System;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(473, 484);
            label2.Name = "label2";
            label2.Size = new Size(81, 35);
            label2.TabIndex = 21;
            label2.Text = "Genre";
            label2.Visible = false;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(1217, 561);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            Controls.Add(button3);
            Name = "Form4";
            Text = "Form4";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button3;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem1;
        private ToolStripMenuItem seachToolStripMenuItem;
        private ToolStripMenuItem datebaseToolStripMenuItem;
        private ToolStripMenuItem booksToolStripMenuItem;
        private ToolStripMenuItem authorsToolStripMenuItem;
        private ToolStripMenuItem buyToolStripMenuItem;
        private DataGridView dataGridView1;
        private Label label1;
        private ToolStripMenuItem authorToolStripMenuItem;
        private ToolStripMenuItem gerneToolStripMenuItem;
        private ToolStripMenuItem bookNameToolStripMenuItem;
        private TextBox textBox3;
        private Button button1;
        private Label label2;
    }
}
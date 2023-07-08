using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookStore
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            using (StoreBookDB sb = new StoreBookDB())
            {
                dataGridView1.DataSource = (from b in sb.Books
                                            join a in sb.Authors on b.ID_Authors equals a.Id

                                            select new
                                            {
                                                NameBook = b.NameBook,
                                                NamePublishing = b.NamePublishing,
                                                NameAuthors = a.FirstName + " " + a.LastName + " " + a.MiddleName,
                                                DateCreate = b.Created,
                                                Pages = b.Pages,
                                                Price = b.Money
                                            }).ToList(); ButtonDeleteCreate();
            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            Hide();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            switch (label1.Text)
            {
                case "Books":
                    textBox1.Visible = textBox2.Visible = textBox4.Visible = textBox3.Visible = dateTimePicker1.Visible = textBox5.Visible = button2.Visible = true;
                    break;
                case "Authors":
                    textBox1.Visible = textBox3.Visible = textBox2.Visible = button2.Visible = true;
                    break;
                case "Users":
                    textBox1.Visible = textBox3.Visible = textBox2.Visible = textBox4.Visible = textBox5.Visible = button2.Visible = true;
                    break;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StoreBookDB sb = new StoreBookDB())
            {
                switch (label1.Text)
                {
                    case "Books":
                        {
                            string[] str = textBox3.Text.Split(' ');
                            bool authorExists = sb.Authors.Any(a => a.LastName == str[0] && a.FirstName == str[1] && a.MiddleName == str[2]);
                            int authorId = 0;
                            if (authorExists)
                            {
                                var author = sb.Authors.FirstOrDefault(a => a.LastName == str[0] && a.FirstName == str[1] && a.MiddleName == str[2]);
                                authorId = author.Id;
                            }
                            else
                            {
                                Author newAuthor = new Author
                                {
                                    FirstName = str[1],
                                    LastName = str[0],
                                    MiddleName = str[2],
                                };
                                sb.Authors.Add(newAuthor);
                                sb.SaveChanges();

                                var author = sb.Authors.FirstOrDefault(a => a.FirstName == str[1]);

                                authorId = author.Id;
                            }

                            Book newBook = new Book
                            {
                                NameBook = textBox1.Text,
                                NamePublishing = textBox2.Text,
                                Created = dateTimePicker1.Value.Date,
                                Pages = Int16.Parse(textBox4.Text),
                                Money = float.Parse(textBox5.Text),
                                ID_Authors = authorId,
                            };

                            sb.Books.Add(newBook);
                            sb.SaveChanges(); booksToolStripMenuItem_Click(sender, e); break;
                        }

                    case "Authors":
                        {
                            bool authorExists = sb.Authors.Any(a => a.LastName == textBox1.Text && a.FirstName == textBox2.Text && a.MiddleName == textBox3.Text);
                            if (!authorExists)
                            {
                                Author newAuthor = new Author
                                {
                                    FirstName = textBox1.Text,
                                    LastName = textBox2.Text,
                                    MiddleName = textBox3.Text,
                                };
                                sb.Authors.Add(newAuthor);
                                sb.SaveChanges();
                            }
                            authorsToolStripMenuItem_Click(sender, e);
                            break;
                        }
                    case "Users":
                        {
                            bool authorExists = sb.Users.Any(a => a.Login == textBox4.Text && a.Password == textBox5.Text);
                            if (!authorExists)
                            {
                                User newUsers = new User
                                {
                                    FirstName = textBox1.Text,
                                    LastName = textBox2.Text,
                                    MiddleName = textBox3.Text,
                                    Login = textBox4.Text,
                                    Password = textBox5.Text,
                                };
                                sb.Users.Add(newUsers);
                                sb.SaveChanges();
                            }
                            userToolStripMenuItem_Click(sender, e);
                            break;
                        }
                }
            }
            textBox1.Visible =
            textBox2.Visible =
            textBox4.Visible =
            dateTimePicker1.Visible =
            textBox3.Visible =
            textBox5.Visible =
            button2.Visible = false;

        }


        private void authorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = textBox2.Visible = textBox4.Visible = textBox3.Visible = dateTimePicker1.Visible = textBox5.Visible = button2.Visible = false;

            label1.Text = "Authors";
            using (StoreBookDB sb = new StoreBookDB())
            {

                dataGridView1.DataSource = (from a in sb.Authors


                                            select new
                                            {
                                                LastName = a.LastName,
                                                FirstName = a.FirstName,
                                                MiddleName = a.MiddleName,

                                            }).ToList();
            }

        }
        private void ButtonDeleteCreate()
        {

            // Создаем столбец с кнопкой удаления
            bool deleteButtonColumnExists = dataGridView1.Columns.Cast<DataGridViewColumn>()
                                  .Any(column => column.Name == "DeleteButtonColumn");
            if (!deleteButtonColumnExists)
            {
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.Name = "DeleteButtonColumn";
                deleteButtonColumn.HeaderText = "Delete";
                deleteButtonColumn.Text = "Delete";
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(deleteButtonColumn);
            }

            dataGridView1.CellClick += (sender, e) =>
            {
                if (e.ColumnIndex == dataGridView1.Columns["DeleteButtonColumn"].Index && e.RowIndex >= 0)
                {

                    int rowIndex = e.RowIndex;

                    DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];

                    using (StoreBookDB sb = new StoreBookDB())
                    {
                        switch (label1.Text)
                        {
                            case "Books":
                                {
                                    string nameBook = selectedRow.Cells["NameBook"].Value?.ToString();
                                    var book = sb.Books.FirstOrDefault(a => a.NameBook == nameBook);
                                    if (book != null)
                                    {
                                        sb.Books.Remove(book);
                                        sb.SaveChanges();
                                        Console.WriteLine("the book has been deleted ");

                                    }
                                    else
                                        Console.WriteLine("the book has not been deleted");
                                    booksToolStripMenuItem_Click(sender, e);
                                    break;
                                }
                            case "Authors":
                                {
                                    string lastName = selectedRow.Cells["LastName"].Value?.ToString();
                                    string firstName = selectedRow.Cells["FirstName"].Value?.ToString();
                                    string middleName = selectedRow.Cells["MiddleName"].Value?.ToString();
                                    var author = sb.Authors.FirstOrDefault(a => a.LastName == lastName && a.FirstName == firstName && a.MiddleName == middleName);
                                    if (author != null)
                                    {
                                        sb.Authors.Remove(author);
                                        sb.SaveChanges();
                                        Console.WriteLine("the author has been deleted ");
                                    }
                                    else
                                        Console.WriteLine("the author has not been deleted");
                                    authorsToolStripMenuItem_Click(sender, e);
                                    break;
                                }
                            case "Users":
                                {
                                    string login = selectedRow.Cells["Login"].Value?.ToString();
                                    string password = selectedRow.Cells["Password"].Value?.ToString();

                                    var user = sb.Users.FirstOrDefault(a => a.Login == login && a.Password == password);
                                    if (user != null)
                                    {
                                        sb.Users.Remove(user);
                                        sb.SaveChanges();
                                        Console.WriteLine("the user has been deleted ");
                                    }
                                    else
                                        Console.WriteLine("the user has not been deleted");
                                    userToolStripMenuItem_Click(sender, e);
                                    break;
                                }
                        }
                    }
                }

            };


        }
        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Users";
            using (StoreBookDB sb = new StoreBookDB())
            {
                dataGridView1.DataSource = (from a in sb.Users


                                            select new
                                            {
                                                FoolName = a.FirstName + " " + a.LastName + " " + a.MiddleName,
                                                Login = a.Login,
                                                Password = a.Password,
                                            }).ToList();
            }
            textBox1.Visible = textBox2.Visible = textBox4.Visible = textBox3.Visible = dateTimePicker1.Visible = textBox5.Visible = button2.Visible = false;

        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = textBox2.Visible = textBox4.Visible = textBox3.Visible = dateTimePicker1.Visible = textBox5.Visible = button2.Visible = false;

            label1.Text = "Books";
            using (StoreBookDB sb = new StoreBookDB())
            {
                dataGridView1.DataSource = (from b in sb.Books
                                            join a in sb.Authors on b.ID_Authors equals a.Id

                                            select new
                                            {
                                                NameBook = b.NameBook,
                                                NamePublishing = b.NamePublishing,
                                                NameAuthors = a.FirstName + " " + a.LastName + " " + a.MiddleName,
                                                DateCreate = b.Created,
                                                Pages = b.Pages,
                                                Price = b.Money
                                            }).ToList();
            }

        }

        private void edetingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            switch (label1.Text)
            {
                case "Books":
                    textBox1.Visible = textBox2.Visible = textBox4.Visible = textBox3.Visible = dateTimePicker1.Visible = textBox5.Visible = button1.Visible = true;
                    break;
                case "Authors":
                    textBox1.Visible = textBox3.Visible = textBox2.Visible = button1.Visible = true;
                    break;
                case "Users":
                    textBox1.Visible = textBox3.Visible = textBox2.Visible = textBox4.Visible = textBox5.Visible = button1.Visible = true;
                    break;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (StoreBookDB sb = new StoreBookDB())
            {
                int rowIndex = 0;
                if (dataGridView1.SelectedRows.Count > 0)
                {

                    rowIndex = dataGridView1.SelectedRows[0].Index;
                }
                switch (label1.Text)
                {
                    case "Books":
                        {
                            var record = sb.Books.FirstOrDefault(r => r.NameBook == dataGridView1.Rows[rowIndex].Cells["NameBook"].Value.ToString());
                            string[] str = textBox3.Text.Split(' ');
                            bool authorExists = sb.Authors.Any(a => a.LastName == str[0] && a.FirstName == str[1] && a.MiddleName == str[2]);
                            int authorId = 0;
                            if (authorExists)
                            {
                                var author = sb.Authors.FirstOrDefault(a => a.LastName == str[0] && a.FirstName == str[1] && a.MiddleName == str[2]);
                                authorId = author.Id;
                            }
                            else
                            {
                                Author newAuthor = new Author
                                {
                                    FirstName = str[1],
                                    LastName = str[0],
                                    MiddleName = str[2],
                                };
                                sb.Authors.Add(newAuthor);
                                sb.SaveChanges();

                                var author = sb.Authors.FirstOrDefault(a => a.FirstName == str[1]);

                                authorId = author.Id;
                            }
                            if (record != null)
                            {

                                record.NameBook = textBox1.Text;
                                record.NamePublishing = textBox2.Text;
                                record.Created = dateTimePicker1.Value.Date;
                                record.Pages = Int16.Parse(textBox4.Text);
                                record.Money = float.Parse(textBox5.Text);
                                record.ID_Authors = authorId;





                                sb.SaveChanges(); booksToolStripMenuItem_Click(sender, e); break;
                            }
                            break;
                        }

                    case "Authors":
                        {
                            var record = sb.Authors.FirstOrDefault(a => a.LastName == dataGridView1.Rows[rowIndex].Cells["LastName"].Value.ToString() && a.FirstName == dataGridView1.Rows[rowIndex].Cells["FirstName"].Value.ToString() && a.MiddleName == dataGridView1.Rows[rowIndex].Cells["MiddleName"].Value.ToString());
                            if (record != null)
                            {

                                record.FirstName = textBox1.Text;
                                record.LastName = textBox2.Text;
                                record.MiddleName = textBox3.Text;


                                sb.SaveChanges();
                            }
                            authorsToolStripMenuItem_Click(sender, e);
                            break;
                        }
                    case "Users":
                        {
                            var record = sb.Users.FirstOrDefault(a => a.Login == dataGridView1.Rows[rowIndex].Cells["Login"].Value.ToString() && a.Password == dataGridView1.Rows[rowIndex].Cells["Password"].Value.ToString());
                            if (record != null)
                            {
                                record.FirstName = textBox1.Text;
                                record.LastName = textBox2.Text;
                                record.MiddleName = textBox3.Text;
                                record.Login = textBox4.Text;
                                record.Password = textBox5.Text;

                                sb.SaveChanges();
                            }
                            userToolStripMenuItem_Click(sender, e);
                            break;
                        }
                }
            }
            textBox1.Visible =
            textBox2.Visible =
            textBox4.Visible =
            dateTimePicker1.Visible =
            textBox3.Visible =
            textBox5.Visible =
            button1.Visible = false;

        }





        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                int rowIndex = dataGridView1.SelectedRows[0].Index;
                switch (label1.Text)
                {
                    case "Books":
                        {

                            textBox1.Text = dataGridView1.Rows[rowIndex].Cells["NameBook"].Value.ToString();
                            textBox2.Text = dataGridView1.Rows[rowIndex].Cells["NamePublishing"].Value.ToString();
                            textBox3.Text = dataGridView1.Rows[rowIndex].Cells["NameAuthors"].Value.ToString();
                            dateTimePicker1.Text = dataGridView1.Rows[rowIndex].Cells["DateCreate"].Value.ToString();
                            textBox4.Text = dataGridView1.Rows[rowIndex].Cells["Pages"].Value.ToString();
                            textBox5.Text = dataGridView1.Rows[rowIndex].Cells["Price"].Value.ToString();
                            break;
                        }

                    case "Authors":
                        {
                            textBox1.Text = dataGridView1.Rows[rowIndex].Cells["LastName"].Value.ToString();
                            textBox2.Text = dataGridView1.Rows[rowIndex].Cells["FirstName"].Value.ToString();
                            textBox3.Text = dataGridView1.Rows[rowIndex].Cells["MiddleName"].Value.ToString();
                            break;
                        }
                    case "Users":
                        {
                            string[] str = dataGridView1.Rows[rowIndex].Cells["FoolName"].Value.ToString().Split(' ');
                            textBox1.Text = str[0];
                            textBox2.Text = str[1];
                            textBox3.Text = str[2];

                            textBox4.Text = dataGridView1.Rows[rowIndex].Cells["Login"].Value.ToString();
                            textBox5.Text = dataGridView1.Rows[rowIndex].Cells["Password"].Value.ToString();
                            break;
                        }
                }


            }
        }

         
    }
}

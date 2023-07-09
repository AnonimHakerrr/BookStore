using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace BookStore
{
    public partial class Form4 : Form
    {
        int Id_User = 0;
        public Form4(int Id)
        {
            this.Id_User = Id;
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
                                                Price = b.Money,
                                                Genre = b.Genre,
                                                CoutSalery = b.CoutSalery,
                                            }).ToList();
            }

        }
        private void BuyButtonCreate()
        {

        }

        private void authorsToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
                                                Price = b.Money,
                                                Genre = b.Genre,
                                                CoutSalery = b.CoutSalery,
                                            }).ToList();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form1 f = new Form1();
            f.Show();
            Hide();

        }

        private void buyToolStripMenuItem_Click(object sender, EventArgs e)
        {

            label1.Text = "My purchases";
            using (StoreBookDB sb = new StoreBookDB())
            {

                var userBooks = sb.UserBooks.Where(ub => ub.UserID == Id_User).Select(ub => new
                {



                    BookName = ub.Book.NameBook,
                    Publishing = ub.Book.NamePublishing,
                    AuthorName = $"{ub.Book.Authors.FirstName} {ub.Book.Authors.LastName} {ub.Book.Authors.MiddleName}",
                    Money = ub.Book.Money,
                    DateCreate = ub.Book.Created,
                    Pages = ub.Book.Pages,
                    Price = ub.Book.Money,
                    Genre = ub.Book.Genre,



                })
       .ToList();
                dataGridView1.DataSource = userBooks;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "BuyButtonColumn")
            {
                if (e.RowIndex >= 0)
                {
                    var nameBook = dataGridView1.Rows[e.RowIndex].Cells["NameBook"].Value?.ToString();
                    var idUser = Id_User;

                    if (!string.IsNullOrEmpty(nameBook))
                    {
                        using (StoreBookDB sb = new StoreBookDB())
                        {
                            var user = sb.Users.FirstOrDefault(r => r.ID == idUser);
                            var bookBuy = sb.Books.FirstOrDefault(r => r.NameBook == nameBook);

                            if (user != null && bookBuy != null)
                            {
                                var userBookAudit = sb.UserBooks.Any(r => r.User == user && r.Book == bookBuy);
                                if (!userBookAudit)
                                {
                                    UserBook userBook = new UserBook
                                    {
                                        Book = bookBuy,
                                        User = user
                                    };
                                    sb.UserBooks.Add(userBook);
                                    sb.SaveChanges();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Проверяем, в каком разделе находится DataGridView
            if (label1.Text.Equals("Books"))
            {
                // Создаем столбец с кнопкой добавления только в разделе "Books"
                bool buyButtonColumnExists = dataGridView1.Columns.Cast<DataGridViewColumn>()
                               .Any(column => column.Name == "BuyButtonColumn");
                if (!buyButtonColumnExists)
                {

                    DataGridViewButtonColumn buyButtonColumn = new DataGridViewButtonColumn();
                    buyButtonColumn.Name = "BuyButtonColumn";
                    buyButtonColumn.HeaderText = "Buy";
                    buyButtonColumn.Text = "Buy";
                    buyButtonColumn.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(buyButtonColumn);
                }
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewButtonCell buttonCell = new DataGridViewButtonCell();
                    buttonCell.Value = "Buy";
                    row.Cells["BuyButtonColumn"] = buttonCell;
                }
            }
            else
            {
                if (dataGridView1.Columns.Contains("BuyButtonColumn"))
                {
                    dataGridView1.Columns.Remove("BuyButtonColumn");
                }
            }

        }
        private void SeachMenu()
        {
            if (textBox3.Visible)
            {
                label2.Visible= textBox3.Visible = button1.Visible = false;
            }
            else
                label2.Visible = textBox3.Visible = button1.Visible = true;

        }
        private void OutputInfo(string What)
        {
            SeachMenu();
            using (StoreBookDB sb = new StoreBookDB())
            {
                switch (What)
                {
                    case "Authors":
                        {
                            string[] str = textBox3.Text.Split(' ');
                            dataGridView1.DataSource = sb.Books.Where(b => b.Authors.FirstName.Contains(str[1])
                            && b.Authors.LastName.Contains(str[0])
                           && b.Authors.MiddleName.Contains(str[2]))
                                .Select(ub => new
                                {
                                    NameBook = ub.NameBook,
                                    Publishing = ub.NamePublishing,
                                    AuthorName = $"{ub.Authors.FirstName} {ub.Authors.LastName} {ub.Authors.MiddleName}",
                                    Money = ub.Money,
                                    DateCreate = ub.Created,
                                    Pages = ub.Pages,
                                    Price = ub.Money,
                                    Genre = ub.Genre,
                                }).ToList();

                            break;
                        }
                    case "Bookname":
                        {
                            dataGridView1.DataSource = sb.Books.Where(b => b.NameBook.Contains(textBox3.Text)).Select(ub => new
                            {
                                NameBook = ub.NameBook,
                                Publishing = ub.NamePublishing,
                                AuthorName = $"{ub.Authors.FirstName} {ub.Authors.LastName} {ub.Authors.MiddleName}",
                                Money = ub.Money,
                                DateCreate = ub.Created,
                                Pages = ub.Pages,
                                Price = ub.Money,
                                Genre = ub.Genre,
                            }).ToList();
                            break;
                        }
                    case "Genre":
                        {
                            dataGridView1.DataSource = sb.Books.Where(b => b.Genre.Contains(textBox3.Text)).Select(ub => new
                            {
                                NameBook = ub.NameBook,
                                Publishing = ub.NamePublishing,
                                AuthorName = $"{ub.Authors.FirstName} {ub.Authors.LastName} {ub.Authors.MiddleName}",
                                Money = ub.Money,
                                DateCreate = ub.Created,
                                Pages = ub.Pages,
                                Price = ub.Money,
                                Genre = ub.Genre,
                            }).ToList(); break;
                        }

                }




            }
        }
        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeachMenu();
            label2.Text = "Authors";
        }

        private void gerneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeachMenu();
            label2.Text = "Genre";
        }

        private void bookNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeachMenu();
            label2.Text = "Bookname";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OutputInfo(label2.Text);
        }
    }
}

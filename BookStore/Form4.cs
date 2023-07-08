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
                                                Price = b.Money
                                            }).ToList();
            }
        }
        private void ButtonBuyCreate()
        {

            // Создаем столбец с кнопкой удаления
            bool deleteButtonColumnExists = dataGridView1.Columns.Cast<DataGridViewColumn>()
                                  .Any(column => column.Name == "BuyButtonColumn");
            if (!deleteButtonColumnExists||label1.Text.Equals("Authors"))
            {
                DataGridViewButtonColumn buyButtonColumn = new DataGridViewButtonColumn();
                buyButtonColumn.Name = "BuyButtonColumn";
                buyButtonColumn.HeaderText = "Buy";
                buyButtonColumn.Text = "Buy";
                buyButtonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(buyButtonColumn);
            }

            dataGridView1.CellClick += (sender, e) =>
            {
                if (e.ColumnIndex == dataGridView1.Columns["BuyButtonColumn"].Index && e.RowIndex >= 0)
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
                                var userBook = new UserBook
                                {
                                   Book=bookBuy,
                                   User=user
                                };
                                sb.UserBooks.Add(userBook);
                                sb.SaveChanges();
                            }
                        }
                    }
                }

            };


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
                                                Price = b.Money
                                            }).ToList(); ButtonBuyCreate();
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
                var user = sb.Users.FirstOrDefault(r => r.ID == Id_User);
                var userBooks = sb.UserBooks.Include(ub => ub.User.ID==Id_User).Include(ub => ub.Book).ToList();
                var data = userBooks.Select(ub => new
                {
                    
                    BookName = ub.Book.NameBook,
                    Publishing = ub.Book.NamePublishing,
                    AuthorName = $"{ub.Book.Authors.FirstName} {ub.Book.Authors.LastName} {ub.Book.Authors.MiddleName}",
                    Money = ub.Book.Money,
                    Created = ub.Book.Created,
                    Pages = ub.Book.Pages,
                 
                }).ToList();
                dataGridView1.DataSource = data;
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace BookStore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            using (StoreBookDB sb = new StoreBookDB())
            {
                dataGridView1.DataSource = sb.Books.Select(e => new { NameBook = e.NameBook, Price = e.Money }).ToList();
                dataGridView3.DataSource = sb.Authors.Where(e => e.Id < 3).Select(e => new { Last_Name = e.LastName, Name = e.FirstName, Middle_Name = e.MiddleName }).ToList();
                dataGridView2.DataSource = sb.Books.OrderBy(book => book.CoutSalery).Take(3).ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
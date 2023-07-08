using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
            label4.Visible = true;
            textBox3.Visible = true;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin")
                textBox3.Visible = label3.Visible = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (StoreBookDB sb = new StoreBookDB())
                {
                    var x = sb.Users;
                    if (textBox1.Text == "admin" && textBox2.Text == "admin")
                    {
                        if (textBox3.Text == "123")
                        {
                            Form3 form = new Form3();
                            textBox3.Visible = label3.Visible = false;
                            form.Show();
                            Hide();
                        }
                    }
                    else if (textBox2.Text == sb.Users.Where(e => e.Login == textBox2.Text).Select(e => e.Login).First())
                    {
                        Form3 form = new Form3();
                        button3.Visible = label4.Visible = textBox3.Visible = label3.Visible = false;
                        form.Show();
                        Hide();
                    }
                    else { MessageBox.Show("register!!!"); }


                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (StoreBookDB sb = new StoreBookDB())
            {
                var x = textBox3.Text.Split();
                User user = new User { LastName = x[0].ToString(), FirstName = x[1], MiddleName = x[2], Login = textBox1.Text, Password = textBox2.Text };
                sb.Users.Add(user);
                sb.SaveChanges();
                Form2 form = new Form2();
                form.Show();
                Hide();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksCatalaog
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                using(var context = new BooksContext())
                {
                    bool isExist = false;
                    foreach (var user in context.Users)
                    {
                        if (textBox1.Text == user.Login)
                        {
                            isExist = true;
                            break;
                        }
                    }
                    if (isExist || textBox1.Text == context.Administrator.Login)
                    {
                        MessageBox.Show("Логин занят");
                    }
                    else
                    {
                        User user = new User
                        {
                            Login = textBox1.Text,
                            Password = textBox2.Text,
                            PhoneNumber = textBox3.Text,
                            LikedBooks = new List<Book>(),
                            ReservedBooks = new List<Book>(),
                        };
                        context.Users.Add(user);
                        context.SaveChanges();
                        UserWindow userWindow = new UserWindow(user);
                        Close();
                    }
                }
            }
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }
    }
}

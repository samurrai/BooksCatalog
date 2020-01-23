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
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(var context = new BooksContext())
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Введите логин или пароль");
                }
                else
                {
                    if (textBox1.Text == context.Administrator.Login && textBox2.Text == context.Administrator.Password)
                    {
                        var window = new AdminWindow();
                        window.Show();
                        Close();
                    }
                    else
                    {
                        bool isExist = false;
                        foreach (var user in context.Users)
                        {
                            if (textBox1.Text == user.Login && textBox2.Text == user.Password)
                            {
                                isExist = true;
                                var window = new UserWindow(user);
                                window.Show();
                                Close();
                            }
                        }
                        if (!isExist)
                        {
                            MessageBox.Show("Неправильно введен логин или пароль");
                        }
                    }
                }
            }
        }
    }
}

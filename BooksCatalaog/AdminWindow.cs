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
    public partial class AdminWindow : Form
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Введите название книги");
            }
            else
            {
                using(var context = new BooksContext())
                {
                    bool isExist = false;
                    Book deletedBook = new Book();
                    foreach (var book in context.Books)
                    {
                        if (book.Name == textBox6.Text)
                        {
                            isExist = true;
                            deletedBook = book;
                            break;
                        }
                    }
                    if (isExist)
                    {
                        context.Books.Remove(deletedBook);
                        MessageBox.Show("Книга удалена");
                    }
                    else
                    {
                        MessageBox.Show("Книга не найдена");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
            else
            {
                using (var context = new BooksContext())
                {
                    var book = new Book
                    {
                        Name = textBox1.Text,
                        Author = textBox2.Text,
                        Publisher = textBox3.Text,
                        PublishDate = textBox4.Text,
                        Genre = textBox5.Text,
                        IsArt = checkBox1.Checked,
                        IsAvailable = true
                    };
                    context.Books.Add(book);
                    context.SaveChanges();
                    MessageBox.Show("Книга добавлена");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using(var context = new BooksContext())
            {
                string users = "";
                foreach (var user in context.Users)
                {
                    users += $"{user.Login} {user.Password} {user.PhoneNumber}\n";
                }
                MessageBox.Show(users);
            }
        }
    }
}

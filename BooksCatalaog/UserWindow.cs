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
    public partial class UserWindow : Form
    {
        User user;

        public UserWindow(User currentUser)
        {
            InitializeComponent();
            using (var context = new BooksContext())
            {
                user = currentUser;
                label3.Text = user.Login;
                label4.Text = user.Password;
                label5.Text = user.PhoneNumber;

                if (context.Books.Count() != 0)
                {
                    foreach (var book in context.Books)
                    {
                        listBox1.Items.Add(book.Name);
                    }
                }

                if (user.LikedBooks != null)
                {
                    foreach (var book in user.LikedBooks)
                    {
                        listBox2.Items.Add(book.Name);
                    }
                }

                if (user.ReservedBooks != null)
                {
                    foreach (var book in user.ReservedBooks)
                    {
                        listBox3.Items.Add(book.Name);
                    }
                }

                if (listBox1.Items.Count != 0)
                {
                    listBox1.SelectedIndex = 0;
                }
                if (listBox2.Items.Count != 0)
                {
                    listBox2.SelectedIndex = 0;
                }
                if (listBox3.Items.Count != 0)
                {
                    listBox3.SelectedIndex = 0;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new BooksContext())
            {
                foreach (var book in context.Books)
                {
                    if ((listBox1.SelectedItem as string) == book.Name)
                    {
                        user.LikedBooks.Add(book);
                        listBox2.Items.Add(book.Name);
                        MessageBox.Show("Вам понравилась книга");
                        break;
                    }
                }
                context.SaveChanges();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var context = new BooksContext())
            {
                foreach (var book in context.Books)
                {
                    if ((listBox1.SelectedItem as string) == book.Name)
                    {
                        book.IsAvailable = false;
                        user.ReservedBooks.Add(book);
                        listBox3.Items.Add(book.Name);
                        MessageBox.Show("Вы забронировали книгу");
                        break;
                    }
                }
                context.SaveChanges();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var context = new BooksContext())
            {
                foreach (var book in context.Books)
                {
                    if ((listBox1.SelectedItem as string) == book.Name)
                    {
                        string info = $"{book.Name}\n{book.Author}\n{book.Publisher}\n{book.PublishDate}\n" +
                            $"{book.Genre}\nХудожественная - {book.IsArt}\nДоступна - {book.IsAvailable}";
                        MessageBox.Show(info);
                    }
                }

            }
        }

        private void UserWindow_Load(object sender, EventArgs e)
        {

        }
    }
}

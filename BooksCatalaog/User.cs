using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCatalaog
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Login { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public virtual List<Book> LikedBooks { get; set; }
        public virtual List<Book> ReservedBooks { get; set; }
    }
}

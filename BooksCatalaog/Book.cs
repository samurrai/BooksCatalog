using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCatalaog
{
    public class Book
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string PublishDate { get; set; }
        public bool IsArt { get; set; }
        public string Genre { get; set; }
        public bool IsAvailable { get; set; }
    }
}

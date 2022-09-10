using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.DTO
{
    public class BookDto
    {
        public string Isbn { get; set; }
        public string Name { get; set; }
        public DateTime? DatePublished { get; set; }
        public int AuthorID { get; set; }
        public List<int> categories { get; set; } = new List<int>();
    }
}

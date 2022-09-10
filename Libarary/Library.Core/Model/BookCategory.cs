using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Core.Models
{
    public class BookCategory
    {
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book  { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

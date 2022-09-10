using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Library.Core.Models;

namespace Library.Core.Models
{
    public class Book
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(10,MinimumLength =3,ErrorMessage ="ISBN must be between 3 to 10 char")]
        public string Isbn { get; set; }

        [Required]
        [MaxLength(200,ErrorMessage ="Title Cannot be more than 100 char")]
        public string Name { get; set; }
        public DateTime? DatePublished { get; set; }
        [ForeignKey("Author")]
        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<BookCategory> BookCategories { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Core.Models
{
    public class Review
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateWriting { get; set; }

        [Required]
        [StringLength(2000,MinimumLength =50, ErrorMessage = "Review Text should be between 50 - 2000 char")]
        public string ReviewText { get; set; }

        [Required]
        [Range(1,5,ErrorMessage ="Rating Must be between 1 to 5 stars")]
        public int Rating { get; set; }
        [ForeignKey("Reviewer")]
        public int ReviewerID { get; set; }
        public virtual Reviewer Reviewer { get; set; }
        [ForeignKey("Book")]
        public int BookID { get; set; }
        public virtual Book Book { get; set; }
     
        
    }
}

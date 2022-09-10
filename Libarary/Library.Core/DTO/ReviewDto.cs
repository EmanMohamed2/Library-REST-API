using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Core.DTO
{
    public class ReviewDto
    {
       
        public DateTime DateWriting { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public int ReviewerID { get; set; }
        public int BookID { get; set; }
    }
}

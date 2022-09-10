﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Core.Models
{
    public class Reviewer
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "First Name Cannot be more than 100 char")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "First Name Cannot be more than 200 char")]
        public string LastName { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Core.DTO
{
    public class AuthorDto
    {
        public string Name { get; set; }
        public  int CountryID { get; set; }


    }
}

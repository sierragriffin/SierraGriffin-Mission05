//Separate table/model for movie categories
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Mission04Assignment.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}

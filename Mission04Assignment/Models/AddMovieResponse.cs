//Movie Model

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Mission04Assignment.Models
{
    public class AddMovieResponse
    {
        //Required fields
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1800, 3500)]
        public ushort Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        //Build foreign key relationship
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //Optional Fields
        public bool Edited { get; set; }

        public string LentTo { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }
    }
}

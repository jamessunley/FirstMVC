using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstMVC.Models
{
    public class CarReviews
    {
        public int Id { get; set; }

        [Range(1,10)]
        [Required]
        public int Rating { get; set; }

        [Required]
        [StringLength(1024)]
        public string Body { get; set; }
        public int CarsId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMVC.Models
{
    public class CarListViewModel
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int Price { get; set; }
        public int CountOfReviews { get; set; }
    }
}
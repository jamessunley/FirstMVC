﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMVC.Models
{
    public class Cars
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public virtual ICollection<CarReviews> Reviews { get; set; }
    }
}
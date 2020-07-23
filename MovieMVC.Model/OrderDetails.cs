﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieMVC.Model
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public OrderHeader OrderHeader{ get; set; }

        [Required]
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public  Movie Movie { get; set; }

        public int Count { get; set; }

        public double Price { get; set; }


    }
}

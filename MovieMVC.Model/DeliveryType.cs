using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieMVC.Model
{
    public class DeliveryType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="Delivery Type")]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}

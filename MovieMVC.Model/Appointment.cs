using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace MovieMVC.Model
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Employee")]
        public string EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual ApplicationUser Employee { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        
        [NotMapped]
        public DateTime AppointmentTime { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerPhoneNumber { get; set; }
        [Required]
        public string CustomerEMail { get; set; }
        public bool isConfirmed { get; set; }
    }
}

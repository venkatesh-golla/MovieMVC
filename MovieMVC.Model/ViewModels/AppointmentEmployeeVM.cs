using System;
using System.Collections.Generic;
using System.Text;

namespace MovieMVC.Model.ViewModels
{
    public class AppointmentEmployeeVM
    {
        public List<Appointment> Appointments { get; set; }
        public List<Employee> Employees { get; set; }
    }
}

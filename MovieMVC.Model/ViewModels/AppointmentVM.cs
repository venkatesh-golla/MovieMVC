using System;
using System.Collections.Generic;
using System.Text;

namespace MovieMVC.Model.ViewModels
{
    public class AppointmentVM
    {
        public List<Appointment> Appointments { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}

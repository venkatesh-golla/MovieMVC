using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieMVC.Data_Access.Data;
using MovieMVC.Model;

namespace MovieMVC.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class BookAppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookAppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost,ActionName("Index")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IndexPost(Appointment appointment)
        {
            try
            {
                appointment.AppointmentDate = appointment.AppointmentDate
                .AddHours(appointment.AppointmentTime.Hour)
                .AddMinutes(appointment.AppointmentTime.Minute); ;
                await _context.Appointments.AddAsync(appointment);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Appointment Created Succesully";
            }
            catch (Exception)
            {
                TempData["Error"]="Something went wrong";
            }
            return RedirectToAction("Index","Home");
        }
    }
}
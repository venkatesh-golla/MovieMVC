﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieMVC.Data_Access.Data;
using MovieMVC.Model;
using MovieMVC.Model.ViewModels;
using MovieMVC.Utilities;

namespace MovieMVC.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee+",")]
    [Area("Admin")]
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        private int PageSize = 2;
        public AppointmentVM AppointmentVM;

        public AppointmentController(ApplicationDbContext context, RoleManager<IdentityRole> roleMaager,
                                        UserManager<IdentityUser> userManager)
        {
            _context = context;
            AppointmentVM = new AppointmentVM()
            {
                Appointments = new List<Appointment>(),
                Employees=new List<Employee>()
            };
            this.roleManager = roleMaager;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index(string searchName = null, string searchEmail = null, string searchPhone = null, string searchDate = null, int productPage = 1)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            StringBuilder param = new StringBuilder();
            param.Append("/Admin/Appointment?productPage=:");
            param.Append("&searchName=");
            if (searchName != null)
            {
                param.Append(searchName);
            }
            param.Append("&searchEmail=");
            if (searchEmail != null)
            {
                param.Append(searchEmail);
            }
            param.Append("&searchPhone=");
            if (searchPhone != null)
            {
                param.Append(searchPhone);
            }
            param.Append("&searchDate=");
            if (searchDate != null)
            {
                param.Append(searchDate);
            }
            AppointmentVM.Appointments = _context.Appointments.ToList();
            AppointmentVM.Appointments = _context.Appointments.Include(s => s.Employee).ToList();
            if (User.IsInRole(SD.Role_Employee))
            {
                AppointmentVM.Appointments = AppointmentVM.Appointments.Where(s => s.EmployeeId == claim.Value).Where(s=>s.isConfirmed==true).ToList();
            }

            if (searchName != null)
            {
                AppointmentVM.Appointments = AppointmentVM.Appointments.Where(c => c.CustomerName.ToLower().Contains(searchName)).ToList();
            }

            if (searchEmail != null)
            {
                AppointmentVM.Appointments = AppointmentVM.Appointments.Where(c => c.CustomerEMail.ToLower().Contains(searchEmail)).ToList();
            }
            if (searchPhone != null)
            {
                AppointmentVM.Appointments = AppointmentVM.Appointments.Where(c => c.CustomerPhoneNumber.ToLower().Contains(searchPhone)).ToList();
            }
            if (searchDate != null)
            {
                try
                {
                    DateTime appDate = Convert.ToDateTime(searchDate);
                    AppointmentVM.Appointments = AppointmentVM.Appointments.Where(c => c.AppointmentDate.ToShortDateString().Equals(appDate.ToShortDateString())).ToList();
                }
                catch (Exception ex)
                {

                }
            }

            var count = AppointmentVM.Appointments.Count;
            AppointmentVM.Appointments = AppointmentVM.Appointments.OrderBy(p => p.AppointmentDate)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize).ToList();
            AppointmentVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = count,
                urlParameter = param.ToString()
            };
            if (AppointmentVM.Appointments.Count>0 && String.IsNullOrEmpty(AppointmentVM.Appointments.FirstOrDefault().EmployeeId))
            {
                foreach (var employee in AppointmentVM.Appointments)
                {
                    if(userManager.Users.Where(u => u.Id == employee.EmployeeId).FirstOrDefault() != null)
                    {
                        Employee emp = new Employee
                        {
                            Id = employee.EmployeeId,
                            Name = userManager.Users.Where(u => u.Id == employee.EmployeeId).FirstOrDefault().UserName
                        };
                        AppointmentVM.Employees.Add(emp);
                    }
 
 
                }
            }

            return View(AppointmentVM);
        }

        [Authorize(Roles = SD.Role_Admin)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Appointments = _context.Appointments.Where(a => a.Id == id).FirstOrDefault();
            var roleEmployee = roleManager.Roles.Where(u => u.Name == SD.Role_Employee).FirstOrDefault();
            var users = userManager.Users;

            var usersInEmployee = new List<Employee> { };
            foreach(var user in users)
            {
                var employee = new Employee
                {
                    Id = user.Id,
                    Name=user.UserName
                };
                if(await userManager.IsInRoleAsync(user, roleEmployee.Name))
                {
                    usersInEmployee.Add(employee);
                }
            }
            ViewData["EmployeeList"] = new SelectList(usersInEmployee,"Id","Name") ;
            return View(Appointments);
        }

        [Authorize(Roles = SD.Role_Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Appointment objAppointmentVM)
        {
            if (ModelState.IsValid)
            {
                objAppointmentVM.AppointmentDate = objAppointmentVM.AppointmentDate
                    .AddHours(objAppointmentVM.AppointmentTime.Hour)
                    .AddMinutes(objAppointmentVM.AppointmentTime.Minute);

                var appointmentFromDb = _context.Appointments.Where(a => a.Id == objAppointmentVM.Id).FirstOrDefault();

                appointmentFromDb.CustomerName = objAppointmentVM.CustomerName;
                appointmentFromDb.CustomerEMail = objAppointmentVM.CustomerEMail;
                appointmentFromDb.CustomerPhoneNumber = objAppointmentVM.CustomerPhoneNumber;
                appointmentFromDb.AppointmentDate = objAppointmentVM.AppointmentDate;
                appointmentFromDb.isConfirmed = objAppointmentVM.isConfirmed;

                if (User.IsInRole(SD.Role_Admin))
                {
                    appointmentFromDb.EmployeeId = objAppointmentVM.EmployeeId;
                }
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(objAppointmentVM);
        }
        

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Appointments = _context.Appointments.Where(a => a.Id == id).FirstOrDefault();

            return View(Appointments);
        }

        [Authorize(Roles = SD.Role_Admin)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Appointments = _context.Appointments.Where(a => a.Id == id).FirstOrDefault();

            return View(Appointments);
        }

        [Authorize(Roles = SD.Role_Admin)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
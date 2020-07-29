﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieMVC.Data_Access.Repository.IRepository;

namespace MovieMVC.ViewComponents
{
    public class UserNameViewComponent:ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserNameViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userFromDB = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == claims.Value);

            return View(userFromDB);
        }
    }
}

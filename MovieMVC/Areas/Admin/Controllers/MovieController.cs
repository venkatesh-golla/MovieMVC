using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using MovieMVC.Data_Access.Repository.IRepository;
using MovieMVC.Model;
using MovieMVC.Model.ViewModels;
using MovieMVC.Utilities;

namespace MovieMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class MovieController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;//for images

        public MovieController(IUnitOfWork unitOfWork,IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            MovieVM movieVM = new MovieVM()
            {
                Movie = new Movie(),
                CategoryList=_unitOfWork.Category.GetAll().Select(i=>new SelectListItem
                {
                    Text=i.Name,
                    Value=i.Id.ToString()
                }),
                DeliveryTypeList = _unitOfWork.DeliveryType.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            if (id == null)
            {
                //create
                return View(movieVM);
            }
            movieVM.Movie = _unitOfWork.Movie.Get(id.GetValueOrDefault());
            if (movieVM.Movie == null)
            {
                return NotFound();
            }
          
            return View(movieVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(MovieVM movieVM)
        {
            if (ModelState.IsValid)
            {

                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\products");
                    var extension = Path.GetExtension(files[0].FileName);
                    if (movieVM.Movie.ImageUrl != null)
                    {
                        //Edit so we need to remove old image
                        var imagePath = Path.Combine(webRootPath, movieVM.Movie.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                    using(var fileStreams=new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStreams);
                    }
                    movieVM.Movie.ImageUrl = @"\images\products\" + fileName+extension;
                }
                else
                {
                    //update when image has not been changed
                    if (movieVM.Movie.Id != 0)
                    {
                        Movie objFromDb = _unitOfWork.Movie.Get(movieVM.Movie.Id);
                        movieVM.Movie.ImageUrl = objFromDb.ImageUrl;
                    }
                }
                if (movieVM.Movie.Id == 0)
                {
                    _unitOfWork.Movie.Add(movieVM.Movie);
                }
                else
                {
                    _unitOfWork.Movie.Update(movieVM.Movie);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                movieVM.CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                movieVM.DeliveryTypeList = _unitOfWork.DeliveryType.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                if (movieVM.Movie.Id != 0)
                {
                    movieVM.Movie = _unitOfWork.Movie.Get(movieVM.Movie.Id);
                }
            }
            return View(movieVM);
        }


        #region
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObjs = _unitOfWork.Movie.GetAll(includeProperties:"Category,DeliveryType");
            return Json(new { data = allObjs });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Movie.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            string webRootPath = _hostEnvironment.WebRootPath;
            var imagePath = Path.Combine(webRootPath, objFromDb.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            _unitOfWork.Movie.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleted Succesfully" });
        }

        #endregion
    }
}
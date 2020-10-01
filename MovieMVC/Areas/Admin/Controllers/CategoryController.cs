using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMVC.Data_Access.Repository.IRepository;
using MovieMVC.Model;
using MovieMVC.Model.ViewModels;
using MovieMVC.Utilities;

namespace MovieMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index(int productPage = 1)
        {
            CategoryVM categoryVM = new CategoryVM()
            {
                Categories = await _unitOfWork.Category.GetAllAsync()
            };
            var count = categoryVM.Categories.Count();
            categoryVM.Categories = categoryVM.Categories.OrderBy(c => c.Name).Skip((productPage - 1) * 2).Take(2).ToList();
            categoryVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = 2,
                TotalItems = count,
                urlParameter = "/Admin/Category/Index?productPage=:"
            };
            return View(categoryVM);
        }
        public async Task<IActionResult> Upsert(int? id)
        {
            Category category = new Category();
            if (id == null)
            {
                //create
                return View(category);
            }
            category =await _unitOfWork.Category.GetAsync(id.GetValueOrDefault());
            if (category == null)
            {
                return NotFound();
            }
          
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id == 0)
                {
                  await  _unitOfWork.Category.AddAsync(category);                    
                }
                else
                {
                    _unitOfWork.Category.Update(category);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }


        #region
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObjs = await _unitOfWork.Category.GetAllAsync();
            return Json(new { data = allObjs });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb =await _unitOfWork.Category.GetAsync(id);
            if (objFromDb == null)
            {
                TempData["Error"] = "Unable to Delete the Category";
                return Json(new { success = false, message = "Error while deleting" });
            }
           await _unitOfWork.Category.RemoveAsync(objFromDb);
            _unitOfWork.Save();
            TempData["Success"] = "Category Deleted Succesfully";
            return Json(new { success = true, message = "Deleted Succesfully" });
        }

        #endregion
    }
}
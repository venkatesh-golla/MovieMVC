using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieMVC.Data_Access.Data;
using MovieMVC.Data_Access.Repository.IRepository;
using MovieMVC.Model;
using MovieMVC.Model.ViewModels;
using MovieMVC.Utilities;

namespace MovieMVC.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _db;
        public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork, ApplicationDbContext db)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Movie> movieList = _unitOfWork.Movie.GetAll(includeProperties:"Category,DeliveryType");

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim!= null)
            {
                var count = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == claim.Value)
                    .ToList().Count;
                HttpContext.Session.SetInt32(SD.ssShopingCart, count);
            }

            return View(movieList);
        }

        public IActionResult MoviesByDirector(string directorName)
        {
            IEnumerable<Movie> movieList = _unitOfWork.Movie.GetAll(c=>c.Director==directorName , includeProperties: "Category,DeliveryType");

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                var count = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == claim.Value)
                    .ToList().Count;
                HttpContext.Session.SetInt32(SD.ssShopingCart, count);
            }

            return View(movieList);
        }

        public IActionResult moviesByCategory(int? categoryId)
        {
            IEnumerable<Movie> movieList = _unitOfWork.Movie.GetAll(c => c.CategoryId == categoryId, includeProperties: "Category,DeliveryType");

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                var count = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == claim.Value)
                    .ToList().Count;
                HttpContext.Session.SetInt32(SD.ssShopingCart, count);
            }

            return View(movieList);
        }

        public IActionResult DirectorsList()
        {
            var listOfDirectors = _db.Movies.Select(d => d.Director).Distinct();
            return View(listOfDirectors);
        }

        public IActionResult CategoryList()
        {
            IEnumerable<Category> listOfCategories;
             listOfCategories = _db.Categories.Distinct();
            return View(listOfCategories);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var movieFromDb = _unitOfWork.Movie.GetFirstOrDefault(m => m.Id == id, includeProperties: "Category,DeliveryType");
            ShoppingCart cartObj = new ShoppingCart()
            {
                Movie = movieFromDb,
                MovieId = movieFromDb.Id
            };
            return View(cartObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            shoppingCart.Id = 0;
            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                shoppingCart.ApplicationUserId = claim.Value;

                ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(
                    m=>m.ApplicationUserId==shoppingCart.ApplicationUserId && m.MovieId==shoppingCart.MovieId,
                    includeProperties:"Movie");
                if (cartFromDb == null)
                {
                    //a record doesnot exist for the user and that movie
                    _unitOfWork.ShoppingCart.Add(shoppingCart);
                }
                else
                {
                    cartFromDb.Count += shoppingCart.Count;
                    _unitOfWork.ShoppingCart.Update(cartFromDb);
                }
                _unitOfWork.Save();

                var count = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == shoppingCart.ApplicationUserId)
                    .ToList().Count;
                HttpContext.Session.SetInt32(SD.ssShopingCart, count);
                //HttpContext.Session.SetObject(SD.ssShopingCart, count);
                return RedirectToAction("Index");
            }
            else
            {
                var movieFromDb = _unitOfWork.Movie.GetFirstOrDefault(m => m.Id == shoppingCart.Id, includeProperties: "Category,DeliveryType");
                ShoppingCart cartObj = new ShoppingCart()
                {
                    Movie = movieFromDb,
                    MovieId = movieFromDb.Id
                };
                return View(cartObj);
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

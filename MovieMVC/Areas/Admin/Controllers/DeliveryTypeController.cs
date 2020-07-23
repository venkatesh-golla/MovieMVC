using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMVC.Data_Access.Repository.IRepository;
using MovieMVC.Model;
using MovieMVC.Utilities;

namespace MovieMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class DeliveryTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeliveryTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            DeliveryType deliveryType = new DeliveryType();
            if (id == null)
            {
                //create
                return View(deliveryType);
            }
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id);
            deliveryType = _unitOfWork.SP_Call.OneRecord<DeliveryType>(SD.Proc_DeliveryType_Get, parameter);
            // deliveryType = _unitOfWork.DeliveryType.Get(id.GetValueOrDefault());
            if (deliveryType == null)
            {
                return NotFound();
            }

            return View(deliveryType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(DeliveryType deliveryType)
        {
            if (ModelState.IsValid)
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Name", deliveryType.Name);
                if (deliveryType.Id == 0)
                {
                    _unitOfWork.SP_Call.Execute(SD.Proc_DeliveryType_Create, parameter);
                   // _unitOfWork.DeliveryType.Add(deliveryType);
                }
                else
                {
                    parameter.Add("@Id", deliveryType.Id);
                    _unitOfWork.SP_Call.Execute(SD.Proc_DeliveryType_Update, parameter);
                  //  _unitOfWork.DeliveryType.Update(deliveryType);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(deliveryType);
        }

        
        #region
        [HttpGet]
        public IActionResult GetAll()
        {
            // var allObjs = _unitOfWork.DeliveryType.GetAll();
            var allObjs = _unitOfWork.SP_Call.List<DeliveryType>(SD.Proc_DeliveryType_GetAll,null);
            return Json(new { data = allObjs });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id);
            var objFromDb = _unitOfWork.SP_Call.OneRecord<DeliveryType>(SD.Proc_DeliveryType_Get, parameter);
            //var objFromDb = _unitOfWork.DeliveryType.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.SP_Call.Execute(SD.Proc_DeliveryType_Delete, parameter);
           // _unitOfWork.DeliveryType.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleted Succesfully" });
        }

        #endregion
    }
}
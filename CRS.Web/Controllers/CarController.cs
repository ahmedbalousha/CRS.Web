using CRS.Core.Constants;
using CRS.Core.Dtos;
using CRS.Core.Enums;
using CRS.Infrastructure.Services.Advertisements;
using CRS.Infrastructure.Services.CarCompanies;
using CRS.Infrastructure.Services.Cars;
using CRS.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRS.Web.Controllers
{
    public class CarController : BaseController
    {

        private readonly ICarService _carService;
        private readonly ICarCompanyService _carCompanyService;

        public CarController(ICarService carService, IUserService userService, ICarCompanyService carCompanyService) : base(userService)
        {
            _carService = carService;
            _carCompanyService = carCompanyService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        //public async Task<IActionResult> GetLog(int Id)
        //{
        //    var logs = await _carService.GetLog(Id);
        //    return View(logs);
        //}

        public async Task<JsonResult> GetCarData(Pagination pagination,Query query)
        {
            var result = await _carService.GetAll(pagination, query);
            return  Json(result);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["carcompanies"] = new SelectList(await _carCompanyService.GetCarCompanyList(), "Id", "Name");
            ViewData["owners"] = new SelectList(await _carService.GetCarOwners(),"Id","FullName");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateCarDto dto)
        {
            
            if (ModelState.IsValid)
            {
                await _carService.Create(dto);
                return Ok(Results.AddSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var user = await _carService.Get(id);
            ViewData["carcompanies"] = new SelectList(await _carCompanyService.GetCarCompanyList(), "Id", "Name");
            ViewData["owners"] = new SelectList(await _carService.GetCarOwners(), "Id", "FullName");
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCarDto dto)
        {
            if (ModelState.IsValid)
            {
                await _carService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _carService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStatus(int id, CarStatus status)
        {
            await _carService.UpdateStatus(id, status);
            return Ok(Results.UpdateStatusSuccessResult());
        }

        [HttpGet]
        public IActionResult GetRentTimes (int id)
        {
         var numberTimesRent =  _carService.GetNumberTimesRent(id);
            return Ok(numberTimesRent);
        }

    }
}

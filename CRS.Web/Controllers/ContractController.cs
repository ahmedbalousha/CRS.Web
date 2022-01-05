using CRS.Core.Constants;
using CRS.Core.Dtos;
using CRS.Infrastructure.Services.Cars;
using CRS.Infrastructure.Services.Contracts;
using CRS.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRS.Web.Controllers
{
    public class ContractController : BaseController
    {
        private readonly IContractService _contractService;
        private readonly ICarService _carService;

        public ContractController(ICarService carService, IUserService userService, IContractService contractService) : base(userService)
        {
            _carService = carService;
            _contractService = contractService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetContractData(Pagination pagination, Query query)
        {
            var result = await _contractService.GetAll(pagination, query);
            return Json(result);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["cars"] = new SelectList(await _carService.GetCarList(), "Id", "CarNumber");
            ViewData["customers"] = new SelectList(await _contractService.GetCustomers(), "Id", "FullName");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateContractDto dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.CustomerId))
            {
                ModelState.Remove("Customer.FullName");
                ModelState.Remove("Customer.Email");
                ModelState.Remove("Customer.PhoneNumber");
                ModelState.Remove("Customer.IdNumber");

            }

            if (ModelState.IsValid)
            {
                await _contractService.Create(dto);
                return Ok(Results.AddSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var user = await _contractService.Get(id);
            ViewData["cars"] = new SelectList(await _carService.GetCarList(), "Id", "CarNumber");
            ViewData["customers"] = new SelectList(await _contractService.GetCustomers(), "Id", "FullName");
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateContractDto dto)
        {
            if (ModelState.IsValid)
            {
                await _contractService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _contractService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }






    }
}

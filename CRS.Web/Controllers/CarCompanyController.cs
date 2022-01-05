using CRS.Core.Constants;
using CRS.Core.Dtos;
using CRS.Infrastructure.Services.CarCompanies;
using CRS.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRS.Web.Controllers
{
    public class CarCompanyController : BaseController
    {

        private readonly ICarCompanyService _carCompanyService;
        public CarCompanyController(ICarCompanyService categoryService, IUserService userService) : base(userService)
        {
            _carCompanyService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetCarCompanyData(Pagination pagination,Query query)
        {
            var result = await _carCompanyService.GetAll(pagination, query);
            return  Json(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarCompanyDto dto)
        {
            if (ModelState.IsValid)
            {
                await _carCompanyService.Create(dto);
                return Ok(Results.AddSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var user = await _carCompanyService.Get(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCarCompanyDto dto)
        {
            if (ModelState.IsValid)
            {
                await _carCompanyService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _carCompanyService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }

    }
}

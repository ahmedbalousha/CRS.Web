using CRS.Core.Constants;
using CRS.Core.Dtos;
using CRS.Infrastructure.Services.Advertisements;
using CRS.Infrastructure.Services.Users;
using CRS.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Controllers
{
    public class AdvertisementController : BaseController
    {

        private readonly IAdvertisementService _advertisementService;

        public AdvertisementController(IAdvertisementService advertisementService,IUserService userService) : base(userService)
        {
            _advertisementService = advertisementService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetAdvertisementData(Pagination pagination,Query query)
        {
            var result = await _advertisementService.GetAll(pagination, query);
            return  Json(result);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["advertisers"] = new SelectList(await _advertisementService.GetAdvertisementAdvertisers(),"Id","FullName");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateAdvertisementDto dto)
        {
            
            if (ModelState.IsValid)
            {
                await _advertisementService.Create(dto);
                return Ok(Results.AddSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var user = await _advertisementService.Get(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateAdvertisementDto dto)
        {
            if (ModelState.IsValid)
            {
                await _advertisementService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _advertisementService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }

    }
}

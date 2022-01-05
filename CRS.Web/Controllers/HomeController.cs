using CRS.Infrastructure.Services;
using CRS.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CRS.Web.Controllers
{
    public class HomeController : BaseController
    {

        private readonly IDashboardService _dashboardService;

        public HomeController(IUserService userService, IDashboardService dashboardService) : base(userService)
        {
            _dashboardService = dashboardService;
        }


       
        public async Task<IActionResult> Index()
        {
            var data = await _dashboardService.GetData();
            return View(data);
        }


        public async Task<IActionResult> GetUserTypeChartData()
        {
            var data = await _dashboardService.GetUserTypeChart();
            return Ok(data);
        }

        

        public async Task<IActionResult> GetContractByMonthChartData()
        {
            var data = await _dashboardService.GetContractByMonthChart();
            return Ok(data);
        }


    }
}

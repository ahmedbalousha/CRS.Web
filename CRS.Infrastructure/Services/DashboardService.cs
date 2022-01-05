using CRS.Infrastructure.Services;
using CRS.Core.Enums;
using CRS.Core.ViewModels;
using CRS.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Infrastructure.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly CRSDbContext _db;

        public DashboardService(CRSDbContext db)
        {
            _db = db;
        }

        public async Task<DashboardViewModel> GetData()
        {
            var data = new DashboardViewModel();
            data.NumberOfUsers = await _db.Users.CountAsync(x => !x.IsDelete);
            data.NumberOfContract = await _db.Contracts.CountAsync(x => !x.IsDelete);
            data.NumberOfCar = await _db.Cars.CountAsync(x => !x.IsDelete);
            data.NumberOfAdvertisement = await _db.Advertisements.CountAsync(x => !x.IsDelete);
            return data;
        }

        public async Task<List<PieChartViewModel>> GetUserTypeChart()
        {

            var data = new List<PieChartViewModel>();
            data.Add(new PieChartViewModel()
            {
                Key = "Administrator",
                Value = await _db.Users.CountAsync(x => !x.IsDelete && x.UserType == UserType.Administrator),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Advertiser",
                Value = await _db.Users.CountAsync(x => !x.IsDelete && x.UserType == UserType.Advertiser),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Customer",
                Value = await _db.Users.CountAsync(x => !x.IsDelete && x.UserType == UserType.Customer),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Car Owner",
                Value = await _db.Users.CountAsync(x => !x.IsDelete && x.UserType == UserType.Owner),
                color = GenrateColor()
            });
            return data;
        }


      


        public async Task<List<PieChartViewModel>> GetContractByMonthChart()

        {

            var data = new List<PieChartViewModel>();
            data.Add(new PieChartViewModel()
            {
                Key = "Jan",
                Value = _db.Contracts.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 1).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Feb",
                Value = _db.Contracts.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 2).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Mar",
                Value = _db.Contracts.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 3).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Apr",
                Value = _db.Contracts.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 4).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "May",
                Value = _db.Contracts.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 5).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Jun",
                Value = _db.Contracts.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 6).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Jul",
                Value = _db.Contracts.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 7).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Aug",
                Value = _db.Contracts.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 8).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Sep",
                Value = _db.Contracts.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 9).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Oct",
                Value = _db.Contracts.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 10).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Nov",
                Value = _db.Contracts.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 11).Count(),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Dec",
                Value = _db.Contracts.Where(x => !x.IsDelete && x.CreatedAt.Date.Month == 12).Count(),
                color = GenrateColor()
            });

            return data;
        }


        private string GenrateColor()
        {
            var random = new Random();
            return String.Format("#{0:X6}", random.Next(0x1000000));
        }
 
    }
}

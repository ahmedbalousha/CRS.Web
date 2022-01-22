using AutoMapper;
using CRS.Core.Exceptions;
using CRS.Core.ViewModels;
using CRS.Data.Models;
using CRS.Data;
using CRS.Infrastructure.Services.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRS.Core.Dtos;
using CRS.Core.Enums;
using Hangfire;

namespace CRS.Infrastructure.Services.Cars
{
    public class CarService : ICarService
    {

        private readonly CRSDbContext _db;
        private readonly IMapper _mapper;
        private readonly IUserService  _userService;
        private readonly IFileService _fileService;
        private readonly IEmailService _emailService;

        public CarService(IFileService fileService,CRSDbContext db, IMapper mapper, IUserService userService, IEmailService emailService)
        {
            _db = db;
            _mapper = mapper;
            _fileService = fileService;
            _userService = userService;
            _emailService = emailService;
        }

        
        public async Task<List<UserViewModel>> GetCarOwners()
        {
            var users = await _db.Users.Where(x => !x.IsDelete && x.UserType == UserType.Owner).ToListAsync();
            return _mapper.Map<List<UserViewModel>>(users);
        }

        public async Task<List<CarChangeLogViewModel>> GetLog(int id)
        {
            var changes = await _db.CarChangeLogs.Where(x => x.ContentId == id ).ToListAsync();
            return _mapper.Map<List<CarChangeLogViewModel>>(changes);
        }

        public async Task<List<CarViewModel>> GetCarList()
        {
            var cars = await _db.Cars.Where(x => !x.IsDelete && x.Status == CarStatus.Free).ToListAsync();
            return _mapper.Map<List<CarViewModel>>(cars);
        }

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Cars.Include(x => x.Owner).Include(x => x.CarCompany).Where(x => !x.IsDelete).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var cars = _mapper.Map<List<CarViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = cars,
                meta = new Meta
                {
                    page = pagination.Page,
                    perpage = pagination.PerPage,
                    pages = pages,
                    total = dataCount,
                }
            };
            return result;
        }

        public async Task<int> Delete(int id)
        {
            var car = await _db.Cars.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if(car == null)
            {
                throw new EntityNotFoundException();
            }
            car.IsDelete = true;
            _db.Cars.Update(car);
            await _db.SaveChangesAsync();
            return car.Id;
        }

        public async Task<UpdateCarDto> Get(int id)
        {
            var car = await _db.Cars.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (car == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateCarDto>(car);
        }


        public async Task<int> Create(CreateCarDto dto)
        {

        
            var car = _mapper.Map<Car>(dto);
            if(dto.Image != null)
            {
                car.ImageUrl = await _fileService.SaveFile(dto.Image, "Images");
            }

            await _db.Cars.AddAsync(car);
            await _db.SaveChangesAsync();
            return car.Id;
        }


        public async Task<int> Update(UpdateCarDto dto)
        {
            var car = await _db.Cars.SingleOrDefaultAsync(x => x.Id == dto.Id && !x.IsDelete);
            if(car == null)
            {
                throw new EntityNotFoundException();
            }

            var updatedCar = _mapper.Map(dto, car);

            if (dto.Image != null)
            {
                updatedCar.ImageUrl = await _fileService.SaveFile(dto.Image, "Images");
            }

             _db.Cars.Update(updatedCar);
             await _db.SaveChangesAsync();

            return car.Id;
        }
        public async Task<int> UpdateStatus(int id, CarStatus status)
        {
            var car = await _db.Cars.Include(x => x.Owner).SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (car == null)
            {
                throw new EntityNotFoundException();
            }

            car.Status = status;
            _db.Cars.Update(car);
            var jobId = BackgroundJob.Schedule(
            () => Console.WriteLine("Delayed!"),
            TimeSpan.FromDays(7));
            await _db.SaveChangesAsync();


            await _emailService.Send(car.Owner.Email, "UPDATE Car STATUS !", $"YOUR Car NOW IS {status.ToString()}");

            return car.Id;
        }
        public int GetNumberTimesRent (int id)
        {
            var numberTimesRent =  _db.Contracts.Where(x => x.CarId == id && !x.IsDelete).Count();
           
            return numberTimesRent;
        }

    }
}

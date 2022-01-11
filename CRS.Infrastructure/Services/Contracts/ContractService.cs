using AutoMapper;
using CRS.Core.Dtos;
using CRS.Core.Enums;
using CRS.Core.Exceptions;
using CRS.Core.ViewModels;
using CRS.Data;
using CRS.Data.Models;
using CRS.Infrastructure.Services.Time;
using CRS.Infrastructure.Services.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Infrastructure.Services.Contracts
{
    public class ContractService : IContractService
    {

        private readonly CRSDbContext _db;
        private readonly IMapper _mapper;
        private readonly IUserService  _userService;
        private readonly IFileService _fileService;
        private readonly TimedHostedService _timedHostedService;


        public ContractService(IFileService fileService,CRSDbContext db, IMapper mapper, IUserService userService, TimedHostedService timedHostedService)
        {
            _db = db;
            _mapper = mapper;
            _fileService = fileService;
            _userService = userService;
            _timedHostedService = timedHostedService;
        }

        
        public async Task<List<UserViewModel>> GetCustomers()
        {
            var users = await _db.Users.Where(x => !x.IsDelete && x.UserType == UserType.Customer).ToListAsync();
            return _mapper.Map<List<UserViewModel>>(users);
        }

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Contracts.Include(x => x.Customer).Include(x => x.Car).Where(x => !x.IsDelete).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var contracts = _mapper.Map<List<ContractViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = contracts,
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
            var contract = await _db.Contracts.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if(contract == null)
            {
                throw new EntityNotFoundException();
            }
            contract.IsDelete = true;
            _db.Contracts.Update(contract);
            await _db.SaveChangesAsync();
            return contract.Id;
        }

        public async Task<UpdateContractDto> Get(int id)
        {
            var contract = await _db.Contracts.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (contract == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateContractDto>(contract);
        }
        public async Task<int> Update(UpdateContractDto dto)
        {

            if (dto.StartDate >= dto.EndDate)
            {
                throw new InvalidDateException();
            }

            var contract = await _db.Contracts.SingleOrDefaultAsync(x => x.Id == dto.Id && !x.IsDelete);
            if (contract == null)
            {
                throw new EntityNotFoundException();
            }

            var updatedContract = _mapper.Map(dto, contract);

            if (dto.Image != null)
            {
                updatedContract.ImageUrl = await _fileService.SaveFile(dto.Image, "Images");
            }

            _db.Contracts.Update(updatedContract);
            await _db.SaveChangesAsync();

            return contract.Id;
        }

        public async Task<int> Create(CreateContractDto dto)
        {

            if (dto.StartDate >= dto.EndDate)
            {
                throw new InvalidDateException();
            }

            var contract = _mapper.Map<Contract>(dto);
            if(dto.Image != null)
            {
                contract.ImageUrl = await _fileService.SaveFile(dto.Image, "Images");
            }

            if (!string.IsNullOrWhiteSpace(dto.CustomerId))
            {
                contract.CustomerId = dto.CustomerId;
            }
            //var updateCar = _db.Cars.SingleOrDefault(x => x.Id == dto.CarId);
            //updateCar.Status = CarStatus.Busy;
            //_db.Cars.Update(updateCar);
            //_db.SaveChanges();
            await _db.Contracts.AddAsync(contract);
            await _db.SaveChangesAsync();
           
            if (contract.CustomerId == null)
            {
                var userId = await _userService.Create(dto.Customer);
                contract.CustomerId = userId;

                _db.Contracts.Update(contract);
                await _db.SaveChangesAsync();

            }
            return contract.Id;
        }


        

    }
}

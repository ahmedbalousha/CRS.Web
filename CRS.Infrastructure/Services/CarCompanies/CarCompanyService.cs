using AutoMapper;
using CRS.Core.Dtos;
using CRS.Core.Exceptions;
using CRS.Core.ViewModels;
using CRS.Data;
using CRS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Infrastructure.Services.CarCompanies
{
    public class CarCompanyService : ICarCompanyService
    {
        private readonly CRSDbContext _db;
        private readonly IMapper _mapper;

        public CarCompanyService(CRSDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<List<CarCompanyViewModel>> GetCarCompanyList()
        {
            var carCompanies = await _db.CarCompanies.Where(x => !x.IsDelete ).ToListAsync();
            return _mapper.Map<List<CarCompanyViewModel>>(carCompanies);
        }

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.CarCompanies.Where(x => !x.IsDelete && (x.Name.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var carCompanies = _mapper.Map<List<CarCompanyViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = carCompanies,
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


        public async Task<int> Create(CreateCarCompanyDto dto)
        {
            var carCompany = _mapper.Map<CarCompany>(dto);
            await _db.CarCompanies.AddAsync(carCompany);
            await _db.SaveChangesAsync();
            return carCompany.Id;
        }


        public async Task<int> Update(UpdateCarCompanyDto dto)
        {
            var carCompany = await _db.CarCompanies.SingleOrDefaultAsync(x => !x.IsDelete && x.Id == dto.Id);
            if(carCompany == null)
            {
                throw new EntityNotFoundException();
            }
            var updatedCarCompany = _mapper.Map<UpdateCarCompanyDto, CarCompany>(dto, carCompany);
            _db.CarCompanies.Update(updatedCarCompany);
            await _db.SaveChangesAsync();
            return updatedCarCompany.Id;
        }


        public async Task<UpdateCarCompanyDto> Get(int Id)
        {
            var carCompany = await _db.CarCompanies.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (carCompany == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateCarCompanyDto>(carCompany);
        }


        public async Task<int> Delete(int Id)
        {
            var carCompany = await _db.CarCompanies.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (carCompany == null)
            {
                throw new EntityNotFoundException();
            }
            carCompany.IsDelete = true;
            _db.CarCompanies.Update(carCompany);
            await _db.SaveChangesAsync();
            return carCompany.Id;
        }


    }
}

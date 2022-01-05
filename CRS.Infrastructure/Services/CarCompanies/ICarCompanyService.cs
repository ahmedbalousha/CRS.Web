
using CRS.Core.Dtos;
using CRS.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Infrastructure.Services.CarCompanies
{
    public interface ICarCompanyService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);

        Task<int> Create(CreateCarCompanyDto dto);

        Task<int> Update(UpdateCarCompanyDto dto);

        Task<UpdateCarCompanyDto> Get(int Id);

        Task<List<CarCompanyViewModel>> GetCarCompanyList();

        Task<int> Delete(int Id);
    }
}

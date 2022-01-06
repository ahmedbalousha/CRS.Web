using CRS.Core.Dtos;
using CRS.Core.Enums;
using CRS.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Infrastructure.Services.Cars
{
    public interface ICarService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<int> Delete(int id);
        Task<int> Create(CreateCarDto dto);
        Task<List<UserViewModel>> GetCarOwners();
        Task<List<CarViewModel>> GetCarList();
        Task<UpdateCarDto> Get(int id);
        Task<int> Update(UpdateCarDto dto);
        Task<List<CarChangeLogViewModel>> GetLog(int id);
        Task<int> UpdateStatus(int id, CarStatus status);

    }
}

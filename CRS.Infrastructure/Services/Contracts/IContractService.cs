using CRS.Core.Dtos;
using CRS.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Infrastructure.Services.Contracts
{
    public interface IContractService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<int> Delete(int id);
        Task<int> Create(CreateContractDto dto);
        Task<List<UserViewModel>> GetCustomers();
        Task<int> Update(UpdateContractDto dto);
        Task<UpdateContractDto> Get(int id);
        //Task<List<ContractViewModel>> GetContractByCustoumer(string serachKey);
    }
}

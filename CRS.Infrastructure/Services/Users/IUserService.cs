using CRS.Core.Dtos;
using CRS.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Infrastructure.Services.Users
{
    public interface IUserService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<string> Create(CreateUserDto dto);
        Task<List<UserViewModel>> GetCustomerList();
        Task<string> Update(UpdateUserDto dto);
        UserViewModel GetUserByUsername(string username);
        Task<string> Delete(string Id);
        Task<UpdateUserDto> Get(string Id);

    }
}

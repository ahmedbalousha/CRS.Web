using AutoMapper;
using CRS.Core.Dtos;
using CRS.Core.ViewModels;
using CRS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Infrastructure.AutoMapper
{
 public  class MapperProfile : Profile
    {
        public MapperProfile() { 


        CreateMap<User, UserViewModel>().ForMember(x => x.UserType, x => x.MapFrom(x => x.UserType.ToString()));
        CreateMap<CreateUserDto, User>().ForMember(x => x.ImageUrl, x => x.Ignore());
        CreateMap<UpdateUserDto, User>().ForMember(x => x.ImageUrl, x => x.Ignore());
        CreateMap<User, UpdateUserDto>().ForMember(x => x.Image, x => x.Ignore());

        CreateMap<CarCompany, CarCompanyViewModel>();
        CreateMap<CreateCarCompanyDto, CarCompany>();
        CreateMap<UpdateCarCompanyDto, CarCompany>();
        CreateMap<CarCompany, UpdateCarCompanyDto>();


        CreateMap<Advertisement, AdvertisementViewModel>()
                .ForMember(x => x.StartDate, x => x.MapFrom(x => x.StartDate.ToString("yyyy:MM:dd")))
                .ForMember(x => x.EndDate, x => x.MapFrom(x => x.EndDate.ToString("yyyy:MM:dd")))
                .ForMember(x => x.Status, x => x.MapFrom(x => x.Status.ToString()));
        CreateMap<CreateAdvertisementDto, Advertisement>().ForMember(x => x.ImageUrl, x => x.Ignore()).ForMember(x => x.Advertiser, x => x.Ignore());
        CreateMap<UpdateAdvertisementDto, Advertisement>().ForMember(x => x.ImageUrl, x => x.Ignore()).ForMember(x => x.Advertiser, x => x.Ignore());
        CreateMap<Advertisement, UpdateAdvertisementDto>().ForMember(x => x.Image, x => x.Ignore());

        CreateMap<Car, CarViewModel>()
        .ForMember(x => x.ProductionYear, x => x.MapFrom(x => x.ProductionYear.ToString("yyyy")))
        .ForMember(x => x.Status, x => x.MapFrom(x => x.Status.ToString()));
        CreateMap<CreateCarDto, Car>().ForMember(x => x.ImageUrl, x => x.Ignore())
        .ForMember(x => x.Owner, x => x.Ignore()).ForMember(x => x.CarCompany, x => x.Ignore());
        CreateMap<UpdateCarDto, Car>().ForMember(x => x.ImageUrl, x => x.Ignore()).ForMember(x => x.Owner, x => x.Ignore());
        CreateMap<Car, UpdateCarDto>().ForMember(x => x.Image, x => x.Ignore());

            CreateMap<Contract, ContractViewModel>();
                //.ForMember(x => x.StartDate, x => x.MapFrom(x => x.StartDate.ToString("yyyy:MM:dd")))
                //.ForMember(x => x.EndDate, x => x.MapFrom(x => x.EndDate.ToString("yyyy:MM:dd")));

        CreateMap<CreateContractDto, Contract>().ForMember(x => x.ImageUrl, x => x.Ignore()).ForMember(x => x.Customer, x => x.Ignore()); 
        CreateMap<UpdateContractDto, Contract>().ForMember(x => x.ImageUrl, x => x.Ignore()).ForMember(x => x.Customer, x => x.Ignore());
        CreateMap<Contract, UpdateContractDto>().ForMember(x => x.Image, x => x.Ignore());

        }
    }
}

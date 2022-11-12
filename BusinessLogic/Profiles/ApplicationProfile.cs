using BusinessLogic.DTOs;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Profiles
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Laptop, LaptopDto>()
                .ForMember(d => d.OSId, opt => opt.MapFrom(s => s.OperationSystemId))
                .ForMember(d => d.OSName, opt => opt.MapFrom(s => s.OperationSystem.Name));

            CreateMap<LaptopDto, Laptop>()
                .ForMember(d => d.OperationSystemId, opt => opt.MapFrom(s => s.OSId));

            CreateMap<UserDto, IdentityUser>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.Email))
                .ForMember(d => d.Id, opt => opt.Ignore());
        }
    }
}
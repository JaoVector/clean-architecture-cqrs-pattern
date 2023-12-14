using AutoMapper;
using FollowMe.Application.UseCases.Usuario.Commands;
using FollowMe.Application.UseCases.Usuario.Responses;
using FollowMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUserRequest, Usuario>();
            CreateMap<Usuario, CreateUserResponse>().ForMember(x => x.Endereco, opt => opt.MapFrom(x => x.Endereco));
        }
    }
}

using AutoMapper;
using FollowMe.Application.UseCases.Endereco.Responses;
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
            

        }
    }
}
/*

CreateMap<Usuario, ReadUserResponse>()
                .ForMember(x => x.Endereco, opt => opt.MapFrom(x => x.Endereco));


CreateMap<CreateUserRequest, Usuario>();
            CreateMap<Usuario, CreateUserResponse>();
            CreateMap<Usuario, ReadUserResponse>()
                .ForMember(x => x.Endereco, opt => opt.MapFrom(x => x.Endereco))
                .ForMember(x => x.Produtos, opt => opt.MapFrom(x => x.Produtos));
            CreateMap<Usuario, ReadAllUserResponse>();
*/
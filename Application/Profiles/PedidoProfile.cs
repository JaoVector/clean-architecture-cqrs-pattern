using AutoMapper;
using FollowMe.Application.UseCases.Endereco.Responses;
using FollowMe.Application.UseCases.Pedido.Commands;
using FollowMe.Application.UseCases.Pedido.Responses;
using FollowMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.Profiles
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile() 
        {
            CreateMap<CreatePedidoRequest, Pedido>();
            CreateMap<Pedido, CreatePedidoResponse>();
            CreateMap<Pedido, UpdateStatusPedidoResponse>();
        }
    }
}

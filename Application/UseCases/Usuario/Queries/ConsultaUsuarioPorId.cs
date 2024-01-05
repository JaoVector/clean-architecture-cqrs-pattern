using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FollowMe.Application.UseCases.Usuario.Responses;
using MediatR;

namespace FollowMe.Application.UseCases.Usuario.Queries
{
    public sealed record ConsultaUsuarioPorId(Guid UsuarioId) : IRequest<ReadUserResponse>;
}

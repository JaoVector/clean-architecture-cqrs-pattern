﻿using FollowMe.Application.UseCases.Usuario.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Usuario.Commands
{
    public sealed record DeleteUserRequest(Guid UsuarioId) : IRequest<ReadAllUserResponse>;
}

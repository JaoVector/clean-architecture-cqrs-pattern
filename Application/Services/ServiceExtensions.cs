using FluentValidation;
using FollowMe.Application.Shared.Behavior;
using FollowMe.Application.UseCases.Pedido.Responses;
using FollowMe.Domain.Interfaces;
using MassTransit;
using MassTransit.Transports.Fabric;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Xml.Linq;

namespace FollowMe.Application.Services
{
    public static class ServiceExtensions
    {
        public static void ConfigurationApplicationApp(this IServiceCollection services) 
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }

        public static void AddBus(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddMassTransit(o => 
            {
                o.UsingRabbitMq((context, cfg) => 
                {
                    cfg.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.Message<CreatePedidoResponse>(e => e.SetEntityName("pedido-requests"));
                    cfg.Publish<CreatePedidoResponse>(e => e.ExchangeType = "direct");
                    cfg.Send<CreatePedidoResponse>();
                });
            });   
        }
    }
}

//https://wrapt.dev/blog/building-an-event-driven-dotnet-application-setting-up-masstransit-and-rabbitmq

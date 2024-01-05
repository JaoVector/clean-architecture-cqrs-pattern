using FollowMe.Domain.Interfaces;
using FollowMe.Persistence.Context;
using FollowMe.Persistence.Messaging;
using FollowMe.Persistence.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using RabbitMQ.Client;

namespace FollowMe.Persistence
{
    public static class ServiceExtensions   
    {
        public static void ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SQLConnection")));
            
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICarrinhoRepository, CarrinhoRepository>();
            services.AddScoped<IItemCarrinhoRepository, ItemCarrinhoRepository>();

            services.AddMassTransit(o =>
            {
                
                o.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(new Uri("rabbitmq://localhost"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.Message<ISendMessage>(e => e.SetEntityName("send-requests"));
                    cfg.Publish<ISendMessage>(e => e.ExchangeType = "direct");
                    cfg.Send<ISendMessage>(e =>
                    {
                        e.UseRoutingKeyFormatter(context => context.Message.routingKey.ToString());
                    });
                });
            });       
           
            //services.AddMassTransitHostedService();
        }
        /*
        public static void AddBus(this IServiceCollection services, IConfiguration configuration)
        {
            
        }
        */
    }
}
/*
 * services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SQLConnection"), 
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)), ServiceLifetime.Transient);
 */
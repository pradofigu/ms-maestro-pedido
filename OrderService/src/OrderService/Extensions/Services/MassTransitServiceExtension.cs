using OrderService.Extensions.Services.ConsumerRegistrations;

namespace OrderService.Extensions.Services;

using OrderService.Resources;
using OrderService.Services;
using SharedKernel.Messages;
using Configurations;
using MassTransit;
using OrderService.Extensions.Services.ProducerRegistrations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

public static class MassTransitServiceExtension
{
    public static void AddMassTransitServices(this IServiceCollection services, IWebHostEnvironment env, IConfiguration configuration)
    {
        var rmqOptions = configuration.GetRabbitMqOptions();

        if (!env.IsEnvironment(Consts.Testing.IntegrationTestingEnvName) 
            && !env.IsEnvironment(Consts.Testing.FunctionalTestingEnvName))
        {
            services.AddMassTransit(mt =>
            {
                mt.AddConsumers(Assembly.GetExecutingAssembly());
                mt.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(rmqOptions.Host, 
                        ushort.Parse(rmqOptions.Port), 
                        rmqOptions.VirtualHost, 
                        h =>
                        {
                            h.Username(rmqOptions.Username);
                            h.Password(rmqOptions.Password);
                        });

                    // Producers -- Do Not Delete This Comment
                    cfg.OrderRefundedEndpoint();
                    cfg.OrderCompletedEndpoint();
                    cfg.OrderPaidEndpoint();
                    cfg.OrderCanceledEndpoint();
                    cfg.OrderCreatedEndpoint();

                    // Consumers -- Do Not Delete This Comment
                    cfg.PaymentCompletedEndpoint(context);
                    cfg.PaymentRefusedEndpoint(context);
                });
            });
            services.AddOptions<MassTransitHostOptions>();
        }
    }
}

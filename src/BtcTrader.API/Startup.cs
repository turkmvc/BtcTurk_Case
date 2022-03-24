//using BtcTrader.API.Consumers;
using BtcTrader.API.Extensions;
using BtcTrader.Application;
using BtcTrader.Infrastructure;

using EventBusRabbitMQ;
using EventBusRabbitMQ.Producer;

using FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using RabbitMQ.Client;

namespace BtcTrader.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddInfrastructure(Configuration);
            services.AddApplication();
            services.AddAutoMapper(typeof(Startup));

            #region EventBus

            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();
                var hostName = Configuration["EventBus:HostName"];
                var retryCountParam = Configuration["EventBus:RetryCount"];
                var username = Configuration["EventBus:UserName"];
                var passsword = Configuration["EventBus:Password"];
                var factory = new ConnectionFactory()
                {
                    HostName = hostName,
                    UserName = username,
                    Password = passsword
                };

                var retryCount = 5;
                if (!string.IsNullOrWhiteSpace(retryCountParam))
                {
                    retryCount = int.Parse(retryCountParam);
                }

                return new DefaultRabbitMQPersistentConnection(factory, retryCount, logger);
            });

            //services.AddSingleton<EventBus_EVENTNAME_Consumer>();
            services.AddSingleton<EventBusRabbitMQProducer>();

            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BtcTrader.API", Version = "v1" });
            });

            services.AddMvc().AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<Validators.NewOrderRequestValidator>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BtcTrader.API v1"));

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseRabbitListener();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

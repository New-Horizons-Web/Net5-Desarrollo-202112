using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Net5.SignalR.Chat.BackEnd.Application;
using Net5.SignalR.Chat.BackEnd.Hubs;
using Net5.SignalR.Chat.BackEnd.Infrastructure.Data.Contexts;
using Net5.SignalR.Chat.BackEnd.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.SignalR.Chat.BackEnd
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
            services.AddDbContext<SignalRChatContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("SignalRChatConnection")));
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Net5.SignalR.Chat.BackEnd", Version = "v1" });
            });

            services.AddSignalR(options =>
            {
                options.EnableDetailedErrors = true;
            })
            .AddJsonProtocol(options => options.PayloadSerializerOptions.PropertyNamingPolicy = null);

            services.AddCors(options =>
            {
                options.AddPolicy("signalr",
                    builder => builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<IRoomUserRepository, RoomUserRepository>();
            services.AddScoped<IChatApplicationService,ChatApplicationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Net5.SignalR.Chat.BackEnd v1"));
            }

            app.UseCors("signalr");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/Chathub");
            });
        }
    }
}

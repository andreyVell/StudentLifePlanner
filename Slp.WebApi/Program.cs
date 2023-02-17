using Autofac;
using Autofac.Extensions.DependencyInjection;
using Slp.WebApi.AppCustomStart;

namespace Slp.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //register services
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new ApiDiModule()));

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCustomSqlContext(builder.Configuration);
            //auth + NOT YET
            //builder.Services.AddCustomAuth0Authentication(builder.Configuration);
            //builder.Services.AddCustomPdsCorsPolicy(builder.Configuration);
            //builder.Services.AddCustomSwagger();
            //builder.Services.AddCustomAutoMapper();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //NOT YET
            //app.UseCustomPdsCorsPolicy();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.Run();
        }
    }
}
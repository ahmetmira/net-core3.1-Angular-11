using FluentValidation.AspNetCore;
using Hospital.Application.Common.Mapping;
using Hospital.Application.Requests.PatientServices.Commands.CreatePatient;
using Hospital.DataAccess;
using Hospital.DataAccess.AbstractRepo;
using Hospital.DataAccess.ConcreteRepo;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;

namespace Hospital.API
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
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddDbContext<HospitalDbContext>(_dbContext => _dbContext.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSwaggerDocument();

            services.AddAutoMapper(AutoMapperConfig.RegisterMappings());
            // MediatR
            var assembly = AppDomain.CurrentDomain.Load("Hospital.Application");
            services.AddMediatR(assembly);
            // Unit of work
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            // FluentValidation
            services.AddControllers()
            .AddFluentValidation(fv =>
            {
                fv.ImplicitlyValidateChildProperties = true;
                fv.ImplicitlyValidateRootCollectionElements = true;

                fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());

                // Other way to register validators
                //fv.RegisterValidatorsFromAssemblyContaining<Startup>();
            });
            services.AddHttpContextAccessor();
            //ModelValidationExtension<Startup>.AddValidationConfigure(services, typeof(Application.AssemblyReference).Assembly);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}

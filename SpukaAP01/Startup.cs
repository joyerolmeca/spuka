using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SpukaAp.Extensions;
using SpukaAp.Models;
using SpukaAp.Models.DataManager;
using SpukaAp.Models.DTO;
using SpukaAp.Models.Repository;
using SpukaAP01.Models.DataManager;


namespace SpukaAp
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
            // services.AddDbContext<spukaContext>(opts =>opts.UseSqlServer(Configuration.GetConnectionString("sqlConnection")));
           //  services.AddDbContext<spukaContext>(opts =>
           //    opts.UseSqlServer(Configuration.GetConnectionString ("sqlConnection")));
            services.AddDbContext<spukaContext>(opts => opts.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=SpukaBD01;"));
            services.AddScoped<IDataRepository3<TAdressen, AdresseDTO>, AdressenDataManager>();
            services.AddScoped<IDataRepository3<TBeguenstigte, BeguenstigteDTO>, BegDataManager>();
            services.AddScoped<IDataRepository3<TZusagen, ZusageDTO>, ZusageDataManager>();
            services.AddScoped<IDataRepository3<TZusagenDetails,ZusagenDetailsDTO>, ZusagenDetailsDataManager>();
            
            services.AddScoped<IDataRepository<TAdressenTyp, AdresseTypDTO>, TAdressenTypDataManager>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                             .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); //JSON serialization
            services.ConfigureCors();
            services.AddCors();

            services.AddAutoMapper(typeof(Startup));
          //  services.AddAutoMapper(typeof(ProfileInOtherAssembly), typeof(ProfileInYetAnotherAssembly));




            /*          var config = new MapperConfiguration(cfg => {
                      cfg.CreateMap<TAdressen, AdresseDTO>();
                      cfg.CreateMap<TBeguenstigte, BeguenstigteDTO>();
                  });
                      config.AssertConfigurationIsValid();
                      var mapper = config.CreateMapper();
                      var dest = mapper.Map<TAdressen, AdresseDTO> ();
                      */

            /*    var config = new MapperConfiguration(cfg => {
                  //  cfg.AllowNullCollections = true;

                    cfg.CreateMap<TBeguenstigte, BeguenstigteDTO>();
                // cfg.CreateMap<TZusagen, ZusageDTO>();


                });*/

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
          
           // config.AssertConfigurationIsValid();

           IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseHttpsRedirection();
          //   _spukaContext.Database.EnsureCreated();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseMvc();
        }
    }
}

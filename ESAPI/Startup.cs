using Autofac;
using System.Reflection;
using ESInfrastructure.Database;
using ESApplication.Processing;
using Autofac.Core;
using ESAPI.AppStart;
using ESApplication.AutoMapper;
using MediatR;
using ESInfrastructure.DBContext;
using ESApplication.Models;
using ESApplication.EmailServices;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ESAPI.Providers;
using Microsoft.AspNetCore.Server.IISIntegration;
using ESAPI.Constants;
using System.Configuration;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Http.Features;

namespace ESAPI
{
    public class Startup
    {
        private const string connectionString = "SQLDbSettings:defaultConnectionString";
        private const string cORSPolicySettings = "CORSPolicySettings:AllowedOrigins"; 
        public static IConfiguration Configuration { get; set; }
        private readonly IWebHostEnvironment _hostingEnvironment;
        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var connectionStringValue = Configuration.GetSection(connectionString).Value;

            builder.RegisterModule(new DataAccessModule(connectionStringValue));
            builder.RegisterModule(new MediatorModule());
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { 
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            services.AddTransient<IMailService, MailService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc(config =>
            {
                config.EnableEndpointRouting = false;
            });

            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = Convert.ToInt32(Configuration.GetSection("FileSize:minsize").Value);
                x.MultipartBodyLengthLimit = Convert.ToInt64(Configuration.GetSection("FileSize:maxsize").Value); // In case of multipart
            });

            services.RegisterApplicationServices(Configuration); 

            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.WithOrigins(Configuration.GetSection(cORSPolicySettings).Value).AllowAnyMethod().AllowAnyHeader();
            })); 
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddHealthChecks();
            services.AddOptions();
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("ApiCorsPolicy");
            app.UseStaticFiles();

            //string uploadsDir = Path.Combine(_hostingEnvironment.ContentRootPath, "Resources");
            //if (!Directory.Exists(uploadsDir))
            //    Directory.CreateDirectory(uploadsDir);

            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    RequestPath = "/Images",
            //    FileProvider = new PhysicalFileProvider(uploadsDir)
            //});

            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseHttpsRedirection();  
            app.UseAuthentication();
            app.UseAuthorization(); 
            app.UseMvc();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

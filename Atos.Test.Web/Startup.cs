using Atos.Test.Application.Features.AddPerson;
using Atos.Test.Application.Features.EditPerson;
using Atos.Test.Application.Features.RemovePerson;
using Atos.Test.Application.Infrastructure;
using Atos.Test.Domain.Person;
using Atos.Test.Infrastructure;
using Atos.Test.Presentation.People;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Atos.Test.Web
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
            services.AddRazorPages();

            services.AddDbContext<TestContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("TestDatabase")));

            services.AddScoped<ICommandHandler<AddPersonCommand>, AddPersonCommandHandler>();
            services.AddScoped<ICommandHandler<EditPersonCommand>, EditPersonCommandHandler>();
            services.AddScoped<ICommandHandler<RemovePersonCommand>, RemovePersonCommandHandler>();
            services.AddScoped<IPeoplePresentationRepository, PeoplePresentationRepository>();
            services.AddScoped<IPersonFactory, PersonFactory>();
            services.AddScoped<IPersonRepository, PersonRepository>();
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PokemonApi.Models;
using PokemonApi.Services;

namespace PokemonApi {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {

            services.Configure<PokemonDatabaseSettings> (
                Configuration.GetSection (nameof (PokemonDatabaseSettings)));

            services.AddSingleton<IPokemonDatabaseSettings> (sp =>
                sp.GetRequiredService<IOptions<PokemonDatabaseSettings>> ().Value);

            services.AddScoped<IPokemonService, PokemonService> ();
            // services.AddSingleton<IPokemonService> (sp =>
            //     sp.GetRequiredService<IOptions<PokemonService>> ().Value);

            services.AddControllers ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseHttpsRedirection ();

            app.UseRouting ();

            app.UseAuthorization ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
    }
}
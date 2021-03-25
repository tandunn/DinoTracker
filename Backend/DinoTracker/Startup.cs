using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DinoTracker.Core;
using DinoTracker.Data;
using DinoTracker.Resolvers;
using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DinoTracker
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            AddHotChocolateServices(services);
            AddDatabase(services);
            services.AddTransient<IDinoRepository, DinoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseGraphQL("/graphql");

            app.UseEndpoints(endpoints =>
            {
                // By default the GraphQL server is mapped to /graphql
                // This route also provides you with our GraphQL IDE. In order to configure the
                // the GraphQL IDE use endpoints.MapGraphQL().WithToolOptions(...).
                endpoints.MapGraphQL();
            });
        }

        private void AddHotChocolateServices(IServiceCollection services)
        {
            services.AddGraphQL(sp => {
                ISchema schema = SchemaBuilder.New()
                                .AddDocumentFromString(ReadSchema())
                                .BindResolver<DinoResolver>(c => c.To<Dino>())
                                .BindResolver<Query>(c => c.To<Query>())
                                .BindResolver<Mutation>(c => c.To<Mutation>())
                                .AddServices(sp)
                                .Create();
                return schema;
            });
        }

        private void AddDatabase(IServiceCollection services)
        {
            services.AddDbContext<DinoTrackerContext>(options => options.UseSqlServer("Server=127.0.0.1;Database=DinoTracker.Dev;User Id=sa;password=yourStrong(!)Password")
                                                                        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        }

        private string ReadSchema()
        {
            string schema;
            using (var schemaStream = Assembly.
                    GetExecutingAssembly().
                    GetManifestResourceStream("DinoTracker.DinoTracker.graphql"))
                    {
                        if (schemaStream == null)
                        {
                            throw new FileNotFoundException("Unable to load schema");
                        }
                        using var reader = new StreamReader(schemaStream);
                        schema = reader.ReadToEnd();
                    }
            return schema;
        }

    }
}

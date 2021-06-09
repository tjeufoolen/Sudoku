using DP1_Sudoku.BusinessLogic;
using DP1_Sudoku.BusinessLogic.Builders;
using DP1_Sudoku.BusinessLogic.Factories;
using DP1_Sudoku.BusinessLogic.Interfaces;
using DP1_Sudoku.BusinessLogic.Strategies.PuzzleLoadingStrategies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace DP1_Sudoku
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            RegisterPuzzleFetchingStrategies(services);
            RegisterBoardBuilders();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }

        private static void RegisterPuzzleFetchingStrategies(IServiceCollection services)
        {
            services.AddSingleton<IPuzzleObjectFactory>(serviceProvider => new PuzzleObjectFactory(
                loadingStrategies: new List<IPuzzleLoadingStrategy>
                {
                    new LocalPuzzleStrategy()
                }
            ));
        }

        private static void RegisterBoardBuilders()
        {
            BoardFactory.GetInstance().AddBoardType("4x4", typeof(FourByFourBoardBuilder));
            BoardFactory.GetInstance().AddBoardType("6x6", typeof(SixBySixBoardBuilder));
            BoardFactory.GetInstance().AddBoardType("9x9", typeof(NineByNineBoardBuilder));
            BoardFactory.GetInstance().AddBoardType("samurai", typeof(SamuraiBoardBuilder));
            BoardFactory.GetInstance().AddBoardType("jigsaw", typeof(JigsawBoardBuilder));
        }
    }
}

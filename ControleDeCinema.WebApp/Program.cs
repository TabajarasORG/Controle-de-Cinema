namespace ControleDeCinema.WebApp;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            
            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute("rotas-padrao", "{controller}/{action}/{id?}");

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }


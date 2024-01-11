using DataBase.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1 {
    public class Program {
        public static void Main(string[] args) {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope()) {
                var db = scope.ServiceProvider.GetRequiredService<DataContext>();
                db.Database.Migrate();
            }
            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
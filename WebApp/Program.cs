using DataBase.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1 {
    public class Program {
        public static void Main(string[] args) {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope()) {
                var db = scope.ServiceProvider.GetRequiredService<DataContext>();
                // Check if there are any pending migrations
                if (db.Database.GetPendingMigrations().Any()) {
                    // Handle the case when there are pending migrations
                    Console.WriteLine(
                        "There are pending migrations. Please apply the migrations before running the application.");
                }
                else {
                    db.Database.Migrate();
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
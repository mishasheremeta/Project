using logic.Models;
using MauiApp1.Resources.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            string dbPath = "server=localhost;database=logic;user=root;password=1111";
            builder.Services.AddDbContext<LogicContext>(options =>
                options.UseMySQL(dbPath))
                ;

            builder.Services.AddTransient<CargosViewModel>();
            builder.Services.AddTransient<DriversViewModel>();
            builder.Services.AddTransient<TransportsViewModel>();
            builder.Services.AddTransient<CustomersViewModel>();
            builder.Services.AddTransient<AddCargoViewModel>();

            builder.Services.AddTransient<CargosPage>();
            builder.Services.AddTransient<DriversPage>();
            builder.Services.AddTransient<TransportsPage>();
            builder.Services.AddTransient<CustomersPage>();

            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddSingleton<App>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
        {
            _ = mauiAppBuilder.Services.AddDbContext<LogicContext>();

            return mauiAppBuilder;
        }
    }
}

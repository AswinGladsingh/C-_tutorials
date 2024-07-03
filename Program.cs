using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using ShoppingCartApp.Controllers;
using ShoppingCartApp.Data;

namespace ShoppingCartApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var mainForm = serviceProvider.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<IDataAccess, DataAccess>();
            services.AddTransient<UserController>();
            services.AddTransient<ProductController>();
            services.AddTransient<CartController>();
            services.AddTransient<MainForm>();
            services.AddTransient<CartView>();
            services.AddTransient<CheckoutView>();
            services.AddTransient<LoginForm>();
            services.AddTransient<SignupForm>();
        }
    }
}

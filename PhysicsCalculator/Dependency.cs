using Microsoft.Extensions.DependencyInjection;
using PhysicsCalculator.Services;
using PhysicsCalculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsCalculator
{
    public static class Dependency
    {
        private static readonly ServiceProvider _provider;

        static Dependency()
        {
            var services = new ServiceCollection();

            services.AddSingleton<MainWindowVM>();
            services.AddSingleton<VelocitieVM>();
            services.AddSingleton<RoVM>();
            services.AddSingleton<StartVM>();

            services.AddSingleton<PageService>();
          //  services.AddSingleton<Repository>();
          //  services.AddSingleton(new LiteDatabase("DataApp/test-app.db"));
          //  services.AddSingleton<EventBus>();

            _provider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => _provider.GetRequiredService<T>();
    }
}

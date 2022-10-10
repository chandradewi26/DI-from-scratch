using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryOutDI.DependencyInjection;

namespace TryOutDI
{
    internal class Program
    {
        //https://www.youtube.com/watch?v=NSVZa4JuTl8
        static void Main(string[] args)
        //static async Task Main(string[] args)
        {
            var services = new DIServiceCollection();

            //--1--
            //Singleton is only created ONCE
            //services.RegisterSingleton(new RandomGuidGenerator());
            //services.RegisterSingleton<RandomGuidGenerator>();
            //services.RegisterTransient<RandomGuidGenerator>();

            //var container = services.GenerateContainer();

            //var serviceFirst = container.GetService<RandomGuidGenerator>();    
            //var serviceSecond = container.GetService<RandomGuidGenerator>();

            //Console.WriteLine(serviceFirst.RandomGuid);
            //Console.WriteLine(serviceSecond.RandomGuid);


            //--2--
            //services.RegisterTransient<ISomeService, SomeServiceOne>();
            //services.RegisterTransient<IRandomGuidProvider, RandomGuidProvider>();


            services.RegisterSingleton<ISomeService, SomeServiceOne>();
            services.RegisterTransient<IRandomGuidProvider, RandomGuidProvider>();
            //services.RegisterSingleton<MainApp>();

            var container = services.GenerateContainer();

            var serviceFirst = container.GetService<ISomeService>();
            var serviceSecond = container.GetService<ISomeService>();
            //var mainApp = container.GetService<MainApp>();

            serviceFirst.PrintSomething();
            serviceSecond.PrintSomething();

            //??
            //await mainApp.StartAsync();

            Console.WriteLine();
        }
    }
}

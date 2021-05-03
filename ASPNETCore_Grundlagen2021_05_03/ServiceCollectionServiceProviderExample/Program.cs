using DependencyInjectionIntroSample.GoodSample;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ServiceCollectionServiceProviderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<ICar, MockCar>(); //Var 1
            //serviceCollection.AddSingleton(typeof(ICar), typeof(MockCar)); //Var 2

            ServiceProvider provider = serviceCollection.BuildServiceProvider(); //

            ICar mockCar = provider.GetRequiredService<ICar>();

            Console.WriteLine("Hello World!");
        }
    }
}

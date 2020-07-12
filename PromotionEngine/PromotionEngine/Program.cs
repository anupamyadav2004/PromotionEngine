using System;
using Microsoft.Extensions.DependencyInjection;
using PromotionEngine.Services;

namespace PromotionEngine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = PromotionEngineModule.InitializeServiceProvider();
            var controller = serviceProvider.GetRequiredService<IPromotionEngineController>();

            string inputString;
            if (args.Length > 0)
            {
                inputString = string.Join(" ", args);
            }
            else
            {
                Console.WriteLine("Please add products followed by space, Eg. A A A B C D");
                inputString = Console.ReadLine();
            }

            if (inputString == null) return;
            var productArgs = inputString.Split(null);
            controller.Run(productArgs);

            if (args.Length > 0) return;
            Console.ReadLine();
        }
    }
}

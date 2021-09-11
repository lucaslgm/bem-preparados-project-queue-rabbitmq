using System;
using System.Threading.Tasks;
using MassTransit;
using Services;

namespace Application
{
  class Program
  {
    public static async Task Main()
    {
      var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
      {
        cfg.ReceiveEndpoint("fila-propostas", e =>
              {
                e.Consumer<QueueConsumer>();
              });
      });

      await busControl.StartAsync();
      try
      {
        Console.WriteLine("Press enter to exit");

        await Task.Run(() => Console.ReadLine());
      }
      finally
      {
        await busControl.StopAsync();
      }
    }
  }
}

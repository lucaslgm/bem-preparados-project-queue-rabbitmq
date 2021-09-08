using System.Threading.Tasks;
using MassTransit;
using Service.Dtos;

namespace Services
{
  public class QueueConsumer : IConsumer<D_PropostaFila>
  {
    public Task Consume(ConsumeContext<D_PropostaFila> context)
    {
      AtualizaSituacao.AtualizarSituacao(context.Message);
      return Task.CompletedTask;
    }
  }
}

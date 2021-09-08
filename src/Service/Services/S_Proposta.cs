using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Repositories;

namespace Services
{
  public static class S_Proposta
  {
    public static async Task<E_Proposta> GetByProposta(decimal proposta)
    {
      var entidade = await R_Proposta.GetByProposta(proposta);

      return entidade;
    }
    public static async Task<int> Update(E_Proposta entidade)
    {
      var ret = await R_Proposta.Update(entidade);
      return ret;
    }
  }
}

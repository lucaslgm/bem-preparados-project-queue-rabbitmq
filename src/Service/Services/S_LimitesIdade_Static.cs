using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Repositories;

namespace Services
{
  public static class S_LimitesIdade
  {
    public static async Task<List<E_LimitesIdade>> BuscarPorConveniada(string conveniada)
    {
      var lista = await R_LimitesIdade.BuscaPorConveniada(conveniada);
      return lista;

    }
  }
}

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories
{
  public static class R_LimitesIdade
  {
    static string connectionstrg = "Server=localhost,1433;Database=master;User Id=sa;Password=;";
    public static async Task<List<E_LimitesIdade>> BuscaPorConveniada(string conveniada)
    {
      string sqlQuery = "SELECT IDADE_INICIAL, IDADE_FINAL, VALOR_LIMITE, PERCENTUAL_MAXIMO_ANALISE FROM [dbo].[TREINA_LIMITES_IDADE_CONVENIADA] WHERE conveniada = @conveniada";

      DynamicParameters parameters = new DynamicParameters();
      parameters.Add("@conveniada", conveniada);

      IEnumerable<E_LimitesIdade> ret;

      using (var connection = new SqlConnection(connectionstrg))
      {
        ret = await connection.QueryAsync<E_LimitesIdade>(sqlQuery, parameters);
      }
      return ret.AsList<E_LimitesIdade>();
    }
  }
}

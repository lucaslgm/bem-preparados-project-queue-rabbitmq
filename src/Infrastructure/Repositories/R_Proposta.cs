using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories
{
  public static class R_Proposta
  {
    static string connectionString = "Server=localhost,1433;Database=master;User Id=sa;Password=;";
    public static async Task<E_Proposta> GetByProposta(decimal proposta)
    {
      string sqlQuery = "SELECT * FROM [dbo].[TREINA_PROPOSTAS] WHERE proposta= @proposta";

      E_Proposta retorno;

      DynamicParameters parameter = new DynamicParameters();
      parameter.Add("@proposta", proposta);

      // using (var connection = new SqlConnection(base.GetConnection()))
      using (var connection = new SqlConnection(connectionString))
      {
        retorno = await connection.QuerySingleOrDefaultAsync<E_Proposta>(sqlQuery, parameter);
      }
      return retorno;
    }
    public static async Task<int> Update(E_Proposta obj)
    {
      string sqlQuery = "UPDATE [dbo].[TREINA_PROPOSTAS] SET SITUACAO = @situacao, DT_SITUACAO = @dt_situacao, " +
      "DATA_ATUALIZACAO = @data_atualizacao WHERE PROPOSTA = @proposta;";

      DynamicParameters parameter = new DynamicParameters();
      parameter.Add("@proposta", obj.Proposta);
      parameter.Add("@situacao", obj.Situacao);
      parameter.Add("@dt_situacao", DateTime.Today);
      parameter.Add("@data_atualizacao", DateTime.UtcNow);

      int retorno;
      using (var connection = new SqlConnection(connectionString))
      {
        retorno = await connection.ExecuteAsync(sqlQuery, parameter);
      }
      return retorno;
    }
  }
}

using System;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Entities;
using Service.Dtos;

namespace Services
{
  public static class AtualizaSituacao
  {

    public static async void AtualizarSituacao(D_PropostaFila propostaFila)
    {
      try
      {

        var proposta = await getProposta(propostaFila.Proposta);
        var limites = await getLimites(propostaFila);

        if (limites == null)
        {
          proposta.Situacao = "RE";
        }
        else if (propostaFila.Vlr_solicitado <= limites.limite)
        {
          proposta.Situacao = "AP";
        }
        else if (propostaFila.Vlr_solicitado <= limites.limiteExtra)
        {
          proposta.Situacao = "AN";
          proposta.Observacao = "PROPOSTA ACIMA DO VALOR LIMITE";
        }
        else
        {
          proposta.Situacao = "PE";
        }

        var update = await updateProposta(proposta);

        if (update == 1)
        {
          System.Console.WriteLine($"atualizou a situação da proposta {propostaFila.Proposta} / Situação: {proposta.Situacao}");
        }
      }
      catch (Exception e)
      {
        System.Console.WriteLine($"Erro ao processar a proposta: {e}");
      }
    }

    public static async Task<D_Limites> getLimites(D_PropostaFila propostaFila)
    {
      var lista = await S_LimitesIdade.BuscarPorConveniada(propostaFila.Conveniada);
      var idadeCliente = DateTime.Today.AddMonths(propostaFila.Prazo).Year - propostaFila.Dt_nascimento.Year;
      decimal percentual = 0;

      D_Limites limites = null;

      lista.ForEach(limite =>
      {
        if (idadeCliente >= limite.Idade_inicial && idadeCliente <= limite.Idade_final)
        {
          limites = new D_Limites();
          limites.limite = limite.Valor_limite;
          percentual = 1 + Convert.ToDecimal(limite.Percentual_maximo_analise) / 100;
          limites.limiteExtra = limite.Valor_limite * percentual;
        }
      });
      return limites;
    }

    public static async Task<E_Proposta> getProposta(string proposta)
    {
      E_Proposta prop = await S_Proposta.GetByProposta(Convert.ToDecimal(proposta));
      return prop;
    }
    public static async Task<int> updateProposta(E_Proposta proposta)
    {
      int ret = await S_Proposta.Update(proposta);
      return ret;
    }
  }
}

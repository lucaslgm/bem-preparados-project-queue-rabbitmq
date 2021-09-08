using System;

namespace Domain.Entities
{
  public class E_Proposta
  {
    public int Id_treina_proposta { get; set; }
    public decimal Proposta { get; set; }
    public string Conveniada { get; set; }
    public string Cpf { get; set; }
    public decimal Vlr_solicitado { get; set; }
    public short Prazo { get; set; }
    public decimal Vlr_financiado { get; set; }
    public string Situacao { get; set; }
    public string Observacao { get; set; }
    public DateTime Dt_situacao { get; set; }
    public string Usuario { get; set; }
    public DateTime Data_atualizacao { get; set; }
    public string Usuario_atualizacao { get; set; }
  }
}

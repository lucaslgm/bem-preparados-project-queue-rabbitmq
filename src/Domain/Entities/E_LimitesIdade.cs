namespace Domain.Entities
{
  public class E_LimitesIdade
  {
    public int Id_treina_lim_idade_conveniada { get; set; }
    public string Conveniada { get; set; }
    public short Idade_inicial { get; set; }
    public short Idade_final { get; set; }
    public short Percentual_maximo_analise { get; set; }
    public decimal Valor_limite { get; set; }
  }
}

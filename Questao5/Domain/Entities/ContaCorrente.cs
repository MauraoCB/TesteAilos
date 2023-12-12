using Microsoft.AspNetCore.Components.Web;
using Questao5.Infrastructure.Services.Controllers;

namespace Questao5.Domain.Entities
{
    public class ContaCorrente
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int Ativo { get; set; }
        public decimal Saldo { get; set; }
        public  DateTime DataHoraConsulta { get; set; }
      //  public List<Movimento> Movimentos { get; set; }
    }
}

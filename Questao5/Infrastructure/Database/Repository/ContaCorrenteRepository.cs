using Questao5.Domain.Entities;
using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Sqlite;
using System.Linq;

namespace Questao5.Infrastructure.Database.Repository
{
    public class ContaCorrenteRepository
    {
        private readonly DatabaseConfig databaseConfig;

        public ContaCorrente GetSaldo(int id)
        {
            ContaCorrente contaCorrente = new ContaCorrente();

            using var connection = new SqliteConnection(databaseConfig.Name);

            var conta = connection.Query<ContaCorrente>("SELECT idcontacorrente Id, Numero, Nome, Ativo FROM contacorrente WHERE idcontacorrente = @id;", id).FirstOrDefault();

            if (conta == null)
            {
                throw new Exception("INVALID_ACCOUNT");
            }

            if (conta.Ativo == 0)
            {
                throw new Exception("INACTIVE_ACCOUNT");
            }

            //Calculate amount
            MovimentoRepository movimentoRepository = new MovimentoRepository(databaseConfig);

            var contaMovimentos = movimentoRepository.ListMovimentos(id);

            decimal creditos = contaMovimentos.Where(m => m.TipoMovimento == "C").Sum(m => m.Valor);
            decimal debitos = contaMovimentos.Where(m => m.TipoMovimento == "D").Sum(m => m.Valor);

            contaCorrente.DataHoraConsulta = DateTime.Now;
            contaCorrente.Saldo = creditos - debitos;

            return contaCorrente;
        }

        public string GetContaCorrenteValida(int id)
        {
            ContaCorrente contaCorrente = new ContaCorrente();

            using var connection = new SqliteConnection(databaseConfig.Name);

            var conta = connection.Query<ContaCorrente>("SELECT idcontacorrente Id, Numero, Nome, Ativo FROM contacorrente WHERE idcontacorrente = @id;", id).FirstOrDefault();

            if (conta == null)
            {
                return "INVALID_ACCOUNT";
            }

            if (conta.Ativo == 0)
            {
               return "INACTIVE_ACCOUNT";
            }

            return "Ativo";
        }
    }
}

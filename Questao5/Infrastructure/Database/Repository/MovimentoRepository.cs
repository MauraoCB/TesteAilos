using Dapper;
using MediatR;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Sqlite;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace Questao5.Infrastructure.Database.Repository
{
    public class MovimentoRepository
    {
        private readonly DatabaseConfig _databaseConfig;
        private readonly SqliteConnection _connection;
        public MovimentoRepository(DatabaseConfig databaseConfig)
        {
            this._databaseConfig = databaseConfig;
            this._connection = new SqliteConnection(databaseConfig.Name);
        }

        public List<Movimento> ListMovimentos(int idContaCorrente)
        {
            return _connection.Query<Movimento>("SELECT IdMovimento, IdContaCorrente, DataMovimento, TipoMovimento, Valor FROM movimento WHERE C.id = @id;", idContaCorrente).ToList();
        }

        public void Save(Movimento movimento)
        {
            DatabaseConfig databaseConfig = new DatabaseConfig();

            SqliteConnection connection = new SqliteConnection(databaseConfig.Name);

            string sqlInsert = @"INSERT INTO movimento (IdMovimento, IdContaCorrente, DataMovimento, TipoMovimento, Valor) VALUES(@IdMovimento, @IdContaCorrente, @DataMovimento, @TipoMovimento, @Valor)";
            _connection.Execute(sqlInsert, movimento);
        }
    }
}

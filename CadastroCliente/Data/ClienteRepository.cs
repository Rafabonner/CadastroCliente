using CadastroCliente.Domain;
using CadastroCliente.Interfaces;
using Dapper;
using System.Data.SqlClient;

namespace CadastroCliente.Data
{
    public class ClienteRepository : IClienteRepository
    {
        private const string connectionString = "Server=localhost,1433;Database=Cliente;User ID=sa;Password=1234;Trusted_Connection=False; TrustServerCertificate=True;";
        public async Task<bool> CreateAsycn(Cliente cliente)
        {
            await using (var connection = new SqlConnection(connectionString))
            {
                var result = await connection.ExecuteAsync("INSERT INTO Clientes VALUES(@Nome,@CPF,@Endereco,@EstadoCivil,@Genero)",
                    new { Nome = cliente.Nome, CPF = cliente.CPF, Endereco = cliente.Endereco, EstadoCivil = cliente.EstadoCivil, Genero = cliente.Genero }).ConfigureAwait(false);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await using (var connection = new SqlConnection(connectionString))
            {
                var result = await connection.ExecuteAsync("DELETE FROM Clientes WHERE ID = @id",
                    new { Id = id }).ConfigureAwait(false);
                return result > 0;
            }
        }

            public async Task<IList<Cliente>> GetAllAsync()
        {
            await using (var connection = new SqlConnection(connectionString))
            {
                return (await connection.QueryAsync<Cliente>("SELECT ID,NOME,CPF,ENDERECO,ESTADOCIVIL,GENERO FROM Clientes").ConfigureAwait(false)).AsList();
            }
        }

        public async Task<Cliente> GetAsync(int id)
        {
            await using (var connection = new SqlConnection(connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Cliente>("SELECT ID,NOME,CPF,ENDERECO,ESTADOCIVIL,GENERO FROM Clientes WHERE ID = @id", new { Id = id }).ConfigureAwait(false);
            }
        }

        public async Task<bool> UpdateAsync(Cliente cliente)
        {
            await using (var connection = new SqlConnection(connectionString))
            {
                var result = await connection.ExecuteAsync("UPDATE Clientes SET NOME = @Nome, CPF = @CPF , ENDERECO = @Endereco, ESTADOCIVIL = @EstadoCivil, GENERO = @Genero WHERE ID = @id ",
                    new { Id = cliente.Id, Nome = cliente.Nome, CPF = cliente.CPF, Endereco = cliente.Endereco, EstadoCivil = cliente.EstadoCivil, Genero = cliente.Genero }).ConfigureAwait(false);
                return result > 0;
            }
        }
    }
}

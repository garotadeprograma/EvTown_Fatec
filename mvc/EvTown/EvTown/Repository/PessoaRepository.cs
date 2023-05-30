using EvTown.Models;
using Npgsql;
using System.Data;

namespace EvTown.Repository
{
    public class PessoaRepository
    {
        private readonly static string _connectionString = "Server=localhost;Port=5432;Database=Cadastro;User Id=postgres;Password=admin";

        public bool Add(Pessoa pessoa)
        {            
            var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "insert into PESSOA (nome, CPF, telefone) values(@nome, @CPF, @celular)";
            command.Parameters.AddWithValue("@nome", pessoa.Nome);
            command.Parameters.AddWithValue("@CPF", pessoa.CPF);
            command.Parameters.AddWithValue("@celular", pessoa.Celular);

            var affectedRowsNr = command.ExecuteNonQuery();
            if (affectedRowsNr > 0)
            {
                return true;
            }

            return false;
        }

        public Pessoa Get(int id)
        {
            var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM PESSOA WHERE email = @email";
            command.Parameters.AddWithValue("@id", id);
            
            NpgsqlDataReader reader = command.ExecuteReader();

            return null;

        }

        public Pessoa Get(string cpf)
        {
            var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM PESSOA";
            command.Parameters.AddWithValue("@cpf", cpf);

            NpgsqlDataReader reader = command.ExecuteReader();


            if (reader.HasRows)
            {
                while (reader.Read()) {
                    reader.GetValue(0);
                Pessoa pessoa = new Pessoa()
                {
                    Id = (int)reader["Id"],
                    Nome = (string)reader["Nome"],
                    CPF = (string)reader["CPF"],
                    Celular = (string)reader["Celular"]
                };
                }

                return null;
            }
            return null;

        }
    }
}

using EvTown.Models;
using Npgsql;
using System.Data;

namespace EvTown.Repository
{
    public class UsuarioRepository
    {
        private readonly static string _connectionString = "Server=localhost;Port=5432;Database=Cadastro;User Id=postgres;Password=admin";

        public bool ValidarUsuario(Usuario usuario)
        {
            if(usuario.email == null || usuario.senha == null) 
                return false;

            var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM USUARIO WHERE email = @email and senha = @senha";
            command.Parameters.AddWithValue("@email", usuario.email);
            command.Parameters.AddWithValue("@senha", usuario.senha);

            NpgsqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)            
                return false;            

            return true;
        }

        public void ResgistrarLogin(Usuario usuario)
        {

        }
    }
}

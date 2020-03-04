using _20GRPED.MVC.A10.MvcAdoNet.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace _20GRPED.MVC.A10.MvcAdoNet.Repositories
{
    public class PessoaMdfRepository : IPessoaRepository
    {
        private string _connectionString
            = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\felipe.andrade\source\repos\20GRPED.MVC.A10.MvcAdoNet\20GRPED.MVC.A10.MvcAdoNet\App_data\MvcAdoNet.mdf;Integrated Security=True;Connect Timeout=30";

        public IEnumerable<PessoaModel> GetAll()
        {
            var cmdText = $"SELECT Id, Nome, Nascimento FROM Pessoa";

            var pessoas = new List<PessoaModel>();

            using (var sqlConnection = new SqlConnection(_connectionString)) //já faz o close e dispose
            using (var sqlCommand = new SqlCommand(cmdText, sqlConnection)) //já faz o close
            {
                sqlCommand.CommandType = CommandType.Text;

                sqlConnection.Open();

                using (var reader = sqlCommand.ExecuteReader())
                {
                    var idColumnIndex = reader.GetOrdinal("ID");
                    var nomeColumnIndex = reader.GetOrdinal("Nome");
                    var nascimentoColumnIndex = reader.GetOrdinal("Nascimento");
                    while (reader.Read())
                    {
                        var id = reader.GetFieldValue<int>(idColumnIndex);
                        var nome = reader.GetFieldValue<string>(nomeColumnIndex);
                        var nascimento = reader.GetFieldValue<DateTime>(nascimentoColumnIndex);

                        var novaPessoa = new PessoaModel
                        {
                            Id = id,
                            Nome = nome,
                            Nascimento = nascimento
                        };
                        pessoas.Add(novaPessoa);
                    }
                }
            }

            return pessoas;
        }

        public void Add(PessoaModel newPessoaModel)
        {
            var cmdText = "INSERT INTO Pessoa" +
                "		(Nome, Nascimento)" +
                "VALUES	(@pessoaNome, @pessoaNascimento);";

            using (var sqlConnection = new SqlConnection(_connectionString)) //já faz o close e dispose
            using (var sqlCommand = new SqlCommand(cmdText, sqlConnection)) //já faz o close
            {
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters
                    .Add("@pessoaNome", SqlDbType.VarChar).Value = newPessoaModel.Nome;
                sqlCommand.Parameters
                    .Add("@pessoaNascimento", SqlDbType.Date).Value = newPessoaModel.Nascimento.Date;

                sqlConnection.Open();

                var resutScalar = sqlCommand.ExecuteScalar();
            }
        }
    }
}

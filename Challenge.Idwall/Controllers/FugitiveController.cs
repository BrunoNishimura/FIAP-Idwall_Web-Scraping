using Challenge.Idwall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;

namespace Challenge.Idwall.Controllers
{
    public class FugitiveController : Controller
    {
        private readonly string _connectionString;

        public FugitiveController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string nome)
        {
            var fugitive = GetFugitiveByNome(nome);
            if (fugitive != null)
            {
                ViewBag.Message = "Nome encontrado no banco de fugitivos";
            }
            else
            {
                ViewBag.Message = "Nome não encontrado";
            }

            return View("Index");
        }

        private Fugitive GetFugitiveByNome(string nome)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                var command = new OracleCommand("SELECT * FROM Fugitives WHERE Nome = :nome", connection);
                command.Parameters.Add(":nome", OracleDbType.Varchar2).Value = nome;

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Fugitive
                    {
                        Id = (int)reader["Id"],
                        Nome = (string)reader["Nome"]
                    };
                }

                return null;
            }
        }
    }
}

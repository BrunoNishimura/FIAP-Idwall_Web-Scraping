using Challenge.Idwall.Web.AspNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Idwall.Web.AspNet.Controllers
{
    public class FugitiveController : Controller
    {
        private IList<FugitiveModel> fugitives;

        public FugitiveController()
        {
            fugitives = new List<FugitiveModel>();
            fugitives.Add(new FugitiveModel(1, "Bruno Yuji Nishimura", "15/02/1995", "Masculino", "Ref"));
        }
        public IActionResult Index()
        {
            return View(fugitives);
        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View(new FugitiveModel());
        }

        [HttpPost]
        public IActionResult Cadastrar(FugitiveModel fugitive)
        {
            Console.WriteLine("Inserindo Fugitivos");
            return RedirectToAction("Index", "Fugitive");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            // Imprime a mensagem de execução
            Console.WriteLine("Consultando pelo Id = " + id);

            // Cria o modelo que SIMULA a consulta no banco de dados
            Models.FugitiveModel Representante = new Models.FugitiveModel(id, "Bruno", "15/02", "Masculino", "ref");


            // Retorna para a View o objeto modelo 
            // com as propriedades preenchidas com dados do banco de dados 
            return View(Representante);
        }

        [HttpPost]
        public IActionResult Editar(FugitiveModel fugitive)
        {
            // Imprime os valores do modelo
            Console.WriteLine("Nome: " + fugitive.FullName);
            Console.WriteLine("Nascimento: " + fugitive.BirthDay);
            Console.WriteLine("Gênero: " + fugitive.Gender);
            // Simila que os dados foram gravados.
            Console.WriteLine("Gravando o Tipo Editado");

            // Substituímos o return View()
            // pelo método de redirecionamento
            return RedirectToAction("Index", "Representante");
        }

        [HttpGet]
        public IActionResult Consultar(int id)
        {
            // Imprime a mensagem de execução
            Console.WriteLine("Consultando pelo Id = " + id);

            // Cria o modelo que SIMULA a consulta no banco de dados
            Models.FugitiveModel Fugitive = new Models.FugitiveModel(id, "Bruno", "15/02", "Masculino", "ref");


            // Retorna para a View o objeto modelo 
            // com as propriedades preenchidas com dados do banco de dados 
            return View(Fugitive);
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            // Imprime a mensagem de execução
            Console.WriteLine("Excluir o Representante Id = " + id);

            // Substituímos o return View()
            // pelo método de redirecionamento
            return RedirectToAction("Index", "Representante");
        }

    }
}

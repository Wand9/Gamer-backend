using gamer_beck.Models;
using Microsoft.AspNetCore.Mvc;
using gamer_beck.Infra;

namespace gamer_beck.Controllers
{
    [Route("[controller]")]
    public class EquipeController : Controller
    {
        private readonly ILogger<EquipeController> _logger;

        public EquipeController(ILogger<EquipeController> logger)
        {
            _logger = logger;
        }

        //instancia do objeto para acessar o banco de dados
        Context c = new Context();

        [Route("Listar")] //http://localhost/Equipe/Listar
        public IActionResult Index()
        {
            //variavel que armazena as equipes listadas do banco de dados
            ViewBag.Equipe = c.Equipe.ToList();
            
            //retorna a view de equipe (TELA)
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
            //return View("Error!");
        //}

        [Route("Cadastrar")]//http://localhost/Equipe/Cadastrar
        public IActionResult Cadastrar(IFormCollection form)
        {
            //instancia do objeto equipe 
            Equipe novaEquipe = new Equipe();

            //atribuicao dos valores recebidos do formulario
            novaEquipe.Nome = form["Nome"].ToString();
            //novaEquipe.Imagem = form["Imagem"].ToString();

             //início da lógica do upload da imagem
            if (form.Files.Count > 0)
            {
                
                var file = form.Files[0];

                var folder = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/img/Equipes");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                //gera o caminho completo até o caminho do arquivo(imagem - nome com extensão)
                var path = Path.Combine(folder, file.FileName);

                //using para que a instrução dentro dele seja encerrado assim que for executada
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                novaEquipe.Imagem = file.FileName;
            }
            else
            {
                novaEquipe.Imagem = "padrao.png";
            }
            //fim da lógica de upload

            //Adiciona objeto na tabela BD
            c.Equipe.Add(novaEquipe);

            //salva alteracoes no BD
            c.SaveChanges();

            //atualixa a lista testar...........
            ViewBag.Equipe = c.Equipe.ToList();

            return LocalRedirect("~/Equipe/Listar");
        }

        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            Equipe equipeBuscada = c.Equipe.FirstOrDefault(e => e.IdEquipe == id);

            c.Remove(equipeBuscada);

            c.SaveChanges();

            return LocalRedirect("~/Equipe/Listar");
        }

        [Route("Editar/{id}")]
        public IActionResult Editar(int id)
        {
            Equipe equipe = c.Equipe.First(x => x.IdEquipe == id);

            ViewBag.Equipe = equipe;

            return View("Edit");
        }

        [Route("Atualizar")]
        public IActionResult Atualizar(IFormCollection form)
        {
            Equipe equipe = new Equipe();

            equipe.IdEquipe = int.Parse(form["IdEquipe"].ToString());

            equipe.Nome = form["Nome"].ToString();

            if (form.Files.Count > 0)
            {
                var file = form.Files[0];

                var folder = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/img/Equipes");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                equipe.Imagem = file.FileName;
                }

                else
                {
                    equipe.Imagem = "padrao.png";
                }

                Equipe equipeBuscada = c.Equipe.First(x => x.IdEquipe == equipe.IdEquipe);
                equipeBuscada.Nome = equipe.Nome;
                equipeBuscada.Imagem = equipe.Imagem;
                c.Equipe.Update(equipeBuscada);
                c.SaveChanges();
                return LocalRedirect("~/Equipe/Listar");
            }
        }











    }
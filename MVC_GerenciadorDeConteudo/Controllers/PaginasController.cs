using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

using Business;
using NVelocity;
using NVelocity.App;

namespace MVC_GerenciadorDeConteudo.Controllers
{
    public class PaginasController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Paginas = new Pagina().Lista();

            return View();
        }
        public ActionResult Novo()
        {


            return View();
        }
        //Insert DADOS NO BANCO
        [HttpPost]
        public void Criar()
        {
            DateTime data;
            DateTime.TryParse(Request["data"], out data);
            var pagina = new Pagina();
            pagina.Nome = Request["nome"];
            pagina.Data = data;
            pagina.Conteudo = Request["conteudo"];
            pagina.Save();
            Response.Redirect("/paginas");
        }
        public void Excluir(int id)
        {
            Pagina.Excluir(id);
            Response.Redirect("/paginas");
        }

        public ActionResult Editar(int id)
        {
            var pagina = Pagina.BuscaPorId(id);
            ViewBag.Pagina = pagina;
            return View();
        }

        //Renderizar em nova aba
        public ActionResult Preview(int id)
        {
            var pagina = Pagina.BuscaPorId(id);
            ViewBag.Pagina = pagina;
            return View();
        }

        public ActionResult PreviewDinamico(int id)
        {
            var pagina = Pagina.BuscaPorId(id);
            Velocity.Init();

            var modelo = new
            {
                Header = "Lista de dados dinamicos",
                Itens = new[]
                {
                    new {ID = 1, Nome = "Texto 001", Negrito = false},
                    new {ID = 1, Nome = "Texto 002", Negrito = true},
                    new {ID = 1, Nome = "Texto 0013", Negrito = false},

                }
            };
            var velocityContext = new VelocityContext();
            velocityContext.Put("model", modelo);

            var html = new StringBuilder();
            bool result = Velocity.Evaluate(velocityContext, new StringWriter(html), "NomeParaCapturarLogError", new StringReader(pagina.Conteudo));

            ViewBag.Html = html.ToString();
            return View();

        }

        //Edição de Arquivos ja criados
        [HttpPost]
        [ValidateInput(false)]
        public void Alterar(int id)
        {
            try
            {
                var pagina = Pagina.BuscaPorId(id);

                DateTime data;
                DateTime.TryParse(Request["data"], out data);

                pagina.Nome = Request["nome"];
                pagina.Data = data;
                pagina.Conteudo = Request["conteudo"];
                pagina.Save();

                TempData["Sucesso"] = "Pagina alterada com sucesso!!";
            }
            catch(Exception err)
            {
                TempData["Erro"] = "Pagina não pode ser alterada!!(" +err.Message+")";
            }
            Response.Redirect("/paginas");
        }
        
    }



    
 }
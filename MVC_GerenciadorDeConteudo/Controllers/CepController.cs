using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

using Business;

namespace MVC_GerenciadorDeConteudo.Controllers
{
    public class CepController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Cep = Business.Cep.Busca("09973000");
            return View();
        }
        public string Consulta(string cep)
        {
            var cepObj = Business.Cep.Busca(cep);
            return new JavaScriptSerializer().Serialize(cepObj);
        }



    }
}


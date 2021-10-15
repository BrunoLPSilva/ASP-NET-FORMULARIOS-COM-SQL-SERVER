using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_GerenciadorDeConteudo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                "sobre",
                "sobre",
                new { Controller = "Paginas", Action = "about" }
                );

            routes.MapRoute(
                "paginas",
                "paginas",
                new { Controller = "Paginas", Action = "Index" }
                );

            // FORMULARIO CRIADO COM ESTA ROTA NO Novo.cshtml
            routes.MapRoute(
                "paginas_criar",
                "paginas/criar",
                new { Controller = "Paginas", Action = "Criar" }
                );

            //NOVO FORMULARIO( VIEW = Novo.cshtml)
            routes.MapRoute(
               "paginas_novo",
               "paginas/novo",
               new { Controller = "Paginas", Action = "Novo" }
               );

            //EDITAR DADOS PAGINA
            routes.MapRoute(
            "paginas_editar",
             "paginas/{id}/editar",
             new { Controller = "Paginas", Action = "Editar", id = 0}
             );

            //ROTA ALTERAR
            //ESPECIE DE VALIDAÇÃO APÓS CLICAR EM ALTERAR
            //CONFIRMAÇÃO VIA BOTÃO "ALTERAR" OS DADOS EDITADOS
            routes.MapRoute(
           "paginas_alterar",
           "paginas/{id}/alterar",
           new { Controller = "Paginas", Action = "Alterar", id = 0 }
           );

            //ROTA PARA EXCLUSÃO DE DADO
            routes.MapRoute(
           "paginas_excluir",
           "paginas/{id}/excluir",
           new { Controller = "Paginas", Action = "Excluir", id = 0 }
           );

            routes.MapRoute(
           "consulta_cep",
           "consulta-cep",
          new { Controller = "Cep", Action = "Index" }
           );

            //ROTA CONTROLER CHAMADA CEP
            routes.MapRoute(
           "api_consulta_cep",
           "api/consulta-cep/{cep}",
          new { Controller = "Cep", Action = "Consulta", cep = "" }
           );

            //ROTA PARA O PREVIEW
            routes.MapRoute(
           "paginas_preview",
           "paginas/{id}/preview",
           new { Controller = "Paginas", Action = "Preview", id = 0 }
           );

            //ROTA PARA O PREVIEW DINAMICO
            routes.MapRoute(
           "paginas_preview_dinamico",
           "paginas/{id}/preview-dinamico",
           new { Controller = "Paginas", Action = "PreviewDinamico", id = 0 }
           );

            //ROTA PARA O PREVIEW DINAMICO
            routes.MapRoute(
           "paginas_preview_dinamico_notema",
           "paginas/{id}/preview-dinamico-notema",
           new { Controller = "Paginas", Action = "PreviewDinamicoNoTema", id = 0 }
           );

            routes.MapRoute(
             "contato",
             "contato",
             new { Controller = "Home", Action = "contact" }
             );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });

        }
    }
}

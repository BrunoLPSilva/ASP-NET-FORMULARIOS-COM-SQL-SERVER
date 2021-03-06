using System;
using System.Collections.Generic;
using System.Data;
using System.Collections.ObjectModel;
using System.Globalization;


namespace Business
{
     public class Pagina
     {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Conteudo { get; set; }
        public DateTime Data { get; set; }

        public List<Pagina> Lista()
        {
            var lista = new List<Pagina>();
            var paginaDb = new Database.Pagina();


            foreach (DataRow row in paginaDb.Lista().Rows)
            {
                var pagina = new Pagina();
                pagina.Id = Convert.ToInt32(row["id"]);
                pagina.Nome = row["nome"].ToString();
                pagina.Conteudo = row["Conteudo"].ToString();
                pagina.Data = Convert.ToDateTime(row["data"]);

                lista.Add(pagina);


            }

            return lista;
            
        }

        //ALTERAR DADOS JA CRIADOS NO BANCO SQL SERVER OU SEJA ITENS NA PAGINA.
        //METODO ACESSAR DATABASE E RETORNAR OBJETO CRIADO
        //RETORNO DE PAGINA 

        public static Pagina BuscaPorId(int id)
        {
            //var pagina = new Pagina();
            //var paginaDb = new Database.Pagina();

            //foreach (DataRow row in paginaDb.BuscaPorId(id).Rows)
            //{
            //    pagina.Id = Convert.ToInt32(row["id"]);
            //    pagina.Nome = row["nome"].ToString();
            //    pagina.Conteudo = row["Conteudo"].ToString();
            //    pagina.Data = Convert.ToDateTime(row["data"]);
            //}

            //return pagina;

            var pagina = new Pagina();
            var paginaDb = new Database.Pagina();


            foreach (DataRow row in paginaDb.BuscaPorId(id).Rows)
            {
                
                pagina.Id = Convert.ToInt32(row["id"]);
                pagina.Nome = row["nome"].ToString();
                pagina.Conteudo = row["Conteudo"].ToString();
                pagina.Data = Convert.ToDateTime(row["data"]);

                


            }

            return pagina;

        }

        //METODO GRAVAR DADOS NO BANCO
        //SALVAR INFORMAÇÕES
        public void Save()
        {
            new Database.Pagina().Salvar(this.Id, this.Nome, this.Conteudo, this.Data);
        }

        public static void Excluir(int id)
        {
            new Database.Pagina().Excluir(id);
        }
    }

}

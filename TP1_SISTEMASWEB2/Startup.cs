using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TP1_SISTEMASWEB2.DataBase.Repository;
using TP1_SISTEMASWEB2.DTO;
using TP1_SISTEMASWEB2.Entidades;

namespace TP1_SISTEMASWEB2
{
    class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            builder.MapRoute("Livro/NomeDoLivro/{id:int}", NomeDoLivro);
            builder.MapRoute("Livro/DetalhesLivro/{id:int}", DetalhesLivro);
            builder.MapRoute("Livro/AutoresLivro/{id:int}", AutoresLivro);
            builder.MapRoute("Rota/Livro/ApresentarLivro/{id:int}", ApresentarLivro);
            var rotas = builder.Build();
            app.UseRouter(rotas);
        }
        public Task NomeDoLivro(HttpContext context)
        {
            arrumarEncoding(context);
            var _repo = new BookRepository();
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            Book book = _repo.getBookById(id);

            var nomeDoLivro = book.nome;

            return context.Response.WriteAsync(nomeDoLivro);
        }
        public Task DetalhesLivro(HttpContext context)
        {
            arrumarEncoding(context);
            var _repo = new BookRepository();
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            Book book = _repo.getBookById(id);

            string detalhes = book.ToString();
            context.Response.Headers.Remove("Content-Type");
            context.Response.Headers.Append("Content-Type", "application/fido.trusted-apps+json");

            return context.Response.WriteAsync(detalhes);
        }

        public Task AutoresLivro(HttpContext context)
        {
            arrumarEncoding(context);
            var _repo = new BookRepository();
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            Book book = _repo.getBookById(id);

            string autores = book.GetAuthorNames();

            return context.Response.WriteAsync(autores);
        }

        public Task ApresentarLivro(HttpContext context)
        {
            var _repo = new BookRepository();
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            Book book = _repo.getBookById(id);

            BookAuthorDTO bookAuthorDTO = new BookAuthorDTO();

            bookAuthorDTO.nomeBook = book.nome;
            foreach(AuthorBook autor in book.AuthorBooks)
            {
                bookAuthorDTO.nomeAutores.Add(autor.Author.name);
            }
            var conteudoArquivo = CarregaArquivoHTML("livro");
            conteudoArquivo = conteudoArquivo.Replace("#NomeDoLivro", book.nome);
            string autoresHtml = "";
            foreach (AuthorBook autor in book.AuthorBooks)
            {
                autoresHtml = autoresHtml + "<li>" + autor.Author.name + "</li>";
            }
            conteudoArquivo = conteudoArquivo.Replace("#Autores", autoresHtml);
            //return context.Response.WriteAsync(JsonConvert.SerializeObject(bookAuthorDTO));
            return context.Response.WriteAsync(conteudoArquivo);
        }

        public void arrumarEncoding(HttpContext context)
        {
            context.Response.Headers.Remove("Content-Type");
            context.Response.Headers.Append("Content-Type", "application/fido.trusted-apps+json");
        }

        private string CarregaArquivoHTML(string nomeArquivo)
        {
            var nomeCompletoArquivo = $"..\\..\\..\\View\\livro.html";
            using (var arquivo = File.OpenText(nomeCompletoArquivo))
            {
                return arquivo.ReadToEnd();
            }
        }
    }
}

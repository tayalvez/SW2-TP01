using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using TP1_SISTEMASWEB2.DataBase.Repository;
using TP1_SISTEMASWEB2.Entidades;

namespace TP1_SISTEMASWEB2
{
    class Program
    {
        static void Main(string[] args)
        {

            BookRepository repository = new BookRepository();

            Console.WriteLine("Digite o id do livro: \n");
            string valor;
            valor = Console.ReadLine();
            int id = int.Parse(valor);

            Book book = repository.getBookById(id);

            Console.WriteLine(book.ToString());
            Console.WriteLine(book.GetAuthorNames());

            IWebHost host = new WebHostBuilder()
            .UseKestrel()
            .UseStartup<Startup>()
            .Build();

            host.Run();

           

            Console.ReadKey();            
        }
    }
}

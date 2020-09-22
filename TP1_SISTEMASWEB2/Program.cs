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

            IWebHost host = new WebHostBuilder()
            .UseKestrel()
            .UseStartup<Startup>()
            .Build();

            host.Run();
            //BookRepository repository = new BookRepository();

            //Console.WriteLine("Digite o número do livro: \n");
            //string valor;
            //valor = Console.ReadLine();
            //int id = int.Parse(valor);

            //Book book = repository.getBookById(id);

            //Console.WriteLine(book.ToString());

            ////List<string> lista = repository.getBookById(1);

            Console.ReadKey();            
        }
    }
}

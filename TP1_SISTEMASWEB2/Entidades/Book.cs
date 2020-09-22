using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP1_SISTEMASWEB2.Entidades
{
    public class Book
    {
        public int id {get; set;}
        public string nome { get; set; } 
        public double price { get; set; }
        public int qty { get; set; }
        public ICollection<AuthorBook> AuthorBooks { get; set; }
            
        public Book(string nome, List<AuthorBook> authorBooks, double price)
        {
            this.nome = nome;
            this.AuthorBooks = authorBooks;
            this.price =price ;
        }

        public override string ToString()
        {
            string autores = "";
            foreach(AuthorBook authorBook in AuthorBooks)
            {
                autores = autores + "\n nome do autor: " + authorBook.Author.name
                + ",\n e-mail do autor: " + authorBook.Author.email
                + ",\n gender: " + authorBook.Author.gender + ", \n ";
            }

            string book = "Nome do Livro: " + nome + "\n\n Autores: [ " +  autores + " ], " + "\n\n Preço: " + price + ",\n Quantidade em estoque: "  + qty;
            return book;
        }

        public Book(string nome, List<AuthorBook> authorBooks, double price, int qty)
        {
            this.nome = nome;
            this.AuthorBooks = authorBooks;
            this.price = price;
            this.qty = qty;
        }
        public Book() { }

        public String GetAuthorNames()
        {
            List<string> listaNomes = AuthorBooks.Select(x => x.Author.name).ToList();
            string nomes = "";

            foreach(string nome in listaNomes)
            {
                nomes = nomes + nome + " \n ";
            }

            return nomes;
        }

    }
}

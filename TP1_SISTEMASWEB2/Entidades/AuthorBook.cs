using System;
using System.Collections.Generic;
using System.Text;

namespace TP1_SISTEMASWEB2.Entidades
{
    public class AuthorBook
    {
        public int id { get; set; }
        public int idBook { get; set; }
        public int idAuthor { get; set; }

        public Book Book { get; set; }
        public Author Author { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TP1_SISTEMASWEB2.Entidades
{
    public class Author
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public char gender { get; set; }
        public ICollection<AuthorBook> AuthorBooks { get; set; }


    }
}

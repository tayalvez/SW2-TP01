using System;
using System.Collections.Generic;
using System.Text;

namespace TP1_SISTEMASWEB2.DTO
{
    class BookAuthorDTO
    {
        public BookAuthorDTO()
        {
            nomeAutores = new List<string>();
        }
        public string nomeBook { get; set; }

        public List<string> nomeAutores { get; set; }
    }
}

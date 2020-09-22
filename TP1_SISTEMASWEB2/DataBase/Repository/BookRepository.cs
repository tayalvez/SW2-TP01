using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP1_SISTEMASWEB2.DataBase.Context;
using TP1_SISTEMASWEB2.Entidades;

namespace TP1_SISTEMASWEB2.DataBase.Repository
{
    class BookRepository
    {
        private readonly Db dbContext;

        public BookRepository()
        {
            dbContext = new Db();
        }

        public Book getBookById(int id)
        {
            var book = dbContext.Book
                .Include(x => x.AuthorBooks)
                .ThenInclude(x => x.Author)
                .Where(x => x.id == id)
                .FirstOrDefault();

            return book;
            
        }
    }
}

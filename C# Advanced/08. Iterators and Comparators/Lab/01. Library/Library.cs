using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library
    {
        private List<Book> books;
        public Library(params Book[] books)
        {
            this.books = books.ToList();
        }
    }
}

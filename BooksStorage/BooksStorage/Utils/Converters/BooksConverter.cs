using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomainModel;
using FacadeServices.Interfaces;

namespace BooksStorage.Utils.Converters
{
    public class BooksConverter: IConverter<BookModel, BookViewModel >
    {
        public BookModel Convert(BookViewModel source)
        {
            var converter = new AuthorConverter();
            return new BookModel
            {
                BookId = source.BookId,
                Title = source.Title,
                PublishDate = source.PublishDate,
                Publisher = source.Publisher,
                PagesCount = source.PagesCount,
                ISBN = source.ISBN,
                BookImage = source.BookImage,
                Authors = source.Authors.Select(converter.Convert).ToArray()
            };
        }

        public BookViewModel Convert(BookModel source)
        {
            var converter = new AuthorConverter();
            return new BookViewModel
            {
                BookId = source.BookId,
                Title = source.Title,
                PublishDate = source.PublishDate,
                Publisher = source.Publisher,
                PagesCount = source.PagesCount,
                ISBN = source.ISBN,
                BookImage = source.BookImage,
                Authors = source.Authors.Select(converter.Convert).ToArray()
            };
        }
    }
}
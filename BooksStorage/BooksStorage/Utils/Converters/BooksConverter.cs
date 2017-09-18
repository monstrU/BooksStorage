using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BooksStorage.ViewModels;
using DomainModel;
using FacadeServices.Interfaces;

namespace BooksStorage.Utils.Converters
{
    public class BooksConverter: IConverter<BookModel, BookViewModel >
    {
        private string BooksUrlFolder { get; set; }
        public BooksConverter(string bookUrlsFolder)
        {
            BooksUrlFolder = bookUrlsFolder;
        }

        public BookModel Convert(BookViewModel source)
        {
            var converter = new PersonConverter();
            return new BookModel
            {
                BookId = source.BookId,
                Title = source.Title,
                PublishDate = source.PublishDate,
                Publisher = source.Publisher,
                PagesCount = source.PagesCount,
                ISBN = source.ISBN,
                BookFileName = source.BookFileName,
                Authors = source.Authors.Select(converter.Convert).ToArray()
            };
        }

        public BookViewModel Convert(BookModel source)
        {
            var converter = new PersonConverter();
            return new BookViewModel
            {
                BookId = source.BookId,
                Title = source.Title,
                PublishDate = source.PublishDate,
                Publisher = source.Publisher,
                PagesCount = source.PagesCount,
                ISBN = source.ISBN,
                BookFileName = source.BookFileName,
                BooksUrlFolder = BooksUrlFolder,
                Authors = source.Authors.Select(converter.Convert).ToArray()
            };
        }
    }
}
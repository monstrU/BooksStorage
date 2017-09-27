using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BooksStorage.ViewModels;
using DomainModel;
using FacadeServices.Interfaces;

namespace BooksStorage.Utils.Converters
{
    public class BooksEditConverter: IConverter<BookModel, BookEditViewModel>
    {
        private string BooksUrlFolder { get;  }
        private  IList<PersonModel> Persons { get; }
        public BooksEditConverter(string bookUrlsFolder, IList<PersonModel> persons)
        {
            BooksUrlFolder = bookUrlsFolder;
            Persons = persons;
        }

        public BookModel Convert(BookEditViewModel source)
        {
            var converter = new PersonEditConverter(Persons);
            return new BookModel
            {
                BookId = source.BookId,
                Title = source.Title,
                PublishDate = source.PublishDate,
                Publisher = source.Publisher,
                PagesCount = source.PagesCount,
                ISBN = source.ISBN,
                BookFileName = source.BookFileName,
                Authors = source.FullAuthorsList
                            .Where(a=>a.IsSelected)
                            .Select(converter.Convert)
                            .ToArray()
            };
        }

        public BookEditViewModel Convert(BookModel source)
        {
            var converter = new PersonEditConverter(source.Authors);
            return new BookEditViewModel
            {
                BookId = source.BookId,
                Title = source.Title,
                PublishDate = source.PublishDate,
                Publisher = source.Publisher,
                PagesCount = source.PagesCount,
                ISBN = source.ISBN,
                BookFileName = source.BookFileName,
                BooksUrlFolder = BooksUrlFolder,
                FullAuthorsList = Persons.Select(converter.Convert).ToArray()
            };
        }
    }
}
using System;
using BooksStorage.ViewModels;
using DomainModel;
using FacadeServices.Interfaces;

namespace BooksStorage.Utils.Converters
{
    public class AuthorConverter : IConverter<AuthorModel, AuthorViewModel>
    {
        public AuthorModel Convert(AuthorViewModel source)
        {
            throw new NotImplementedException();
        }

        public AuthorViewModel Convert(AuthorModel source)
        {
            return new AuthorViewModel
            {
                BookId= source.BookId,
                Person = new PersonViewModel()
                {
                    PersonId = source.PersonId,
                    Name = "name" + source.PersonId,
                    Family = "f"+source.PersonId
                }
            };
        }
    }
}
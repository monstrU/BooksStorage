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
            return new AuthorModel
            {
                BookId = source.BookId,
                Person = new PersonModel()
                {
                    PersonId = source.Person.PersonId,
                    Name = source.Person.Name,
                    Family = source.Person.Family
                }
            };
        }

        public AuthorViewModel Convert(AuthorModel source)
        {
            return new AuthorViewModel
            {
                BookId= source.BookId,
                Person = new PersonViewModel()
                {
                    PersonId = source.Person.PersonId,
                    Name = source.Person.Name,
                    Family = source.Person.Family
                }
            };
        }
    }
}
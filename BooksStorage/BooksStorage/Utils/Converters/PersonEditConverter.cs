using System.Collections.Generic;
using System.Linq;
using BooksStorage.ViewModels;
using DomainModel;
using FacadeServices.Interfaces;

namespace BooksStorage.Utils.Converters
{
    public class PersonEditConverter : IConverter<PersonModel, PersonEditViewModel>
    {
        private IList<PersonModel> Persons { get; }

        public PersonEditConverter(IList<PersonModel> persons)
        {
            Persons = persons;
        }
        public PersonEditConverter()
        {
            Persons = new List<PersonModel>();
        }
        public PersonModel Convert(PersonEditViewModel source)
        {
            return new PersonModel
            {
                PersonId = source.PersonId,
                Family = source.Family,
                Name = source.Name
            };
        }

        public PersonEditViewModel Convert(PersonModel source)
        {
            return new PersonEditViewModel
            {
                PersonId = source.PersonId,
                Family = source.Family,
                Name = source.Name,
                IsSelected = Persons.Any(p => p.PersonId == source.PersonId)
            };
        }

    }
}
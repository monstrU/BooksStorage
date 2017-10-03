using BooksStorage.ViewModels;
using DomainModel;
using FacadeServices.Interfaces;

namespace BooksStorage.Utils.Converters
{
    public class PersonConverter : IConverter<PersonModel, PersonViewModel>
    {
        public PersonModel Convert(PersonViewModel source)
        {
            return new PersonModel
            {
                PersonId = source.PersonId.GetValueOrDefault(),
                Family = source.Family,
                Name = source.Name
            };
        }

        public PersonViewModel Convert(PersonModel source)
        {
            return new PersonViewModel
            {
                PersonId = source.PersonId,
                Family = source.Family,
                Name = source.Name
            };
        }
        
    }
}
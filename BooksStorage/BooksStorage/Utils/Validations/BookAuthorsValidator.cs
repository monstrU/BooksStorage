using System.Collections.Generic;
using System.Linq;
using BooksStorage.Utils.Interfaces;
using BooksStorage.ViewModels;

namespace BooksStorage.Utils.Validations
{
    public class BookAuthorsValidator: IBookValidator
    {
        public IList<PersonEditViewModel> Authors { get; set; }

        public BookAuthorsValidator(IList<PersonEditViewModel> authors)
        {
            Authors = authors;
        }

        public bool Validate()
        {
            return Authors.Any(a => a.IsSelected);
        }
    }
}
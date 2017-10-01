using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BooksStorage.Utils.Validations;

namespace BooksStorage.ViewModels
{
    /// <summary>
    /// класс для редактирования книги  - с полным списком авторов
    /// </summary>
    public class BookEditViewModel : BookShortViewModel, IValidatableObject
    {
        public string DisplayBookSrcImage
        {
            get { return string.Format("{0}/{1}", BooksUrlFolder, BookFileName); }
        }

        public string BooksUrlFolder { get; set; }


        public int[] CheckedAuthors { get; set; }
        public IList<PersonEditViewModel> FullAuthorsList { get; set; }

        public string BookItemId
        {
            get { return string.Format("{0}{1}", BookItemidPrefix, BookId); }
        }

        public bool IsNewBook
        {
            get { return !BookId.HasValue; }
        }

        public BookEditViewModel()
        {
            FullAuthorsList = new List<PersonEditViewModel>();
            CheckedAuthors = new int[0];
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var baseResult = base.Validate(validationContext);

            if ((validationContext.ObjectType.BaseType != null &&
                 validationContext.ObjectType.BaseType != typeof (BookShortViewModel)) ||
                (validationContext.ObjectType.BaseType == null &&
                 validationContext.ObjectType != typeof (BookEditViewModel)))
            {
                throw new Exception("Валидатор объекта использован для недопустимого типа");
            }

            var book = validationContext.ObjectInstance as BookEditViewModel;
            var results = new List<ValidationResult>();
            if (book != null)
            {

                var authorsValidator = new BookAuthorsValidator(book.FullAuthorsList);

                if (!authorsValidator.Validate())
                    results.Add(new ValidationResult(
                        "При создании книги не указан ни один автор."));

            }
            return baseResult.Union(results);
        }
    }
}

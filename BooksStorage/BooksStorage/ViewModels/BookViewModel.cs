using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BooksStorage.ViewModels
{
    public class BookViewModel : IValidatableObject
    {
        public int BookId { get; set; }
        [Required(ErrorMessage = "Введите название")]
        [StringLength(30, ErrorMessage = "Длина названия не должна превышать 30 символов.")]
        [DisplayName("Название")]
        public string  Title { get; set; }

        [DisplayName("Количество страниц")]
        [Required(ErrorMessage = "Введите количество страниц")]
        [Range(1,10000,ErrorMessage =  "Количество страниц не должно превышать 10 000")]
        public int PagesCount { get; set; }

        [DisplayName("Издательство")]
        [StringLength(30, ErrorMessage = "Длина названия издательства не должна превышать 30 символов.")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "Необходимо указать дату публикации!")]
        [DisplayName("Дата публикации")]
        [DataType(DataType.DateTime,ErrorMessage = "Дата публикации должна быть введена в формате дд.мм.гггг")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PublishDate { get; set; }

        [Required]
        [DisplayName("ISBN")]

        public string ISBN { get; set; }

        public string BookFileName { get; set; }

        public string DisplayBookFileName { get
        {
            return string.Format("{0}/{1}", BooksUrlFolder, BookFileName);
        } }

        public string BooksUrlFolder { get; set; }

        public IList<PersonViewModel> Authors { get; set; }

        public static string BookItemidPrefix = "idBook";

        public string BookItemId
        {
            get { return string.Format("{0}{1}", BookItemidPrefix, BookId); }
        }

        public BookViewModel()
        {
            Authors = new List<PersonViewModel>();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (validationContext.ObjectType != typeof (BookViewModel))
            {
                throw  new Exception("Валидатор объекта использован для недопустимого типа");
            }
            var book = validationContext.ObjectInstance as BookViewModel;
            var results = new List<ValidationResult>();
            if (book != null)
            {
                const int startPublishDateYear = 1980;
                if (book.PublishDate.Year < startPublishDateYear)
                    results.Add(new ValidationResult(
                        $"Дата публикации книги {book.PublishDate:dd.MM.yyyy} должна быть позже {startPublishDateYear} года"));
                else
                    results.Add(ValidationResult.Success);
            }
            return results;
        }
    }
}

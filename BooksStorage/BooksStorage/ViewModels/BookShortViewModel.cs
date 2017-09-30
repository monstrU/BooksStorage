using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BooksStorage.Utils.Validations;

namespace BooksStorage.ViewModels
{
    /// <summary>
    /// короткие сведения о книге - без авторов
    /// </summary>
    public class BookShortViewModel : IValidatableObject
    {
        public static string BookItemidPrefix = "idBook";
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
        [DataType(DataType.Text,ErrorMessage = "Дата публикации должна быть введена в формате дд.мм.гггг")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PublishDate { get; set; }

        [Required]
        [DisplayName("ISBN")]

        public string ISBN { get; set; }

        [DisplayName("Обложка")]
        public string BookFileName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if ((validationContext.ObjectType.BaseType != null && validationContext.ObjectType.BaseType != typeof(BookShortViewModel)) ||
                (validationContext.ObjectType.BaseType == null && validationContext.ObjectType != typeof(BookShortViewModel)))
            {
                throw  new Exception("Валидатор объекта использован для недопустимого типа");
            }

            var book = validationContext.ObjectInstance as BookShortViewModel;
            var results = new List<ValidationResult>();
            if (book != null)
            {
                var publishDateValidator= new PublishDateValidator(book.PublishDate);
                
                if (!publishDateValidator.Validate())
                    results.Add(new ValidationResult(
                        $"Дата публикации книги {book.PublishDate:dd.MM.yyyy} должна быть позже {PublishDateValidator.StartPublishDateYear} года"));
                
                var isbnValidator = new ISBNValidator(book.ISBN);
                if (!isbnValidator.Validate())
                {
                    results.Add(new ValidationResult(
                        $"Задан неверный ISBN книги {book.ISBN}"));
                }
            }

            if (!results.Any())
            {
                results.Add(ValidationResult.Success);
            }
            return results;
        }
    }
}
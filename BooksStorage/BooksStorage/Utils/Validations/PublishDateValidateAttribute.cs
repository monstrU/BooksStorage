using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;

namespace BooksStorage.Utils.Validations
{
    public class PublishDateValidateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult result;
            DateTime dateField;
            
            var format = new DateTimeFormatInfo
            {
                ShortDatePattern = "dd.MM.yyyy"
            };
            
            if (DateTime.TryParse(value.ToString(), format, DateTimeStyles.None, out dateField))
            {
                const int startPublishDateYear = 1980;
                if (dateField.Year < startPublishDateYear)
                    result = new ValidationResult(
                        $"Дата публикации книги {dateField:dd.MM.yyyy} должна быть позже {startPublishDateYear} года");
                else
                    result = ValidationResult.Success;
            }
            else
                result= new ValidationResult($"Использован неверный формат для даты {value}");
            return result;
        }

        public override bool IsValid(object value)
        {
            
            bool result = false;
            DateTime dateField;
            if (DateTime.TryParseExact(value.ToString(), "{0:dd.MM.yyyy}", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out dateField))
            {
                const int startPublishDateYear = 1980;
                result = dateField.Year > startPublishDateYear;
            }
            
            return result;
        }
    }
}

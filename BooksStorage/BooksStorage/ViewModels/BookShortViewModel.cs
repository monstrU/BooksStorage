using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BooksStorage.Utils.Validations;

namespace BooksStorage.ViewModels
{
    /// <summary>
    /// �������� �������� � ����� - ��� �������
    /// </summary>
    public class BookShortViewModel : IValidatableObject
    {
        public static string BookItemidPrefix = "idBook";
        public int BookId { get; set; }

        [Required(ErrorMessage = "������� ��������")]
        [StringLength(30, ErrorMessage = "����� �������� �� ������ ��������� 30 ��������.")]
        [DisplayName("��������")]
        public string  Title { get; set; }

        [DisplayName("���������� �������")]
        [Required(ErrorMessage = "������� ���������� �������")]
        [Range(1,10000,ErrorMessage =  "���������� ������� �� ������ ��������� 10 000")]
        public int PagesCount { get; set; }

        [DisplayName("������������")]
        [StringLength(30, ErrorMessage = "����� �������� ������������ �� ������ ��������� 30 ��������.")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "���������� ������� ���� ����������!")]
        [DisplayName("���� ����������")]
        [DataType(DataType.Text,ErrorMessage = "���� ���������� ������ ���� ������� � ������� ��.��.����")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PublishDate { get; set; }

        [Required]
        [DisplayName("ISBN")]

        public string ISBN { get; set; }

        [DisplayName("�������")]
        public string BookFileName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if ((validationContext.ObjectType.BaseType != null && validationContext.ObjectType.BaseType != typeof(BookShortViewModel)) ||
                (validationContext.ObjectType.BaseType == null && validationContext.ObjectType != typeof(BookShortViewModel)))
            {
                throw  new Exception("��������� ������� ����������� ��� ������������� ����");
            }

            var book = validationContext.ObjectInstance as BookShortViewModel;
            var results = new List<ValidationResult>();
            if (book != null)
            {
                var publishDateValidator= new PublishDateValidator(book.PublishDate);
                
                if (!publishDateValidator.Validate())
                    results.Add(new ValidationResult(
                        $"���� ���������� ����� {book.PublishDate:dd.MM.yyyy} ������ ���� ����� {PublishDateValidator.StartPublishDateYear} ����"));
                
                var isbnValidator = new ISBNValidator(book.ISBN);
                if (!isbnValidator.Validate())
                {
                    results.Add(new ValidationResult(
                        $"����� �������� ISBN ����� {book.ISBN}"));
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
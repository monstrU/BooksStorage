using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [DataType(DataType.DateTime,ErrorMessage = "���� ���������� ������ ���� ������� � ������� ��.��.����")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PublishDate { get; set; }

        [Required]
        [DisplayName("ISBN")]

        public string ISBN { get; set; }

        [DisplayName("�������")]
        public string BookFileName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (validationContext.ObjectType != typeof (BookViewModel))
            {
                throw  new Exception("��������� ������� ����������� ��� ������������� ����");
            }
            var book = validationContext.ObjectInstance as BookViewModel;
            var results = new List<ValidationResult>();
            if (book != null)
            {
                const int startPublishDateYear = 1980;
                if (book.PublishDate.Year < startPublishDateYear)
                    results.Add(new ValidationResult(
                        $"���� ���������� ����� {book.PublishDate:dd.MM.yyyy} ������ ���� ����� {startPublishDateYear} ����"));
                else
                    results.Add(ValidationResult.Success);
            }
            return results;
        }
    }
}
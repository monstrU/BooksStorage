using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksStorage.Utils;
using BooksStorage.ViewModels;

namespace DomainModel
{
    public class BookViewModel
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
        [DisplayName("Дата публикации")]
        public DateTime PublishDate { get; set; }
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
    }
}

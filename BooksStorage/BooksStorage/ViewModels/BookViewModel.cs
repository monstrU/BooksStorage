using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksStorage.ViewModels;

namespace DomainModel
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string  Title { get; set; }
        public int PagesCount { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public string ISBN { get; set; }
        public string BookFileName { get; set; }
        public string DisplayBookFileName { get
        {
            return string.Format("{0}/{1}", BooksUrlFolder, BookFileName);
        } }

        public string BooksUrlFolder { get; set; }

        public IList<PersonViewModel> Authors { get; set; }

        public BookViewModel()
        {
            Authors = new List<PersonViewModel>();
        }
    }
}

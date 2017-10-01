using System.Collections.Generic;

namespace BooksStorage.ViewModels
{
    /// <summary>
    /// модель  для просмотра книги
    /// </summary>
    public class BookViewModel : BookShortViewModel
    {
        public string DisplayBookSrcImage {
            get {
                return string.Format("{0}/{1}", BooksUrlFolder, BookFileName);
            }
        }

        public string BooksUrlFolder { get; set; }

        public IList<PersonViewModel> Authors { get; set; }
        
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

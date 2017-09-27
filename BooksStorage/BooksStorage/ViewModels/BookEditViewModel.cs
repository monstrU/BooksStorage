using System.Collections.Generic;

namespace BooksStorage.ViewModels
{
    /// <summary>
    /// класс для редактирования книги  - с полным списком авторов
    /// </summary>
    public class BookEditViewModel : BookShortViewModel
    {
        public string DisplayBookSrcImage {
            get {
                return string.Format("{0}/{1}", BooksUrlFolder, BookFileName);
            }
        }

        public string BooksUrlFolder { get; set; }

        

        public IList<PersonEditViewModel> FullAuthorsList { get; set; }

        public string BookItemId
        {
            get { return string.Format("{0}{1}", BookItemidPrefix, BookId); }
        }

        public BookEditViewModel()
        {
            FullAuthorsList = new List<PersonEditViewModel>();
        }
    }
}


namespace BooksStorage.ViewModels
{
    public class AuthorViewModel
    {
        public int BookId { get; set; }
        public PersonViewModel Person { get; set; }

        public AuthorViewModel()
        {
            Person = new PersonViewModel();
        }
    }
}
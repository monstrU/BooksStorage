using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BooksStorage.ViewModels
{
    public class PersonEditViewModel: PersonViewModel
    {
        /// <summary>
        /// автор указан у книги
        /// </summary>
        public bool IsSelected { get; set; }
        
    }
}
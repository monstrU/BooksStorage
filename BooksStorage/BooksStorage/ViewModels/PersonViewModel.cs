using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BooksStorage.ViewModels
{
    public class PersonViewModel
    {
        public int PersonId { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Фамилия")]
        public string Family { get; set; }   
    }
}
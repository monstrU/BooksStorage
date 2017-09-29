using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BooksStorage.ViewModels
{
    public class PersonViewModel
    {
        public int PersonId { get; set; }
        [Required(ErrorMessage = "Заполните поле Имя")]
        [DisplayName("Имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Заполните поле Фамилия")]
        [DisplayName("Фамилия")]
        public string Family { get; set; }

        public string DisplayAuthorName
        {
            get
            {
                return string.Format("{0} {1}", Name, Family);
            }
        }

        public static string PersonIdPrefix = "idPerson";
            
    }
}
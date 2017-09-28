using System.ComponentModel;


namespace BooksStorage.ViewModels
{
    public class PersonViewModel
    {
        public int PersonId { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Фамилия")]
        public string Family { get; set; }

        public string DisplayAuthorName
        {
            get
            {
                return string.Format("{0} {1}", Name, Family);
            }
        }

        public static string PersonIdPrefix = "PersonId";
            
    }
}
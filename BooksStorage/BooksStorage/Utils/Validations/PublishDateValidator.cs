using System;
using BooksStorage.Utils.Interfaces;

namespace BooksStorage.Utils.Validations
{
    public class PublishDateValidator: IBookValidator
    {
        public DateTime PublishDate { get;  }
        public const int StartPublishDateYear = 1980;
        public PublishDateValidator(DateTime publishDate)
        {
            PublishDate = publishDate;
        }

        public bool Validate()
        {
            
            return (PublishDate.Year > StartPublishDateYear);
        }
    }
}
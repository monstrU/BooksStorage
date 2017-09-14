using System.Collections.Generic;

namespace BooksStorage.Utils
{
    public interface IOperationResult
    {
        bool IsSuccess { get; set; }
        IList<string> ErrorMessages { get; set; }
    }
}
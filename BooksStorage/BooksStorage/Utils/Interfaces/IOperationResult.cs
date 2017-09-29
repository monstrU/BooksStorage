using System.Collections.Generic;

namespace BooksStorage.Utils.Interfaces
{
    public interface IOperationResult
    {
        bool IsSuccess { get; set; }
        IList<string> ErrorMessages { get; set; }
    }
    
}
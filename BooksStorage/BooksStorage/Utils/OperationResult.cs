using System.Collections.Generic;
using BooksStorage.Utils.Interfaces;

namespace BooksStorage.Utils
{
    public class OperationResult : IOperationResult
    {
        public bool IsSuccess { get; set; }
        
        public IList<string> ErrorMessages { get; set; }

        public OperationResult()
        {
            ErrorMessages=new List<string>();
        }
    }
}
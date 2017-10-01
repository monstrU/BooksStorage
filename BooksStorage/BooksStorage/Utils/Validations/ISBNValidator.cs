using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using BooksStorage.Utils.Interfaces;

namespace BooksStorage.Utils.Validations
{
    /// <summary>
    /// валидатор 13 значного номера ISBN
    /// </summary>
    public class ISBNValidator : IBookValidator
    {
        public string ISBN { get; }
        public ISBNValidator(string isbn)
        {
            ISBN = isbn;
        }

        public bool Validate()
        {
            const int validISBNLenght = 13;
            const int divider = 10;
            var result = true;

            var regex = new Regex("(\\d)",
                   RegexOptions.IgnoreCase
                   | RegexOptions.CultureInvariant
                   | RegexOptions.IgnorePatternWhitespace
                   | RegexOptions.Compiled
                   );
            
            var chars = regex.Matches(ISBN);

            var numbers = (chars.Cast<Match>().Select(number => Convert.ToInt16(number.Value))).ToArray();

            result = numbers.Length == validISBNLenght;

            result = true;
            if (result)
            {
                var numberLength = numbers.Length;
                var mul2 = 0;
                for (var i = 0; i < numberLength-1; i++)
                {
                    var k = (i + 1) %2;
                    var mn = k%2 == 1 ? 1 : 3;
                    mul2 += numbers[i]*mn;
                }
                var div2 = mul2%divider;
                result = (divider-div2) == numbers[numbers.Length - 1];
               
            }

            return result;
        }
    }
}
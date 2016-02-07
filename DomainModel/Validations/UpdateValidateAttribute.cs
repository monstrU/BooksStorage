using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Validations
{
    public class UpdateValidateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = false;
            var dateField = (DateTime) value;
            if (dateField != null)
            {
                result= DateTime.Compare(DateTime.Now, dateField) <= 0;
            }
            return result;
        }
    }
}

﻿using System;
using System.Globalization;
using System.Web.Http.Controllers;

namespace BooksStorage.Utils.ModelBinders.WebApi
{

    public class CustomDateBinder : System.Web.Http.ModelBinding.IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, System.Web.Http.ModelBinding.ModelBindingContext bindingContext)
        {
            var result = false;

            if (actionContext == null)
                throw new ArgumentNullException("actionContext", "controllerContext is null.");
            if (bindingContext == null)
                throw new ArgumentNullException("bindingContext", "bindingContext is null.");

            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (value == null)
                throw new ArgumentNullException(bindingContext.ModelName);
            
            try
            {
            
                DateTime dateField;

                var format = new DateTimeFormatInfo
                {
                    ShortDatePattern = "dd.MM.yyyy"
                };

                result = DateTime.TryParse(value.AttemptedValue, format, DateTimeStyles.None, out dateField);

                if (result)
                {
                    bindingContext.Model = dateField;
                    bindingContext.ModelState.SetModelValue(bindingContext.ModelName, value);
                }
            }
            catch
            {
                result = false;
            }
            if (!result)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, string.Format("Неверная дата. Дата должна быть передана в формате ДД.ММ.ГГГГ."));
            }

            return result;
        }

        
    }
}
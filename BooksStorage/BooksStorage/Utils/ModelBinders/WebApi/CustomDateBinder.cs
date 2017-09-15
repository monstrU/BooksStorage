using System;
using System.Globalization;
using System.Web.Http.Controllers;



namespace BooksStorage.Utils.ModelBinders
{

    public class CustomDateBinder : System.Web.Http.ModelBinding.IModelBinder
    {
        /*    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext == null)
                throw new ArgumentNullException("controllerContext", "controllerContext is null.");
            if (bindingContext == null)
                throw new ArgumentNullException("bindingContext", "bindingContext is null.");

            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (value == null)
                throw new ArgumentNullException(bindingContext.ModelName);

            CultureInfo cultureInf = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            cultureInf.DateTimeFormat.ShortDatePattern = "dd.MM.yyyy";

            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, value);

            try
            {
                var date = value.ConvertTo(typeof(DateTime), cultureInf);

                return date;
            }
            catch (Exception ex)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex);
                return null;
            }
        }*/

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

            CultureInfo cultureInf = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            cultureInf.DateTimeFormat.ShortDatePattern = "dd.MM.yyyy";
            
            try
            {
                var resultDate=value.ConvertTo(typeof(DateTime), cultureInf);
                bindingContext.Model = resultDate;
                bindingContext.ModelState.SetModelValue(bindingContext.ModelName, value);
                result = true;
            }
            catch
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, string.Format("Дата должна быть передана в формате ДД.ММ.ГГГГ."));

            }

            return result;
        }

        
    }
}
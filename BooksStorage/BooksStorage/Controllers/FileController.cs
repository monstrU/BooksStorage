using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BooksStorage.Utils;
using BooksStorage.Utils.Interfaces;
using BooksStorage.ViewModels;
using FacadeServices.Interfaces.Services;

namespace BooksStorage.Controllers
{
    public class FileController : ApiControllerBase
    {
        public IBooksService BooksService { get; set; }

        public FileController(IBooksService booksService)
        {
            BooksService = booksService;
        }

        [ActionName("Upload")]
        [HttpPost]
        public async Task<IHttpActionResult> Upload()
        {
            IOperationResult result;

            if (!Request.Content.IsMimeMultipartContent())
            {
                return BadRequest();
            }
            var provider = new MultipartMemoryStreamProvider();
            // путь к папке на сервере
            string root = System.Web.HttpContext.Current.Server.MapPath("~/Images/");
            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
                string filename="";
                foreach (var file in provider.Contents)
                {
                    if (!string.IsNullOrEmpty(file.Headers.ContentDisposition.FileName))
                    {
                        filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                        byte[] fileArray = await file.ReadAsByteArrayAsync();

                        using (FileStream fs = new FileStream(root + filename, FileMode.Create))
                        {
                            await fs.WriteAsync(fileArray, 0, fileArray.Length);
                        }
                    }
                }
                result= new OperationResult<string>
                {
                    IsSuccess = true,
                    DataResult = filename
                };
            }
            catch (Exception exception)
            {
                result= new OperationResult
                {
                    IsSuccess = false,
                    ErrorMessages = { exception.Message}
                };
            }
            return  CreateResult(result);

        }
    }
}

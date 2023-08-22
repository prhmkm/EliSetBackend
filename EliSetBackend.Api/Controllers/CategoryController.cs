using EliSetBackend.Core.Helpers;
using EliSetBackend.Core.Model.Base;
using EliSetBackend.Domain.Models;
using EliSetBackend.Service.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;

namespace EliSetBackend.Api.Controllers
{
    //[Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        IServiceWrapper _service;
        private readonly AppSettings _appSettings;
        public CategoryController(IServiceWrapper service, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _service = service;
        }
        [HttpGet("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            try
            {

                List<Category> res = _service.Category.GetCategories();
                return Ok(new
                {
                    TimeStamp = DateTime.Now,
                    ResponseCode = HttpStatusCode.OK,
                    Message = "گروه بندی با موفقیت ارسال شد",
                    Value = new { response = res },
                    Error = new { }
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    TimeStamp = DateTime.Now,
                    ResponseCode = HttpStatusCode.InternalServerError,
                    Message = "خطای داخلی سرور رخ داده است",
                    Value = new { },
                    Error = new { Response = ex.ToString() }
                });
            }
        }
    }
}

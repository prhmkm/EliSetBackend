using EliSetBackend.Core.Model.Base;
using EliSetBackend.Domain.Models;
using EliSetBackend.Service.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;
using static EliSetBackend.Domain.DTOs.ClotheDTO;

namespace EliSetBackend.Api.Controllers
{
    //[Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ClotheController : Controller
    {
        IServiceWrapper _service;
        private readonly AppSettings _appSettings;
        public ClotheController(IServiceWrapper service, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _service = service;
        }
        [AllowAnonymous]
        [HttpGet("GetAllClothes")]
        public IActionResult GetAllClothes([FromHeader] int categoryId, [FromHeader] int pageSize, [FromHeader] int pageNumber)
        {
            try
            {
                List<GetAllClothes> res = _service.Clothe.GetAll(categoryId);
                int max = res.Count();
                if (pageSize != 0 && pageNumber != 0)
                {
                    res = res.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                }

                return Ok(new
                {
                    TimeStamp = DateTime.Now,
                    ResponseCode = HttpStatusCode.OK,
                    Message = "لباس ها با موفقیت ارسال شد",
                    Value = new { response = res, max = max },
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
        [HttpPost("AddClothe")]
        public IActionResult AddClothe([FromBody] AddNewClothe addNewClothe)
        {
            try
            {
                if (addNewClothe == null)
                {
                    return Ok(new
                    {
                        TimeStamp = DateTime.Now,
                        ResponseCode = HttpStatusCode.BadRequest,
                        Message = "اطلاعات فرستاده نشده است",
                        Value = new { },
                        Error = new { }
                    });
                }
                if (string.IsNullOrEmpty(addNewClothe.Title))
                {
                    return Ok(new
                    {
                        TimeStamp = DateTime.Now,
                        ResponseCode = HttpStatusCode.BadRequest,
                        Message = "عنوان لباس فرستاده نشده است",
                        Value = new { },
                        Error = new { }
                    });
                }
                if (addNewClothe.CategoryId == 0)
                {
                    return Ok(new
                    {
                        TimeStamp = DateTime.Now,
                        ResponseCode = HttpStatusCode.BadRequest,
                        Message = "شناسه گروه بندی لباس فرستاده نشده است",
                        Value = new { },
                        Error = new { }
                    });
                }
                if (string.IsNullOrEmpty(addNewClothe.Description))
                {
                    return Ok(new
                    {
                        TimeStamp = DateTime.Now,
                        ResponseCode = HttpStatusCode.BadRequest,
                        Message = "توضیعات لباس فرستاده نشده است",
                        Value = new { },
                        Error = new { }
                    });
                }
                

                Clothe clotheCreated = new Clothe()
                {
                    Title = addNewClothe.Title.Trim(),
                    CategoryId = addNewClothe.CategoryId,
                    Description = addNewClothe.Description,
                };

                var id = _service.Clothe.Add(clotheCreated);

                int count = 1;
                foreach (var item in addNewClothe.Pictures)
                {
                    var Photo = _service.Picture.Upload(DateTime.Now.ToString("MMddHHmmss") + "-clothes" + count, item, 1, id);
                    count++;
                }

                return Ok(new
                {
                    TimeStamp = DateTime.Now,
                    ResponseCode = HttpStatusCode.OK,
                    Message = "لباس با موفقیت ثبت شد",
                    Value = new { },
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

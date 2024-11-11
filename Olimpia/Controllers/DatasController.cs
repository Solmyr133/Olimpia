using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Olimpia.Models;
using static Olimpia.Models.DTOs;

namespace Olimpia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatasController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Data> Post(CreateDataDTO createDataDTO)
        {
            DateTime currentTime = DateTime.Now;

            Data data = new Data
            {
                Id = Guid.NewGuid(),
                Country = createDataDTO.Country,
                County = createDataDTO.County,
                Description = createDataDTO.Description,
                CreatedTime = currentTime,
                UpdatedTime = currentTime,
            };

            if (data != null)
            {
                using (var context = new OlimpiaContext())
                {
                    context.Datas.Add(data);
                    context.SaveChanges();
                    return StatusCode(201, data);
                }
            }

            return BadRequest();
        }

    }
}

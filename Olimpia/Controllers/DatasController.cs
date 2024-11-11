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
            var context = new OlimpiaContext();

            DateTime currentTime = DateTime.Now;

            Data data = new Data
            {
                Id = Guid.NewGuid(),
                Country = createDataDTO.Country,
                County = createDataDTO.County,
                Description = createDataDTO.Description,
                CreatedTime = currentTime,
                UpdatedTime = currentTime,
                PlayerId = createDataDTO.PlayerId,
            };

            if (data != null)
            {
                context.Datas.Add(data);
                context.SaveChanges();
                return StatusCode(201, data);
            }

            return BadRequest();
        }

        [HttpPut]
        public ActionResult<Data> Put(UpdateDataDTO updateDataDTO)
        {
            var context = new OlimpiaContext();

            DateTime currentTime = DateTime.Now;

            Data existingData = context.Datas.FirstOrDefault(x => x.Id == updateDataDTO.Id);

            existingData.Country = updateDataDTO.Country;
            existingData.County = updateDataDTO.County;
            existingData.Description = updateDataDTO.Description;
            existingData.UpdatedTime = currentTime;

            if (existingData != null)
            {
                context.Datas.Update(existingData);
                context.SaveChanges();

                return StatusCode(201, existingData);
            }

            return BadRequest();
        }
    }
}

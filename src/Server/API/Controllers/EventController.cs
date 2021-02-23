using System;
using System.Threading.Tasks;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/event")]
    [ApiController]
    public class EventController : Controller
    {
        private IApplicationService _service;

        public EventController(IApplicationService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all events
        /// </summary>
        /// <remarks>
        /// Sample result:
        ///
        ///     {
        ///        "timestamp": "1539112021301",
        ///        "tag": "brasil.nordeste.sensor02 >",
        ///        "valor": "",
        ///        "status": "Error"
        ///     }
        ///     {
        ///        "timestamp": "1539112021301",
        ///        "tag": "brasil.sudeste.sensor04 >",
        ///        "valor": "k4875p",
        ///        "status": "Processed"
        ///     }
        ///
        /// </remarks>
        /// <returns>All events</returns>
        [HttpGet("all")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var response = await _service.GetAllEvents();
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Save a new Event 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /
        ///     {
        ///        "timestamp": "1539112021301",
        ///        "tag": "brasil.sudeste.sensor01 >",
        ///        "valor" : "558742"
        ///     }
        /// </remarks>
        /// <param name="sensorEventModel"></param>
        /// <returns>A newly created Event</returns>
        /// <response code="200">Returns the newly created item</response>
        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] SensorEventRequestModel sensorEventModel)
        {
            try
            {
                var response = await _service.SaveEvent(sensorEventModel);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get Events per region 
        /// </summary>
        /// <remarks>
        /// Sample result:
        ///
        ///     {
        ///        "country": "brasil",
        ///        "region": "sul",
        ///        "total" : "7"
        ///     }
        ///
        /// </remarks>
        /// <param name="region"></param>
        /// <returns>Returns country, region and the total number of events per region</returns>
        /// <response code="200">Returns the newly created item</response>
        [HttpGet("region/{region}")]
        public async Task<IActionResult> GetSensorEventCountByRegion(string region)
        {
            try
            {
                var response = await _service.GetTagEventByRegion(region);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get Events per sensor name
        /// </summary>
        /// <remarks>
        /// Sample result:
        ///
        ///      {
        ///          "country": "brasil",
        ///          "region": "sul",
        ///          "sensorName": "sensor01",
        ///          "total": 5
        ///      },
        ///      {
        ///         "country": "brasil",
        ///         "region": "sul",
        ///         "sensorName": "sensor02",
        ///         "total": 2
        ///      }
        /// </remarks>
        /// <param name="region"></param>
        /// <returns>Returns the number of events per sensor name</returns>
        /// <response code="200">Returns the newly created item</response>
        [HttpGet("sensor/{region}")]
        public ActionResult GetSensorEventCountBySensorName(string region)
        {
            try
            {
                var response = _service.GetTagEventBySensorName(region);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
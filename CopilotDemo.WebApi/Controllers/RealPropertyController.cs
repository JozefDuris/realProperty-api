using CopilotDemo.Application.Interfaces;
using CopilotDemo.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CopilotDemo.Api.Controllers
{
    [ApiController]
    [Route("real-properties")]
    [Authorize]
    public class RealPropertyController : ControllerBase
    {
        private readonly IRealPropertyService _realPropertyService;
        private readonly IAdvertisementGenerationService _advertisementGenerationService;
        private readonly IActivityLogService _activityLogService;

        public RealPropertyController(
            IRealPropertyService realPropertyService,
            IAdvertisementGenerationService advertisementGenerationService,
            IActivityLogService activityLogService)
        {
            _realPropertyService = realPropertyService;
            _advertisementGenerationService = advertisementGenerationService;
            _activityLogService = activityLogService;
        }

        [HttpGet("{id}")]
        public ActionResult<RealProperty?> GetRealProperty(int id)
        {
            var result = _realPropertyService.GetPropertyById(id);
            if (result != null)
            {
                _activityLogService.Log(User.Identity?.Name ?? "anonymous", $"Viewed property {id}");
                return new OkObjectResult(result);
            }
            return new NotFoundResult();
        }

        [HttpGet("{id}/advertisement")]
        public ActionResult<string> GetAdvertisementForProperty(int id)
        {
            var property = _realPropertyService.GetPropertyById(id);
            if (property != null)
            {
                var advertisement = _advertisementGenerationService.GenerateAdvertisement(property);
                _activityLogService.Log(User.Identity?.Name ?? "anonymous", $"Viewed advertisement for property {id}");
                return new OkObjectResult(advertisement);
            }
            return new NotFoundResult();
        }

        [HttpGet("{id}/versions/{versionNumber}")]
        public ActionResult<RealPropertyVersion?> GetRealPropertyVersion(int id, int versionNumber)
        {
            var version = _realPropertyService.GetPropertyVersionById(id, versionNumber);
            if (version != null)
            {
                _activityLogService.Log(User.Identity?.Name ?? "anonymous", $"Viewed version {versionNumber} of property {id}");
                return new OkObjectResult(version);
            }
            return new NotFoundResult();
        }

        [HttpGet]
        public ActionResult<IEnumerable<RealProperty>> GetAllRealProperties()
        {
            var properties = _realPropertyService.GetAllProperties();
            _activityLogService.Log(User.Identity?.Name ?? "anonymous", "Viewed all properties");
            return new OkObjectResult(properties);
        }

        // --- CRUD for Admins ---
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateProperty([FromBody] RealProperty property)
        {
            _realPropertyService.AddProperty(property);
            _activityLogService.Log(User.Identity?.Name ?? "anonymous", $"Created property {property.Id}");
            return CreatedAtAction(nameof(GetRealProperty), new { id = property.Id }, property);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateProperty(int id, [FromBody] RealProperty property)
        {
            var updated = _realPropertyService.UpdateProperty(id, property);
            if (updated)
            {
                _activityLogService.Log(User.Identity?.Name ?? "anonymous", $"Updated property {id}");
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProperty(int id)
        {
            var deleted = _realPropertyService.DeleteProperty(id);
            if (deleted)
            {
                _activityLogService.Log(User.Identity?.Name ?? "anonymous", $"Deleted property {id}");
                return NoContent();
            }
            return NotFound();
        }
    }
}

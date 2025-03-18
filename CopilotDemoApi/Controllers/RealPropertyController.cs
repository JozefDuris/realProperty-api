using CopilotDemoApi.Models;
using CopilotDemoApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CopilotDemoApi.Controllers
{
    [ApiController]
    [Route("real-properties")]
    [Authorize]
    public class RealPropertyController : ControllerBase
    {
        private readonly IRealPropertyService _realPropertyService;
        private readonly IAdvertisementGenerationService _advertisementGenerationService;

        public RealPropertyController(
            IRealPropertyService realPropertyService,
            IAdvertisementGenerationService advertisementGenerationService)
        {
            _realPropertyService = realPropertyService;
            _advertisementGenerationService = advertisementGenerationService;
        }

        [HttpGet("{id}")]
        public ActionResult<RealProperty?> GetRealProperty(int id)
        {
            var result = _realPropertyService.GetPropertyById(id);
            if (result != null)
            {
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
                return new OkObjectResult(version);
            }
            return new NotFoundResult();
        }

    }
}

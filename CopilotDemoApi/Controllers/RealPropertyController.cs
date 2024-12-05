using CopilotDemoApi.Models;
using CopilotDemoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CopilotDemoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RealPropertyController : ControllerBase
    {
        private readonly IRealPropertyService _realPropertyService;
        private readonly IAdvertisementGenerationService _advertisementGenerationService;

        private readonly ILogger<RealPropertyController> _logger;

        public RealPropertyController(ILogger<RealPropertyController> logger, IRealPropertyService realPropertyService, IAdvertisementGenerationService advertisementGenerationService)
        {
            _logger = logger;
            _realPropertyService = realPropertyService;
            _advertisementGenerationService = advertisementGenerationService;
        }

        [HttpGet("realProperties/{id}", Name = "GetRealProperty")]
        public ActionResult<RealProperty?> GetRealProperty(int id)
        {
            var result = _realPropertyService.GetPropertyById(id);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            return new NotFoundResult();
        }

        [HttpGet("realProperties/{id}/advertisement", Name = "GetRealPropertyAd")]
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

        // need to extend existing functionality to get also specific version
        // to do so, first RealProperty model needs to be updated so address, rooms, area, propertytype and price properties will be moved into RealPropertyVersionDetails and RealProperty will contain list of versions, each containing RealPropertyVersionDetails model and version number
        // next, RealPropertyService needs to be updated with new method to get specific version of RealProperty
        // next, LiteDbService needs to be updated so DB will contain real properties with versions
        // next, new endpoint should be created to get specific version of RealProperty
        // finally we need to update unit tests to cover new functionality

    }
}

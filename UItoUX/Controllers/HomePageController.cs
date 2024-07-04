using Microsoft.AspNetCore.Mvc;
using UItoUX.Service.Interface;

namespace UItoUX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePageController(IHomePageService homePageService) : ControllerBase
    {
        /// <summary>
        /// Retrieves details for the home page details.
        /// </summary>
        /// <returns>A JSON result containing the home page details.
        /// 1. Brand Details
        /// 2. Product Details
        /// 3. Slide Details
        /// 4. Banner Details
        /// </returns>
        /// <response code="200">Success</response>
        /// <response code="203">Failed</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        public async Task<IActionResult> HomePageDetails()
        {
            return Ok(await homePageService.HomePageDetails());
        }
    }
}

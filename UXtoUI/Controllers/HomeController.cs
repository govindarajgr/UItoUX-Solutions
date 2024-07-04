using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UItoUX.Models;

namespace UItoUX.Controllers
{
    public class HomeController(HttpClient httpClient, IConfiguration configuration) : Controller
    {

        public async Task<IActionResult> Index()
        {
            HomepageDTO homepageDTO = new HomepageDTO();

            // Get the API base URL from appsettings.json
            string apiBaseURL = configuration.GetValue<string>("AppSettings:APIBaseURL") ?? string.Empty;

            string apiEndpoint = $"{apiBaseURL}/api/HomePage";

            var response = await httpClient.GetFromJsonAsync<APIResultArgs>(apiEndpoint);

            if (response != null && response.StatusCode == 200 && response.ResultData != null)
            {
                // Convert ResultData to JSON string and then deserialize it to HomepageDTO
                var homepageDataJson = response.ResultData.ToString();
                if (!string.IsNullOrEmpty(homepageDataJson))
                {
                    var resultdata = JsonSerializer.Deserialize<HomepageDTO>(homepageDataJson, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    homepageDTO = resultdata ?? homepageDTO;
                }
            }
            return View(homepageDTO);
        }

    }
}

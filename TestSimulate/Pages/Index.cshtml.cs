using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestSimulate.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public string Message { get; set; } = "Ingen simulerad traffik utförd";
        public async Task<IActionResult> OnPostMinKnapp()
        {
            var uri = "https://simulate-newton.azurewebsites.net";

            using var client = new HttpClient();

            for (int i = 0; i < 100; i++)
            {
                try
                {
                    var response = await client.GetAsync(uri);
                    Console.WriteLine($"Request {i + 1}, Status : {response.StatusCode}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Request {i + 1} Failed: {ex.Message}");
                }
                await Task.Delay(10);
            }
            Message = "simulerad traffik utförd";
            return Page(); 
        }

        public void OnGet()
        {

        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace DemoApp;

[Route("base")]
public class BaseController : Controller
{
    // GET
    public IActionResult Index()
    {
        return Ok();
    }
    [Route("error")]
    public IActionResult Error()
    {
        var myDeviceId = 0;
        try
        {
            var dict = new Dictionary<string, int> { { "MN01-LTE-M", 1 }, {"MN01-V3", 2} };
            myDeviceId = dict["MN01-3IN"];        
        }
        catch (Exception ex)
        {
            SentrySdk.CaptureException(ex);
        }
        return Ok(myDeviceId);
    }
}
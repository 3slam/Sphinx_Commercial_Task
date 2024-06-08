using Microsoft.AspNetCore.Mvc;
using Sphinx_Commercial_Task.Service.IServices;

namespace Sphinx_Commercial_Task.Web.Controllers
{


	[Route("api/[controller]")]
	[ApiController]
	public class ClientController(IClientService service) : Controller
	{

		[HttpGet]
		public IActionResult Get()
		{
			var list = service.GetClients();
			return Json(new { data = list });
		}
	}
}

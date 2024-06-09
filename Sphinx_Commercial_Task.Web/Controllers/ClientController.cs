using Microsoft.AspNetCore.Mvc;
using Sphinx_Commercial_Task.Repository;


namespace Sphinx_Commercial_Task.Web.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ClientController(IUnitOfWork unitOfWork) : Controller
    {

        [HttpGet]
        public IActionResult Get()
        {
            var list = unitOfWork.Client.GetTableNoTracking().ToList();
            return Json(new { data = list });
        }
    }
}

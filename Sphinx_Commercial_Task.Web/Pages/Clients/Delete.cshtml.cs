using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sphinx_Commercial_Task.Data.Entities;
using Sphinx_Commercial_Task.Repository;

namespace Sphinx_Commercial_Task.Web.Pages.Clients
{
	[BindProperties]
	public class DeleteModel(IUnitOfWork unitOfWork) : PageModel
	{
		public Client Client { get; set; }


		public void OnGet(int id) => Client = unitOfWork.Client.GetById(id);


		public async Task<IActionResult> OnPost()
		{
			var clientFromDb = unitOfWork.Client.GetById(Client.Id);
			if (clientFromDb != null)
			{
				await unitOfWork.Client.DeleteAsync(clientFromDb);
				await unitOfWork.SaveChangesAsync();
				TempData["success"] = "Client deleted successfully";
				return RedirectToPage("ListAllClients");
			}

			return Page();
		}
	}
}

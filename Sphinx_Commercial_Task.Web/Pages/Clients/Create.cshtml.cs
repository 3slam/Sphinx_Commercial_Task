using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sphinx_Commercial_Task.Data.Entities;
using Sphinx_Commercial_Task.Repository;
using Sphinx_Commercial_Task.Web.ViewModels;

namespace Sphinx_Commercial_Task.Web.Pages.Clients
{

	[BindProperties]
	public class CreateModel(IUnitOfWork unitOfWork, IMapper mapper) : PageModel
	{
		public List<SelectListItem> States { get; } = new List<SelectListItem>
		{
			new SelectListItem { Value = "Active", Text = "Active" },
			new SelectListItem { Value = "Inactive", Text = "Inactive" },
			new SelectListItem { Value = "Pending", Text = "Pending" }
		};
		public List<SelectListItem> Classes { get; } = new List<SelectListItem>
		{
			new SelectListItem { Value = "A", Text = "A" },
			new SelectListItem { Value = "B", Text = "B" },
			new SelectListItem { Value = "C", Text = "C" }
		};
		public ClientViewModel Client { get; set; }
		public void OnGet() { }

		public async Task<IActionResult> OnPost()
		{
			if (ModelState.IsValid)
			{
				await unitOfWork.Client.AddAsync(mapper.Map<Client>(Client));
				await unitOfWork.SaveChangesAsync();
				TempData["success"] = "Client created successfully";
				return RedirectToPage("ListAllClients");
			}
			return Page();

		}

	}
}

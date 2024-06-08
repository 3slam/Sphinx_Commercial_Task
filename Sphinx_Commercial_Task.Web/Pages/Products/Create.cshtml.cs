using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sphinx_Commercial_Task.Data.Entities;
using Sphinx_Commercial_Task.Repository;
using Sphinx_Commercial_Task.Web.ViewModels;

namespace Sphinx_Commercial_Task.Web.Pages.Products
{

	[BindProperties]
	public class CreateModel(IUnitOfWork unitOfWork, IMapper mapper) : PageModel
	{
		public List<SelectListItem> IsActiveItems { get; } = new List<SelectListItem>
		{
			new SelectListItem { Value = "true", Text = "Active" },
			new SelectListItem { Value = "false", Text = "Inactive" },

		};

		public ProductViewModel Product { get; set; }
		public void OnGet() { }

		public async Task<IActionResult> OnPost()
		{
			if (ModelState.IsValid)
			{
				await unitOfWork.Product.AddAsync(mapper.Map<Product>(Product));
				await unitOfWork.SaveChangesAsync();
				TempData["success"] = "Product created successfully";
				return RedirectToPage("ListAllProducts");
			}
			return Page();

		}

	}
}

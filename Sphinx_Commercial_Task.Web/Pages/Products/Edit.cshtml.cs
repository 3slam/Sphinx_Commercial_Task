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
	public class EditModel(IUnitOfWork unitOfWork, IMapper mapper) : PageModel
	{
		public List<SelectListItem> IsActiveItems { get; } = new List<SelectListItem>
		{
			new SelectListItem { Value = "true", Text = "Active" },
			new SelectListItem { Value = "false", Text = "Inactive" },

		};
		public int ProductId { get; set; }
		public ProductViewModel Product { get; set; }
		public void OnGet(int id)
		{
			Product = mapper.Map<ProductViewModel>(unitOfWork.Product.GetById(id));
			ProductId = id;
		}


		public async Task<IActionResult> OnPost()
		{

			if (ModelState.IsValid)
			{
				Product updatedProduct = mapper.Map<Product>(Product);
				updatedProduct.Id = ProductId;
				await unitOfWork.Product.UpdateAsync(updatedProduct);
				await unitOfWork.SaveChangesAsync();
				TempData["success"] = "Product updated successfully";
				return RedirectToPage("ListAllProducts");
			}
			return Page();
		}

	}
}

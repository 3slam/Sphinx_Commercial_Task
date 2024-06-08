using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sphinx_Commercial_Task.Data.Entities;
using Sphinx_Commercial_Task.Repository;

namespace Sphinx_Commercial_Task.Web.Pages.Products
{
	[BindProperties]

	public class DeleteModel(IUnitOfWork unitOfWork) : PageModel
	{
		public Product Product { get; set; }
		public List<SelectListItem> IsActiveItems { get; } = new List<SelectListItem>
		{
			new SelectListItem { Value = "true", Text = "Active" },
			new SelectListItem { Value = "false", Text = "Inactive" },

		};

		public void OnGet(int id) => Product = unitOfWork.Product.GetById(id);


		public async Task<IActionResult> OnPost()
		{
			var productFromDb = unitOfWork.Product.GetById(Product.Id);

			if (productFromDb != null)
			{

				var relatedProduct = unitOfWork.
					ClientProduct.
					GetTableNoTracking().
					Where(CP => CP.ProductId == productFromDb.Id).ToList();

				if (relatedProduct.Count == 0)
				{
					await unitOfWork.Product.DeleteAsync(productFromDb);
					await unitOfWork.SaveChangesAsync();
					TempData["success"] = "Product deleted successfully";
				}
				else
				{
					TempData["error"] = "Product cannot be deleted as it has related Clients";
				}

				return RedirectToPage("ListAllProducts");
			}

			return Page();
		}

	}

}

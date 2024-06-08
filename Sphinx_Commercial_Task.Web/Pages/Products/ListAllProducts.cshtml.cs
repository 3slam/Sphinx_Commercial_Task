using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sphinx_Commercial_Task.Data.Entities;
using Sphinx_Commercial_Task.Repository;

namespace Sphinx_Commercial_Task.Web.Pages.Products
{
	[BindProperties]
	public class ListAllProductsModel(IUnitOfWork unitOfWork) : PageModel
	{
		public List<Product> Products { get; set; }
		public void OnGet() => Products = unitOfWork.Product
			.GetTableNoTracking().
			 OrderBy(c => c.Name).ToList();
	}
}

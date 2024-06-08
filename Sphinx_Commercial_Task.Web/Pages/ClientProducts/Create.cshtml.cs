using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sphinx_Commercial_Task.Data.Entities;
using Sphinx_Commercial_Task.Repository;
using Sphinx_Commercial_Task.Web.ViewModels;

namespace Sphinx_Commercial_Task.Web.Pages.ClientProducts
{
	[BindProperties]
	public class CreateModel(IUnitOfWork unitOfWork) : PageModel
	{
		public CreateClientProductViewModel ClientProduct { get; set; }
		public List<SelectListItem> Products { get; set; }
		public List<SelectListItem> Clients { get; set; }
		public async Task OnGetAsync()
		{
			ClientProduct = new CreateClientProductViewModel();
			Products = await unitOfWork.Product.GetTableNoTracking().Where(p => p.IsActive == true)
			   .Select(p => new SelectListItem
			   {
				   Value = p.Id.ToString(),
				   Text = p.Name
			   }).ToListAsync();

			Clients = await unitOfWork.Client.GetTableNoTracking()
			   .Select(c => new SelectListItem
			   {
				   Value = c.Id.ToString(),
				   Text = c.Name
			   }).ToListAsync();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (ModelState.IsValid)
			{
				var clientProduct = new ClientProduct
				{
					ProductId = ClientProduct.ProductId,
					ClientId = ClientProduct.ClientId,
					StartDate = ClientProduct.StartDate,
					EndDate = ClientProduct.EndDate,
					License = ClientProduct.License
				};

				await unitOfWork.ClientProduct.AddAsync(clientProduct);
				await unitOfWork.SaveChangesAsync();

				return RedirectToPage("../Clients/ListAllClients");
			}
			return Page();

		}
	}
}


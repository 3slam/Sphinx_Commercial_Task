using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sphinx_Commercial_Task.Data.Entities;
using Sphinx_Commercial_Task.Repository;
using Sphinx_Commercial_Task.Web.ViewModels;

namespace Sphinx_Commercial_Task.Web.Pages.Products
{
	public class DetailsModel(IUnitOfWork unitOfWork, IMapper mapper) : PageModel
	{
		public Product Product { get; set; }
		public List<ClientProductViewModel> ClientProductList { get; set; }

		public void OnGet(int id)
		{
			Product = unitOfWork.Product.GetById(id);
			ClientProductList = mapper.Map<List<ClientProductViewModel>>
				(Product.ClientProducts.OrderBy(c => c.Client.Code).ToList());
		}

	}
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sphinx_Commercial_Task.Data.Entities;
using Sphinx_Commercial_Task.Repository;
using Sphinx_Commercial_Task.Web.ViewModels;

namespace Sphinx_Commercial_Task.Web.Pages.Clients
{
	public class DetailsModel(IUnitOfWork unitOfWork, IMapper mapper) : PageModel
	{
		public Client Client { get; set; }
		public List<ClientProductViewModel> ClientProductList { get; set; }

		public void OnGet(int id)
		{
			Client = unitOfWork.Client.GetById(id);
			ClientProductList = mapper.Map<List<ClientProductViewModel>>
				(Client.ClientProducts.OrderBy(c => c.Product.Name).ToList());
		}
	}
}

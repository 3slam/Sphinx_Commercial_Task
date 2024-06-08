using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sphinx_Commercial_Task.Data.Entities;
using Sphinx_Commercial_Task.Repository;

namespace Sphinx_Commercial_Task.Web.Pages.Clients
{
	[BindProperties]
	public class ListAllClientsModel(IUnitOfWork unitOfWork) : PageModel
	{
		public List<Client> Clients { get; set; }
		public void OnGet() => Clients = unitOfWork.Client
			.GetTableNoTracking().
			 OrderBy(c => c.Code).ToList();

	}
}

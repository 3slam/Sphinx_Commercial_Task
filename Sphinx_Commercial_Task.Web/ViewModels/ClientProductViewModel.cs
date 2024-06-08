using Sphinx_Commercial_Task.Data.Entities;

namespace Sphinx_Commercial_Task.Web.ViewModels
{
	public class ClientProductViewModel
	{
		public Product Product { get; set; }

		public Client Client { get; set; }
		public DateTime StartDate { get; set; }

		public DateTime? EndDate { get; set; }

		public string License { get; set; }
	}
}

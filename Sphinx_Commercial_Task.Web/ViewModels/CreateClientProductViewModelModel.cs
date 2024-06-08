using System.ComponentModel.DataAnnotations;

namespace Sphinx_Commercial_Task.Web.ViewModels
{
	public class CreateClientProductViewModel
	{
		[Required]
		public int ProductId { get; set; }
		[Required]
		public int ClientId { get; set; }
		[Required]

		public DateTime StartDate { get; set; } = DateTime.Now;
		public DateTime? EndDate { get; set; }

		[Required]
		[StringLength(255)]
		public string License { get; set; }


	}
}

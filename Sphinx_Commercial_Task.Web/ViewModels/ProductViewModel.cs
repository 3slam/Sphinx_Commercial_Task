using System.ComponentModel.DataAnnotations;

namespace Sphinx_Commercial_Task.Web.ViewModels
{
	public class ProductViewModel
	{


		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[Required]
		[StringLength(150)]
		public string Description { get; set; }

		[Required]
		public bool IsActive { get; set; }


	}
}

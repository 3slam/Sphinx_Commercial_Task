using System.ComponentModel.DataAnnotations;

namespace Sphinx_Commercial_Task.Web.ViewModels
{
    public class EditClientViewModel
    {

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(9)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Code must be a number")]
        public string Code { get; set; }

        [Required]
        public char Class { get; set; }

        [Required]
        public string State { get; set; }
    }
}

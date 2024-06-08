using Sphinx_Commercial_Task.Repository;
using System.ComponentModel.DataAnnotations;

namespace Sphinx_Commercial_Task.Web.Validations
{
    public class UniqueCodeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var unitOfWork = (IUnitOfWork)validationContext.GetService(typeof(IUnitOfWork));
                var existingCode = unitOfWork.Client.GetTableNoTracking()
                    .Where(cp => cp.Code == value.ToString()).Count();

                if (existingCode != 0)
                {
                    return new ValidationResult("Code must be unique.");
                }
            }
            return ValidationResult.Success;
        }
    }
}

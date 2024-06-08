using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sphinx_Commercial_Task.Data.Entities;
using Sphinx_Commercial_Task.Repository;

namespace Sphinx_Commercial_Task.Web.Pages.ClientProducts
{
    [BindProperties]
    public class DeleteModel(IUnitOfWork unitOfWork) : PageModel
    {
        public ClientProduct ClientProduct { get; set; }
        public void OnGet(int id) => ClientProduct = unitOfWork.ClientProduct.GetById(id);


        public async Task<IActionResult> OnPost()
        {
            var clientFromDb = unitOfWork.ClientProduct.GetById(ClientProduct.Id);
            if (clientFromDb != null)
            {
                await unitOfWork.ClientProduct.DeleteAsync(clientFromDb);
                await unitOfWork.SaveChangesAsync();
                TempData["success"] = "ClientProduct deleted successfully";
                return RedirectToPage("ListAllClientProduct");
            }

            return Page();
        }
    }
}

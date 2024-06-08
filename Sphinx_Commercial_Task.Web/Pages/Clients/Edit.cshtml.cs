using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sphinx_Commercial_Task.Data.Entities;
using Sphinx_Commercial_Task.Repository;
using Sphinx_Commercial_Task.Web.ViewModels;

namespace Sphinx_Commercial_Task.Web.Pages.Clients


{
    [BindProperties]
    public class EditModel(IUnitOfWork unitOfWork, IMapper mapper) : PageModel
    {
        public List<SelectListItem> States { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Active", Text = "Active" },
            new SelectListItem { Value = "Inactive", Text = "Inactive" },
            new SelectListItem { Value = "Pending", Text = "Pending" }
        };
        public List<SelectListItem> Classes { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "A", Text = "A" },
            new SelectListItem { Value = "B", Text = "B" },
            new SelectListItem { Value = "C", Text = "C" }
        };
        public int ClientId { get; set; }

        public EditClientViewModel Client { get; set; }
        public void OnGet(int id)
        {
            Client = mapper.Map<EditClientViewModel>(unitOfWork.Client.GetById(id));
            ClientId = id;
        }


        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {
                Client updatedClient = mapper.Map<Client>(Client);

                updatedClient.Id = ClientId;
                await unitOfWork.Client.UpdateAsync(updatedClient);
                await unitOfWork.SaveChangesAsync();
                TempData["success"] = "Client updated successfully";
                return RedirectToPage("ListAllClients");
            }
            return Page();
        }
    }
}

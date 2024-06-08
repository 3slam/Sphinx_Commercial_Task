using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sphinx_Commercial_Task.Data.Entities;
using Sphinx_Commercial_Task.Repository;
using Sphinx_Commercial_Task.Web.ViewModels;

namespace Sphinx_Commercial_Task.Web.Pages.ClientProducts
{
    [BindProperties]
    public class EditModel(IUnitOfWork unitOfWork, IMapper mapper) : PageModel
    {

        public EditClientProductViewModel ClientProduct { get; set; }
        public List<SelectListItem> Products { get; set; }
        public List<SelectListItem> Clients { get; set; }

        public async Task OnGetAsync(int id)
        {
            ClientProduct = mapper.Map<EditClientProductViewModel>(unitOfWork.ClientProduct.GetById(id));
            Products = await unitOfWork.Product.GetTableNoTracking().Where(p => p.IsActive == true)
               .Select(p => new SelectListItem
               {
                   Value = p.Id.ToString(),
                   Text = p.Name
               }).ToListAsync();

            Clients = await unitOfWork.Client.GetTableNoTracking()
               .Select(c => new SelectListItem
               {
                   Value = c.Id.ToString(),
                   Text = c.Name
               }).ToListAsync();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.ClientProduct.UpdateAsync(mapper.Map<ClientProduct>(ClientProduct));
                await unitOfWork.SaveChangesAsync();
                TempData["success"] = "Client Product updated successfully";
                return RedirectToPage("ListAllClientproduct");
            }
            return Page();
        }
    }

}
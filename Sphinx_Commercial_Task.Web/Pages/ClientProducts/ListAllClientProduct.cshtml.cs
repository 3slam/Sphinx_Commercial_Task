using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sphinx_Commercial_Task.Data.Entities;
using Sphinx_Commercial_Task.Repository;

namespace Sphinx_Commercial_Task.Web.Pages.ClientProducts
{
    [BindProperties]
    public class ListAllClientProductModel(IUnitOfWork unitOfWork) : PageModel
    {

        public List<ClientProduct> ClientProducts { get; set; }
        public void OnGet() => ClientProducts = unitOfWork.ClientProduct
                  .GetTableNoTracking().ToList();

    }
}

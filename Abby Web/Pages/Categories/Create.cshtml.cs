using Abby_Web.Data;
using Abby_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby_Web.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]  // we can also add this annotation at class level if we have multiple properties
        public Category Category { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "Name and Display order sholud not be the same.");
            }
            if(ModelState.IsValid)
            {
                await _db.categories.AddAsync(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category is created sccessfully..!";
                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}

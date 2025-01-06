using CarsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarsApp.Pages.Cars
{

    public class ReserveModel : PageModel
    {
        private readonly CarsApp.Data.CarDbContext _context;

        public ReserveModel(CarsApp.Data.CarDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Car? Car { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Car != null)
            {
                _context.Cars.Add(Car);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }

}

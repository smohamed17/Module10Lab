using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VirtualPetAdoption.Data;
using VirtualPetAdoption.Models;
 
namespace VirtualPetAdoption.Pages
{ // this is a new instance of the context of the database being created. 
    public class IndexModel : PageModel
    {
        private readonly PetAdoptionContext _context;
 // there is a initializing the new database context object 
 // that we have created and pet adoption context was created by the service of the application.

        public IndexModel(PetAdoptionContext context)
        {
            _context = context;
        }
 // using the attributes of the classes of the energypreference, name, and match. 

        [BindProperty]
        public string Name { get; set; } = "";
 // using the energy level they want to see in a pet
        [BindProperty]
        public int EnergyPreference { get; set; }
 // using the pet object to see if the pet matches. 
        public Pet? Match { get; set; }
 // onget will get the called during the page loaded up . 
        public void OnGet()
        {
        }
 // using the onpost method to get called when the user clicks submit on the form. 
        public void OnPost()
        {
            // The best match is the pet with the closest energy level.
            // it will subtract the pet's energy level from the user's preferred energy level. 
            // it will grab the first pet in the result set since they're the best match. 
            Match = _context.Pets
                .OrderBy(p => Math.Abs(p.EnergyLevel - EnergyPreference))
                .First();
        }
    }
}

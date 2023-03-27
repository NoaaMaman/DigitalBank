<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
=======
﻿using Microsoft.AspNetCore.Mvc;
>>>>>>> 6b020f7139a3606cc80faecac92a2003862d6710
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
<<<<<<< HEAD
    [Authorize]
    public class IndexModel : PageModel
    {
       
=======
    public class IndexModel : PageModel
    {
>>>>>>> 6b020f7139a3606cc80faecac92a2003862d6710
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
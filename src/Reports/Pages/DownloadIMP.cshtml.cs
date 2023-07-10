using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Reports.Pages
{
    public class DownloadModelIMP : PageModel
    {
        private readonly IWebHostEnvironment _env;

        public DownloadModelIMP(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult OnGet()
        {
            var filePath = Path.Combine(_env.ContentRootPath, "ImpactFactor.xls");

            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes, "application/force-download", "ImpactFactor.xls");
        }
    }
}

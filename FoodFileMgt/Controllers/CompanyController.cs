using FoodFileMgt.Services.Interfaces;
using FoodFileMgt.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodFileMgt.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyViewModel model)
        {
            var response = await _companyService.CreateCompanyAsync(model);
            if(response.Status)
            {
                return RedirectToAction("Home","Index");
            }
            return View(model);
        }
    }
}

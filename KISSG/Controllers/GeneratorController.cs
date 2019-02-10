using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KISSG.Templates.OnePageSite;
using KISSG.Services;

namespace KISSG.Controllers
{   
    public class GeneratorController : Controller
    {
        private HtmlGeneratorService service = new HtmlGeneratorService();
        
        public IActionResult Index()
        {
            return View();
        }
    
        [HttpGet]
        public IActionResult WelcomeTemplate()
        {
            return View("CreateWelcome");
        }

        
        [HttpPost]
        public async Task<IActionResult> WelcomeTemplate([Bind("SiteName,FirstSectionColor,LogoUrl,Motto,MottoColor," +
            "MainSectionBgColor,MainSectionTxtColor,MainSection,PictureUrl,Projects,ContactSectionBgColor," +
            "ContactSectionTxtColor,Email,Phone,Address")] Welcome welcome)
        {
            if (ModelState.IsValid)
            {
               await service.GenerateHtmlResponse(welcome, Response);
            }
            
            return View("Index");
        }
        
    }
}

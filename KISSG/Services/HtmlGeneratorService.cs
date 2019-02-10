using KISSG.Templates.OnePageSite;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KISSG.Services
{
    public class HtmlGeneratorService 
    {
        public async Task GenerateHtmlResponse(HtmlTemplate template, HttpResponse Response)
        {
            String pageContent = template.TransformText();
            System.IO.File.WriteAllText(template.SiteName+".html", pageContent);

            Response.Clear();
            Response.Headers.Clear();
            Response.Headers.Add("Content-Disposition", $"attachment; filename={template.SiteName}.html");
            Response.Headers.Add("Content-Length", pageContent.Length.ToString());
            Response.ContentType = "text/plain";
            await Response.SendFileAsync(template.SiteName+".html");
            System.IO.File.Delete(template.SiteName+".html");
        }
    }
}

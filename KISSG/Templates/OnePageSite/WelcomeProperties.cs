using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KISSG.Templates.OnePageSite
{
    partial class Welcome : HtmlTemplate
    {
        public string SiteName { get; set; }
        public string FirstSectionColor { get; set; }
        public string LogoUrl { get; set; }
        public string Motto { get; set; }
        public string MottoColor { get; set; }
        public string MainSectionBgColor { get; set; }
        public string MainSectionTxtColor { get; set; }
        public string MainSection { get; set; }
        public string PictureUrl { get; set; }
        public List<string> Projects { get; set; }
        public string ContactSectionBgColor { get; set; }
        public string ContactSectionTxtColor { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        
    }
}

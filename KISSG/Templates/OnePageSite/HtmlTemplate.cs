namespace KISSG.Templates.OnePageSite
{
    public interface HtmlTemplate
    {
         string SiteName { get; set; }
         string TransformText();
    }
}
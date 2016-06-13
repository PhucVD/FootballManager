using System.Web.Mvc;

namespace FootballManager.Web.Extensions
{
    public static class HtmlExtension
    {
        public static MvcHtmlString AjaxButton(this HtmlHelper helper, string label, AjaxButtonOptions options, object htmlAttributes = null)
        {
            TagBuilder tabBuilder = new TagBuilder("button");
            tabBuilder.MergeAttribute("type", "button");
            tabBuilder.MergeAttribute("class", "ajax-button");
            tabBuilder.AddCssClass(options.CssClass);

            tabBuilder.MergeAttribute("data-url", options.Url);
            tabBuilder.MergeAttribute("data-method", options.Method.ToUpper());
            tabBuilder.MergeAttribute("data-target-id", options.TargetId);
            tabBuilder.SetInnerText(label);
            if (htmlAttributes != null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                tabBuilder.MergeAttributes(attributes);
            }

            return new MvcHtmlString(tabBuilder.ToString());
        }
    }

    public class AjaxButtonOptions
    {
        public string Url { get; set; }
        public string Method { get; set; }
        public string TargetId { get; set; }
        public string CssClass { get; set; }

    }
}
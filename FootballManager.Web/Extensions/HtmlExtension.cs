using System;
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

        public static MvcHtmlString Xeditable(this HtmlHelper helper, XeditableOptions options, object htmlAttributes = null)
        {
            TagBuilder tabBuilder = new TagBuilder("a");
            tabBuilder.MergeAttribute("href", "#");
            tabBuilder.MergeAttribute("class", "editable editable-click");
            tabBuilder.AddCssClass(options.CssClass);

            tabBuilder.MergeAttribute("data-url", options.Url);
            tabBuilder.MergeAttribute("data-type", options.GetXeditableType());
            tabBuilder.MergeAttribute("data-pk", options.Pk);
            tabBuilder.SetInnerText(options.Value);
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

    public class XeditableOptions
    {
        public string Url { get; set; }
        public XeditableType Type { get; set; }
        public string Pk { get; set; }
        public string Value { get; set; }
        public string CssClass { get; set; }

        public string GetXeditableType()
        {
            string type = "text";
            switch (Type)
            {
               case XeditableType.Text:
                    type = "text";
                    break;
                case XeditableType.Select2:
                    type = "select2";
                    break;
            }
            
            return type;
        }
    }

    public enum XeditableType
    {
        Text = 1,
        Select2,
        DateTime
    }
}
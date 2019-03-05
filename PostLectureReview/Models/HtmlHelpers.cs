using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLectureReview.Models
{
    public static class HtmlHelpers
    {
        public static IHtmlContent RemoveLink(this IHtmlHelper htmlHelper, string linkText, string container, string deleteElement)
        {
            var js = string.Format("javascript:removeNestedForm(this,'{0}', '{1}'); return false;",
                            container, deleteElement);
            TagBuilder tb = new TagBuilder("a");
            tb.Attributes.Add("href", "#");
            tb.Attributes.Add("onclick", js);
            tb.TagRenderMode = TagRenderMode.Normal;
            tb.InnerHtml.Append(linkText);
            HtmlContentBuilder result = new HtmlContentBuilder();
            return result.AppendHtml(tb);
        }

        public static IHtmlContent AddLink<T>(this IHtmlHelper<T> htmlHelper, string linkText, string container, string counter, string collection, Type nestedType)
        {
            var ticks = DateTime.UtcNow.Ticks;
            System.Diagnostics.Debug.WriteLine("\n");
            var nestedObject = Activator.CreateInstance(nestedType);
            var temp = htmlHelper.EditorFor(x => nestedObject);
            var step1 = temp.ToString();
            var step2 = step1.JsEncode();
            System.Diagnostics.Debug.WriteLine("input: " + htmlHelper + ", " + linkText + ", " + container + ", " + counter + ", " + collection + ", " + nestedType);
            System.Diagnostics.Debug.WriteLine("HtmlHelper: " + temp);
            System.Diagnostics.Debug.WriteLine("ToString: " + step1);
            System.Diagnostics.Debug.WriteLine("JsEncode: " + step2);
            System.Diagnostics.Debug.WriteLine("\n");
            var partial = step2;
            partial = partial.Replace("id=\\\"nestedObject", "id=\\\"" 
                              + collection + "_" + ticks + "_");
            partial = partial.Replace("name=\\\"nestedObject", "name=\\\"" 
                              + collection + "[" + ticks + "]");
            var js = string.Format("javascript:addNestedForm('{0}', '{1}', '{2}', '{3}'); return false;", 
                            container, counter, ticks, partial);
            TagBuilder tb = new TagBuilder("a");
            tb.Attributes.Add("href", "#");
            tb.Attributes.Add("onclick", js);
            tb.TagRenderMode = TagRenderMode.Normal;
            tb.InnerHtml.Append(linkText);
            HtmlContentBuilder result = new HtmlContentBuilder();
            return result.AppendHtml(tb);
        }

        private static string JsEncode(this string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            int i;
            int len = s.Length;
            StringBuilder sb = new StringBuilder(len + 4);
            string t;
            for (i = 0; i < len; i += 1)
            {
                char c = s[i];
                switch (c)
                {
                    case '>':
                    case '"':
                    case '\\':
                        sb.Append('\\');
                        sb.Append(c);
                        break;
                    case '\b':
                        sb.Append("\\b");
                        break;
                    case '\t':
                        sb.Append("\\t");
                        break;
                    case '\n':
                        break;
                    case '\f':
                        sb.Append("\\f");
                        break;
                    case '\r':
                        break;
                    default:
                        if (c < ' ')
                        {
                            string tmp = new string(c, 1);
                            t = "000" + int.Parse(tmp, System.Globalization.NumberStyles.HexNumber);
                            sb.Append("\\u" + t.Substring(t.Length - 4));
                        }
                        else
                        {
                            sb.Append(c);
                        }
                        break;
                }
            }
            return sb.ToString();
        }
    }
}

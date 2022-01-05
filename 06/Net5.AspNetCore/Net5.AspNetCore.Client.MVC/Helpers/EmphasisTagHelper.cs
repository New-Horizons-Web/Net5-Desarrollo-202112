using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Net5.AspNetCore.Client.MVC.Helpers
{    
    [HtmlTargetElement("emphasis",TagStructure=TagStructure.NormalOrSelfClosing)]
    public class EmphasisTagHelper:TagHelper
    {
        public string MyParameter { get; set; } //my-parameter

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "strong";
            output.Content.SetHtmlContent(MyParameter);
        }

        //my-parameter="erick"
        //<strong>erick</strong>
    }

}

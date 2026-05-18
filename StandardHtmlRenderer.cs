namespace Task_5
{
    public class StandardHtmlRenderer : HtmlRenderer
    {
        protected override string OpenTag(LightElementNode element)
        {
            return "<" + element.TagName + element.GetClasses();
        }

        protected override string CloseTag(LightElementNode element)
        {
            return "</" + element.TagName + ">";
        }

        protected override bool IsSelfClosing(LightElementNode element)
        {
            return element.ClosingType == "single";
        }
    }
}

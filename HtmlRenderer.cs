namespace Task_5
{
    public abstract class HtmlRenderer
    {
        public string Render(LightElementNode element, int indent = 0)
        {
            string space = new string(' ', indent);

            if (IsSelfClosing(element))
            {
                return space + OpenTag(element) + "/>";
            }

            var result = space + OpenTag(element) + ">\n";

            foreach (var child in element.GetChildren())
            {
                result += RenderChild(child, indent + 2) + "\n";
            }

            result += space + CloseTag(element);

            return result;
        }

        protected virtual string RenderChild(LightNode child, int indent)
        {
            return child.OuterHTML(indent);
        }

        protected abstract string OpenTag(LightElementNode element);
        protected abstract string CloseTag(LightElementNode element);
        protected abstract bool IsSelfClosing(LightElementNode element);
    }
}

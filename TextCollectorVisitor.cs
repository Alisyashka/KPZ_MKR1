namespace Task_5
{
    public class TextCollectorVisitor : ILightNodeVisitor
    {
        public string Text { get; private set; } = "";

        public void VisitElement(LightElementNode element)
        {

        }

        public void VisitText(LightTextNode textNode)
        {
            Text += textNode.InnerHTML() + " ";
        }
    }
}

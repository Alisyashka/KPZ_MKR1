namespace Task_5
{
    public class CountVisitor : ILightNodeVisitor
    {
        public int ElementCount { get; private set; } = 0;
        public int TextCount { get; private set; } = 0;

        public void VisitElement(LightElementNode element)
        {
            ElementCount++;
        }

        public void VisitText(LightTextNode textNode)
        {
            TextCount++;
        }
    }
}

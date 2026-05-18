namespace Task_5
{
    public interface ILightNodeVisitor
    {
        void VisitElement(LightElementNode element);
        void VisitText(LightTextNode textNode);
    }
}

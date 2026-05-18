namespace Task_5
{
    public class VisibleState : IElementState
    {
        public string HandleRender(LightElementNode element, int indent)
        {
            return element.DefaultOuterHTML(indent);
        }

        public void HandleEvent(LightElementNode element, string eventName)
        {
            element.DefaultTriggerEvent(eventName);
        }
    }
}
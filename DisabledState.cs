namespace Task_5
{
    public class DisabledState : IElementState
    {
        public string HandleRender(LightElementNode element, int indent)
        {
            return element.DefaultOuterHTML(indent);
        }

        public void HandleEvent(LightElementNode element, string eventName)
        {
            Console.WriteLine("Element is disabled. Event ignored.");
        }
    }
}
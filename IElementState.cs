namespace Task_5
{
    public interface IElementState
    {
        string HandleRender(LightElementNode element, int indent);
        void HandleEvent(LightElementNode element, string eventName);
    }
}
namespace Task_5
{
    public class HiddenState : IElementState
    {
        public string HandleRender(LightElementNode element, int indent)
        {
            return ""; 
        }

        public void HandleEvent(LightElementNode element, string eventName)
        {

        }
    }
}
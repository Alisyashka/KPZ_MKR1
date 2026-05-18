namespace Task_5
{
    public class LightTextNode : LightNode
    {
        private string text;

        public LightTextNode(string text)
        {
            this.text = text;
        }

        public override string OuterHTML(int indent = 0)
        {
            return text;
        }

        public override string InnerHTML()
        {
            return text;
        }
    }
}
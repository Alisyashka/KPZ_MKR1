using System.Text;

namespace Task_5
{
    public class LightElementNode : LightNode
    {
        public string TagName;
        private string displayType;
        public string ClosingType;
        private IElementState state = new VisibleState();

        private List<string> classes = new List<string>();
        private List<LightNode> children = new List<LightNode>();
        public List<LightNode> GetChildren()
        {
            return children;
        }

        public void SetState(IElementState newState)
        {
            state = newState;
        }

        public string GetClasses()
        {
            if (classes.Count == 0)
                return "";

            return " class=\"" + string.Join(" ", classes) + "\"";
        }

        private Dictionary<string, List<ICommand>> events =
        new Dictionary<string, List<ICommand>>();

        public LightElementNode(string tagName, string displayType, string closingType)
        {
            this.TagName = tagName;
            this.displayType = displayType;
            this.ClosingType = closingType;
        }

        public void AddClass(string className)
        {
            classes.Add(className);
        }

        public void AddChild(LightNode node)
        {
            children.Add(node);
        }

        public int ChildCount()
        {
            return children.Count;
        }

        public void AddEventListener(string eventName, ICommand command)
        {
            if (!events.ContainsKey(eventName))
            {
                events[eventName] = new List<ICommand>();
            }

            events[eventName].Add(command);
        }

        public void DefaultTriggerEvent(string eventName)
        {
            if (events.ContainsKey(eventName))
            {
                foreach (var command in events[eventName])
                {
                    command.Execute();
                }
            }
            else
            {
                Console.WriteLine("Event not found: " + eventName);
            }
        }

        public void TriggerEvent(string eventName)
        {
            state.HandleEvent(this, eventName);
        }

        private HtmlRenderer renderer = new StandardHtmlRenderer();

        public void SetRenderer(HtmlRenderer newRenderer)
        {
            renderer = newRenderer;
        }

        public override string OuterHTML(int indent = 0)
        {
            return state.HandleRender(this, indent);
        }

        public string RenderWithTemplate(int indent = 0)
        {
            return renderer.Render(this, indent);
        }

        public override string InnerHTML()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var child in children)
            {
                sb.Append(child.OuterHTML());
            }

            return sb.ToString();
        }

        public string DefaultOuterHTML(int indent = 0)
        {
            string space = new string(' ', indent);

            if (ClosingType == "single")
            {
                return space + "<" + TagName + GetClasses() + "/>";
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(space + "<" + TagName + GetClasses() + ">");

            foreach (var child in children)
            {
                if (child is LightTextNode)
                {
                    sb.AppendLine(new string(' ', indent + 2) + child.OuterHTML());
                }
                else
                {
                    sb.AppendLine(child.OuterHTML(indent + 2));
                }
            }

            sb.Append(space + "</" + TagName + ">");

            return sb.ToString();
        }
        public override void Accept(ILightNodeVisitor visitor)
        {
            visitor.VisitElement(this);

            foreach (var child in children)
            {
                child.Accept(visitor);
            }
        }
    }
}
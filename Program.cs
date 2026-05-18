using Task_5.Task_5;

namespace Task_5
{
    internal class Program
    {
        static void Main()
        {
            var root = new LightElementNode("div", "block", "paired");

            var button = new LightElementNode("button", "inline", "paired");
            button.AddChild(new LightTextNode("Click me"));

            // Command pattern
            button.AddEventListener("click", new ClickCommand());
            button.AddEventListener("click", new SecondClickCommand());

            var span = new LightElementNode("span", "inline", "paired");
            span.AddChild(new LightTextNode("Hello"));

            root.AddChild(button);
            root.AddChild(span);

            Console.WriteLine("HTML:");
            Console.WriteLine(root.OuterHTML());

            Console.WriteLine("\nTrigger click:");
            button.TriggerEvent("click");

            // Iterator
            Console.WriteLine("\n=== DFS ===");
            ILightIterator dfs = new DepthFirstIterator(root);

            while (dfs.HasNext())
            {
                Console.WriteLine(dfs.Next().GetType().Name);
            }

            Console.WriteLine("\n=== BFS ===");
            ILightIterator bfs = new BreadthFirstIterator(root);

            while (bfs.HasNext())
            {
                Console.WriteLine(bfs.Next().GetType().Name);
            }

            Console.WriteLine("\n--- STATE DEMO ---");

            // Hidden
            button.SetState(new HiddenState());
            Console.WriteLine("Hidden button:");
            Console.WriteLine(root.OuterHTML());

            // Disabled
            button.SetState(new DisabledState());
            Console.WriteLine("\nDisabled button click:");
            button.TriggerEvent("click");

            // Back to normal
            button.SetState(new VisibleState());
            Console.WriteLine("\nVisible button:");
            Console.WriteLine(root.OuterHTML());

            Console.WriteLine("\n--- TEMPLATE METHOD DEMO ---");

            var customRenderer = new StandardHtmlRenderer();
            root.SetRenderer(customRenderer);

            Console.WriteLine(root.RenderWithTemplate());
        }
    }
}
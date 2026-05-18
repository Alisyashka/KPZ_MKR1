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

            var span = new LightElementNode("span", "inline", "paired");
            span.AddChild(new LightTextNode("Hello"));

            root.AddChild(button);
            root.AddChild(span);

            Console.WriteLine("=== DFS ===");
            ILightIterator dfs = new DepthFirstIterator(root);

            while (dfs.HasNext())
            {
                var node = dfs.Next();
                Console.WriteLine(node.GetType().Name);
            }

            Console.WriteLine("\n=== BFS ===");
            ILightIterator bfs = new BreadthFirstIterator(root);

            while (bfs.HasNext())
            {
                var node = bfs.Next();
                Console.WriteLine(node.GetType().Name);
            }
        }
    }
}
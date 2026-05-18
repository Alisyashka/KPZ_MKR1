namespace Task_5
{
    using System.Collections.Generic;

    namespace Task_5
    {
        public class BreadthFirstIterator : ILightIterator
        {
            private Queue<LightNode> queue = new Queue<LightNode>();

            public BreadthFirstIterator(LightNode root)
            {
                queue.Enqueue(root);
            }

            public bool HasNext()
            {
                return queue.Count > 0;
            }

            public LightNode Next()
            {
                var current = queue.Dequeue();

                if (current is LightElementNode element)
                {
                    foreach (var child in element.GetChildren())
                    {
                        queue.Enqueue(child);
                    }
                }

                return current;
            }
        }
    }
}

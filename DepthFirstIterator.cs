using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
{
    using System.Collections.Generic;

    namespace Task_5
    {
        public class DepthFirstIterator : ILightIterator
        {
            private Stack<LightNode> stack = new Stack<LightNode>();

            public DepthFirstIterator(LightNode root)
            {
                stack.Push(root);
            }

            public bool HasNext()
            {
                return stack.Count > 0;
            }

            public LightNode Next()
            {
                var current = stack.Pop();

                if (current is LightElementNode element)
                {
                    var children = element.GetChildren();

                    for (int i = children.Count - 1; i >= 0; i--)
                    {
                        stack.Push(children[i]);
                    }
                }

                return current;
            }
        }
    }
}

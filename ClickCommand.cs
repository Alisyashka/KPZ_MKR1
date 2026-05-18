namespace Task_5
{
    namespace Task_5
    {
        public class ClickCommand : ICommand
        {
            public void Execute()
            {
                Console.WriteLine("Button clicked!");
            }
        }

        public class SecondClickCommand : ICommand
        {
            public void Execute()
            {
                Console.WriteLine("Second click handler!");
            }
        }

        public class MouseOverCommand : ICommand
        {
            public void Execute()
            {
                Console.WriteLine("Mouse over button!");
            }
        }
    }
}

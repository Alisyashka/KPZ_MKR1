namespace Task_5
{
    internal class Program
    {
        static void Main()
        {
            LightElementNode button =
                new LightElementNode("button", "inline", "paired");

            button.AddClass("btn");
            button.AddChild(new LightTextNode("Press me"));

            button.AddEventListener("click", () =>
            {
                Console.WriteLine("Button clicked!");
            });

            button.AddEventListener("click", () =>
            {
                Console.WriteLine("Second click handler!");
            });

            button.AddEventListener("mouseover", () =>
            {
                Console.WriteLine("Mouse over button!");
            });

            Console.WriteLine("HTML:");
            Console.WriteLine(button.OuterHTML());

            Console.WriteLine("\nTrigger click:");
            button.TriggerEvent("click");

            Console.WriteLine("\nTrigger mouseover:");
            button.TriggerEvent("mouseover");

            Console.WriteLine("\nTrigger keydown:");
            button.TriggerEvent("keydown");
        }
    }
}
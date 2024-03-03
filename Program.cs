//----c# II (Dor Ben Dor) ----
//       Noga Levkovitz
//---------------------------

namespace DlegentsHomework
{
    internal class Program
    {
        public delegate void PublicDelegate();

        static void Main(string[] args)
        {
            Predicate<string> predicate = x => x.Contains("s");
            ObservableLimitedList observableList = new ObservableLimitedList(predicate);
            PublicDelegate publicDelegate = () => Console.WriteLine("Public delegate called.");

            observableList.ListChanged += items => Console.WriteLine("List changed. Items: " + string.Join(", ", items));
            observableList.ListChanged += items => publicDelegate.Invoke();

            int sCount = 0;
            for (int i = 0; i < 10; i++)
            {
                string newItem;
                if (sCount < 3 && i < 3)
                {
                    newItem = "Item" + i + "s";
                    sCount++;
                }
                else
                {
                    newItem = "Item" + i;
                }

                observableList.TryAdd(newItem);
            }

            Console.WriteLine("Total items containing 's': " + sCount);
            Console.WriteLine("All items:");
            observableList.PrintAll();
        }
    }
}
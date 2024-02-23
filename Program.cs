//----c# II (Dor Ben Dor) ----
//       Noga Levkovitz
//---------------------------

namespace DlegentsHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> predicate = x => x.Contains("s");
            ObservableLimitedList observableList = new ObservableLimitedList(predicate);

            observableList.ListChanged += items => Console.WriteLine("List changed. Items: " + string.Join(", ", items));

            int sCount = 0;
            for (int i = 0; i < 10; i++)
            {
                string newItem = "Items" + i;
                if (newItem.Contains("s") && sCount < 4)
                {
                    sCount++;
                }

                if(sCount > 3)
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
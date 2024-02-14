using System.ComponentModel;

namespace DlegentsHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ObservableLimitedList A_list = new ObservableLimitedList();

            Predicate<string> predicate = A_list.ContainsS;

            ObservableLimitedList observableList = new ObservableLimitedList();

            observableList.ListChanged += A_list.ListChangedHandler;

            int sItemsCount = 0;
            for (int i = 0; i <= 10; i++)
            {
                string newItem = "Item" + i;
                if (A_list.ContainsS(newItem))
                {
                    sItemsCount++;
                    A_list.TryAdd(newItem);
                }

                if (sItemsCount == 3)
                {
                    Console.WriteLine("All items added:");
                    A_list.PrintAll();
                }
                
                else
                {
                    Console.WriteLine("The words don't meet the requirements");
                }
            }
        }
    }
}
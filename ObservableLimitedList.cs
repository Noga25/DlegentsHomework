using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DlegentsHomework
{
    class ObservableLimitedList
    {
        List<string> list = new List<string>() { };
        public event Action<string> ListChanged;
        private Predicate<string> _Predicate;

        public bool ContainsS(string userName)
        {
            return userName.Contains("s");
        }

        public void Observable_Limited_List(Predicate<string> predicate)
        {
            _Predicate = predicate;
        }

        public bool TryAdd(string userName)
        {
            if (ContainsS(userName))
            {
                list.Add(userName);
                OnListChanged(userName);
                return true;
            }

            return false;
        }

        private void OnListChanged(string message)
        {
            ListChanged?.Invoke(message);
        }

        public void ListChangedHandler(string userName)
        {
            Console.WriteLine($"List changed. Item added: {userName}");
        }

        public void PrintAll()
        {
            foreach (var iteams in list)
            {
                Console.WriteLine(iteams);
            }
        }
    }
}

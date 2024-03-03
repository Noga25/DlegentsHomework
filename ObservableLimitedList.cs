﻿//----c# II (Dor Ben Dor) ----
//       Noga Levkovitz
//---------------------------

namespace DlegentsHomework
{
    class ObservableLimitedList
    {
        private Predicate<string> _predicate;
        private List<string> _list;

        public event Action<List<string>> ListChanged;

        public ObservableLimitedList(Predicate<string> predicate)
        {
            _predicate = predicate;
            _list = new List<string>();
        }

        public bool TryAdd(string item)
        {
            if (_predicate(item))
            {
                _list.Add(item);
                OnListChanged();
                return true;
            }
            return false;
        }

        public void PrintAll()
        {
            foreach (var item in _list)
            {
                Console.WriteLine(item);
            }
        }

        private void OnListChanged()
        {
            ListChanged?.Invoke(_list);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListProject
{
    public class CustomList<T>
    {
        private int count;
        private int capacity;
        public T[] items;

        public CustomList()
        {
            items = new T[4];
            count = 0;
            capacity = 4;
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }
        }

        public T this[int i]
        {
            get
            {
                return items[i];
            }
            set
            {
                items[i] = value;
            }
        }

        public void AddItem(T item, CustomList<T> items)
        {
            T[] tempList = new T[items.Capacity]; 
            if(items.Count >= items.Capacity)
            {
                tempList = items;

            }
        }

        public void RemoveItem(T item)
        {

        }

        public override string ToString()
        {
            string listToString = "hello";

            return listToString;
        }

        public void ZipLists()
        {

        }
    }
}

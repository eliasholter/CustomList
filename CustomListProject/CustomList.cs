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

        public void AddItem(T item)
        {
            if(Count >= Capacity)
            {
                NeedsDoubleCapacity(item);
            }
            else
            {
                items[Count] = item;
                count += 1;
            }
        }

        public void NeedsDoubleCapacity(T item)
        {
            T[] tempList = new T[capacity *= 2];
            for (int i = 0; i < Count - 1; i++)
            {
                tempList[i] = items[i];
            }
            tempList[Count + 1] = item;
            count += 1;
            items = tempList;
        }

        public void RemoveItem(T item)
        {

        }

        public override string ToString()
        {
            string newString = "";

            return newString;
        }

        public void ZipLists()
        {

        }
    }
}

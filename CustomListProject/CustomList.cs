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

        public CustomList(int initialCapacity)
        {
            items = new T[initialCapacity];
            count = 0;
            capacity = initialCapacity;
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
            T[] tempList = new T[capacity *= 2]; 
            if(Count >= Capacity)
            {
                for (int i = 0; i < Capacity - 1; i++)
                {
                    tempList[i] = items[i];
                }
                items = tempList;

                
            }
            else
            {
                items[Count + 1] = item;
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

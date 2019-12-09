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

            for (int i = 0; i < Count; i++)
            {
                tempList[i] = items[i];
            }

            tempList[Count] = item;
            count += 1;
            items = tempList;
        }

        public void RemoveItem(T item)
        {
            int i = 0;
            int j = 0;
            T[] tempList = new T[capacity];

            while(!EqualityComparer<T>.Default.Equals(items[j], item)) 
            {
                tempList[i] = items[j];
                i++;
                j++;
            }

            j++;

            while (j < Count)
            {
                tempList[i] = items[j];
                i++;
                j++;
            }

            items = tempList;
            count -= 1;
        }

        public override string ToString()
        {
            string newString = "";

            for(int i = 0; i < Count; i++)
            {
                newString = newString + items[i].ToString() + " ";
            }

            return newString;
        }

        public void ZipLists(CustomList<T> listOne, CustomList<T> listTwo)
        {
            T[] tempList;

            if(listOne.capacity > listTwo.capacity)
            {
                tempList = new T[listOne.capacity * 2];
                capacity = listOne.Capacity * 2;
            }
            else
            {
                tempList = new T[listTwo.capacity * 2];
                capacity = listTwo.Capacity * 2;
            }

            int i = 0;
            int k = 0;
            int j = 1;

            while(i < listOne.Count && i < listTwo.Count)
            {
                tempList[k] = listOne[i];
                tempList[j] = listTwo[i];

                i++;
                k+=2;
                j+=2;
            }

            if(i < listOne.Count)
            {
                while(i < listOne.Count)
                {
                    tempList[i] = listOne[i];

                    i++;
                }
            }
            else if(i < listTwo.Count)
            {
                while(i < listTwo.Count)
                {
                    tempList[i] = listTwo[i];

                    i++;
                }
            }

            items = tempList;
            count = listOne.Count + listTwo.Count;
        }
    }
}

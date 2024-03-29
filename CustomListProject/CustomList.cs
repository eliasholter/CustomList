﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListProject
{
    public class CustomList<T> : IEnumerable
    {
        private int count;
        private int capacity;
        public T[] items;

        public CustomList(int originalCapacity = 4)
        {
            items = new T[originalCapacity];
            count = 0;
            capacity = originalCapacity;
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

        public void Add(T item)
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

        public bool Remove(T item)
        {
            int j = 0;
            bool itemFound = false;
            T[] tempList = new T[capacity];

            for(int i = 0; i < Count; i++)
            {
                if(!EqualityComparer<T>.Default.Equals(items[i], item) || itemFound == true)
                {
                    tempList[j] = items[i];
                    j++;
                }
                else
                {
                    itemFound = true;
                }

            }

            if(itemFound == true)
            {
                count -= 1;
            }

            items = tempList;
            return itemFound;
        }

        public void RemoveAt(int index)
        {
            int j = 0;
            bool itemRemoved = false;
            T[] tempList = new T[capacity];
            
            for(int i = 0; i < Count; i++)
            {
                if(index == i)
                {
                    itemRemoved = true;
                }
                else
                {
                    tempList[j] = items[i];
                    j++;
                }
            }

            if(itemRemoved == true)
            {
                count -= 1;
            }

            items = tempList;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder("");
            string newString = "";

            for (int i = 0; i < Count; i++)
            {
                newString = str.Append(items[i]) + "";
            }

            return newString;
        }

        public static CustomList<T> operator +(CustomList<T> listOne, CustomList<T> listTwo)
        {
            CustomList<T> tempList = new CustomList<T>(4);

            for (int i = 0; i < listOne.Count; i++)
            {
                tempList.Add(listOne[i]);
            }
            for (int j = 0; j < listTwo.Count; j++)
            {
                tempList.Add(listTwo[j]);
            }


            return tempList;
        }

        public static CustomList<T> operator -(CustomList<T> listOne, CustomList<T> listTwo)
        {

            for(int i = 0; i < listTwo.Count; i++)
            {
               listOne.Remove(listTwo[i]);
            }

            return listOne;
        }

        public void ZipLists(CustomList<T> listTwo)
        {
            T[] tempList;
            int countOne = Count;
            int countTwo = listTwo.Count;

            if(capacity > listTwo.capacity)
            {
                tempList = new T[capacity * 2];
                capacity = Capacity * 2;
            }
            else
            {
                tempList = new T[listTwo.capacity * 2];
                capacity = listTwo.Capacity * 2;
            }

            int i = 0;
            int k = 0;
            int j = 1;

            while(i < Count && i < listTwo.Count)
            {
                tempList[k] = items[i];
                tempList[j] = listTwo[i];

                i++;
                k+=2;
                j+=2;
            }

            if(i < Count)
            {
                while(i < Count)
                {
                    j--;
                    tempList[j] = items[i];

                    i++;
                    j++;
                }
            }
            else if(i < listTwo.Count)
            {
                j--;
                while(i < listTwo.Count)
                {
                    tempList[j] = listTwo[i];

                    i++;
                    j++;
                }
            }

            items = tempList;
            count = Count + listTwo.Count;
        }

        public CustomList<T> FindAll(T item)
        {
            int j = 0;
            CustomList<T> tempList = new CustomList<T>();

            for (int i = 0; i < Count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(items[i], item))
                {
                    tempList.Add(items[i]);
                }
            }

            return tempList;
        }

        public IEnumerator GetEnumerator()
        {
            for(int i = 0; i < Count; i++)
            {
                yield return items[i];
            }
        }
    }
}

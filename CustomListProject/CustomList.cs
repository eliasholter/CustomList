using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListProject
{
    public class CustomList<T>
    {
        T[] list;
        public int count;
        public int capacity;

        public CustomList()
        {
            list = new T[4];
            count = 0;
            capacity = 4;
        }

        public void Indexer()
        {

        }

        public void AddItem(T item)
        {

        }

        public void RemoveItem(T item)
        {

        }

        public void ToString()
        {

        }

        public void ZipLists()
        {

        }
    }
}

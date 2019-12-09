using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListProject
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> list = new CustomList<int>();

            list.AddItem(0);
            list.AddItem(1);
            list.AddItem(2);
            list.AddItem(3);
            list.AddItem(4);
        }
    }
}

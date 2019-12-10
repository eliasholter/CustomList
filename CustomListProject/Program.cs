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
            CustomList<int> listOne = new CustomList<int>(4);
            CustomList<int> listTwo = new CustomList<int>(4);
            CustomList<int> newList;

            listOne.Add(1);
            listOne.Add(3);
            listOne.Add(5);
            listTwo.Add(2);
            listTwo.Add(3);
            listTwo.Add(6);

            newList = listOne - listTwo;

            Console.WriteLine(newList);
            Console.ReadLine();
        }
    }
}

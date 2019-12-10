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
            CustomList<int> testList = new CustomList<int>(4) { 3, 2, 3, 4 };
            int[] listOfThrees = testList.FindAll(3);

            foreach(int three in listOfThrees)
            {
                Console.WriteLine(three);
            }
            Console.ReadLine();

        }
    }
}

using System;
using CustomListProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrayTest
{
    [TestClass]
    public class ArrayTest_AddMethod
    {
        [TestMethod]
        public void Add_AddItemToList_CountIncreases()
        {
            CustomList<int> testList = new CustomList<int>();
            int newListItem = 3;
            int expected = testList.count + 1;

            testList.AddItem(newListItem);

            Assert.AreEqual(expected, testList.count);
        }

        [TestMethod]
        public void Add_AddItemToListWithNoMoreCapacity_CapacityDoubles()
        {
            CustomList<int> testList = new CustomList<int>();
            int newListItem = 3;
            int expected = testList.capacity * 2;

            for (int i = 0; i < 6; i++)
            {
                testList.AddItem(newListItem);
            }

            Assert.AreEqual(expected, testList.capacity);
        }
    }
}

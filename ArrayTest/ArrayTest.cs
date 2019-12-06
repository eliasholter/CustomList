using System;
using CustomListProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrayTest
{
    [TestClass]
    public class ArrayTest
    {
        // Indexer Method Tests
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_IndexRequestedOutsideOfRange_ExceptionThrown()
        {
            CustomList<int> testList = new CustomList<int>();

            int indexToCheck = testList[5];
        }

        [TestMethod]
        public void Indexer_CheckIndex_ReturnsValueThatWasRequested()
        {
            CustomList<int> testList = new CustomList<int>();
            int newListItem = 3;
            int expected = newListItem;

            testList.AddItem(newListItem);
            int actual = testList[3];

            Assert.AreEqual(expected, actual);
        }

        // Add Method Tests
        [TestMethod]
        public void Add_AddItemToList_CountIncreases()
        {
            CustomList<int> testList = new CustomList<int>();
            int newListItem = 3;
            int expected = 1;
            int actual;

            testList.AddItem(newListItem);
            actual = testList.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_AddItemToListWithNoMoreCapacity_ContainsEntireOriginalList()
        {
            CustomList<int> testList = new CustomList<int>();
            int newListItem = 3;
            int expected = 5;
            int actual;
            
            testList.AddItem(newListItem);
            testList.AddItem(newListItem);
            testList.AddItem(newListItem);
            testList.AddItem(newListItem);
            testList.AddItem(newListItem);
            actual = testList.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_AddItemToListWithNoMoreCapacity_MaintainsOriginalListOrder()
        {
            CustomList<int> testList = new CustomList<int>();
            int itemOne = 1;
            int itemTwo = 2;
            int itemThree = 3;
            int itemFour = 4;
            int itemFive = 5;
            int expected = 5;

            testList.AddItem(itemOne);
            testList.AddItem(itemTwo);
            testList.AddItem(itemThree);
            testList.AddItem(itemFour);
            testList.AddItem(itemFive);
            int actual = testList.Count;

            Assert.AreEqual(expected, );
        }

        [TestMethod]
        public void Add_AddItemToListWithNoMoreCapacity_CapacityDoubles()
        {
            CustomList<int> testList = new CustomList<int>();
            int newListItem = 3;
            int expected = testList.Capacity * 2;

            for (int i = 0; i < 6; i++)
            {
                testList.AddItem(newListItem);
            }

            Assert.AreEqual(expected, testList.Capacity);
        }

        //[TestMethod]
        //[ExpectedException(typeof(InvalidCastException))]
        //public void Add_AddItemToListOfIncompatibleType_ExceptionThrown()
        //{
        //    CustomList<string> testList = new CustomList<string>();
        //    int newListItem = 3;

        //    testList.AddItem(newListItem);
        //    //Assert.ThrowsException(typeof(ArrayTypeMismatchException);
        //}
    }
}

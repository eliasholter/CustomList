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

            testList[0] = newListItem;
            int actual = testList[0];

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

            Assert.AreEqual(expected, actual);
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
            int actual = testList.Capacity;

            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //[ExpectedException(typeof(ArrayTypeMismatchException))]
        //public void Add_AddItemToListOfIncompatibleType_ExceptionThrown()
        //{
        //    CustomList<int> testList = new CustomList<int>();
        //    var newListItem = "3";

        //    testList.AddItem(newListItem);
        //}

        // Remove Method Tests


        // ToString Override Method Tests
        [TestMethod]
        public void ToString_ConvertsIntegerArrayToString_ContainsEntireList()
        {
            CustomList<int> testList = new CustomList<int>();
            testList.AddItem(1);
            testList.AddItem(2);
            testList.AddItem(3);
            testList.AddItem(4);
            string expected = "1 2 3 4 ";
           
            string actual = testList.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_ConvertsDoubleArrayToString_ContainsEntireList()
        {
            CustomList<double> testList = new CustomList<double>();
            testList.AddItem(.25);
            testList.AddItem(.5);
            testList.AddItem(.75);
            testList.AddItem(.99);
            string expected = "0.25 0.5 0.75 0.99 ";

            string actual = testList.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_ConvertsBooleanArrayToString_ContainsEntireList()
        {
            CustomList<bool> testList = new CustomList<bool>();
            testList.AddItem(true);
            testList.AddItem(false);
            testList.AddItem(true);
            testList.AddItem(false);
            string expected = "True False True False ";

            string actual = testList.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_ConvertsByteArrayToString_ContainsEntireList()
        {
            CustomList<byte> testList = new CustomList<byte>();
            testList.AddItem(25);
            testList.AddItem(40);
            testList.AddItem(60);
            testList.AddItem(254);
            string expected = "25 40 60 254 ";

            string actual = testList.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_ConvertsCharArrayToString_ContainsEntireList()
        {
            CustomList<char> testList = new CustomList<char>();
            testList.AddItem('a');
            testList.AddItem('b');
            testList.AddItem('c');
            testList.AddItem('d');
            string expected = "a b c d ";

            string actual = testList.ToString();

            Assert.AreEqual(expected, actual);
        }

        // 
    }
}

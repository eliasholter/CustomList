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
            CustomList<int> testList = new CustomList<int>(4);

            int indexToCheck = testList[5];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_NegativeIndexRequested_ExceptionThrown()
        {
            CustomList<int> testList = new CustomList<int>(4);

            int indexToCheck = testList[-1];
        }

        [TestMethod]
        public void Indexer_CheckIndex_ReturnsValueThatWasRequested()
        {
            CustomList<int> testList = new CustomList<int>(4);
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
            CustomList<int> testList = new CustomList<int>(4);
            int newListItem = 3;
            int expected = 1;
            int actual;

            testList.Add(newListItem);
            actual = testList.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_AddItemToListWithNoMoreCapacity_ContainsEntireOriginalList()
        {
            CustomList<int> testList = new CustomList<int>(4);
            int newListItem = 3;
            int expected = 5;
            int actual;
            
            testList.Add(newListItem);
            testList.Add(newListItem);
            testList.Add(newListItem);
            testList.Add(newListItem);
            testList.Add(newListItem);
            actual = testList.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_AddItemToListWithNoMoreCapacity_MaintainsOriginalListOrder()
        {
            CustomList<int> testList = new CustomList<int>(4);
            string expected = "12345";

            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            testList.Add(4);
            testList.Add(5);
            string actual = testList.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_AddItemToListWithNoMoreCapacity_CapacityDoubles()
        {
            CustomList<int> testList = new CustomList<int>(4);
            int newListItem = 3;
            int expected = testList.Capacity * 2;

            for (int i = 0; i < 6; i++)
            {
                testList.Add(newListItem);
            }
            int actual = testList.Capacity;

            Assert.AreEqual(expected, actual);
        }

        // Remove Method Tests
        [TestMethod]
        public void Remove_RemoveItemFromList_CountDecreases()
        {
            CustomList<int> testList = new CustomList<int>(4) { 3, 2 };
            int expected = 1;
            int actual;

            testList.Remove(3);
            actual = testList.Count;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Remove_RemoveItemFromList_RetainsPreviousCapacity()
        {
            CustomList<int> testList = new CustomList<int>(4) { 3, 2 };
            int expected = 4;
            int actual;

            testList.Remove(3);
            actual = testList.Capacity;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_RemoveItemFromList_DoesNotContainRemovedItem()
        {
            CustomList<int> testList = new CustomList<int>(4) { 3, 2, 1, 4 };
            int expected = 2;

            testList.Remove(3);
            int actual = testList[0];

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_RemoveItemFromList_MovesEntriesDownSoThereAreNoGaps()
        {
            CustomList<int> testList = new CustomList<int>(4) { 3, 2, 1, 4 };
            string expected = "314";

            testList.Remove(2);
            string actual = testList.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_RemoveItemFromList_DoesNotRemoveAnything()
        {
            CustomList<int> testList = new CustomList<int>(4) { 1, 2, 3, 4 };
            string expected = "1234";

            testList.Remove(5);
            string actual = testList.ToString();

            Assert.AreEqual(expected, actual);
        }

        // RemoveAt Method Tests
        [TestMethod]
        public void RemoveAt_RemoveItemAtIndexOutsideOfRangeFromList_NothingWillBeRemoved()
        {
            CustomList<int> testList = new CustomList<int>() { 1, 2, 3, 4 };
            string expected = "1234";

            testList.RemoveAt(4);
            string actual = testList.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAt_RemoveItemAtIndexOutsideOfRangeFromList_CountDoesNotChange()
        {
            CustomList<int> testList = new CustomList<int>(4) { 1, 2, 3, 4 };
            int expected = 4;

            testList.RemoveAt(4);
            int actual = testList.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAt_RemoveItemAtIndexFromList_RemoveOnlyItemAtIndex()
        {
            CustomList<int> testList = new CustomList<int>(4) { 1, 2, 3, 4 };
            string expected = "124";

            testList.RemoveAt(2);
            string actual = testList.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAt_RemoveItemAtIndexFromList_CountDecreasesByOne()
        {
            CustomList<int> testList = new CustomList<int>(4) { 1, 2, 3, 4 };
            int expected = 3;

            testList.RemoveAt(2);
            int actual = testList.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAt_RemoveItemAtIndexFromList_CapacityDoesNotChange()
        {
            CustomList<int> testList = new CustomList<int>(4) { 1, 2, 3, 4 };
            int expected = 4;

            testList.RemoveAt(2);
            int actual = testList.Capacity;

            Assert.AreEqual(expected, actual);
        }

        // ToString Override Method Tests
        [TestMethod]
        public void ToString_ConvertsIntegerArrayToString_ContainsEntireList()
        {
            CustomList<int> testList = new CustomList<int>(4) { 1, 2, 3, 4 };
            string expected = "1234";
           
            string actual = testList.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_ConvertsDoubleArrayToString_ContainsEntireList()
        {
            CustomList<double> testList = new CustomList<double>(4) { .25, .5, .75, .99 };
            string expected = "0.250.50.750.99";

            string actual = testList.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_ConvertsBooleanArrayToString_ContainsEntireList()
        {
            CustomList<bool> testList = new CustomList<bool>(4) { true, false, true, false };
            string expected = "TrueFalseTrueFalse";

            string actual = testList.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_ConvertsByteArrayToString_ContainsEntireList()
        {
            CustomList<byte> testList = new CustomList<byte>(4) { 25, 40, 60, 254 };
            string expected = "254060254";

            string actual = testList.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_ConvertsCharArrayToString_ContainsEntireList()
        {
            CustomList<char> testList = new CustomList<char>(4) { 'a', 'b', 'c', 'd' };
            string expected = "abcd";

            string actual = testList.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_ConvertsEmptyArrayToString_ReturnsEmptyString()
        {
            CustomList<int> testList = new CustomList<int>(4);
            string expected = "";

            string actual = testList.ToString();

            Assert.AreEqual(expected, actual);
        }

        // Plus Operator Tests
        [TestMethod]
        public void OverridePlusOperator_AddListsTogether_CountEqualsSumOfTwoPreviousListCounts()
        {
            CustomList<int> testListOne = new CustomList<int>(4) { 1, 3, 5 };
            CustomList<int> testListTwo = new CustomList<int>(4) { 2, 4, 6 };
            CustomList<int> finalList = new CustomList<int>(4);
            int expected = 6;

            finalList = testListOne + testListTwo;
            int actual = finalList.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OverridePlusOperator_AddListsTogether_FinalListIsInOrder()
        {
            CustomList<int> testListOne = new CustomList<int>(4) { 1, 3, 5, 7 };
            CustomList<int> testListTwo = new CustomList<int>(4) { 2, 4, 6, 8 };
            CustomList<int> finalList = new CustomList<int>(4);
            string expected = "13572468";

            finalList = testListOne + testListTwo;
            string actual = finalList.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OverridePlusOperator_AddTwoDifferentSizeListsTogether_CapacityOfNewListIsDoubleTheCapacityOfTheLargerList()
        {
            CustomList<int> testListOne = new CustomList<int>(4) { 1, 3, 5 };
            CustomList<int> testListTwo = new CustomList<int>(4) { 2, 4, 6, 9 };
            CustomList<int> finalList = new CustomList<int>(4);
            int expected = testListTwo.Capacity * 2;

            finalList = testListOne + testListTwo;
            int actual = finalList.Capacity;

            Assert.AreEqual(expected, actual);
        }

        //Subtraction Operator Tests
       [TestMethod]
        public void OverrideSubtractionOperator_SubtractOneListFromAnother_CountEqualsOriginalCountMinusNumberOfItemsRemoved()
        {
            CustomList<int> testListOne = new CustomList<int>(4) { 1, 3, 5 };
            CustomList<int> testListTwo = new CustomList<int>(4) { 2, 3, 6 };
            CustomList<int> finalList = new CustomList<int>(4);
            int expected = 2;

            finalList = testListOne - testListTwo;
            int actual = finalList.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OverrideSubtractionOperator_SubtractOneListFromAnother_FinalListIsInOrder()
        {
            CustomList<int> testListOne = new CustomList<int>(4) { 1, 3, 5, 7 };
            CustomList<int> testListTwo = new CustomList<int>(4) { 2, 1, 3, 5 };
            CustomList<int> finalList = new CustomList<int>(4);
            string expected = "7";

            finalList = testListOne - testListTwo;
            string actual = finalList.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OverrideSubtractionOperator_SubtractOneListFromAnotherWithNoCommonTerms_DoesNotSubtractAnything()
        {
            CustomList<int> testListOne = new CustomList<int>(4) { 1, 3, 5 };
            CustomList<int> testListTwo = new CustomList<int>(4) { 2, 4, 6 };
            CustomList<int> finalList = new CustomList<int>(4);
            string expected = "135";

            finalList = testListOne - testListTwo;
            string actual = finalList.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OverrideSubtractionOperator_SubtractOneListFromAnother_OnlyRemoveOneInstanceOfItemInFirstListForEachInstanceInTheSecondList()
        {
            CustomList<int> testListOne = new CustomList<int>(4) { 1, 3, 1, 7 };
            CustomList<int> testListTwo = new CustomList<int>(4) { 2, 1, 3, 5 };
            CustomList<int> finalList = new CustomList<int>(4);
            string expected = "17";

            finalList = testListOne - testListTwo;
            string actual = finalList.ToString();

            Assert.AreEqual(expected, actual);
        }

        // Zip Method Tests
        [TestMethod]
        public void ZipLists_ZipListsTogether_CountEqualsSumOfTwoPreviousListCounts()
        {
            CustomList<int> testListOne = new CustomList<int>(4);
            CustomList<int> testListTwo = new CustomList<int>(4);
            testListOne.Add(1);
            testListOne.Add(3);
            testListOne.Add(5);
            testListTwo.Add(2);
            testListTwo.Add(4);
            testListTwo.Add(6);
            int expected = 6;

            testListOne.ZipLists(testListTwo);
            int actual = testListOne.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ZipLists_ZipListsTogether_ContainsContentsofBothOldListsInterlacedInOrder()
        {
            CustomList<int> testListOne = new CustomList<int>(4);
            CustomList<int> testListTwo = new CustomList<int>(4);
            string expected = "123456";
            testListOne.Add(1);
            testListOne.Add(3);
            testListOne.Add(5);
            testListTwo.Add(2);
            testListTwo.Add(4);
            testListTwo.Add(6);

            testListOne.ZipLists(testListTwo);

            string actual = testListOne.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ZipLists_ZipListsTogether_CapacityOfNewListIsDoubleTheCapacityOfTheLargerList()
        {
            CustomList<int> testListOne = new CustomList<int>(4);
            CustomList<int> testListTwo = new CustomList<int>(4);
            testListOne.Add(1);
            testListOne.Add(3);
            testListOne.Add(5);
            testListTwo.Add(2);
            testListTwo.Add(4);
            testListTwo.Add(6);
            testListTwo.Add(9);
            int expected = testListTwo.Capacity*2;

            testListOne.ZipLists(testListTwo);
            int actual = testListOne.Capacity;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ZipLists_ZipTwoDifferentSizeListsTogether_AfterTheEndOfSmallerListStillAddsTheRestOfLargerList()
        {
            CustomList<int> testListOne = new CustomList<int>(4);
            CustomList<int> testListTwo = new CustomList<int>(4);
            testListOne.Add(1);
            testListOne.Add(3);
            testListOne.Add(5);
            testListTwo.Add(2);
            testListTwo.Add(4);
            testListTwo.Add(6);
            testListTwo.Add(9);
            testListTwo.Add(69);
            testListTwo.Add(101);
            string expected = "123456969101";

            testListOne.ZipLists(testListTwo);
            string actual = testListOne.ToString();

            Assert.AreEqual(expected, actual);
        }

        // FindAll Method Tests
        [TestMethod]
        public void FindAll_SearchForSpecifiedItem_ReturnsArrayOfCorrectLength()
        {
            CustomList<int> testList = new CustomList<int>() { 3, 2, 3, 4};
            int expected = 2;

            int actual = testList.FindAll(3).Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindAll_SearchForSpecifiedItem_ReturnsArrayWithCountZero()
        {
            CustomList<int> testList = new CustomList<int>(4) { 3, 2, 3, 4 };
            int expected = 0;

            int actual = testList.FindAll(1).Count;

            Assert.AreEqual(expected, actual);
        }
    }
}

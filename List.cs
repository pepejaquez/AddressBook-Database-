﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book
{
    class List
    {
        // Capacity is used to initailize the myMemory array.
        static int capacity = 5;
        int[] myMemory = new int[capacity];

        // Tracks how may item are in the myMemory array.
        int items = 0;

        public List()
        {

        }

        //static void Main()
        //{

        //    List tester = new List();

        //    tester.Add(1);
        //    tester.Add(2);
        //    tester.Add(3);
        //    tester.Add(4);
        //    tester.Add(5);

        //    tester.print();
        //    Console.WriteLine();

        //    tester.Insert(2, 3333);
        //    tester.print();
        //}

        /// <summary>
        /// The add method adds an item to the end of the array. If the array is full, the method will double the size of the array, copy the contents of the array to the tempMemory array, point the memory location to the newly sized array, and then adds the new item.
        /// </summary>
        /// <param name="i">'i' is the integer type to add to myMemory array.</param>
        public void Add(int i)
        {
            // This tracks the first open index of the myMemory array.
            int firstopen = items;

            // Check if the array is maxed out. If so create a new array doubling the size of the current array and copy the contents to the new array.
            ResizeList();

            // Add the new item to the newly sized array.
            myMemory[firstopen] = i;

            // Track the current number of items in the array.
            items++;
        }


        /// <summary>
        /// Print the contents of the list.
        /// </summary>
        public void print()
        {
            for(int i = 0; i < items; i++)
            {
                {
                    Console.WriteLine(myMemory[i]);
                }
            }
        }

        private void ResizeList()
        {
            if (items == capacity)
            {
                // Double the capacity for the array
                capacity *= 2;

                //Temp array to hold the contents of the old array.
                int[] tempMemory = new int[capacity];

                // Used to place the contents of the old array in the proper place in the newly sized array.
                int trackIndex = 0;

                foreach (int j in myMemory)
                {
                    tempMemory[trackIndex] = j;
                    trackIndex++;
                }

                // Point the old array to the newly sized array.
                myMemory = tempMemory;

            }
        }

        /// <summary>
        /// Removes the first occurance of 'item'.
        /// </summary>
        /// <param name="item"></param>
        public void Remove(int item)
        {            
            for(int i = 0; i < items; i++)
            {
                // If the item is found, shift the remaining items to the left.
                if(myMemory[i] == item)
                {
                    for(int j = i; j < items - 1; j++)
                    {
                        myMemory[j] = myMemory[j + 1];
                    }
                    items--;
                    break;
                }
            }            
        }

        /// <summary>
        /// Removes the item at the specified index.
        /// </summary>
        /// <param name="index">An integer that corresponds to the index.</param>
        public void RemoveAt(int index)
        {
            myMemory[index] = 0;
        }


        /// <summary>
        /// Insert a new item at the specified index.
        /// </summary>
        /// <param name="index">The position in the list for the item to be inserted.</param>
        /// <param name="item">The object to be inserted.</param>
        public void Insert(int index, int item)
        {
            // Items is used to track how many items need to be shifted to the right to get to the insertion index.
            for (int i = items; i >= index; i--)
            {
                // If the insertion index = 0  AND i = 0 bypass the for loop and insert the item.
                if (!(i == 0 && index == 0))
                    myMemory[i] = myMemory[i - 1];
            }
            myMemory[index] = item;
            items++;
        }


    }
}
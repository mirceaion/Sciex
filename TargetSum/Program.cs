using System;
using System.Linq;
using System.Collections.Generic;

namespace TargetSum
{
    class Program
    {
        static private List<int> origList = new List<int>() { 4, 3, 21, 6, 7, 2, 5 };
        static private int target = 14;
        static List<List<int>> foundLists = new List<List<int>>();
        static void Main(string[] args)
        {            
            FindList(origList, target, new List<int>());
            Console.WriteLine("Hello World!");
        }

        private static void FindList(List<int> list, int target, List<int> currentPath)
        {
            foreach (int elem in list)
            {
                currentPath.Add(elem);
                List<int> newList = list.ToArray().ToList();                
                if( newList.Remove(elem) == false) throw new Exception("Failed removing element.");
                
                if (target == elem)
                {                    
                    foundLists.Add(currentPath.ToList());
                    currentPath.Remove(elem);
                    continue;
                }
                else if (elem > target)
                {
                    currentPath.Remove(elem);
                    continue;
                }
                FindList(newList, target - elem, currentPath);
                currentPath.Remove(elem);
            }
            // if we got here without this path was unsuccesful
            // remove the last element from path
        }
    }
}

﻿using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AlgoExpert
{


    public class BST
    {
        public int value;
        public BST left;
        public BST right;

        public BST(int value)
        {
            this.value = value;
        }

        public void insert(int value)
        {
            if (value < this.value)
            {
                if (left == null)
                {
                    left = new BST(value);
                }
                else
                {
                    left.insert(value);
                }
            }
            else
            {
                if (right == null)
                {
                    right = new BST(value);
                }
                else
                {
                    right.insert(value);
                }
            }
        }
    }
    public class Node
    {
        public string name;
        public List<Node> children = new List<Node>();

        public Node(string name)
        {
            this.name = name;
        }

        public static List<string> lst = new List<string>();

        public List<string> DepthFirstSearch(List<string> array)
        {
            // Write your code here.
            array.Add(name);
            foreach (var child in children)
            {
                child.DepthFirstSearch(array);
            }

            return array;
        }

        public Node AddChild(string name)
        {
            Node child = new Node(name);
            children.Add(child);
            return this;
        }
    }
    class Program
    {


        public static int difference = 0;
        public static int mindifferencesofar = 100000000;
        public static int closestsofar = 0;

        public static int FindClosestValueInBst(BST tree, int target)
        {
            // Write your code here.
            int minNode = tree.value;
            var currNode = tree;
            while (currNode != null)
            {
                if (Math.Abs(target - minNode) > Math.Abs(target - currNode.value))
                    minNode = currNode.value;

                if (target > currNode.value)
                    currNode = currNode.right;
                else if (target < currNode.value)
                    currNode = currNode.left;
                else
                    break;
            }
            return minNode;
        }

        public class BST
        {
            public int value;
            public BST left;
            public BST right;

            public BST(int value)
            {
                this.value = value;
            }
        }

        public class BinaryTree
        {
            public int value;
            public BinaryTree left;
            public BinaryTree right;

            public BinaryTree(int value)
            {
                this.value = value;
                this.left = null;
                this.right = null;
            }
        }

        public static List<int> lst = new List<int>();


        public static void BranchSums(BinaryTree root, int pathSum)
        {
            if (root == null) return;

            pathSum = pathSum + root.value;
            if ((root.left == null) && (root.right == null))
            {

                lst.Add(pathSum);
                return;
            }

            BranchSums(root.left, pathSum);
            BranchSums(root.right, pathSum);
        }

        public static List<int> BranchSums(BinaryTree root)
        {
            // Write your code here.
            lst.Clear();
            BranchSums(root, 0);
            return lst;
        }
        public static int[] TwoNumberSum(int[] array, int targetSum)
        {
            // Write your code here.
            var dict = new Dictionary<int, int>();
            int[] arr = new int[2];
            for (int i = 0; i < array.Length; i++)
            {
                if (!dict.ContainsKey(array[i]))
                {
                    dict.Add(array[i], array[i]);
                }
            }

            for (int j = 0; j < array.Length; j++)
            {
                dict.Remove(array[j]);

                if (dict.ContainsKey(targetSum - array[j]))
                {
                    arr[0] = array[j];
                    arr[1] = targetSum - array[j];
                    return arr;
                }

                dict.Add(array[j], array[j]);

            }

            return new int[0];
        }

        public static bool IsValidSubsequence(List<int> array, List<int> sequence)
        {
            // Write your code here.
            int sequencePointer = 0;

            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] == sequence[sequencePointer]) sequencePointer++;

                if (sequencePointer == sequence.Count) return true;
            }

            return false;
        }

        public int[] SortedSquaredArray(int[] array)
        {
            // Write your code here.
            int[] arrresult = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                arrresult[i] = array[i] * array[i];
            }

            Array.Sort(arrresult);

            return arrresult;
        }

        public string TournamentWinner(List<List<string>> competitions, List<int> results)
        {
            // Write your code here.
            string winner = "";
            int wincounter = 0;


            var dict = new Dictionary<string, int>();

            for (int i = 0; i < competitions.Count; i++)
            {
                var lst = competitions[i];

                if (results[i] == 1)
                {
                    winner = lst[0].ToString();
                }
                else
                {
                    winner = lst[1].ToString();
                }

                if (dict.ContainsKey(winner))
                {
                    var dictvalue = 0;
                    dict.TryGetValue(winner, out dictvalue);

                    wincounter = dictvalue;
                    wincounter = wincounter + 1;
                    dict.Remove(winner);
                    dict.Add(winner, wincounter);
                }
                else
                {
                    dict.Add(winner, 1);
                }
            }
            KeyValuePair<string, int> max = new KeyValuePair<string, int>();

            foreach (KeyValuePair<string, int> entry in dict)
            {
                if (entry.Value > max.Value)
                {
                    max = entry;
                }
            }

            return max.Key;
        }

        public int MinimumWaitingTime(int[] queries)
        {
            // Write your code here.
            if (queries.Length <= 1)
                return 0;
            Array.Sort(queries);
            int cWait = 0;
            int total = 0;
            for (int i = 1; i < queries.Length; i++)
            {
                cWait += queries[i - 1];
                total += cWait;
            }

            return total;
        }

        public int NonConstructibleChange(int[] coins)
        {
            // Write your code here.
            int change = 0;
            Array.Sort(coins);

            for (int i = 0; i < coins.Length; i++)
            {
                if (change + 1 >= coins[i])
                {
                    change = change + coins[i];
                    continue;
                }
                else
                    break;
            }
            return change + 1;
        }






        public static int nodeDepths = 0;

        public static int NodeDepths(BinaryTree root)
        {
            // Write your code here.
            nodeDepths = 0;
            CalculateNodeDepths(root, -1);
            return nodeDepths;
        }

        public static void CalculateNodeDepths(BinaryTree root, int nodeDepth)
        {
            // Write your code here.
            if (root == null) return;



            nodeDepth++;
            nodeDepths = nodeDepths + nodeDepth;
            CalculateNodeDepths(root.left, nodeDepth);
            CalculateNodeDepths(root.right, nodeDepth);
        }

        enum StudentColor
        {
            StudentColor_Red = 1,
            StudentColor_Blue = 2
        }

        public bool ClassPhotos(List<int> redShirtHeights, List<int> blueShirtHeights)
        {
            // Write your code here.
            redShirtHeights.Sort();
            blueShirtHeights.Sort();

            if (redShirtHeights[0] == blueShirtHeights[0])
                return false;

            StudentColor frontRow = redShirtHeights[0] < blueShirtHeights[0] ? StudentColor.StudentColor_Red : StudentColor.StudentColor_Blue;

            for (int i = 1; i < redShirtHeights.Count; i++)
            {
                if (redShirtHeights[i] < blueShirtHeights[i] && frontRow != StudentColor.StudentColor_Red)
                    return false;
                else if (blueShirtHeights[i] < redShirtHeights[i] && frontRow != StudentColor.StudentColor_Blue)
                    return false;
                else if (redShirtHeights[i] == blueShirtHeights[i])
                    return false;
            }

            return true;


        }


        public int TandemBicycle(int[] redShirtSpeeds, int[] blueShirtSpeeds, bool fastest)
        {
            // Write your code here.
            int sum = 0;

            Array.Sort(redShirtSpeeds);
            Array.Sort(blueShirtSpeeds);

            if (fastest) Array.Reverse(blueShirtSpeeds);

            for (int i = 0; i < redShirtSpeeds.Length; i++)
            {
                sum = sum + Math.Max(redShirtSpeeds[i], blueShirtSpeeds[i]);
            }

            return sum;

        }

        public class LinkedList
        {
            public int value;
            public LinkedList next;

            public LinkedList(int value)
            {
                this.value = value;
                this.next = null;
            }
        }

        public LinkedList RemoveDuplicatesFromLinkedList(LinkedList linkedList)
        {
            // Write your code here.

            LinkedList head = linkedList;


            while (linkedList.next != null)
            {
                while (linkedList.value == linkedList.next.value)
                {
                    if (linkedList.next.next != null)
                        linkedList.next = linkedList.next.next;
                    else
                    {
                        linkedList.next = null;
                        break;
                    }
                }

                if (linkedList.next == null) break;

                linkedList = linkedList.next;




            }



            return head;
        }

        public static int ProductSum(List<object> array, int depth = 1)
        {
            // Write your code here.
            var sum = 0;
            foreach (var el in array)
            {
                sum += el is IList<object>
                    ? ProductSum(el as List<object>, depth + 1)
                    : (int)el;
            }

            return sum * depth;
        }

        public static int GetNthFib(int n)
        {
            // Write your code here.
            if (n == 2) return 1;
            else if (n == 1) return 0;
            else return GetNthFib(n - 1) + GetNthFib(n - 2);
        }

        public static int BinarySearch(int[] array, int target)
        {
            // Write your code here.

            return BinarySearch(array, target, 0, array.Length - 1);
        }

        public static int BinarySearch(int[] array, int target, int left, int right)
        {
            if (left > right) return -1;

            int middle = (left + right) / 2;
            int potentialMatch = array[middle];

            if (target == potentialMatch)
                return middle;
            else if (target < potentialMatch)
                return BinarySearch(array, target, left, middle - 1);
            else
                return BinarySearch(array, target, middle + 1, right);


        }

        public static int[] FindThreeLargestNumbers(int[] array)
        {
            // Write your code here.
            int[] result = new int[3];
            int firestHeighestNumber = Int32.MinValue;
            int SecondHighestNumber = Int32.MinValue;
            int ThirdHeighestNumber = Int32.MinValue;
            int firestHeighestNumberIndex = 0;
            int SecondHighestNumberIndex = 0;



            for (int i = 0; i < array.Length; i++)
            {

                if (array[i] > firestHeighestNumber)
                {
                    firestHeighestNumber = array[i];
                    firestHeighestNumberIndex = i;
                }
            }

            for (int i = 0; i < array.Length; i++)
            {

                if (i == firestHeighestNumberIndex) continue;



                if (array[i] > SecondHighestNumber)
                {
                    SecondHighestNumber = array[i];
                    SecondHighestNumberIndex = i;
                }

            }

            for (int i = 0; i < array.Length; i++)
            {
                if ((i == firestHeighestNumberIndex) || (i == SecondHighestNumberIndex)) continue;

                ThirdHeighestNumber = Math.Max(array[i], ThirdHeighestNumber);

            }

            return new int[] { ThirdHeighestNumber, SecondHighestNumber, firestHeighestNumber };
        }

        public static int[] BubbleSort(int[] array)
        {
            // Write your code here.
            if (array.Length == 0) return new int[] { };
            bool isSorted = false;
            int counter = 0;
            while (!isSorted)
            {
                isSorted = true;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        swap(i, i + 1, array);
                        isSorted = false;

                    }
                    counter++;
                }

            }
            return array;
        }

        public static void swap(int i, int j, int[] array)
        {
            int temp = array[j];
            array[j] = array[i];
            array[i] = temp;

        }

        public static int[] InsertionSort(int[] array)
        {
            // Write your code here.
            int sortedUpto = 0;
            while (sortedUpto < array.Length - 1)
            {
                int min = Int32.MaxValue;
                int minIndex = 0;

                for (int i = sortedUpto; i < array.Length; i++)
                {
                    if (array[i] < min)
                    {
                        min = array[i];
                        minIndex = i;
                    }
                }

                Swap(minIndex, sortedUpto, array);
                sortedUpto++;
            }

            return array;
        }

        public static int[] SelectionSort(int[] array)
        {
            // Write your code here.
            for (int i = 0; i < array.Length; i++)
            {
                var minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[minIndex] > array[j])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    var temp = array[minIndex];
                    array[minIndex] = array[i];
                    array[i] = temp;
                }
            }
            return array;
        }

        public static bool IsPalindrome(string str)
        {
            // Write your code here.

            for (int i = 0; i < (str.Length / 2); i++)
            {
                if (str[i] != str[(str.Length - 1) - i])
                {
                    return false;
                }

            }

            return true;
        }

        public static string CaesarCypherEncryptor(string str, int key)
        {
            // Write your code here.
            string alphabets = "abcdefghijklmnopqrstuvwxyz";
            int index = 0;
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                index = str[i] - 'a';

                index = index + key;

                if (index > 25)
                {
                    index = index % 26;
                }

                result.Append(alphabets[index]);

            }

            return result.ToString();
        }

        public string RunLengthEncoding(string str)
        {
            // Write your code here.
            StringBuilder result = new StringBuilder();
            int currentCount = 0;
            string currentLetter = "";

            int i = 0;

            if (str.Length == 1)
            {
                return "1" + str[0].ToString();
            }



            while (i < str.Length - 1)
            {

                currentCount = 1;
                currentLetter = str[i].ToString();
                while (str[i] == str[i + 1])
                {

                    currentCount++;
                    i++;

                    if (i == str.Length - 1)
                    {
                        break;
                    }

                    if (currentCount == 9)
                    {
                        break;
                    }

                }

                result.Append(currentCount.ToString() + currentLetter.ToString());


                if ((i == str.Length - 2) && ((str[i] != str[i + 1]) || (currentCount == 9)))
                {

                    result.Append("1" + str[i + 1].ToString());

                }

                i++;

            }

            return result.ToString();
        }

        public bool GenerateDocument(string characters, string document)
        {
            // Write your code here.

            var dictChars = new Dictionary<char, int>();
            var dictDocs = new Dictionary<char, int>();


            for (int i = 0; i < characters.Length; i++)
            {
                if (dictChars.ContainsKey(characters[i]))
                {
                    dictChars[characters[i]] = dictChars[characters[i]] + 1;
                }
                else
                {
                    dictChars.Add(characters[i], 1);
                }
            }

            for (int j = 0; j < document.Length; j++)
            {
                if (dictDocs.ContainsKey(document[j]))
                {
                    dictDocs[document[j]] = dictDocs[document[j]] + 1;
                }
                else
                {
                    dictDocs.Add(document[j], 1);
                }
            }

            int charCount = 0;
            int docsCount = 0;

            for (int k = 0; k < document.Length; k++)
            {
                if (dictChars.ContainsKey(document[k]))
                {
                    dictChars.TryGetValue(document[k], out charCount);
                    dictDocs.TryGetValue(document[k], out docsCount);
                    if (charCount < docsCount)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }




            return true;
        }

        public int FirstNonRepeatingCharacter(string str)
        {
            // Write your code here.

            int[] chars = new int[26];

            foreach (char s in str)
            {
                chars[s - 'a'] = chars[s - 'a'] + 1;

            }

            for (int i = 0; i < str.Length; i++)
            {
                if (chars[str[i] - 'a'] == 1)
                {
                    return i;
                }

            }


            return -1;
        }

        public static List<int[]> ThreeNumberSum(int[] array, int targetSum)
        {
            // Write your code here.
            Array.Sort(array);
            int leftPointer, rightPointer, numberToFind;
            List<int[]> result = new List<int[]>();
            for (int i = 0; i < array.Length; i++)
            {
                leftPointer = i + 1;
                rightPointer = array.Length - 1;
                numberToFind = targetSum - array[i];
                while (leftPointer < rightPointer)
                {
                    int sum = array[leftPointer] + array[rightPointer];
                    if (numberToFind == sum)
                    {
                        result.Add(new int[] { array[i], array[leftPointer], array[rightPointer] });
                        leftPointer++;
                        rightPointer--;
                    }
                    if (numberToFind > sum)
                    {
                        leftPointer++;
                    }
                    if (numberToFind < sum)
                    {
                        rightPointer--;
                    }
                }
            }
            return result;

        }

        public static int[] SmallestDifference(int[] arrayOne, int[] arrayTwo)
        {
            // Write your code here.
            Array.Sort(arrayOne);
            Array.Sort(arrayTwo);
            int p1 = 0;
            int p2 = 0;
            int[] response = new int[2];
            int? smallestDifference = null;
            while (smallestDifference != 0 && p1 < arrayOne.Length && p2 < arrayTwo.Length)
            {
                int curDiff = AbsDiff(arrayOne[p1], arrayTwo[p2]);
                if (curDiff < smallestDifference || smallestDifference == null)
                {
                    smallestDifference = curDiff;
                    response[0] = arrayOne[p1];
                    response[1] = arrayTwo[p2];
                }

                if (arrayOne[p1] < arrayTwo[p2])
                {
                    p1++;
                    continue;
                }

                p2++;


            }
            return response;
        }

        public static int AbsDiff(int firstValue, int secondValue)
        {
            return Math.Abs(firstValue - secondValue);
        }
        public static void Swap(int a, int b, int[] arr)
        {
            var temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        public static List<int> MoveElementToEnd(List<int> array, int toMove)
        {
            // Write your code here.


            int p1 = 0;
            int p2 = array.Count - 1;

            while (p1 < p2)
            {
                if (array[p2] == toMove)
                {
                    p2--;
                    continue;
                }

                if (array[p1] == toMove)
                {
                    var temp = array[p1];
                    array[p1] = array[p2];
                    array[p2] = temp;
                    p2--;

                }
                else
                {

                    p1++;
                }

            }
            return array;
        }

        public static bool IsMonotonic(int[] array)
        {
            // Write your code here.
            if (array.Length <= 1) return true;
            bool goingUp = array[array.Length - 1] > array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if ((!goingUp) && (array[i] > array[i - 1])) return false;
                else if ((goingUp) && (array[i] < array[i - 1])) return false;
            }
            return true;
        }

        public static List<int> SpiralTraverse(int[,] array)
        {
            // Write your code here.
            if (array.GetLength(1) == 1 && array.GetLength(0) == 1) return new List<int> { array[0, 0] };

            var sCol = 0;
            var sRow = 0;
            var eCol = array.GetLength(1) - 1;
            var eRow = array.GetLength(0) - 1;
            var result = new List<int>();

            while (eRow >= sRow && eCol >= sCol)
            {
                for (var i = sCol; i <= eCol; i++)
                {
                    result.Add(array[sRow, i]);
                }

                for (var i = sRow + 1; i <= eRow; i++)
                {
                    result.Add(array[i, eCol]);
                }

                for (var i = eCol - 1; i >= sCol && eRow > sRow; i--)
                {
                    result.Add(array[eRow, i]);
                }

                for (var i = eRow - 1; i > sRow && eCol > sCol; i--)
                {
                    result.Add(array[i, sCol]);
                }

                eCol--;
                sCol++;
                eRow--;
                sRow++;
            }

            return result;
        }

        public static int LongestPeak(int[] array)
        {
            // Write your code here.
            if (array.Length <= 2) return 0;

            var inc = 0;
            var dec = 0;
            var max = 0;

            for (var i = 1; i < array.Length; i++)
            {
                var val = array[i];
                var prevVal = array[i - 1];

                if (val == prevVal)
                {
                    inc = 0;
                    dec = 0;
                    continue;
                }

                if (val > prevVal)
                {
                    if (dec > 0)
                    {
                        inc = 0;
                    }
                    dec = 0;
                    inc++;
                    continue;
                }

                if (val < prevVal && inc > 0)
                {
                    dec++;
                    max = Math.Max(max, inc + dec + 1);
                }
            }
            return max;
        }

        public int[] ArrayOfProducts(int[] array)
        {
            // Write your code here.
            int[] result = new int[array.Length];
            int productAll = 1, zeroCount = 0, zi = -1;

            for (var i = 0; i < array.Length; i++)
            {
                if (array[i] == 0) { zeroCount++; zi = i; }

                if (zeroCount > 1) return result;

                if (array[i] == 0) continue;

                productAll = productAll * array[i];
            }

            if (zi != -1)
            {
                result[zi] = productAll; return result;
            }

            for (var i = 0; i < array.Length; i++)
            {
                result[i] = productAll / array[i];
            }
            return result;
        }

        public int FirstDuplicateValue(int[] array)
        {
            // Write your code here.
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (dict.ContainsKey(array[i])) return array[i];
                else dict.Add(array[i], array[i]);
            }

            return -1;

        }

        public int[][] MergeOverlappingIntervals(int[][] intervals)
        {
            // Write your code here.
            Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]));

            List<int[]> result = new List<int[]>();
            var prevInterval = intervals[0];
            result.Add(prevInterval);

            for (var i = 1; i < intervals.Length; i++)
            {
                int[] currInterval = intervals[i];

                if (prevInterval[1] >= currInterval[0])
                {
                    prevInterval[1] = Math.Max(currInterval[1], prevInterval[1]);
                }
                else
                {
                    prevInterval = currInterval;
                    result.Add(prevInterval);
                }
            }
            return result.ToArray();
        }

        public static void InvertBinaryTree(BinaryTree tree)
        {
            // Write your code here.
            if (tree == null) return;

            if ((tree.left != null) && (tree.right != null))
            {
                BinaryTree temp = tree.left;
                tree.left = tree.right;
                tree.right = temp;
            }

            else if (tree.left == null)
            {

                tree.left = tree.right;
                tree.right = null;
            }

            else if (tree.right == null)
            {

                tree.right = tree.left;
                tree.left = null;
            }

            InvertBinaryTree(tree.left);
            InvertBinaryTree(tree.right);




        }

        public static int findClosestNumber(int N, int M)
        {
            int multiple = 0;
            int product = M;
            while (product < N)
            {
                multiple++;
                product = M * multiple;
            }

            if (Math.Abs(product - N) < Math.Abs((M * (multiple - 1)) - N)) return product;
            else return M * (multiple - 1);
        }

        public static bool ZeroSumSubArray(int[] nums)
        {
            if (nums.Length == 0)
            {
                return false;
            }
            if (nums.Length == 1)
            {
                return nums[0] == 0;
            }
            int sum = 0;
            var zeroSumDictionary = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (sum == 0)
                {
                    return true;
                }
                nums[i] = sum;
                if (!zeroSumDictionary.ContainsKey(sum))
                {
                    zeroSumDictionary.Add(sum, new List<int> { i });
                }
                else
                {
                    zeroSumDictionary[sum].Add(i);
                    return true;
                }

            }
            return false;
        }

        public static string ReverseWordsInString(string str)
        {
            string reverseWords = "";
            string word = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    word = str[i] + word;
                    reverseWords = word + reverseWords;
                    word = "";
                }
                else
                {
                    word = word + str[i];
                }
            }
            reverseWords = word + reverseWords;
            return reverseWords;
        }

        public static List<List<string>> groupAnagrams(List<string> words)
        {
            var memo = new Dictionary<string, List<string>>();
            foreach (var elm in words)
            {
                var sortedString = string.Concat(elm.OrderBy(c => c));
                if (memo.ContainsKey(sortedString))
                {
                    memo[sortedString].Add(elm);
                }
                else
                {
                    memo[sortedString] = new List<string> { elm };
                }
            }
            return memo.Values.ToList();
        }
        public static int[][] RemoveIslands(int[][] matrix)
        {
            var notIslands = new bool[matrix.Length, matrix[0].Length];
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    bool rowIsBorder = row == 0 || row == matrix.Length - 1;
                    bool colIsBorder = col == 0 || col == matrix[row].Length - 1;
                    bool isBorder = rowIsBorder || colIsBorder;
                    if (!isBorder) continue;
                    if (matrix[row][col] != 1) continue;
                    DFS(matrix, row, col, notIslands);
                }
            }

            for (int row = 1; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    if (matrix[row][col] == 1 && notIslands[row, col] == false)
                    {
                        matrix[row][col] = 0;
                    }
                }

            }
            return matrix;
        }

        public static void DFS(int[][] matrix, int row, int col, bool[,] notIslands)
        {
            if (matrix[row][col] == 0 || notIslands[row, col] == true)
            {
                return;
            }
            notIslands[row, col] = true;
            if (row > 0) DFS(matrix, row - 1, col, notIslands);
            if (row < matrix.Length - 1) DFS(matrix, row + 1, col, notIslands);
            if (col > 0) DFS(matrix, row, col - 1, notIslands);
            if (col < matrix[0].Length - 1) DFS(matrix, row, col + 1, notIslands);
        }

        public static bool BalanceBracket(string str)
        {
            var leftBrackets = new List<Char>() { '{', '[', '(' };
            var rightBrackets = new List<Char>() { '}', ']', ')' };
            var stackBrackets = new Stack<char>();

            foreach (var currentBracket in str)
            {
                if (leftBrackets.Contains(currentBracket))
                {
                    stackBrackets.Push(currentBracket);
                }
                else if (rightBrackets.Contains(currentBracket))
                {
                    if (stackBrackets.Count == 0) return false;
                    var lastBracketInTheStack = stackBrackets.Pop();
                    var indexOfCurrentBracketInTheRightBrackets = rightBrackets.IndexOf(currentBracket);
                    var indexOfLastBracketInTheLeftBrackets = leftBrackets.IndexOf(lastBracketInTheStack);
                    if (indexOfCurrentBracketInTheRightBrackets != indexOfLastBracketInTheLeftBrackets) return false;
                }
            }

            return stackBrackets.Count == 0 ? true : false;
        }

        public static int[] NextGreaterElement(int[] array)
        {
            var nextindexArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                var counter = (i + 1) % array.Length;
                var maxValue = Int32.MinValue;
                while (counter != i)
                {
                    if (array[i] < array[counter])
                    {
                        maxValue = array[counter];
                        break;
                    }
                    counter = (counter + 1) % array.Length;
                }
                nextindexArray[i] = (maxValue != Int32.MinValue) ? maxValue : -1;
            }
            return nextindexArray;
        }

        public static int[] SearchInSortedMatrix(int[,] matrix, int target)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var start = 0;
                var end = matrix.GetLength(1) - 1;
                while (start <= end)
                {
                    var mid = (start + end) / 2;
                    if (target == matrix[i, mid])
                        return new int[2] { i, mid };
                    else if (target > matrix[i, mid])
                        start = mid + 1;
                    else
                        end = mid - 1;
                }
            }
            return new int[2] { -1, -1 };
        }

        public static string[] MinimumCharactersForWords(string[] words)
        {
            var letters = new Dictionary<char, int>();
            var charsList = new List<string>();

            foreach (var word in words)
            {
                var frequencies = new Dictionary<char, int>();

                foreach (var letter in word)
                {
                    frequencies[letter] = frequencies.GetValueOrDefault(letter, 0) + 1;

                    if (letters.ContainsKey(letter))
                    {
                        if (letters[letter] < frequencies[letter])
                        {
                            letters[letter]++;
                            charsList.Add(Char.ToString(letter));
                        }
                    }
                    else
                    {
                        letters.Add(letter, 1);
                        charsList.Add(char.ToString(letter));
                    }

                }
            }

            return charsList.ToArray();
        }

        static int closestMultiple(int n, int x)
        {
            if (x > n)
                return x;
            n = n + x / 2;
            n = n - (n % x);
            return n;
        }

        public static bool ValidateBST(BST tree)
        {
            return ValidateHelper(tree, int.MinValue, int.MaxValue);
        }

        public static bool ValidateHelper(BST tree, int min, int max)
        {
            if (tree == null) return true;
            if (tree.value < max && tree.value >= min)
            {
                return ValidateHelper(tree.left, min, tree.value) && ValidateHelper(tree.right, tree.value, max);
            }
            else
            {
                return false;
            }
        }

        public static int MaxSubsetSumNoAdjacent(int[] array)
        {
            // Write your code here.
            if (array == null || array.Length == 0)
            {
                return 0;
            }

            if (array.Length == 1)
            {
                return array[0];
            }

            var secondLastMax = 0;
            var lastMax = array[0];
            var index = 1;

            while (index < array.Length)
            {
                var current = array[index] + secondLastMax;
                var temp = lastMax;
                lastMax = Math.Max(lastMax, current);
                secondLastMax = temp;
                index++;
            }

            return lastMax;
        }

        public static async Task<bool> interveavingString(string one, string two, string three)
        {
            int p1 = 0;
            int p2 = 0;

            for (int i = 0; i < three.Length; i++)
            {

                if (p1 < one.Length)
                {
                    if (three[i] == one[p1]) p1++;
                }
                if (p2 < two.Length)
                {
                    if (three[i] == two[p2]) p2++;
                }

            }

            return p1 == one.Length && p2 == two.Length;

        }



        private static Task<int> AdditionAsync(int no1, int no2)
        {
            return Task.Run(() => SUM(no1, no2));
            //Local function 
            int SUM(int x, int y)
            {
                return x + y;
            }
        }


        public static int covertgo1(string S)
        {
            if (S == "") return 0;

            var charsFrequency = new int[26];

            foreach (var c in S)
            {
                charsFrequency[c - 'A']++;
            }

            var CharAFrequency = charsFrequency[0] / 3;
            var CharBFrequency = charsFrequency[1];
            var CharNFrequency = charsFrequency[13] / 2;

            return Math.Min(CharNFrequency, Math.Min(CharAFrequency, CharBFrequency));


        }

        public static int covergo2(int N, string S)
        {
            int[,] arrayReservervedSeats = new int[N, 10];
            int familiesCount = 0;
            var reserverSeats = S.Split(' ');
            var dict = new Dictionary<string, string>();

            var CharDict = new Dictionary<int, string>();
            int key = 0;

            for (char c = 'A'; c <= 'K'; c++)
            {
                if (c == 'I') continue;
                CharDict.Add(key, c.ToString());
                key++;
            }


            for (int i = 0; i < reserverSeats.Length; i++)
            {
                if (!dict.ContainsKey(reserverSeats[i]))
                {
                    dict.Add(reserverSeats[i], reserverSeats[i]);
                }
            }

            for (int j = 0; j < N; j++)
            {
                for (int k = 0; k < 10; k++)
                {
                    var str = (j + 1).ToString() + CharDict[k];
                    if (dict.ContainsKey(str))
                    {
                        arrayReservervedSeats[j, k] = 1;
                    }
                }
            }

            for (int m = 0; m < N; m++)
            {
                if (arrayReservervedSeats[m, 1] == 0 && arrayReservervedSeats[m, 2] == 0 && arrayReservervedSeats[m, 3] == 0 && arrayReservervedSeats[m, 4] == 0)
                {
                    familiesCount++;
                    arrayReservervedSeats[m, 1] = 1;
                    arrayReservervedSeats[m, 2] = 1;
                    arrayReservervedSeats[m, 3] = 1;
                    arrayReservervedSeats[m, 4] = 1;
                }
                if (arrayReservervedSeats[m, 5] == 0 && arrayReservervedSeats[m, 6] == 0 && arrayReservervedSeats[m, 7] == 0 && arrayReservervedSeats[m, 8] == 0)
                {
                    familiesCount++;
                    arrayReservervedSeats[m, 5] = 1;
                    arrayReservervedSeats[m, 6] = 1;
                    arrayReservervedSeats[m, 7] = 1;
                    arrayReservervedSeats[m, 8] = 1;
                }

                if (arrayReservervedSeats[m, 3] == 0 && arrayReservervedSeats[m, 4] == 0 && arrayReservervedSeats[m, 5] == 0 && arrayReservervedSeats[m, 6] == 0)
                {
                    familiesCount++;
                }
            }
            return familiesCount;
        }

        public static void checkduplicate(int[] numbers)
        {
            var dict = new Dictionary<int, int>();


            for (int i = 0; i < numbers.Length; i++)
            {
                if (!dict.ContainsKey(numbers[i]))
                {
                    dict.Add(numbers[i], 1);
                }
                else
                {
                    dict[numbers[i]]++;
                }

            }

            int y = 3 / 2;

            return;

        }

        public static int[,] RotateMatrix(int[,] matrix, IEnumerable<char> operations)
        {

            int[,] result = matrix;
            foreach (var c in operations)
            {
                result = RotateArray(result, c == 'C' ? true : false);
            }
            return result;

        }

        public static int[,] RotateArray(int[,] matrix, bool isClockwise)
        {
            int width;
            int height;
            int[,] dst;
            height = matrix.GetLength(0);
            width = matrix.GetLength(1);
            dst = new int[width, height];
            if (isClockwise)
            {
                //for (int row = 0; row < height; row++)
                //{
                //    for (int col = 0; col < width; col++)
                //    {
                //        int newRow;
                //        int newCol;
                //        newRow = col;
                //        newCol = height - (row + 1);
                //        dst[newCol, newRow] = matrix[col, row];
                //    }
                //}

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        // calculate the new row and column index for the rotated array
                        int newRow = j;
                        int newCol = height - i - 1;

                        // copy the element from the original array to the rotated array
                        dst[newRow, newCol] = matrix[i, j];
                    }
                }
            }
            else // anticlockwise
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        int newRow = width - j - 1;
                        int newCol = i;
                        dst[newRow, newCol] = matrix[i, j];
                    }
                }
            }

            return dst;
        }

        public static int getMin(string s)
        {

            Stack<string> paranthesesStack = new Stack<string>();

            foreach (var c in s)
            {
                if (c == '(')
                {
                    paranthesesStack.Push(c.ToString());
                }

                else if (c == ')')
                {
                    if (paranthesesStack.Count == 0)
                    {
                        paranthesesStack.Push(c.ToString());

                    }

                    else if (paranthesesStack.Peek() != "(")
                    {
                        paranthesesStack.Push(c.ToString());
                    }
                    else
                    {
                        paranthesesStack.Pop();
                    }
                }


            }

            return paranthesesStack.Count;
        }

        public List<List<string>> Semordnilap(string[] words)
        {
            List<List<string>> semordnilap = new List<List<string>>();
            Dictionary<string, string> sortedStringMap = new Dictionary<string, string>();
            foreach (string word in words)
            {
                char[] wordArr = word.ToCharArray();
                Array.Sort(wordArr);
                string sortedString = new string(wordArr);
                if (!sortedStringMap.ContainsKey(sortedString))
                {
                    sortedStringMap.Add(sortedString, word);
                }
                else
                {
                    semordnilap.Add(new List<string>() {
                        sortedStringMap[sortedString], word
                    });
                }

            }
            return semordnilap;
        }

        public static BST MinHeightBst(List<int> array, int startIndex = 0, int endIndex = -1)
        {
            // Write your code here.
            if (endIndex == -1)
            {
                endIndex = array.Count - 1;
            }
            var parentIndex = startIndex + (endIndex - startIndex) / 2;
            var bst = new BST(array[parentIndex]);
            if (parentIndex > startIndex)
            {
                bst.left = MinHeightBst(array, startIndex, parentIndex - 1);
            }
            if (parentIndex < endIndex)
            {
                bst.right = MinHeightBst(array, parentIndex + 1, endIndex);
            }

            return bst;
        }

        public void traverseTreeFromLargestToLowest(BST tree, int k, List<int> candidates)
        {
            if (tree == null || candidates.Count >= k)
                return;

            traverseTreeFromLargestToLowest(tree.right, k, candidates);
            candidates.Add(tree.value);
            traverseTreeFromLargestToLowest(tree.left, k, candidates);

        }


        public int FindKthLargestValueInBst(BST tree, int k)
        {
            // Write your code here.
            var candidates = new List<int>();
            traverseTreeFromLargestToLowest(tree, k, candidates);
            if (k <= candidates.Count)
            {
                return candidates[k - 1];
            }

            return -1;
        }

        public int BinaryTreeDiameter(BinaryTree tree)
        {
            if (tree == null) return 0;
            int leftHeight = Height(tree.left);
            int rightHeight = Height(tree.right);

            int leftDiameter = BinaryTreeDiameter(tree.left);
            int rightDiameter = BinaryTreeDiameter(tree.right);

            return Math.Max(leftHeight + rightHeight, Math.Max(leftDiameter, rightDiameter));
        }
        private int Height(BinaryTree tree)
        {
            if (tree == null) return 0;
            return 1 + Math.Max(Height(tree.left), Height(tree.right));
        }

        public bool OneEdit(string stringOne, string stringTwo)
        {
            // Write your code here.
            if (Math.Abs(stringOne.Length - stringTwo.Length) > 1)
                return false;

            return IsReplace(stringOne, stringTwo);
        }

        private bool IsReplace(string longer, string smaller)
        {
            if (longer.Length < smaller.Length)
                return IsReplace(smaller, longer);

            var madeEdit = false;

            for (int l = 0, s = 0; l < longer.Length && s < smaller.Length; s++, l++)
            {
                if (longer[l] != smaller[s])
                {
                    if (madeEdit) return false;
                    madeEdit = true;

                    if (longer.Length != smaller.Length)
                        s--;
                }

            }
            return true;
        }

        public static bool GlobMatching(string fileName, string pattern)
        {
            var wildcard = '*';
            var questionmark = '?';

            var p1 = 0;
            var p2 = 0;

            while (p1 < fileName.Length && p2 < pattern.Length)
            {
                if (fileName[p1] == pattern[p2] || pattern[p2] == questionmark)
                {
                    p1++;
                    p2++;
                }
                else if (pattern[p2] == wildcard)
                {
                    while (p2 < pattern.Length && (pattern[p2] == wildcard || pattern[p2] == questionmark))
                        p2++;

                    if (p2 == pattern.Length)
                        return true;

                    while (p1 < fileName.Length && fileName[p1] != pattern[p2])
                        p1++;

                }
                else
                    return false;

            }
            while (p2 < pattern.Length && pattern[p2] == wildcard)
                p2++;

            return p1 == fileName.Length && p2 == pattern.Length;
        }
        static void Main(string[] args)
        {

            Console.Title = "async Task<int> Main";
            int number1 = 5, number2 = 10;
            //  Console.WriteLine($"Sum of {number1} and {number2} is: {await AdditionAsync(number1, number2)}");
            Console.WriteLine("Press any key to exist.");
            Console.ReadKey();


            //var result345 = await interveavingString("algoexpert", "your-dream-job45", "your-algodream-expertjob" );
            //return result345;

            var words = new string[] { "this", "that", "did", "deed", "them!", "a" };


            int[,] matrix12 = new int[,]
            {
                {1, 4, 7, 12, 15, 1000} ,
                   {2, 5, 19, 31, 32, 1001} ,
                   {3, 8, 24, 33, 35, 1002} ,
                   {40, 41, 42, 44, 45, 1003},
                {99, 100, 103, 106, 128, 1004},
            };

            int[][] matrix =
            {
                new int[] { 1, 0, 0, 0, 0, 0 },
                new int[] { 0, 1, 0, 1, 1, 1 },
                new int[] { 0, 0, 1, 0, 1, 0 },
                new int[] { 1, 1, 0, 0, 1, 0 },
                new int[] { 1, 0, 1, 1, 0, 0 },
                new int[] { 1, 0, 0, 0, 0, 1 },

            };
            var result14 = SearchInSortedMatrix(matrix12, 44);
            int[] array = new int[] { 2, 5, -3, -4, 6, 7, 2 };
            var result13 = NextGreaterElement(array);

            var result12 = BalanceBracket("[}");



            var result1 = RemoveIslands(matrix);



            List<string> mylist = new List<string> { "yo", "act", "flop", "tac", "foo", "cat", "oy", "olfp" };
            List<List<string>> result = groupAnagrams(mylist);

            /* Stack<string> mystack = new Stack<string>();
			mystack.Push("abs");
			mystack.Pop();

			Queue<string> queue = new Queue<string>();
			queue.Enqueue("test");
			queue.Dequeue(); */

            //string result =  ReverseWordsInString("this is rizwan");

            int[] nums = new int[] { -5, -5, 3, 3, -2 };
            //bool result = ZeroSumSubArray(nums);

            // int result = findClosestNumber(13, 4);
            Console.WriteLine("Hello World");
            Console.ReadLine();
        }
    }
}

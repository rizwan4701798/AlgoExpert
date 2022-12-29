using System;
using System.Diagnostics;
using System.IO;
using quick_code_test;
using System.Threading;

using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TestConsoleApp
{



    public enum SomeValues
    {
        Red = 1,
        Blue = 2,
        Green = 4,
        Black = 8,
        White = 16,
        Orange = 32,
        Yellow = 64,
        Pink = 128,
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Solution
    {

        public bool AreEqual(TreeNode s, TreeNode t)
        {
            if (s == null || t == null) return s == t;
            return s.val == t.val && AreEqual(s.left, t.left) && AreEqual(s.right, t.right);
        }

        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (s == null || t == null) return s == t; // this is test comment
            return AreEqual(s, t) || IsSubtree(s.left, t) || IsSubtree(s.right, t);
        }


        int globalSum = int.MinValue;
        public int MaxPathSum(TreeNode root)
        {
            DFS(root);
            return globalSum;
        }

        private int DFS(TreeNode root)
        {
            if (root == null) return 0;

            var leftSum = DFS(root.left);
            var rightSum = DFS(root.right);

            var localSum = root.val;
            localSum += Math.Max(0, leftSum);
            localSum += Math.Max(0, rightSum);

            globalSum = Math.Max(localSum, globalSum);

            return Math.Max(root.val, Math.Max(root.val + leftSum, root.val + rightSum));
        }
    }

    public class LinkedList
    {
        public int Value;
        public LinkedList Next = null;

        public LinkedList(int value)
        {
            this.Value = value;
        }
    }


    public class Program6
    {
        // This is an input class. Do not edit.
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


        public class Program3
        {

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

            public class BinaryTree
            {
                public int value;
                public BinaryTree left;
                public BinaryTree right;

                public BinaryTree(int value)
                {
                    this.value = value;
                    left = null;
                    right = null;
                }
            }
        }

        public class Program2
        {
            // This is the class of the input root. Do not edit it.
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
        }

        public class Program1
        {
            public static int difference = 0;
            public static int mindifferencesofar = 100000000;
            public static int closestsofar = 0;

            public static void Solve(BST tree, int target)
            {
                if (tree == null) return;


                if (tree.value == target)
                {
                    closestsofar = tree.value;
                }
                else if (target > tree.value)
                {
                    difference = target - tree.value;

                    if (difference < mindifferencesofar)
                    {
                        mindifferencesofar = difference;
                        closestsofar = tree.value;
                    }
                    Solve(tree.right, target);
                }
                else
                {

                    difference = tree.value - target;

                    if (difference < mindifferencesofar)
                    {
                        mindifferencesofar = difference;
                        closestsofar = tree.value;
                    }

                    Solve(tree.left, target);


                }



            }


            public static int FindClosestValueInBst(BST tree, int target)
            {
                // Write your code here.
                Solve(tree, target);
                return closestsofar;
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
        }



        public class LRUCache
        {

            private DoubleLinkedList _list = new DoubleLinkedList();
            private Hashtable _hashtable = new Hashtable();
            private int size;
            public LRUCache(int capacity)
            {
                size = capacity;
            }

            public int Get(int key)
            {
                if (_hashtable.ContainsKey(key))
                {
                    KeyValuePair<int, DoubleLinkedListNode> valuePair = (KeyValuePair<int, DoubleLinkedListNode>)_hashtable[key];
                    _list.MoveNodeToFirst(valuePair.Value);

                    return valuePair.Key;
                }

                return -1;
            }

            public void Put(int key, int value)
            {
                if (_hashtable.ContainsKey(key))
                {
                    KeyValuePair<int, DoubleLinkedListNode> valuePair = (KeyValuePair<int, DoubleLinkedListNode>)_hashtable[key];
                    _list.MoveNodeToFirst(valuePair.Value);
                    _hashtable[key] = new KeyValuePair<int, DoubleLinkedListNode>(value, _list.GetFirst());
                }
                else
                {
                    _list.AddFirst(key);
                    _hashtable.Add(key, new KeyValuePair<int, DoubleLinkedListNode>(value, _list.GetFirst()));
                    ControlSize();
                }
            }

            private void ControlSize()
            {
                if (_list.Count > size)
                {
                    _hashtable.Remove(_list.GetLast().Value);
                    _list.RemoveLast();
                }
            }

            class DoubleLinkedList
            {
                private DoubleLinkedListNode _dummyFirst = new DoubleLinkedListNode(-1);
                private DoubleLinkedListNode _dummyLast = new DoubleLinkedListNode(-1);
                public DoubleLinkedListNode GetFirst() => _dummyFirst.Next;
                public DoubleLinkedListNode GetLast() => _dummyLast.Prev;
                public int Count { get; private set; }

                public DoubleLinkedList()
                {
                    _dummyFirst.Next = _dummyLast;
                    _dummyLast.Prev = _dummyFirst;
                }

                public void AddFirst(int value)
                {
                    DoubleLinkedListNode newNode = new DoubleLinkedListNode(value);
                    newNode.Prev = _dummyFirst;
                    newNode.Next = _dummyFirst.Next;
                    _dummyFirst.Next.Prev = newNode;
                    _dummyFirst.Next = newNode;
                    Count++;
                }

                public void RemoveLast()
                {
                    DoubleLinkedListNode last = GetLast();
                    last.Prev.Next = last.Next;
                    _dummyLast.Prev = last.Prev;
                    last.Prev = null;
                    last.Next = null;
                    Count--;
                }

                public void MoveNodeToFirst(DoubleLinkedListNode node)
                {
                    node.Prev.Next = node.Next;
                    node.Next.Prev = node.Prev;
                    node.Next = _dummyFirst.Next;
                    node.Prev = _dummyFirst;
                    _dummyFirst.Next.Prev = node;
                    _dummyFirst.Next = node;
                }

            }




            class DoubleLinkedListNode
            {
                public DoubleLinkedListNode(int value)
                {
                    Value = value;
                }
                public DoubleLinkedListNode Next { get; set; }
                public DoubleLinkedListNode Prev { get; set; }
                public int Value { get; }
            }
        }


        public class KthLargest
        {

            private int kth;
            private List<int> stream;
            public KthLargest(int k, int[] nums)
            {
                kth = k;
                Array.Sort(nums);
                stream = new List<int>(nums);
            }

            public int Add(int val)
            {
                int idx = stream.BinarySearch(val); // O(log N)

                if (idx < 0)
                    stream.Insert(~idx, val); // O(n)
                else
                    stream.Insert(idx, val); // O(n)

                return stream[stream.Count - kth];
            }
        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public List<int> lst = new List<int>();
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }


        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }



        public class Solution
        {
            int level = 0;
            int xLevel = 0;
            int yLevel = 0;
            int iX = 0;
            int iY = 0;
            bool result = false;
            TreeNode xParent = null;
            TreeNode yParent = null;

            public void Solve(TreeNode root, TreeNode parent, int Level, int x, int y)
            {
                if (root == null) return;
                if (result) return;

                if (root.val == x)
                {
                    xLevel = Level;
                    xParent = parent;
                }

                if (root.val == y)
                {
                    yLevel = Level;
                    yParent = parent;
                }



                if ((root.val == y) && (Level == xLevel) && (parent != xParent))
                {
                    result = true;
                }

                if ((root.val == x) && (Level == yLevel) && (parent != yParent))
                {
                    result = true;
                }

                Level++;

                Solve(root.left, root, Level, x, y);
                Solve(root.right, root, Level, x, y);

            }


            public bool IsCousins(TreeNode root, int x, int y)
            {
                if ((root == null) || (root.val == x) || (root.val == y)) return false;



                Solve(root, root, level, x, y);
                return result;
            }
        }

        class Node
        {

            public int Data;
            public Node LeftNode;
            public Node RightNode;

            public Node()
            {

            }

            public Node(int num)
            {
                this.Data = num;
            }
        }

        class BTree
        {

            public Node Root;
            public int MaxSum = 0;
            public string MaxSumPath = "";

            public Node GetRoot()
            {
                return Root;
            }

            public void FindMaxSumandPath(Node RootNode, int[] pathArray, int currentPathIndex)
            {

                if (RootNode == null)
                {
                    return;
                }

                pathArray[currentPathIndex] = RootNode.Data;

                if (currentPathIndex > 0)
                {
                    if ((IsEven(pathArray[currentPathIndex]) && IsEven(pathArray[currentPathIndex - 1])) || (IsOdd(pathArray[currentPathIndex]) && IsOdd(pathArray[currentPathIndex - 1])))
                    {
                        return;
                    }
                }
                currentPathIndex++;

                if (RootNode.LeftNode == null && RootNode.RightNode == null) // Bottom Node
                {

                    int currentPathSum = 0;
                    currentPathSum = GetPathSum(pathArray, currentPathIndex);

                    if (currentPathSum > MaxSum)
                    {
                        MaxSumPath = GetPath(pathArray, currentPathIndex);
                        MaxSum = currentPathSum;
                    }
                }
                else
                {
                    // recursive calls
                    FindMaxSumandPath(RootNode.LeftNode, pathArray, currentPathIndex);
                    FindMaxSumandPath(RootNode.RightNode, pathArray, currentPathIndex);
                }
            }

            public bool IsEven(int num)
            {
                return (num % 2 == 0) ? true : false;
            }

            public bool IsOdd(int num)
            {
                return (num % 2 == 0) ? false : true;
            }

            string GetPath(int[] ints, int len)
            {
                int i;
                string strPath = "";
                for (i = 0; i < len; i++)
                {
                    strPath = strPath + ints[i].ToString();
                    if (i < len - 1)
                        strPath = strPath + ", ";
                }

                return strPath;
            }

            int GetPathSum(int[] ints, int len)
            {
                int i;
                int pathSum = 0;
                for (i = 0; i < len; i++)
                {
                    pathSum = pathSum + ints[i];
                }
                return pathSum;
            }


            public BTree()
            {

                Root = null;

            }

            public Node CreateNewNode(int data)
            {
                Node newNode = new Node();
                newNode.Data = data;
                newNode.LeftNode = null;
                newNode.RightNode = null;

                if (Root == null)
                    Root = newNode;

                return (newNode);
            }


        }

        class Program
        {


            public static int sum = 0;
            public ListNode ReverseList(ListNode head)
            {
                if (head == null)
                {
                    return head;
                }

                // last node or only one node
                if (head.next == null)
                {
                    return head;
                }

                ListNode newHeadNode = ReverseList(head.next);

                // change references for middle chain
                head.next.next = head;
                head.next = null;

                // send back new head 
                // node in every recursion
                return newHeadNode;
            }
            static int CompareString(string Str1, string Str2)
            {

                int firstIndex = Str1.IndexOf(Str2);
                int secondIndex = Str1.LastIndexOf(Str2);

                if (firstIndex < 0)
                {
                    return 0;
                }

                else if (firstIndex == secondIndex)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }

            }


            public static void bitwiseOperators()
            {
                //
                //   Binary
                //

                //
                //   Bitwise operators
                //
                //      And     & (Both)
                //      Or      | (Either)
                //      Xor     ^ (Exclusive or, different)
                //      Not     ~ (Invert)
                //    

                byte a = 122;
                byte b = 7;

                byte result = (byte)(a & b);

                //Console.WriteLine($"{ Convert.ToString(a, 2).PadLeft(8, '0')} &");
                //Console.WriteLine($"{ Convert.ToString(b, 2).PadLeft(8, '0')}");
                //Console.WriteLine($"--------");
                //Console.WriteLine($"{ Convert.ToString(result, 2).PadLeft(8, '0')}");
                //Console.WriteLine();

                //
                //   Bitwise Shifting
                //
                //      Left    <<
                //      Right   >>
                //      


                //byte c = 25;

                //var cResult = (byte)(c << 4);

                //Console.WriteLine($"{ Convert.ToString(c, 2).PadLeft(8, '0')} << 1");
                //Console.WriteLine($"--------");
                //Console.WriteLine($"{ Convert.ToString(cResult, 2).PadLeft(8, '0')}");


                //   Usage
                //   
                //      Toggling boolean
                //      Enum flags
                //      Masking
                //

                // Invert booleans
                var d = true;
                d ^= true;

                // Enum flags
                var someVals = (byte)(SomeValues.Blue);
                Console.WriteLine($"{ Convert.ToString((byte)someVals, 2).PadLeft(8, '0')}");

                if ((someVals & (byte)SomeValues.Blue) == (byte)SomeValues.Blue)
                    Console.WriteLine("Blue was included");
                if ((someVals & (byte)SomeValues.White) == (byte)SomeValues.White)
                    Console.WriteLine("White was included");

                // Masking 
                //
                // -----1- Input
                // 0000010 < Important bit (the mask)

                // 0000010

                var input = (byte)(SomeValues.White | SomeValues.Blue);
                var mask = (byte)SomeValues.Blue;
                var r = input & mask;


                Console.ReadLine();
            }


            public static int CalPiontList(string[] ops)
            {
                int totalScore = 0;
                //  ArrayList arList = new ArrayList();
                var arList = new List<int>();





                for (int i = 0; i < ops.Length; i++)
                {
                    int variable = 0;
                    int.TryParse(ops[i], out variable);

                    if (ops[i] == "D")
                    {


                        arList.Add(2 * arList[arList.Count - 1]);
                    }
                    else if (ops[i] == "C")
                    {
                        arList.RemoveAt(arList.Count - 1);
                    }
                    else if (ops[i] == "+")
                    {
                        arList.Add(arList[arList.Count - 1] + arList[arList.Count - 2]);
                    }
                    else
                    {
                        arList.Add(variable);
                    }
                }

                foreach (var item in arList)
                {
                    totalScore = totalScore + int.Parse(item.ToString());
                }

                return totalScore;

            }

            public static int CalPiont(string[] ops)
            {
                int totalScore = 0;
                ArrayList arList = new ArrayList();





                for (int i = 0; i < ops.Length; i++)
                {
                    int variable = 0;
                    int.TryParse(ops[i], out variable);

                    if (ops[i] == "D")
                    {


                        arList.Add(2 * (int.Parse(arList[arList.Count - 1].ToString())));
                    }
                    else if (ops[i] == "C")
                    {
                        arList.RemoveAt(arList.Count - 1);
                    }
                    else if (ops[i] == "+")
                    {
                        arList.Add(int.Parse(arList[arList.Count - 1].ToString()) + int.Parse(arList[arList.Count - 2].ToString()));
                    }
                    else
                    {
                        arList.Add(variable);
                    }




                }

                foreach (var item in arList)
                {
                    totalScore = totalScore + int.Parse(item.ToString());
                }

                return totalScore;

            }


            public static int[] TwoSum(int[] nums, int target)
            {

                var numberNames = new Dictionary<int, int>();
                int[] ar = new int[2];
                for (int i = 0; i < nums.Length; i++)
                {
                    if (!numberNames.ContainsKey(nums[i]))
                        numberNames.Add(nums[i], i);
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    int result43;

                    if (numberNames.TryGetValue(target - nums[i], out result43))
                    {
                        if ((result43 > -1) && (result43 != i))
                        {
                            ar[0] = i;
                            ar[1] = result43;
                            break;

                        }
                    }
                }
                return ar;
            }

            public static int MajorityElement(int[] nums)
            {
                var dict = new Dictionary<int, int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    if (dict .ContainsKey(nums[i]))
                    {
                        dict[nums[i]] = dict[nums[i]] + 1;

                    }
                    else
                    {
                        dict.Add(nums[i], 1);

                    }

                }

                foreach (var pair in dict)
                {
                    if (pair.Value > nums.Length / 2)
                    {
                        return pair.Key;
                    }

                }

                return 0;

            }


            public static int CounElementsWithList(int[] arr)
            {

                Array.Sort(arr);
                int totalCount = 0;
                int duplicateCount = 1;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (i > 0)
                    {

                        if (arr[i] == arr[i - 1])
                        {
                            duplicateCount++;
                            continue;
                        }
                        else
                        {

                            if (i < arr.Length - 1)
                            {
                                if (arr[i] == arr[i + 1] - 1)
                                {
                                    totalCount = totalCount + duplicateCount;
                                }
                                else
                                {
                                    duplicateCount = 1;
                                }
                            }


                        }

                    }



                }

                return totalCount;

            }

            public static int CounElements(int[] arr)
            {

                Array.Sort(arr);
                int totalCount = 0;
                int duplicateCount = 1;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (i > 0)
                    {

                        if (arr[i] == arr[i - 1])
                        {
                            duplicateCount++;
                            continue;

                        }
                        else
                        {
                            duplicateCount = 1;
                        }

                    }

                    if (i < arr.Length - 1)
                    {
                        if (arr[i] == arr[i + 1] - 1)
                        {
                            totalCount = totalCount + duplicateCount;
                        }
                        else
                        {
                            duplicateCount = 1;
                        }
                    }

                }

                return totalCount;

            }
            public static string abInteger(int A, int B)
            {
                // write your code in C# 6.0 with .NET 4.5 (Mono)
                string Bigger = "a";
                string Smaller = "b";
                int nBigger = A;
                int nSmaller = B;
                string result = "";
                int difference = 0;
                bool isBigger = true;
                if (A > B)
                {
                    Bigger = "a";
                    Smaller = "b";
                    difference = A - B;
                    nBigger = A;
                    nSmaller = B;
                }
                else
                {
                    Bigger = "b";
                    Smaller = "a";
                    difference = B - A;
                    nBigger = B;
                    nSmaller = A;
                }
                for (int i = 0; i < difference;)
                {

                    if (isBigger)
                    {
                        result = result + Bigger + Bigger;
                        i = i + 2;
                        nBigger = nBigger - 2;
                        isBigger = false;
                    }

                    else
                    {

                        result = result + Smaller;
                        i++;
                        nSmaller = nSmaller - 1;
                        isBigger = true;
                    }

                }
                var sum = nSmaller + nBigger;
                for (int i = 0; i < sum;)
                {
                    if (isBigger)
                    {
                        if (result.Length > 2)
                        {

                        }
                        if ((nBigger > 0) && ((result.Length > 2) || (result.Substring(result.Length - 2) != Bigger + Bigger)))
                        {
                            result = result + Bigger;

                            i = i + 1;
                            nBigger = nBigger - 1;
                        }
                        isBigger = false;
                    }
                    else
                    {
                        if ((nSmaller > 0) && ((result.Length > 2) || (result.Substring(result.Length - 2) != Smaller + Smaller)))
                        {
                            result = result + Smaller;
                            i++;
                            nSmaller = nSmaller - 1;
                        }
                        isBigger = true;
                    }
                }

                return result;
            }

            public static void Solve(TreeNode root, TreeNode Parent)
            {
                if (root == null) return;
                if ((root.left == null) && (root.right == null) && (Parent.left == root))
                {
                    sum = sum + root.val;

                }
                else
                {
                    Solve(root.left, root);
                    Solve(root.right, root);

                }

            }

            public static void Solve(TreeNode root, TreeNode parent, int val)
            {
                if ((root == null) && (val < parent.val))
                {
                    parent.left = new TreeNode(val);
                    return;
                }
                else if ((root == null) && (val > parent.val))
                {
                    parent.right = new TreeNode(val);
                    return;
                }
                if (val < root.val)
                {
                    Solve(root.left, root, val);
                }
                else
                {
                    Solve(root.right, root, val);
                }
            }

            public static TreeNode InsertIntoBST(TreeNode root, int val)
            {
                if (root == null)
                {
                    root = new TreeNode(val);
                    return root;
                }

                Solve(root, root, val);
                return root;
            }

            public static int SumOfLeftLeaves(TreeNode root)
            {

                Solve(root, root);
                return sum;


            }


            public static bool MakeEqual(string[] words)
            {
                int[] freq = new int[26];


                foreach (var word in words)
                {
                    foreach (var chr in word)
                    {
                        freq[chr - 'a']++;
                    }
                }

                for (int i = 0; i < 26; i++)
                {
                    if (freq[i] % words.Length != 0)
                        return false;
                }

                return true;
            }

            public static void Merge(int[] nums1, int m, int[] nums2, int n)
            {
                int nInidex = 0;
                int mInidex = 0;
                int[] result = new int[nums1.Length];
                int curElem = 0;

                if (n == 0)
                {
                    return;
                }

                if (m == 0)
                {

                    Array.Copy(nums2, nums1, nums2.Length);
                    return;
                }

                int index = 0;
                for (int i = m; i < nums1.Length; i++)
                {
                    nums1[i] = nums2[index++];
                }

                Array.Sort(nums1);
            }
            public static int MaxSubArray(int[] nums)
            {
                int MaxSum = nums[0];
                int currSum = 0;

                foreach (var num in nums)
                {
                    if (currSum < 0) currSum = 0;
                    currSum = currSum + num;
                    MaxSum = Math.Max(MaxSum, currSum);


                }
                return MaxSum;
            }


            public static int[] Intersect(int[] nums1, int[] nums2)
            {
                var dArray = new List<int> { };
                int nIndex = 0;
                int mIndex = 0;

                Array.Sort(nums1);
                Array.Sort(nums2);

                for (int i = 0; i < nums1.Length + nums2.Length; i++)
                {

                    if (nIndex >= nums1.Length) break;
                    if (mIndex >= nums2.Length) break;

                    if (nums1[nIndex] == nums2[mIndex])
                    {
                        dArray.Add(nums1[nIndex]);
                        nIndex++;
                        mIndex++;
                    }

                    else if (nums1[nIndex] > nums2[mIndex])
                    {
                        mIndex++;
                    }
                    else
                    {
                        nIndex++;

                    }



                }

                return dArray.ToArray();

            }

            public static bool IsValid(string s)
            {
                var myStack = new Stack<string>();
                var popString = "";

                if (s.Length == 1)
                {
                    return false;
                }



                for (int i = 0; i < s.Length; i++)
                {
                    if ((s[i] == '(') || (s[i] == '{') || (s[i] == '['))
                    {
                        myStack.Push(s[i].ToString());
                    }
                    else
                    {

                        if (myStack.Count == 0)
                        {
                            return false;
                        }

                        popString = myStack.Pop();

                        if ((s[i] == ')') && (popString != "("))
                        {
                            return false;
                        }
                        else if ((s[i] == '}') && (popString != "{"))
                        {
                            return false;
                        }
                        else if ((s[i] == ']') && (popString != "["))
                        {
                            return false;
                        }
                    }
                }

                if (myStack.Count == 0) return true;
                else return false;
            }


            public static int[][] MatrixReshape(int[][] mat, int r, int c)
            {


                if (mat == null) return null;

                if ((r == 0) && (c == 0)) return mat;




                int[] num1 = new int[r * c];
                int counter = 0;

                // Declare the array of two elements.
                int[][] arr = new int[r][];

                for (int x = 0; x < r; x++)
                {
                    arr[x] = new int[c];

                }

                if ((mat.Length * mat[0].Length) != (arr.Length * arr[0].Length))
                {
                    return mat;
                }



                for (int i = 0; i < mat.Length; i++)
                {
                    for (int j = 0; j < mat[i].Length; j++)
                    {



                        num1[counter] = mat[i][j];
                        counter++;
                    }
                }

                counter = 0;

                for (int k = 0; k < arr.Length; k++)
                {
                    for (int m = 0; m < arr[k].Length; m++)
                    {
                        arr[k][m] = num1[counter];
                        counter++;
                    }
                }

                return arr;

            }




            public int[][] MatrixReshapeEfficient(int[][] mat, int r, int c)
            {


                if (mat[0].Length * mat.Length != r * c)
                    return mat;
                int[][] a = new int[r][];

                for (int x = 0; x < r; x++)
                {
                    a[x] = new int[c];

                }


                int m = 0, n = 0;
                for (int i = 0; i < mat.Length; i++)
                {
                    for (int j = 0; j < mat[i].Length; j++)
                    {
                        a[m][n++] = mat[i][j];
                        if (n > c - 1)
                        {
                            n = 0;
                            m++;
                        }
                    }
                }

                return a;

            }


            public int[][] Transpose(int[][] matrix)
            {



                int[][] result = new int[matrix[0].Length][];

                for (int x = 0; x < matrix[0].Length; x++)
                {
                    result[x] = new int[matrix.Length];

                }



                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix[0].Length; j++)
                    {
                        result[j][i] = matrix[i][j];
                    }
                }


                return result;



            }



            public void Rotate(int[] nums, int k)
            {

                if (nums.Length < k) ;


                if (k > nums.Length) k %= nums.Length;


                int[] temp12Nums = new int[nums.Length];

                Array.Copy(nums, temp12Nums, nums.Length);

                for (int j = 0; j < nums.Length; j++)
                {
                    int newIndex = j + (k);
                    if (newIndex > nums.Length - 1) newIndex = newIndex - (nums.Length);

                    nums[newIndex] = temp12Nums[j];
                }


            }



            public static int Distance = 0;
            public static bool BreakExecution = false;





            public static int[][] UpdateMatrix(int[][] mat)
            {
                if (mat == null) return mat;

                for (int i = 0; i < mat.Length; i++)
                {
                    for (int j = 0; j < mat[i].Length; j++)
                    {
                        if (mat[i][j] == 0) continue;
                        //Solve(mat, i, j, out Distance);
                        mat[i][j] = Distance;
                        Distance = 0;
                        BreakExecution = false;
                    }
                }

                return mat;

            }

            //public static void Solve(int[][] mat, int i, int j, out int Distance)
            //{
            //    if ((i < 0) || (j < 0) || (i >= mat.Length) || (j >= mat[0].Length)) return;

            //    if (BreakExecution) return;






            //    if (mat[i][j] == 0)
            //    {

            //        BreakExecution = true;
            //        return;
            //    }

            //    Distance++;



            //    Solve(mat, i + 1, j, Distance);
            //    Solve(mat, i, j + 1, Distance);
            //    Solve(mat, i - 1, j, Distance);
            //    Solve(mat, i, j - 1, Distance);




            //}

            public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
            {

                if (root1 == null)
                {
                    root1 = root2;
                }
                else if (root2 != null)
                {
                    if (root1.left == null)
                    {
                        root1.left = root2.left;
                    }
                    else if (root2.left != null)
                    {
                        MergeTrees(root1.left, root2.left);
                    }
                    root1.val += root2.val;

                    if (root1.right == null)
                    {
                        root1.right = root2.right;
                    }
                    else if (root2.right != null)
                    {
                        MergeTrees(root1.right, root2.right);

                    }


                }
                return root1;
            }

            public int NumIslands(char[][] grid)
            {

                int result = 0;

                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        if (grid[i][j] == '1')
                        {
                            CountIsland(grid, i, j);
                            result++;
                        }
                    }
                }

                return result;
            }

            public void CountIsland(char[][] grid, int i, int j)
            {
                if ((i < 0) || (j < 0) || (i >= grid.Length) || (j >= grid[0].Length)) return;


                if (grid[i][j] == '0') return;

                grid[i][j] = '0';

                CountIsland(grid, i + 1, j);
                CountIsland(grid, i, j + 1);
                CountIsland(grid, i - 1, j);
                CountIsland(grid, i, j - 1);

            }


            public static int MaxProfitToaste(int[] prices)
            {

                int maxProfit = 0;

                if (prices.Length > 5)
                {
                    int buy = 0;
                    int sell = 4;
                    int minsofar = 1000000000;

                    while (sell < prices.Length)
                    {
                        minsofar = Math.Min(prices[buy], minsofar);
                        maxProfit = Math.Max(maxProfit, prices[sell] - minsofar);
                        sell++;
                        buy++;
                    }

                }
                else
                {
                    return 0;
                }

                return maxProfit;
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

            public static int MaxArea(int[] height)
            {
                int firstPointer = 0;
                int secondPointer = height.Length - 1;
                int MaxArea = 0;
                int currentArea = 0;


                while (firstPointer < secondPointer)
                {
                    currentArea = (secondPointer - firstPointer) * (Math.Min(height[firstPointer], height[secondPointer]));

                    MaxArea = Math.Max(MaxArea, currentArea);

                    if (height[secondPointer] > height[firstPointer])
                    {
                        firstPointer++;
                    }
                    else
                    {
                        secondPointer--;
                    }
                }

                return MaxArea;
            }

            public static int[] TwoNumberSum1(int[] array, int targetSum)
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

            public static bool CanPlaceFlowers(int[] flowerbed, int n)
            {

                int count = 0;
                if (flowerbed.Length == 1)
                {
                    if (flowerbed[0] == 0)
                    {
                        count++;
                    }
                    return count >= n;
                }

                for (int i = 0; i < flowerbed.Length; i++)
                {
                    if (flowerbed[i] == 0)
                    {
                        if (i == 0 && (i + 1) != flowerbed.Length)
                        {
                            if (flowerbed[i + 1] != 1)
                            {
                                flowerbed[i] = 1;
                                count++;
                            }
                        }
                        if (i > 0 && (i + 1) < flowerbed.Length)
                        {
                            if (flowerbed[i - 1] != 1 && flowerbed[i + 1] != 1)
                            {
                                flowerbed[i] = 1;
                                count++;
                            }
                        }
                        if (i == flowerbed.Length - 1)
                        {
                            if (flowerbed[i - 1] != 1)
                            {
                                flowerbed[i] = 1;
                                count++;
                            }
                        }
                    }

                }

                return count >= n;


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

            public static int programmerStrings(string s)
            {
                string programmerstring = "programmer";

                int[] freqP = new int[26];
                int[] freqfirstP = new int[26];
                int[] freqsecondsP = new int[26];
                int firstProgLastIndex = 0;
                int secondProgFirstIndex = s.Length;

                foreach (var c in programmerstring)
                {
                    freqP[c - 'a']++;

                }

                for (int i = 0; i < s.Length; i++)
                {
                    freqfirstP[s[i] - 'a']++;

                    if ((freqfirstP['r' - 'a'] == freqP['r' - 'a']) && (freqfirstP['m' - 'a'] == freqP['m' - 'a']) && (freqfirstP['p' - 'a'] == freqP['p' - 'a']) && (freqfirstP['o' - 'a'] == freqP['o' - 'a']) && (freqfirstP['g' - 'a'] == freqP['g' - 'a']) && (freqfirstP['a' - 'a'] == freqP['a' - 'a']))
                    {
                        firstProgLastIndex = i;
                        break;

                    }

                }


                for (int j = s.Length - 1; j >= 0; j--)
                {
                    freqsecondsP[s[j] - 'a']++;

                   if ((freqsecondsP['r' - 'a'] == freqP['r' - 'a']) && (freqsecondsP['m' - 'a'] == freqP['m' - 'a']) && (freqsecondsP['p' - 'a'] == freqP['p' - 'a']) && (freqsecondsP['o' - 'a'] == freqP['o' - 'a']) && (freqsecondsP['g' - 'a'] == freqP['g' - 'a']) && (freqsecondsP['a' - 'a'] == freqP['a' - 'a']))
                        {
                        secondProgFirstIndex = j;
                        break;

                    }

                }


                return secondProgFirstIndex - firstProgLastIndex;





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

            public static int GetNthFib(int n)
            {
                // Write your code here.
                if (n == 2) return 1;
                else if (n == 1) return 0;
                else return GetNthFib(n - 1) + GetNthFib(n - 2);
            }


            public static LinkedList ReverseLinkedList(LinkedList head)
            {
                // Write your code here.


                LinkedList prev = null;


                while (head != null)
                {
                   // LinkedList next = head.Next;
                  //  head.Next = prev;
                    prev = head;
                  //  head = next;

                }

                return prev;



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

            //public static void InvertBinaryTree(BinaryTree tree)
            //{
            //    // Write your code here.
            //    if (tree == null) return;

            //    if ((tree.left != null) && (tree.right != null))
            //    {
            //        BinaryTree temp = tree.left;
            //        tree.left = tree.right;
            //        tree.right = temp;
            //    }

            //    else if (tree.left == null)
            //    {

            //        tree.left = tree.right;
            //        tree.right = null;
            //    }

            //    else if (tree.right == null)
            //    {

            //        tree.right = tree.left;
            //        tree.left = null;
            //    }

            //    InvertBinaryTree(tree.left);
            //    InvertBinaryTree(tree.right);




            //}

            public static bool IsSubsequence(string s, string t)
            {

                int firstStringPointer = 0;

                if (s.Length == 0) return true;
                if (t.Length == 0) return false;

                for (int i = 0; i < t.Length; i++)
                {
                    if (t[i] == s[firstStringPointer])
                    {
                        firstStringPointer++;
                    }
                    if (firstStringPointer >= s.Length)
                    {
                        return true;
                    }
                }

                return false;
            }

            public IList<IList<string>> GroupAnagrams(string[] strs)
            {
                if (strs == null || strs.Length == 0)
                    return null;

                List<IList<string>> result = new List<IList<string>>();
                List<string> temp = new List<string>();
                System.Collections.Hashtable dictionary = new System.Collections.Hashtable();
                int currentIndex = 0;

                if (strs.Length == 1)
                {
                    temp.Add(strs[0]);

                    result.Add(temp);
                }
                else
                {
                    foreach (var item in strs)
                    {
                        if (dictionary.Contains(SortString(item)))
                            result[(int)dictionary[SortString(item)]].Add(item);
                        else
                        {
                            dictionary.Add(SortString(item), currentIndex++);

                            temp = new List<string>();
                            temp.Add(item);

                            result.Add(temp);
                        }
                    }
                }

                return result;
            }

            public static string SortString(string input)
            {
                return "";

                //char[] characters = input.ToArray();
                //Array.Sort(characters);

                //return new string(characters);
            }

            public static int toptal23(string[] T, string[] R)
            {
                // write your code in C# 6.0 with .NET 4.7 (Mono 6.12)
                int totalGroupsCount = 0;
                int passedGroupCount = 0;
                int score = 0;
                var dictTestCases = new Dictionary<string, string>();

                for (int i = 0; i < T.Length; i++)
                {
                    if (!dictTestCases.ContainsKey(T[i]))
                    {
                        dictTestCases.Add(T[i], R[i]);
                    }
                }

                for (int j = 0; j < T.Length; j++)
                {
                    if (dictTestCases.ContainsKey(T[j]))
                    {

                        bool isTestPassed = true;


                        if (dictTestCases[T[j]] != "OK")
                        {
                            isTestPassed = false;
                        }

                       

                        dictTestCases.Remove(T[j]);
                        if (Char.IsLetter(T[j][T[j].Length - 1]))
                        {
                            T[j] = T[j].Remove(T[j].Length - 1);
                        }

                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            if (dictTestCases.ContainsKey(T[j] + c))
                            {

                                if (dictTestCases[T[j] + c] != "OK")
                                {
                                    isTestPassed = false;
                                }

                                dictTestCases.Remove(T[j]+c);
                            }



                        }

                        if (isTestPassed) passedGroupCount++;

                        totalGroupsCount++;
                    }

                    

                }

                score = Math.Abs((passedGroupCount * 100) / totalGroupsCount);

                return score;


            }

            public int[] ProductExceptSelf(int[] nums)
            {
                int[] ret = new int[nums.Length];
                ret[0] = 1;
                for (int i = 1; i < nums.Length; i++)
                {
                    ret[i] = ret[i - 1] * nums[i - 1];
                }
                int right = 1;
                for (int i = nums.Length - 1; i >= 0; i--)
                {
                    ret[i] = ret[i] * right;
                    right *= nums[i];
                }
                return ret;
            }

            public static int MaxProduct(int[] nums)
            {
                var n = nums.Length;

                if (n == 0) return 0;
                if (n == 1) return nums[0];

                var minArr = new int[n];
                var maxArr = new int[n];

                minArr[0] = nums[0];
                maxArr[0] = nums[0];

                for (int i = 1; i < n; i++)
                {
                    maxArr[i] = Math.Max(Math.Max(maxArr[i - 1] * nums[i], minArr[i - 1] * nums[i]), nums[i]);
                    minArr[i] = Math.Min(Math.Min(minArr[i - 1] * nums[i], maxArr[i - 1] * nums[i]), nums[i]);
                }

                return maxArr.Max();
            }

            public int SearchRotatedArray(int[] nums, int target)
            {
                var n = nums.Length;

                var left = 0;
                var right = n - 1;

                while (left <= right)
                {
                    var mid = left + (right - left) / 2;
                    if (nums[mid] == target)
                    {
                        return mid;
                    }
                    else if (nums[left] <= nums[mid])
                    {
                        // NOTE: left might equal to mid [3,1], single number matches the rule, so need nums[left] <= nums[mid]
                        // increasing on the left
                        if (nums[left] <= target && target <= nums[mid])
                        {
                            right = mid - 1;
                        }
                        else
                        {
                            left = mid + 1;
                        }
                    }
                    else
                    {
                        // increasing on the right
                        if (nums[mid] <= target && target <= nums[right])
                        {
                            left = mid + 1;
                        }
                        else
                        {
                            right = mid - 1;
                        }
                    }
                }

                return -1;
            }

            public static int FindMin(int[] nums)
            {
                var n = nums.Length;

                var left = 0;
                var right = n - 1;

                var globalMin = int.MaxValue;

                while (left <= right)
                {
                    var mid = left + (right - left) / 2;
                    if (nums[mid] < nums[right])
                    {
                        globalMin = Math.Min(globalMin, nums[mid]);
                        right = mid - 1;
                    }
                    else
                    {
                        globalMin = Math.Min(globalMin, nums[left]);
                        left = mid + 1;
                    }
                }

                return globalMin;
            }

            public static int GetSumBinary(int a, int b)
            {
                if (b == 0) return a;

                var noCarry = a ^ b;
                var carry = a & b;

                return GetSumBinary(noCarry, carry << 1);
            }

            public static int MissingNumber(int[] nums)
            {
                for (int i = 0; i <= nums.Length; i++)
                {
                    if (nums.Contains(i) == false)
                        return i;
                }
                return -1;
            }

            public int LengthOfLIS(int[] nums)
            {
                int len = nums.Length;
                if (len < 2) return len;
                int[] dp = new int[len];
                int count = 0;

                for (int i = 0; i < len; i++)
                {
                    int idx = Array.BinarySearch(dp, 0, count, nums[i]);
                    if (idx < 0) idx = ~idx;
                    dp[idx] = nums[i];
                    if (idx == count) count++;
                }

                return count;
            }

            public int LongestCommonSubsequence(string text1, string text2)
            {
                //     d l l e d 
                //  f  0 0 0 0 0          
                //  l  0 1 1 1 1   
                //  d  1 1 1 1 2    
                int n = text1.Length;
                int m = text2.Length;
                int[][] dp = new int[n + 1][];

                for (int i = 0; i <= n; ++i)
                {
                    dp[i] = new int[m + 1];
                }

                for (int i = 1; i <= n; ++i)
                {
                    for (int j = 1; j <= m; ++j)
                    {
                        if (text1[i - 1] == text2[j - 1])
                        {
                            dp[i][j] = dp[i - 1][j - 1] + 1;
                        }
                        dp[i][j] = Math.Max(dp[i][j], Math.Max(dp[i - 1][j], dp[i][j - 1]));
                    }

                }

                return dp[n][m];
            }

            public IList<IList<int>> CombinationSum(int[] candidates, int target)
            {
                var result = new List<IList<int>>();
                if (candidates.Length == 0) return result;
                Array.Sort(candidates);
                DFS(candidates, target, 0, new List<int>(), result);
                return result;
            }

            public int NumDecodings(string s)
            {
                if (s == null || s.Length == 0 || s[0] == '0')
                    return 0;

                int n = s.Length;
                int[] dp = new int[n + 1];

                dp[0] = 1;
                dp[1] = 1;

                for (int i = 2; i <= n; i++)
                {
                    int num1 = int.Parse(s.Substring(i - 1, 1));
                    int num2 = int.Parse(s.Substring(i - 2, 2));
                    int c1 = num1 > 0 ? dp[i - 1] : 0;
                    int c2 = num2 >= 10 && num2 <= 26 ? dp[i - 2] : 0;
                    dp[i] = c1 + c2;
                }

                return dp[n];
            }

            public bool CanJump(int[] nums)
            {
                int farthest = nums[0];

                for (int i = 0; i < nums.Length; i++)
                {
                    if (i > farthest)
                        return false;

                    farthest = Math.Max(farthest, i + nums[i]);
                    if (farthest > nums.Length)
                        return true;
                }

                return true;
            }

            public bool CanFinish(int n, int[][] prerequisites)
            {
                var graph = new Dictionary<int, HashSet<int>>();
                for (int i = 0; i < n; i++)
                    graph[i] = new HashSet<int>();

                int[] inDegree = new int[n];
                foreach (var p in prerequisites)
                {
                    int u = p[0], v = p[1];
                    graph[v].Add(u);
                    inDegree[u]++;
                }

                for (int i = 0; i < n; i++)
                {
                    int curr = FindCourseToTake(graph, inDegree);
                    if (curr < 0)
                        break;
                    if (graph[curr] != null)
                    {
                        foreach (var next in graph[curr])
                            inDegree[next]--;
                        graph[curr] = null;
                    }
                }

                return inDegree.Sum() == 0;
            }


            public IList<IList<int>> PacificAtlantic1(int[][] matrix)
            {

                List<IList<int>> res = new List<IList<int>>();
                if (matrix == null || matrix.Length == 0)
                    return res;

                int m = matrix.Length, n = matrix[0].Length;
                bool[,] pacific = new bool[m, n];
                bool[,] atlantic = new bool[m, n];

                for (int row = 0; row < m; row++)
                {
                    DFS1(row, 0, matrix, pacific, matrix[row][0]);
                    DFS1(row, n - 1, matrix, atlantic, matrix[row][n - 1]);
                }

                for (int col = 0; col < n; col++)
                {
                    DFS1(0, col, matrix, pacific, matrix[0][col]);
                    DFS1(m - 1, col, matrix, atlantic, matrix[m - 1][col]);
                }

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (pacific[i, j] && atlantic[i, j])
                            res.Add(new List<int>() { i, j });
                    }
                }

                return res;
            }

            private void DFS1(int row, int col, int[][] matrix, bool[,] reach, int prev)
            {
                int m = matrix.Length, n = matrix[0].Length;

                if (row < 0 || row >= m || col < 0 || col >= n || reach[row, col] || matrix[row][col] < prev)
                    return;

                reach[row, col] = true;
                DFS1(row, col + 1, matrix, reach, matrix[row][col]);
                DFS1(row, col - 1, matrix, reach, matrix[row][col]);
                DFS1(row + 1, col, matrix, reach, matrix[row][col]);
                DFS1(row - 1, col, matrix, reach, matrix[row][col]);
            }

            public int[][] Insert(int[][] intervals, int[] newInterval)
            {
                List<int[]> result = new List<int[]>();
                int i = 0;

                // Step 1 - add all intervals ending before newInterval starts
                while (i < intervals.Length && intervals[i][1] < newInterval[0])
                    result.Add(intervals[i++]);

                // Step 2 - update the newInterval by merging with all overlapping intervals
                while (i < intervals.Length && intervals[i][0] <= newInterval[1])
                {
                    newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                    newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
                    i++;
                }
                result.Add(newInterval); // add updated interval

                // Step 3 - add remaining intervals
                while (i < intervals.Length)
                    result.Add(intervals[i++]);

                return result.ToArray();
            }

            public ListNode MergeKLists(ListNode[] lists)
            {
                if (lists == null || lists.Length == 0)
                    return null;
                if (lists.Length == 1)
                    return lists[0];

                var dict = new Dictionary<int, List<ListNode>>();

                foreach (var list in lists)
                {
                    var cur = list;
                    while (cur != null)
                    {
                        if (dict.ContainsKey(cur.val))
                            dict[cur.val].Add(cur);
                        else
                            dict.Add(cur.val, new List<ListNode>() { cur });

                        cur = cur.next;
                    }
                }

             

                var sorted = dict.OrderBy(d => d.Key).ToArray();
                ListNode head = null, curNode = null;
                foreach (var nodes in sorted)
                {
                    foreach (var node in nodes.Value)
                    {
                        if (head == null)
                        {
                            head = node;
                            curNode = head;
                        }
                        else
                        {
                            curNode.next = node;
                            curNode = curNode.next;
                        }
                    }
                }

                if (curNode != null)
                    curNode.next = null;

                return head;
            }

            public void ReorderList(ListNode head)
            {
                if (head == null || head.next == null || head.next.next == null)
                    return;

                MergeLists(head, ReverseList(FindMiddleNode(head)));
            }

            private ListNode FindMiddleNode(ListNode head)
            {
                ListNode fast = head,
                         slow = head,
                         tail = null;

                while (fast != null && fast.next != null)
                {
                    fast = fast.next.next;
                    tail = slow;
                    slow = slow.next;
                }

                tail.next = null;

                return slow;
            }

            public void SetZeroes(int[][] matrix)
            {
                var firstRow = 1;
                var firstCol = 1;

                var n = matrix.Length;

                if (n == 0) return;
                var m = matrix[0].Length;

                for (int i = 0; i < n; i++)
                {
                    if (matrix[i][0] == 0)
                    {
                        firstCol = 0;
                    }
                }

                for (int j = 0; j < m; j++)
                {
                    if (matrix[0][j] == 0)
                    {
                        firstRow = 0;
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i][j] == 0)
                        {
                            matrix[i][0] = 0;
                            matrix[0][j] = 0;
                        }
                    }
                }

                // set 0

                for (int j = 1; j < m; j++)
                {
                    if (matrix[0][j] == 0)
                    {
                        for (int i = 1; i < n; i++)
                        {
                            matrix[i][j] = 0;
                        }
                    }
                }

                for (int i = 1; i < n; i++)
                {
                    if (matrix[i][0] == 0)
                    {
                        for (int j = 1; j < m; j++)
                        {
                            matrix[i][j] = 0;
                        }
                    }
                }

                if (firstRow == 0)
                {
                    for (int j = 1; j < m; j++)
                    {
                        matrix[0][j] = 0;
                    }
                }

                if (firstCol == 0)
                {
                    for (int i = 1; i < n; i++)
                    {
                        matrix[i][0] = 0;
                    }
                }
            }

            private ListNode ReverseList1(ListNode head)
            {
                ListNode n1 = head,
                         n2 = n1.next,
                         n3 = n2?.next;

                n1.next = null;

                while (n2 != null)
                {
                    n2.next = n1;

                    n1 = n2;
                    n2 = n3;

                    if (n3 != null)
                        n3 = n3.next;
                }

                return n1;
            }

            private void MergeLists(ListNode l1, ListNode l2)
            {
                ListNode cur = new ListNode(),
                         next = l1;

                while (l1 != null && l2 != null)
                {
                    cur.next = next;
                    cur = cur.next;

                    if (next == l1)
                    {
                        l1 = l1.next;
                        next = l2;
                    }
                    else if (next == l2)
                    {
                        l2 = l2.next;
                        next = l1;
                    }
                }

                if (l1 != null)
                    cur.next = l1;

                if (l2 != null)
                    cur.next = l2;
            }

            public ListNode RemoveNthFromEnd(ListNode head, int n)
            {
                if (head == null)
                    return null;

                ListNode dummyNode = new ListNode(-1),
                         tempNode1 = dummyNode,
                         tempNode2 = dummyNode;
                tempNode1.next = head;

                for (int i = 1; i <= n + 1; i++)
                    tempNode2 = tempNode2.next;

                while (tempNode2 != null)
                {
                    tempNode1 = tempNode1.next;
                    tempNode2 = tempNode2.next;
                }

                tempNode1.next = tempNode1.next.next;

                return dummyNode.next;
            }

            public int LongestConsecutive(int[] nums)
            {
                var n = nums.Length;
                if (n == 0) return 0;
                var numAndLeftRight = new Dictionary<int, Tuple<int, int>>();

                var global = 1;

                foreach (var num in nums)
                {
                    if (numAndLeftRight.ContainsKey(num)) continue;

                    var pre = num - 1;
                    var next = num + 1;

                    var start = numAndLeftRight.ContainsKey(pre) ? numAndLeftRight[pre].Item1 : num;
                    var end = numAndLeftRight.ContainsKey(next) ? numAndLeftRight[next].Item2 : num;

                    global = Math.Max(end - start + 1, global);

                    var curRange = Tuple.Create(start, end);
                    numAndLeftRight[num] = curRange;
                    numAndLeftRight[start] = curRange;
                    numAndLeftRight[end] = curRange;
                }

                return global;
            }

            private int FindCourseToTake(Dictionary<int, HashSet<int>> graph, int[] inDegree)
            {
                for (int i = 0; i < inDegree.Length; i++)
                    if (inDegree[i] == 0 && graph[i] != null)
                        return i;
                return -1;
            }

            /*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

            /*

            public Node CloneGraph(Node node)
            {
                if (node == null)
                    return node;

                Queue<Node> queue = new Queue<Node>();
                Dictionary<Node, Node> visited = new Dictionary<Node, Node>();  // key: node, val: copy

                queue.Enqueue(node);
                visited.Add(node, new Node(node.val));

                while (queue.Count > 0)
                {
                    Node curr = queue.Dequeue();
                    foreach (var neighbor in curr.neighbors)
                    {
                        if (!visited.ContainsKey(neighbor))
                        {
                            // deep copy neighbor node
                            visited.Add(neighbor, new Node(neighbor.val));
                            queue.Enqueue(neighbor);
                        }

                        // add neighbor's copy to curr's copy
                        visited[curr].neighbors.Add(visited[neighbor]);
                    }
                }

                return visited[node];
            }

    */

            public int UniquePaths(int m, int n)
            {
                // Matrix to store the value of possible ways to reach each cell
                int[][] dp = new int[m][];

                // C# thing, as we cannot define int[][] dp = new int[m][n]; 
                for (int i = 0; i < m; i++)
                {
                    dp[i] = new int[n];
                }

                //Base Conditions 
                // all first column of every row as 1
                for (int i = 0; i < dp.Length; i++)
                    dp[i][0] = 1;
                // all first row of every column as 1
                for (int i = 0; i < dp[0].Length; i++)
                    dp[0][i] = 1;

                for (int i = 1; i < m; i++)
                {
                    for (int j = 1; j < n; j++)
                    {
                        dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
                    }
                }

                return dp[m - 1][n - 1];
            }

            public int Rob1(int[] nums)
            {
                var (p2, p) = (0, 0);
                foreach (var n in nums) (p2, p) = (p, Math.Max(p, p2 + n));
                return p;
            }

            public int Rob(int[] nums)
            {
                if (nums.Length == 1) return nums[0];
                var (p2, p) = (0, 0);
                for (var i = 0; i < nums.Length - 1; i++)
                {
                    (p2, p) = (p, Math.Max(p2 + nums[i], p));
                }
                var max = p;
                (p2, p) = (0, 0);
                for (var i = 1; i < nums.Length; i++)
                {
                    (p2, p) = (p, Math.Max(p2 + nums[i], p));
                }
                return Math.Max(max, p);
            }

            private void DFS(int[] candidates, int target, int start, IList<int> oneResult, IList<IList<int>> result)
            {
                if (target == 0)
                {
                    result.Add(new List<int>(oneResult));
                }
                else if (target > 0)
                {
                    for (int i = start; i < candidates.Length; i++)
                    {
                        oneResult.Add(candidates[i]);
                        DFS(candidates, target - candidates[i], i, oneResult, result);
                        oneResult.RemoveAt(oneResult.Count - 1);
                    }
                }
            }

            public bool WordBreak(string s, IList<string> wordDict)
            {
                var n = s.Length;
                var dp = new bool[n + 1];

                dp[0] = true;
                for (int i = 1; i <= n; i++)
                {
                    var sIndex = i - 1;
                    foreach (var word in wordDict)
                    {
                        var wordLen = word.Length;
                        var lastChar = word.Last();

                        if (lastChar == s[sIndex] && sIndex + 1 >= wordLen)
                        {
                            if (s.Substring(sIndex - wordLen + 1, wordLen) == word)
                            {
                                dp[i] |= dp[i - wordLen];
                            }
                        }
                    }
                }

                return dp[n];
            }
            public static int CoinChange(int[] coins, int amount)
            {
                var n = coins.Length;

                var dp = new int[amount + 1];

                for (int i = 1; i <= amount; i++)
                {
                    dp[i] = int.MaxValue;
                    for (int j = 0; j < n; j++)
                    {
                        var pre = i - coins[j];
                        if (pre >= 0 && dp[pre] != int.MaxValue)
                        {
                            dp[i] = Math.Min(dp[i], dp[pre] + 1);
                        }
                    }
                }

                if (dp[amount] == int.MaxValue)
                {
                    return -1;
                }

                return dp[amount];
            }
            public static int ClimbStairs(int n)
            {
                if (n <= 2)
                    return n;

                int[] res = new int[n + 1];

                res[1] = 1;
                res[2] = 2;

                for (int i = 3; i <= n; i++)
                    res[i] = res[i - 1] + res[i - 2];

                return res[n];
            }

            public uint reverseBits(uint n)
            {
                var power = 31;
                uint answer = 0;
                while (n != 0)
                { // check n > 0 is better than check power >= 0
                    answer += ((n & 1) << power);
                    power--;
                    n >>= 1;
                }
                return answer;
            }

            public IList<IList<int>> ThreeSum(int[] nums)
            {
                List<IList<int>> res = new List<IList<int>>();
                if (nums == null || nums.Length < 3)
                    return res;

                Array.Sort(nums);
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // If nums[i] > 0, we can't find a valid triplet, since nums is sorted and nums[i] the smallest number.
                    // To avoid duplicate triplets, we should skip nums[i] if nums[i] == nums[i-1]
                    if (nums[i] > 0 || (i > 0 && nums[i] == nums[i - 1]))
                        continue;

                    int left = i + 1, right = nums.Length - 1;
                    while (left < right)
                    {
                        if (nums[i] + nums[left] + nums[right] == 0)
                        {
                            res.Add(new List<int>() { nums[i], nums[left], nums[right] });
                            left++;
                            right--;

                            while (left < right && nums[left] == nums[left - 1])
                                left++;
                            while (left < right && nums[right] == nums[right + 1])
                                right--;
                        }
                        else if (nums[i] + nums[left] + nums[right] > 0)
                            right--;
                        else
                            left++;
                    }
                }

                return res;
            }

            public static int HammingWeight(uint n)
            {
                uint count = 0;
                for (int i = 0; i < 32; i++)
                {
                    count += n & 1;
                    n >>= 1;
                }
                return (int)count;
            }

            public int[] CountBits(int n)
            {
                if (n == 0)
                    return new int[1] { 0 };

                int[] res = new int[n + 1];
                res[0] = 0;

                for (int i = 1; i < res.Length; i++)
                {
                    res[i] = res[i >> 1] + (i & 1);
                }

                return res;
            }

            public bool Exist(char[][] board, string word)
            {

                if (board == null || board[0].Length == 0)
                    return false;
                if (word == "")
                    return true;

                for (int i = 0; i < board.Length; i++)
                {
                    for (int j = 0; j < board[0].Length; j++)
                    {
                        if (WordSearch(board, word, i, j, 0))
                            return true;
                    }
                }

                return false;
            }

            public string LongestPalindrome(string s)
            {
                if (s.Length == 1) return s;

                int res = 0;
                int l = 0;
                int r = 0;
                int len = s.Length;

                for (int i = 0; i < len; i++)
                {
                    for (int diff = 1; i - diff + 1 >= 0 && i + diff < len; diff++)
                    {
                        if (s[i - diff + 1] != s[i + diff]) break;
                        else if (res < diff * 2)
                        {
                            res = diff * 2;
                            l = i - diff + 1;
                            r = i + diff;
                        }
                    }
                }

                for (int i = 0; i < len; i++)
                {
                    for (int diff = 1; i - diff >= 0 && i + diff < len; diff++)
                    {
                        if (s[i - diff] != s[i + diff]) break;
                        else if (res < diff * 2 + 1)
                        {
                            res = diff * 2 + 1;
                            l = i - diff;
                            r = i + diff;
                        }
                    }
                }

                return s.Substring(l, r - l + 1);
            }

            public bool IsSameTree(TreeNode p, TreeNode q)
            {
                if (Equals(p, null) || Equals(q, null))
                    return Equals(q, p);
                return Equals(p.val, q.val) && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            }

            public bool IsPalindrome(string s)
            {
                int start = 0;
                int end = s.Length - 1;

                while (start < end)
                {
                    if (!Char.IsLetterOrDigit(s[start]))
                    {
                        start++;
                        continue;
                    }

                    if (!Char.IsLetterOrDigit(s[end]))
                    {
                        end--;
                        continue;
                    }

                    if (Char.ToLower(s[start]) != Char.ToLower(s[end]))
                    {
                        return false;
                    }

                    start++;
                    end--;
                }

                return true;
            }

            public int CharacterReplacement(string s, int k)
            {
                if (s == null || s.Length == 0)
                    return 0;

                Dictionary<char, int> dic = new Dictionary<char, int>();


                int left = 0, right = 0, cnt = 0, maxCnt = 0, maxlen = 0;

                while (right < s.Length)
                {
                    char rightChar = s[right];
                    if (dic.ContainsKey(rightChar))
                        dic[rightChar]++;
                    else
                        dic.Add(rightChar, 1);
                    right++;


                    maxCnt = Math.Max(maxCnt, dic[rightChar]);


                    if (right - left - maxCnt > k)
                    {

                        char leftChar = s[left];
                        dic[leftChar]--;
                        left++;
                    }

                    maxlen = Math.Max(maxlen, right - left);
                }

                return maxlen;
            }

            private bool WordSearch(char[][] board, string word, int i, int j, int idx)
            {
                if (idx == word.Length)
                    return true;
                if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length || word[idx] != board[i][j])
                    return false;

                board[i][j] = '#'; // visted

                bool find = WordSearch(board, word, i - 1, j, idx + 1)
                    || WordSearch(board, word, i + 1, j, idx + 1)
                    || WordSearch(board, word, i, j - 1, idx + 1)
                    || WordSearch(board, word, i, j + 1, idx + 1);

                board[i][j] = word[idx]; // backtracking

                return find;
            }

         

            static void Main(string[] args)
            {
                



                string[] T = new string[5] { "codility1", "codility3", "codility2", "codility4b", "codility4a" };
                string[] R = new string[5] { "Wrong answer", "OK", "OK", "Time limit exceeded", "OK" };
                int istry76 =   toptal23( T,  R);


                string strggg = "bujrnytmoufnkgvpvjuvucjfzgyiankznkvquqduyzsehkoatikwckxpdgudcsxgqqtqlqmhkwsklsnabgzbxwmnovosjhfyjqlrtgvqmfpzytfsriugbfdarcbpzihtxvbzropxxdzrdgeyovsjpbuobetmrtgylypddnnmrpsucxwtpoegxpxvjyjjhqylnngzkjmjrksnnuaumvrniqrihulasoiqnkwcwmhhrghgbqizijqofavgpguzgqpaouezkbiirkqbebxhwqacnqdhtccpbwslarwokpqfvicdcflekunuqymjhjjpystvthjneesizkpziffyuoqpnjgkcjgunflxpnhbzcuuyiucctdpmtnrchmrramiapfwugkhbljsyjifuoaehacivmeqevsjcdelevkwuletdzyojqpfzfpiwrinsoxfhqbwysaiqccsyfnduhrguuwysquvebtgaqpuiopijcfqnfnsvwlmqznsndaoarsqqhegexnpmzvugsxwdoduelhpdektspfuhnylmyfgsxmoedwvzvlvvlsmfigcqllzpexrpkhykyiqbshifycdhnjxiprezjnsuemqpykbxcovphaedipawxhkszkfirwhdiujzkemipzpehmbrvxbyzepqowsmdrlthiegamtfnidunjzlgqnfumyhvsxkfeqggwujvhwjvwkwbkhgldjhuwzdpxhpydxepgwkkmfmdbarmpwwxsscxvtzxdhhzdfboncipfnnjughfrnfnnwcvejshlpvxpoqnmftgrolxqdongudajqatzzqswpgypgwwxgofeibnmcnfouuopqpowhlipgtwvpjpwecvlacyvmqpejotcjvncnpieinglxcsgixadnoyxpdkougzegwaxpwyzcvnbfbgfzgzqmtumltovtbdjnaciaknqjpawhwtdxmbaxzjcmrysxdkiqosjtmfyxajzwfgmdpmumoakz";
                programmerStrings(strggg);





                int toasteresult = 0;
                int[] intstaticIntArray12456 = new int[13] { 3, 2, 4, 7, 8, 5, 5, 5, 1, 5, 5, 5, 100 };

                toasteresult = MaxProfitToaste(intstaticIntArray12456);



                int[][] jagged_arr23 =
    {
    new int[] {0, 0, 0},
    new int[] {0, 1, 0},
    new int[] {1, 1, 1},

};
                UpdateMatrix(jagged_arr23);



                // int[] num154 = new int[7] { 1,2,3,4,5,6,7 };
                // Rotate(num154, 3);




                string strString = "()[]{}";
                var abvfr = IsValid(strString);


                //int[] num1 = new int[6] { 1, 2, 3, 0, 0, 0 };

                //int[] num2 = new int[3] { 2, 5, 6 };

                int[] num1 = new int[4] { 1, 2, 2, 1 };

                int[] num2 = new int[2] { 2, 2 };

                var ty = Intersect(num1, num2);



                Merge(num1, 1, num2, 1);


                string[] str77 = new string[3] { "abc", "aabc", "bc" };
                MakeEqual(str77);


                int[] intstaticIntArray1245 = new int[3] { 1, 2, 3 };
                int grtr = CounElements(intstaticIntArray1245);

                int[] inst55 = new int[3] { 1, 2, 3 };





                string[] staticIntArray1245 = new string[5] { "5", "2", "C", "D", "+" };


                string[] staticIntArray12456 = new string[8] { "5", "-2", "4", "C", "D", "9", "+", "+" };

                CalPiontList(staticIntArray12456);

                SieveOfEratosthenes(50);

                #region code1

                int[][] jagged_arr =
      {
    new int[] {1, 2, 3, 4,7,8},
    new int[] {1, 2, 3, 4,7,8},
    new int[] {1, 2, 3, 4,7,8},
    new int[] {1, 2, 3, 4,7,8},
    new int[] {1, 2, 3, 4,7,8},
    new int[] {1, 2, 3, 4,7,8}
};



                int[][] jaggedArray = new int[5][];
                jaggedArray[0] = new int[3];
                jaggedArray[1] = new int[5];
                jaggedArray[2] = new int[2];
                jaggedArray[3] = new int[8];
                jaggedArray[4] = new int[10];
                jaggedArray[0] = new int[] { 3, 5, 7, };
                jaggedArray[1] = new int[] { 1, 0, 2, 4, 6 };
                jaggedArray[2] = new int[] { 1, 6 };
                jaggedArray[3] = new int[] { 1, 0, 2, 4, 6, 45, 67, 78 };
                jaggedArray[4] = new int[] { 1, 0, 2, 4, 6, 34, 54, 67, 87, 78 };

                int n1 = hourglassSum(jagged_arr);
                int[] staticIntArray12 = new int[7] { 200, -20, -20, -20, -20, -20, -20 };
                string[] staticIntArray13 = new string[7] { "2020-01-01", "2020-02-01", "2020-02-11", "2020-02-05", "2020-02-05", "2020-02-05", "2020-02-05" };
                solutionwitdDict(staticIntArray12, staticIntArray13);
                abInteger(3, 3);
                //int[] staticIntArray12 = new int[3] { 3,2,4};
                TwoSum(staticIntArray12, 6);
                // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
                var numberNames = new Dictionary<int, int>();
                numberNames.Add(0, 2); //adding a key/value using the Add() method
                numberNames.Add(1, 7);
                numberNames.Add(2, 9);
                int result43;
                if (numberNames.TryGetValue(0, out result43))
                {
                    Console.WriteLine(result43);
                }
                int[] intArray;
                intArray = new int[5];
                //int[] intArray;
                //intArray = new int[100];

                #endregion
                #region code
                int[] staticIntArray = new int[3] { 1, 3, 5 };
                int[,] numbers = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
                string[,] names = new string[2, 2] { { "Rosy", "Amy" }, { "Peter", "Albert" } };
                //int[,] numbers = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
                //string[,] names = new string[,] { { "Rosy", "Amy" }, { "Peter", "Albert" } };
                var str23 = twoStrings("hi", "hello");
                Console.WriteLine(str23);
                int n = 100;   //Convert.ToInt32(Console.ReadLine());
                int[] ar = new int[100] { 50, 49, 38, 49, 78, 36, 25, 96, 10, 67, 78, 58, 98, 8, 53, 1, 4, 7, 29, 6, 59, 93, 74, 3, 67, 47, 12, 85, 84, 40, 81, 85, 89, 70, 33, 66, 6, 9, 13, 67, 75, 42, 24, 73, 49, 28, 25, 5, 86, 53, 10, 44, 45, 35, 47, 11, 81, 10, 47, 16, 49, 79, 52, 89, 100, 36, 6, 57, 96, 18, 23, 71, 11, 99, 95, 12, 78, 19, 16, 64, 23, 77, 7, 19, 11, 5, 81, 43, 14, 27, 11, 63, 57, 62, 3, 56, 50, 9, 13, 45 }; // Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp))
                int result = sockMerchant(n, ar);
                Console.WriteLine(result);
                Console.ReadLine();

                //  textWriter.WriteLine(result);
                ///// textWriter.Flush();
                // textWriter.Close();
                Random rnd = new Random();
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                HighlyOptimizedThreadSafeDuplicateCheckService service = new HighlyOptimizedThreadSafeDuplicateCheckService();
                //for (int i = 0; i < 1000000; i++)
                //{
                //    service.IsThisTheFirstTimeWeHaveSeen(rnd.Next(1, 1000000));
                //}

                Thread[] threads = new Thread[20];
                for (int i = 0; i < threads.Length; i++)
                {
                    threads[i] = new Thread(service.IsThisTheFirstTimeWeHaveSeenTest);
                }
                foreach (Thread thread in threads)
                {
                    thread.Start();
                }
                foreach (Thread thread in threads)
                {
                    thread.Join();
                }
                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;
                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine("RunTime " + elapsedTime);
                Console.ReadLine();
                result = CompareString("tretr", "tr");
                Console.WriteLine(result);
                Console.ReadLine();
                Console.WriteLine("Hello World!");
                var bytes = FileToByteArray("D:/TimeSolv/mmm.docx");
                var str = System.Text.Encoding.Default.GetString(bytes);
                int a = 0;
                #endregion
            }
            public static byte[] FileToByteArray(string fileName)
            {
                byte[] fileData = null;

                using (FileStream fs = File.OpenRead(fileName))
                {
                    var binaryReader = new BinaryReader(fs);
                    fileData = binaryReader.ReadBytes((int)fs.Length);
                }
                return fileData;
            }

            public static int[] SortArray(int[] nums)
            {
                SortMerge(nums, 0, nums.Length - 1);
                return nums;
            }

            //public static void MainMerge(int[] numbers, int left, int mid, int right)
            //{
            //    int[] temp = new int[numbers.Length];
            //    int i, eol, num, pos;
            //    eol = (mid - 1);
            //    pos = left;
            //    num = (right - left + 1);

            //    while ((left <= eol) && (mid <= right))
            //    {
            //        if (numbers[left] <= numbers[mid])
            //            temp[pos++] = numbers[left++];
            //        else
            //            temp[pos++] = numbers[mid++];
            //    }
            //    while (left <= eolmain
            //        temp[pos++] = numbers[left++];
            //    while (mid <= right)
            //        temp[pos++] = numbers[mid++];
            //    for (i = 0; i < num; i++)
            //    {
            //        numbers[right] = temp[right];
            //        right--;
            //    }
            //}

            bool solve(TreeNode root, long left, long right)
            {
                if (root == null)
                {
                    return true;
                }
                if (root.val <= left || root.val >= right) return false;
                return solve(root.left, left, root.val) && solve(root.right, root.val, right);

            }

            public bool IsValidBST(TreeNode root)
            {

                return solve(root, Int64.MinValue, Int64.MaxValue);


            }

            public static void SortMerge(int[] numbers, int left, int right)
            {
                int mid;
                if (right > left)
                {
                    mid = (right + left) / 2;
                    SortMerge(numbers, left, mid);
                    SortMerge(numbers, (mid + 1), right);
                  //  MainMerge(numbers, left, (mid + 1), right);
                }
            }

            public int SingleNumber(int[] nums)
            {

                if (nums.Length < 2)
                {
                    return nums[0];
                }

                Array.Sort(nums);

                for (int i = 0; i < nums.Length - 1; i += 2)
                {
                    if (nums[i] != nums[i + 1])
                    {
                        return nums[i];
                    }
                }


                return nums[nums.Length - 1];
            }

            public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
            {
                int oldColor = image[sr][sc];
                change(image, sr, sc, newColor, oldColor);
                return image;
            }


            public int countIsland(int[][] grid, int i, int j)
            {
                if ((i < 0) || (j < 0) || (i > grid.Length - 1) || (j > grid[i].Length - 1) || (grid[i][j] == 0))
                {
                    return 0;
                }


                grid[i][j] = 0;

                return (1 + countIsland(grid, i + 1, j) +
                  countIsland(grid, i - 1, j) +
                  countIsland(grid, i, j + 1) +
                  countIsland(grid, i, j - 1));

            }

            public int MaxAreaOfIsland(int[][] grid)
            {

                int iCount = 0;
                int MaxiCount = 0;

                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {

                        if (grid[i][j] == 1)
                        {
                            iCount = countIsland(grid, i, j);
                        }

                        MaxiCount = Math.Max(MaxiCount, iCount);

                        iCount = 0;
                    }
                }

                return MaxiCount;

            }

            private void change(int[][] image, int sr, int sc, int newColor, int oldColor)
            {
                if ((sr >= 0) && (sr <= image.Length - 1) && (sc >= 0) && (sc <= image[0].Length - 1))
                {
                    if (image[sr][sc] == oldColor && newColor != oldColor)
                    {
                        image[sr][sc] = newColor;
                        change(image, sr + 1, sc, newColor, oldColor);
                        change(image, sr - 1, sc, newColor, oldColor);
                        change(image, sr, sc + 1, newColor, oldColor);
                        change(image, sr, sc - 1, newColor, oldColor);
                    }
                }
            }

            public int BalancedStringSplit(string s)
            {

                int rCount = 0;
                int lCount = 0;
                int splitCount = 0;


                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == 'L') lCount++;
                    else if (s[i] == 'R') rCount++;

                    if ((rCount != 0) && (lCount == rCount))
                    {
                        rCount = 0;
                        lCount = 0;
                        splitCount++;
                    }
                }

                return splitCount;
            }


            public int LengthOfLongestSubstring(string s)
            {

                var prevAppearance = new Dictionary<char, int>();
                int maxSubstringLength = 0;
                int prevNonRepeatingSubstringStartIndex = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (prevAppearance.ContainsKey(s[i]))
                    {
                        prevNonRepeatingSubstringStartIndex =
                            Math.Max(prevAppearance[s[i]] + 1, prevNonRepeatingSubstringStartIndex);
                    }
                    maxSubstringLength =
                        Math.Max(maxSubstringLength, i - prevNonRepeatingSubstringStartIndex + 1);
                    prevAppearance[s[i]] = i;
                }

                return maxSubstringLength;
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

            public static int solutionwitdDict(int[] A, string[] D)
            {
                int totalBalace = 0;
                string currentMonth = "";
                var freeMonth = new int[12];
                int index = 0;
                int freeMonthCounter = 12;

                var dict = new Dictionary<int, string>();

                for (int i = 0; i < A.Length; i++)
                {
                    totalBalace = totalBalace + A[i];
                    if (A[i] < 0)
                    {
                        var arrD = D[i].Split('-');

                        currentMonth = arrD[1].ToString();

                        index = Int32.Parse(currentMonth);
                        if (dict.ContainsKey(index))
                        {
                            var dictvalue = "";
                            if (dict.TryGetValue(index, out dictvalue))
                            {
                                var arrdictvalue = dictvalue.Split(',');

                                var counter = Int32.Parse(arrdictvalue[0]) + 1;
                                var sum = Int32.Parse(arrdictvalue[1]) + A[i];
                                dict.Remove(index);


                                dict.Add(index, counter + "," + sum);
                            }
                        }
                        else
                        {
                            dict.Add(index, "1" + "," + A[i]);
                        }
                    }
                }

                foreach (var entry in dict)
                {


                    var arrValue = entry.Value.Split(',');
                    if ((Int32.Parse(arrValue[0]) >= 3) && (Int32.Parse(arrValue[1]) <= -100))
                    {
                        freeMonthCounter = freeMonthCounter - 1;
                    }
                }

                totalBalace = totalBalace - (5 * freeMonthCounter);
                return totalBalace;
            }


            public ListNode DeleteDuplicates(ListNode head)
            {


                ListNode tail = head;

                if ((head == null) || (head.next == null))
                {
                    return head;

                }


                while (tail.next != null)
                {

                    if (tail.val == tail.next.val)
                    {

                        if (tail.next.next != null)
                        {
                            tail.next = tail.next.next;
                        }
                        else
                        {
                            tail.next = null;

                        }
                    }
                    else
                    {
                        if (tail.next != null)
                            tail = tail.next;
                        else
                            tail.next = null;

                    }


                }

                return head;



            }



            public static IList<int> PreorderTraversal(TreeNode root)
            {

                List<int> lst = new List<int>();

                if (root == null)
                {
                    return lst;
                }

                lst.Add(root.val);

                PreorderTraversal(root.left);

                PreorderTraversal(root.right);

                return lst;
            }

            int iMaxDepth = 0;

            public void Solve(TreeNode root, int currentDepth)
            {
                if (root == null) return;

                currentDepth++;

                if ((root.left == null) && (root.right == null))
                {
                    if (currentDepth > iMaxDepth) iMaxDepth = currentDepth;
                }
                else
                {
                    Solve(root.left, currentDepth);
                    Solve(root.right, currentDepth);
                }

            }

            public int MaxDepth(TreeNode root)
            {

                Solve(root, 0);
                return iMaxDepth;

            }

            public void SolveInvertTree(TreeNode root)
            {
                if (root == null) return;

                TreeNode tempNode = new TreeNode();

                tempNode = root.left;
                root.left = root.right;
                root.right = tempNode;


                SolveInvertTree(root.left);
                SolveInvertTree(root.right);



            }

            public TreeNode InvertTree(TreeNode root)
            {
                SolveInvertTree(root);
                return root;
            }


            public static IList<int> InorderTraversal(TreeNode root)
            {

                List<int> lst = new List<int>();

                if (root == null)
                {
                    return lst;

                }

                if (root.left != null)
                {
                    InorderTraversal(root.left);
                }
                lst.Add(root.val);
                if (root.right != null)
                {
                    InorderTraversal(root.right);
                }

                return lst;
            }


            public IList<IList<int>> LevelOrder(TreeNode root)
            {
                IList<IList<int>> result = new List<IList<int>>();

                if (root == null) return result;

                int Level = 0;

                var q = new Queue<TreeNode>();


                q.Enqueue(root);

                while (q.Count > 0)
                {


                    result.Add(new List<int>());



                    int size = q.Count;

                    for (int i = 0; i < size; i++)
                    {

                        var node = q.Dequeue();
                        result[Level].Add(node.val);



                        if (node.left != null)
                        {
                            q.Enqueue(node.left);
                        }

                        if (node.right != null)
                        {
                            q.Enqueue(node.right);
                        }
                    }

                    Level++;



                }

                return result;




            }

            public static IList<int> PostorderTraversal(TreeNode root)
            {

                List<int> lst = new List<int>();
                if (root == null)
                {
                    return lst;

                }

                if (root.left != null)
                {
                    PostorderTraversal(root.left);
                }

                if (root.right != null)
                {
                    PostorderTraversal(root.right);
                }

                lst.Add(root.val);

                return lst;
            }

            public static ListNode RemoveElements(ListNode head, int val)
            {

                ArrayList arr = new ArrayList();
                ArrayList arr1 = new ArrayList();
                while (head != null)
                {
                    arr.Add(head.val);
                    head = head.next;
                }
                for (int i = 0; i < arr.Count; i++)
                {
                    if (int.Parse(arr[i].ToString()) == val)
                    {
                        continue;
                    }
                    else
                    {
                        arr1.Add(int.Parse(arr[i].ToString()));
                    }
                }
                ListNode tail = null;
                for (int j = 0; j < arr1.Count; j++)
                {
                    if (head == null)
                    {
                        head = new ListNode(int.Parse(arr1[j].ToString()));
                        tail = head;
                    }
                    else
                    {
                        ListNode newNode = new ListNode(int.Parse(arr1[j].ToString()));
                        tail.next = newNode;
                        tail = newNode;
                    }
                }
                return head;



            }


            public ListNode ReverseListiterative(ListNode head)
            {
                ListNode cur = head;
                ListNode prev = null;

                while (cur != null)
                {
                    ListNode temp = cur.next;
                    cur.next = prev;
                    prev = cur;
                    cur = temp;

                }
                return prev;
            }

            public static ListNode ReverseListArrayList(ListNode head)
            {
                var arr = new ArrayList();

                while (head != null)
                {
                    arr.Add(head.val);
                    head = head.next;

                }

                ListNode tail = null;
                for (int j = arr.Count - 1; j >= 0; j--)
                {

                    if (head == null)
                    {
                        head = new ListNode(int.Parse(arr[j].ToString()));
                        tail = head;
                    }
                    else
                    {
                        var newNode = new ListNode(int.Parse(arr[j].ToString()));
                        tail.next = newNode;
                        tail = newNode;
                    }

                }

                return head;
            }

            public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
            {

                //TC : O(n) ; SC : O(1)
                if (l1 == null && l2 == null)
                    return l1;
                if (l1 == null)
                    return l2;
                else if (l2 == null)
                    return l1;

                ListNode head = null, tail = null;

                if (l1.val <= l2.val)
                {
                    head = tail = l1;
                    l1 = l1.next;
                }
                else
                {
                    head = tail = l2;
                    l2 = l2.next;
                }

                while (l1 != null && l2 != null)
                {
                    if (l1.val <= l2.val)
                    {
                        tail.next = l1;
                        tail = l1;
                        l1 = l1.next;
                    }
                    else
                    {
                        tail.next = l2; //pointing/making link to that node
                        tail = l2; // moving it to that node
                        l2 = l2.next;

                    }
                }
                if (l1 == null) // if anyone of the list finishes early we move tail to the other list
                    tail.next = l2;
                else
                    tail.next = l1;

                return head;


            }


            public static bool hasCycle(ListNode head)
            {
                if (head == null)
                {
                    return false;
                }

                HashSet<ListNode> nodeSet = new HashSet<ListNode>();

                ListNode pointer = new ListNode(head.val);
                pointer.next = head.next;
                // Iterage through the linked list
                while (pointer != null)
                {
                    // Check if the node is in the set already
                    if (nodeSet.Contains(pointer))
                    {
                        return true;
                    }
                    else
                    {
                        nodeSet.Add(pointer);
                        pointer = pointer.next;
                    }
                }
                return false;
            }




            public int MaxProfit(int[] prices)
            {

                int maxProfit = 0;

                if (prices.Length > 1)
                {
                    int buy = 0;
                    int sell = 1;

                    while (sell < prices.Length)
                    {
                        if (prices[sell] < prices[buy])
                        {
                            buy = sell;
                        }
                        else
                        {
                            if (prices[sell] - prices[buy] > maxProfit)
                            {
                                maxProfit = prices[sell] - prices[buy];
                            }
                        }
                        sell++;
                    }

                }
                else
                {
                    return 0;
                }

                return maxProfit;
            }


            public static bool IsAnagram(string s, string t)
            {
                if ((s == "") || (t == ""))
                    return false;


                int[] freq = new int[26];
                int[] freq1 = new int[26];

                foreach (var c in s)
                {
                    freq[c - 'a']++;
                }


                foreach (var c in t)
                {
                    freq1[c - 'a']++;
                }


                for (int i = 0; i < freq.Length; i++)
                {
                    if (freq[i] != freq1[i])
                    {
                        return false;
                    }

                }


                return true;
            }

            public static bool CanConstruct(string ransomNote, string magazine)
            {

                if ((ransomNote == "") || (magazine == ""))
                    return false;


                int[] freq = new int[26];
                int[] freq1 = new int[26];

                foreach (var c in magazine)
                {
                    freq[c - 'a']++;
                }


                foreach (var c in ransomNote)
                {
                    freq1[c - 'a']++;
                }


                for (int i = 0; i < freq.Length; i++)
                {
                    if (freq[i] < freq1[i])
                    {
                        return false;
                    }

                }


                return true;




            }

            public static int FirstUniqChar(string s)
            {

                if (string.IsNullOrEmpty(s))
                    return -1;

                int[] freq = new int[26];
                foreach (var c in s)
                {
                    freq[c - 'a']++;
                }

                for (int i = 0; i < s.Length; i++)
                {
                    if (freq[s[i] - 'a'] == 1)
                        return i;
                }

                return -1;

            }


            public string ReverseWords(string s)
            {
                s = s.Trim();
                var arrS = s.Split(' ');
                StringBuilder sb = new StringBuilder();

                for (int i = arrS.Length - 1; i >= 0; i--)
                {
                    if (arrS[i].ToString() == " ")
                    {

                        continue;
                    }

                    if (arrS[i].ToString() == "")
                    {

                        continue;
                    }

                    string tS = arrS[i].ToString().Trim();
                    sb.Append(tS);

                    if (i > 0) sb.Append(" ");

                }

                return sb.ToString();
            }
            public static int solution123(int[] A, string[] D)
            {
                // write your code in C# 6.0 with .NET 4.5 (Mono)

                // write your code in Java SE 8
                int totalBalace = 0;
                int currentMonthCounter = 1;
                int currentMonthTransactions = 0;
                string currentMonth = "";
                var freeMonth = new int[12];
                int index = 0;
                int freeMonthCounter = 12;



                for (int i = 0; i < A.Length; i++)
                {
                    totalBalace = totalBalace + A[i];
                    if ((i > 0) && (A[i] < 0))
                    {
                        var arrD = D[i].Split('-');

                        currentMonth = arrD[1].ToString();
                        var arrD1 = D[i - 1].Split('-');
                        var previousMonth = arrD1[1].ToString();


                        if ((currentMonth == previousMonth))
                        {
                            currentMonthTransactions = currentMonthTransactions + A[i];
                            currentMonthCounter = currentMonthCounter + 1;
                            if ((currentMonthCounter >= 3) && (currentMonthTransactions <= -100))
                            {
                                index = Int32.Parse(currentMonth);
                                freeMonth[index] = 1;
                            }
                        }
                        else
                        {
                            currentMonthTransactions = A[i];

                        }
                    }

                }

                for (int i = 0; i < freeMonth.Length; i++)
                {
                    if (freeMonth[i] > 0)
                        freeMonthCounter = freeMonthCounter - 1;
                }
                totalBalace = totalBalace - (5 * freeMonthCounter);

                return totalBalace;

            }

            public bool IsValidSudoku(char[][] board)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        char c = board[i][j];
                        if (c != '.')
                        {
                            if (!validate(board, i, j, c))
                            {
                                // System.out.println(c + "   " + i + "   " + j);
                                return false;
                            }
                        }
                    }
                }
                return true;
            }


            public bool validate(char[][] board, int row, int col, char c)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (i != row && board[i][col] != '.' && board[i][col] == c)
                        return false; //check rows
                    if (i != col && board[row][i] != '.' && board[row][i] == c)
                        return false; //check columns

                    int x = 3 * (row / 3) + i / 3;
                    int y = 3 * (col / 3) + i % 3;

                    if (x != row && y != col && board[x][y] != '.' && board[x][y] == c)
                        return false; //check 3*3 block
                }
                return true;
            }

            public bool SearchMatrix(int[][] matrix, int target)
            {

                int pos = -1;
                for (int j = 0; j < matrix.Length; j++)
                {
                    for (int k = 0; k < matrix[j].Length; k++)
                    {
                        if ((matrix[j][k] > target) || (matrix[j][matrix[j].Length - 1] < target))
                        {
                            continue;
                        }
                        else
                        {
                            pos = Array.BinarySearch(matrix[j], target);
                        }
                    }
                }

                if (pos > -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public static int hourglassSum(int[][] arr)
            {
                int maxSum = -100000;
                int currentSum = 0;

                for (int j = 0; j < arr.Length - 2; j++)
                {
                    for (int k = 0; k < arr[j].Length - 2; k++)
                    {
                        currentSum = arr[j][k] + arr[j][k + 1] + arr[j][k + 2] + arr[j + 1][k + 1] + arr[j + 2][k] + arr[j + 2][k + 1] + arr[j + 2][k + 2]; //+ arr[k+1][l] + arr[k + 2] + 
                        if (currentSum > maxSum)
                        {
                            maxSum = currentSum;
                        }
                    }
                }

                return maxSum;
            }

            public static void SieveOfEratosthenes(int n)
            {


                bool[] prime = new bool[n + 1];

                for (int i = 0; i < n; i++)
                    prime[i] = true;

                for (int p = 2; p * p <= n; p++)
                {
                    // If prime[p] is not changed,
                    // then it is a prime
                    if (prime[p] == true)
                    {
                        // Update all multiples of p
                        for (int i = p * p; i <= n; i += p)
                            prime[i] = false;
                    }
                }

                // Print all prime numbers
                for (int i = 2; i <= n; i++)
                {
                    if (prime[i] == true)
                        Console.Write(i + " ");
                }
            }

            // Complete the sockMerchant function below.
            static int sockMerchant(int n, int[] ar)
            {

                int Count = 0;
                string strHolder = "";

                if (n < 2)
                {
                    return Count;
                }

                for (int i = 0; i < n; i++)
                {
                    if (strHolder.IndexOf("," + ar[i].ToString() + ",") > -1)
                    {
                        strHolder = strHolder.Remove(strHolder.IndexOf("," + ar[i].ToString() + ","), ar[i].ToString().Length + 2);
                        Count++;
                    }
                    else
                    {
                        strHolder = strHolder + "," + ar[i].ToString() + ",";
                    }
                }

                return Count;
            }

            static int smallest(int[] A)
            {
                Hashtable my_hashtable1 = new Hashtable();

                for (int j = 0; j < A.Length; j++)
                {
                    if (!my_hashtable1.Contains(A[j].ToString().GetHashCode()))
                        my_hashtable1.Add(A[j].ToString().GetHashCode(), A[j]);
                }

                for (int i = 1; i < 1000000; i++)
                {
                    if (!my_hashtable1.Contains(i.ToString().GetHashCode()))
                    {
                        return i;

                    }
                }

                return 1000000;

            }

            public static int binaryGap(int N)
            {
                // write your code in C# 6.0 with .NET 4.5 (Modfasdfsad

                string binary = Convert.ToString(N, 2);

                var s1arr = binary.ToCharArray();

                int CurrentCount = -1;
                int MaxCount = -1;

                for (int i = 0; i < s1arr.Length; i++)
                {
                    if ((s1arr[i] == '1') && (CurrentCount == -1))
                    {
                        CurrentCount = 0;
                    }

                    if ((s1arr[i] == '0') && (CurrentCount > -1))
                    {
                        CurrentCount++;
                    }

                    if ((s1arr[i] == '1') && (CurrentCount > 0))
                    {
                        if (CurrentCount > MaxCount)
                        {
                            MaxCount = CurrentCount;
                        }

                        CurrentCount = 0;

                    }
                }

                if (MaxCount == -1)
                {

                    return 0;
                }
                else
                {
                    return MaxCount;
                }

            }

            static string twoStrings(string s1, string s2)
            {
                var s1arr = s1.ToCharArray();
                var s2arr = s2.ToCharArray();

                Hashtable my_hashtable1 = new Hashtable();
                Hashtable my_hashtable2 = new Hashtable();

                for (int i = 0; i < s1arr.Length; i++)
                {
                    if (!my_hashtable1.Contains(s1arr[i].ToString().GetHashCode()))
                        my_hashtable1.Add(s1arr[i].ToString().GetHashCode(), s1arr[i]); //   GetHashString(s1arr[i].ToString()));
                }

                for (int j = 0; j < s2arr.Length; j++)
                {
                    if (!my_hashtable2.Contains(s2arr[j].ToString().GetHashCode()))
                        my_hashtable2.Add(s2arr[j].ToString().GetHashCode(), s2arr[j]);
                }

                foreach (DictionaryEntry item in my_hashtable1)
                {
                    if (my_hashtable2.ContainsKey(item.Key))
                    {
                        return "Yes";
                    }

                    //}

                    return "No";
                }
                return "No";

            }

        }
    }
}

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AlgoExpert
{

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
			int maxPoints = 0;

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

		public static bool ZeroSumSubArray(int[] nums){
			if(nums.Length ==0){
				return false;
			}
			if(nums.Length == 1){
				return nums[0] == 0;
			}
			int sum = 0;
			var zeroSumDictionary = new Dictionary<int, List<int>>();
			for (int i = 0; i < nums.Length; i++)
			{
				sum += nums[i];
				if(sum == 0){
					return true;
				}
				nums[i] = sum;
				if(!zeroSumDictionary.ContainsKey(sum)){
					zeroSumDictionary.Add(sum, new List<int>{i});
				} else {
					zeroSumDictionary[sum].Add(i);
					return true;
				}

			}
			return false;
		}

		public static string ReverseWordsInString(string str){
			string reverseWords = "";
			string word = "";
			for (int i = 0; i < str.Length; i++)
			{
				if(str[i] == ' '){
					word = str[i] + word;
					reverseWords = word + reverseWords;
					word = "";
				} else {
					word = word + str[i];
				}
			}
			reverseWords = word + reverseWords;
			return reverseWords;
		}



		static void Main(string[] args)
        {			
			
			string result =  ReverseWordsInString("this is rizwan");
			
			int[] nums = new int[]{-5,-5,3,3,-2};
			//bool result = ZeroSumSubArray(nums);
			
			// int result = findClosestNumber(13, 4);
			Console.WriteLine(result);
			Console.ReadLine();
        }
    }
}

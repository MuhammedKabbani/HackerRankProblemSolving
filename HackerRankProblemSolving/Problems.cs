using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankProblemSolving
{
	public static class Problems
	{
		/// <summary>
		/// https://www.hackerrank.com/challenges/simple-array-sum/problem
		/// </summary>
		public static int SimpleArraySum(List<int> arr)
		{
			return arr.Sum();
		}
		/// <summary>
		/// https://www.hackerrank.com/challenges/plus-minus/problem
		/// </summary>
		public static void PlusMinus(List<int> arr)
		{
			double numOfp = arr.Count(x => x > 0);
			double numOfn = arr.Count(x => x < 0);
			double numOfz = arr.Count(x => x == 0);

			Console.WriteLine(numOfp / arr.Count);
			Console.WriteLine(numOfn / arr.Count);
			Console.WriteLine(numOfz / arr.Count);
		}
		/// <summary>
		/// https://www.hackerrank.com/challenges/equality-in-a-array/problem
		/// </summary>
		public static int EqualizeArray(List<int> arr)
		{
			List<int> frequency = new List<int>(new int[arr.Max()]);

			foreach (var element in arr)
			{
				frequency[element - 1]++;
			}
			return arr.Count - frequency.Max();
		}
		/// <summary>
		/// https://www.hackerrank.com/challenges/the-time-in-words
		/// </summary>
		public static string TimeInWords(int h, int m)
		{
			List<string> hours = new List<string>(){
			"one",
			"two",
			"three",
			"four",
			"five",
			"six",
			"seven",
			"eight",
			"nine",
			"ten",
			"eleven",
			"twelve",
		};
			List<string> onluk = new List<string>(){
			"ten",
			"twenty",
			"thirty",
			"fourty",
			"fifty",
		};
			List<string> tens = new List<string>(){
			"eleven",
			"twelve",
			"thirteen",
			"fourteen",
			"fifteen",
			"sixteen",
			"seventeen",
			"eighteen",
			"nineteen",
		};
			string hour = hours[h - 1];
			string hourP1 = hours[h];
			string minutes = m == 1 ? "minute" : "minutes";
			if (m == 0)
			{
				return hour + " o' clock";
			}
			else if (m == 30)
			{
				return "half past " + hour;
			}
			else if (m == 15)
			{
				return "quarter past " + hour;
			}
			else if (m == 45)
			{
				return "quarter to " + hourP1;
			}
			else if (m < 30)
			{
				if (m % 10 == 0)
				{
					return onluk[m / 10 - 1] + " " + minutes + " past " + hour;
				}
				else if (m < 10)
				{
					return hours[m - 1] + " " + minutes + " past " + hour;
				}
				else if (m < 20)
				{
					return tens[m % 10 - 1] + " " + minutes + " past " + hour;
				}
				else
				{
					return onluk[1] + " " + hours[m % 10 - 1] + " " + minutes + " past " + hour;
				}
			}
			else
			{
				var min = m - 30;
				if (min % 10 == 0)
				{
					return onluk[m / 10 - 1] + " " + minutes + " to " + hourP1;
				}
				else if (m > 50)
				{
					return hours[9 - m % 50] + " " + minutes + " to " + hourP1;
				}
				else if (m > 40)
				{
					return tens[9 - m % 40] + " " + minutes + " to " + hourP1;
				}
				else
				{
					return onluk[1] + " " + hours[9 - m % 30] + " " + minutes + " to " + hourP1;
				}
			}
		}
		/// <summary>
		/// https://www.hackerrank.com/challenges/service-lane/problem
		/// </summary>
		public static List<int> ServiceLane(List<int> width, List<List<int>> cases)
		{
			List<int> result = new List<int>();

			foreach (var list in cases)
			{
				int i = list[0];
				int j = list[1];

				result.Add(width.GetRange(i, j - i + 1).Min());
			}
			return result;
		}
		/// <summary>
		/// https://www.hackerrank.com/challenges/acm-icpc-team/problem
		/// </summary>
		public static List<int> AcmTeam(List<string> topics)
		{
			int max = 0;
			int countOfMax = 0;
			int count;
			for (int i = 0; i < topics.Count - 1; i++)
			{
				for (int j = i + 1; j < topics.Count; j++)
				{
					count = 0;
					for (int k = 0; k < topics[j].Length; k++)
					{
						if (topics[i][k] == '1' || topics[j][k] == '1')
						{
							count++;
						}
					}
					if (count > max)
					{
						max = count;
						countOfMax = 1;
					}
					else if (count == max)
					{
						countOfMax++;
					}
				}
			}
			List<int> result = new List<int>() { max, countOfMax };

			return result;
		}
		/// <summary>
		/// https://www.hackerrank.com/challenges/taum-and-bday/problem
		/// </summary>
		public static long TaumBday(long b, long w, long bc, long wc, long z)
		{

			if (bc > wc + z) return ((b + w) * wc + b * z);
			if (wc > bc + z) return ((b + w) * bc + w * z);

			return (b * bc + w * wc);

		}
		/// <summary>
		/// https://www.hackerrank.com/challenges/happy-ladybugs
		/// </summary>
		public static string HappyLadybugs(string b)
		{
			int bosluk = b.Count(x => x == '_');

			if (bosluk == b.Length) return "YES";
			if (b.Length == 1) return "NO";
			var existedColors = b.GroupBy(x => x).Select(x => x.Key).ToList();
			foreach (var color in existedColors)
			{
				if (color == '_') continue;

				if (b.Count(x => x == color) == 1)
				{
					return "NO";
				}

			}
			if (bosluk == 0)
			{
				for (int i = 0; i < b.Length; i++)
				{
					if (i == 0)
					{
						if (b[i] != b[i + 1]) return "NO";
						continue;
					}
					else if (i == b.Length - 1)
					{

						if (b[i] != b[i - 1]) return "NO";
						continue;
					}
					if (b[i] != b[i - 1] && b[i] != b[i + 1]) return "NO";
				}
			}

			return "YES";
		}
		/// <summary>
		/// https://www.hackerrank.com/challenges/correctness-invariant/problem
		/// </summary>
		/// <param name="A"></param>
		public static void InsertionSort(int[] A)
		{
			for (int i = 1; i < A.Length; i++)
			{
				for (int j = 0; j < i; j++)
				{
					if (A[i] <= A[j])
					{
						int temp = A[j];
						A[j] = A[i];
						A[i] = temp;
					}
				}
			}

			Console.WriteLine(string.Join(" ", A));
		}
		/// <summary>
		/// https://www.hackerrank.com/challenges/mars-exploration/problem
		/// </summary>
		public static int MarsExploration(string s)
		{
			int result = 0;
			string sos = "SOS";
			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] != sos[i % 3]) result++;
			}
			return result;
		}
		/// <summary>
		/// https://www.hackerrank.com/challenges/hackerrank-in-a-string/problem
		/// </summary>
		public static string HackerrankInString(string s)
		{
			// ashfda
			char[] hackerrankArray = { 'h', 'a', 'c', 'k', 'e', 'r', 'r', 'a', 'n', 'k' };
			string result = "NO";
			int sayac = 0;
			for (int i = 0; i < s.Length; i++)
			{

				sayac = 0;
				if (s[i] == hackerrankArray[0])
					for (int j = i; j < s.Length; j++)
					{
						if (s[j] == hackerrankArray[sayac])
						{

							sayac++;
							if (sayac == 10)
								break;
						}
					}
				if (sayac == 10)
					break;

			}
			if (sayac == 10)
				result = "YES";

			return result;
		}
		/// <summary>
		/// https://www.hackerrank.com/challenges/pangrams/problem
		/// </summary>
		public static string Pangrams(string s)
		{
			string input = s.ToLower();

			Dictionary<char, int> letters = new Dictionary<char, int>();

			foreach (var letter in input)
			{
				if (!letters.ContainsKey(letter) && Char.IsLetter(letter))
				{
					letters[letter] = 1;
				}
				else
				{
					continue;
				}
				if (letters.Keys.Count == 26)
					return "pangram";
			}
			return "not pangram";
		}
		/// <summary>
		/// https://www.hackerrank.com/challenges/weighted-uniform-string/problem
		/// </summary>
		public static List<string> WeightedUniformStrings(string s, List<int> queries)
		{
			Dictionary<char, int> subUniStrings = new Dictionary<char, int>();
			List<string> result = new List<string>();
			int curCharNum = 1;
			char prevChar = s[0];
			string subUni = prevChar.ToString();
			for (int i = 1; i < s.Length; i++)
			{
				if (s[i] == prevChar)
				{
					curCharNum++;

				}
				else
				{
					if (!subUniStrings.ContainsKey(prevChar))
						subUniStrings.Add(prevChar, curCharNum);
					else if (subUniStrings[prevChar] < curCharNum)
						subUniStrings[prevChar] = curCharNum;

					curCharNum = 1;
				}
				prevChar = s[i];
			}
			if (s.Length > 2 && s[s.Length - 2] == prevChar)
			{
				curCharNum++;
			}

			if (!subUniStrings.ContainsKey(prevChar))
				subUniStrings.Add(prevChar, curCharNum);
			else if (subUniStrings[prevChar] < curCharNum)
				subUniStrings[prevChar] = curCharNum;
			foreach (var query in queries)
			{
				bool found = false;

				foreach (var charachter in subUniStrings.Keys)
				{
					var weight = (int)charachter - 96;
					if (query % weight == 0 && query <= subUniStrings[charachter] * weight)
					{
						result.Add("Yes");
						found = true;
						break;
					}
				}
				if (!found) { result.Add("No"); }
			}

			return result;
		}
		/// <summary>
		/// https://www.hackerrank.com/challenges/funny-string/problem
		/// </summary>
		public static string FunnyString(string s)
		{
			char[] stringArray = s.ToCharArray();
			Array.Reverse(stringArray);
			string reversed = new string(stringArray);

			for (int i = 0; i < s.Length - 1; i++)
			{
				int dif1 = Math.Abs(s[i] - s[i + 1]);
				int dif2 = Math.Abs(reversed[i] - reversed[i + 1]);
				if (dif1 != dif2) return "Not Funny";
			}

			return "Funny";
		}
		/// <summary>
		/// https://www.hackerrank.com/challenges/alternating-characters/problem
		/// </summary>
		public static int AlternatingCharacters(string s)
		{
			int deletions = 0;

			for (int i = 0; i < s.Length; i++)
			{
				char cur = s[i];
				if (i + 1 < s.Length && s[i] == s[i + 1])
				{
					deletions++;
				}

			}
			return deletions;
		}
		/// <summary>
		/// https://www.hackerrank.com/challenges/the-love-letter-mystery/problem
		/// </summary>
		public static int TheLoveLetterMystery(string s)
		{
			int middle = s.Length / 2;
			int result = 0;
			for (int i = 0; i < middle; i++)
			{
				if (s[i] < s[s.Length - 1 - i])
				{
					result += s[s.Length - 1 - i] - s[i];
				}
				else
				{
					result += s[i] - s[s.Length - 1 - i];
				}
			}

			return result;
		}
		/// <summary>
		/// https://www.hackerrank.com/challenges/luck-balance/problem
		/// </summary>
		public static int LuckBalance(int k, List<List<int>> contests)
		{
			List<int> important = contests.Where(x => x[1] == 1).Select(x => x[0]).ToList();
			List<int> notImportant = contests.Where(x => x[1] == 0).Select(x => x[0]).ToList();

			int result = notImportant.Sum();
			int count = important.Count;
			for (int i = 0; i < count - k; i++)
			{
				int min = important.Min();
				result -= min;
				important.Remove(min);
			}
			result += important.Sum();
			return result;
		}
		/// <summary>
		/// https://www.hackerrank.com/challenges/maximizing-xor/problem
		/// </summary>
		public static int MaximizingXor(int l, int r)
		{
			int max = 0;

			for (int i = l; i <= r; i++)
			{
				for (int j = l; j <= r; j++)
				{
					int result = i ^ j;

					max = result > max ? result : max;
				}
			}

			return max;
		}
		/// <summary>
		/// https://www.hackerrank.com/challenges/camelcase/problem
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static int Camelcase(string s)
		{
			return s.Count(x => Char.IsUpper(x)) + 1;
		}
		/// <summary>
		/// https://www.hackerrank.com/challenges/marcs-cakewalk/problem
		/// </summary>
		public static long MarcsCakewalk(List<int> calorie)
		{
			long sum = 0;
			int index = 0;
			while (calorie.Count > 0)
			{
				int max = calorie.Max();
				sum += (long)(Math.Pow(2, index) * max);
				calorie.Remove(max);
				index++;
			}
			return sum;
		}
		/// <summary>
		/// https://www.hackerrank.com/challenges/string-construction/problem
		/// </summary>
		public static int StringConstruction(string s)
		{
			int result = 0;
			string resultStr = "";
			for (int i = 0; i < s.Length; i++)
			{
				if (!resultStr.Contains(s[i]))
				{
					result++;
					resultStr += s[i];
				}
			}
			return result;
		}
        /// <summary>
        /// https://leetcode.com/problems/merge-sorted-array
        /// </summary>
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            List<int> result = new List<int>();
            int idx1 = 0;
            int idx2 = 0;
			int empIdx = m - 1;
            if (m == 0)
            {
                nums2.ToList().ForEach(x => { nums1[idx1] = x; idx1++; });
                return;
            }
            else if (n == 0)
            {
                return;
            } 
			while (idx1 < m && idx2 < n)
			{
				int num1 = nums1[idx1];
				int num2 = nums2[idx2];

				if (num1 < num2)
				{
					result.Add(num1);
					idx1++;
				}
				else if (num2 < num1)
				{
					result.Add(num2);
					idx2++;
				}
				else
				{
					result.Add(num1);
					result.Add(num2);
					idx1++;
					idx2++;
				}
            }
			while (idx1 < m)
			{
                int num1 = nums1[idx1];
                result.Add(num1);
				idx1++;
            }
            while (idx2 < n)
            {
                int num2 = nums2[idx2];
                result.Add(num2);
				idx2++;
            }

            idx1 = 0;
            result.ForEach(x => { nums1[idx1] = x; idx1++; });
        }
        /// <summary>
        /// https://leetcode.com/problems/remove-element
        /// </summary>
        public static int RemoveElement(int[] nums, int val)
        {
			int idx = 0;
            for (int i = 0; i < nums.Length; i++)
            {
				if (nums[i] != val)
                {
                    nums[idx] = nums[i];
                    idx++;
                }
            }
			return idx;
        }
        /// <summary>
        /// https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/
        /// </summary>
        public static int RemoveDuplicates(int[] nums)
        {
			int lastNum = int.MinValue, lastNumFreq = 1;
			int idx = 0;
            for (int i = 0; i < nums.Length; i++)
            {
				int num = nums[i];
				if (num == lastNum)
				{
					lastNumFreq++;
					if (lastNumFreq <= 2)
					{
						nums[idx] = num;
						idx++;
                    }
                }
				else
				{
					lastNumFreq = 1;
					lastNum = num;
                    nums[idx] = num;
                    idx++;
                }
            }
			return idx;
        }
        /// <summary>
        /// https://leetcode.com/problems/majority-element
        /// </summary>
        public static int MajorityElement(int[] nums)
        {
			int result = 0;
			int maxValue = int.MinValue;
			Dictionary<int, int> dict = new Dictionary<int, int>();
			foreach (var num in nums)
			{
				if (dict.ContainsKey(num))
					dict[num]++;
				else
					dict[num] = 1;
				if (dict[num] > maxValue)
				{
					maxValue = dict[num];
					result = num;
                }
			}
			return result;
		}
        /// <summary>
        /// https://leetcode.com/problems/rotate-array
        /// </summary>
        public static void Rotate(int[] nums, int k)
        {
            int arrLen = nums.Length;
            int[] result = new int[arrLen];
            int idx = 0;

            for (int i = 0; i < arrLen; i++)
            {
                result[(i + k) % arrLen] = nums[idx];
				idx++;
            }
            idx = 0;
            foreach (var num in result)
            {
                nums[idx] = num;
                idx++;
            }
        }
    }
}

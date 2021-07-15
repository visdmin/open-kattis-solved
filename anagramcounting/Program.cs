/*
    Problem:  https://open.kattis.com/problems/nanagrams
    CPU time: 0.03 s
*/

using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;

namespace ProblemB
{
    class anagramcounting
    {

        public static BigInteger GetAnagramCount(ReadOnlySpan<char> word)
        {
            if (word.Length < 1) { return 0; }

            var characterMap = new Dictionary<char, long>();
            foreach (char character in word) {
                if (!characterMap.ContainsKey(character)) { characterMap.Add(character, 0); }
                characterMap[character]++;
            }

            var result = Fact(word.Length);
            // Used compiler does not accept <foreach ((_, charCount) in ...)> interesting.
            foreach (KeyValuePair<char, long> item in characterMap.Where(charCnt => charCnt.Value >= 2))  {
                result = BigInteger.Divide(result, Fact(item.Value));
            }

            return result;
        }

        public static BigInteger Fact(BigInteger num)
        {
            var result = new BigInteger(1);
            while (!num.IsOne) {
                result = BigInteger.Multiply(result, num);
                num    = num - 1;
            }
            return result;
        }

        static void Main(string[] args)
        {
            var line = String.Empty;
            while (!String.IsNullOrEmpty(line = Console.ReadLine())) {
                Console.WriteLine(GetAnagramCount(line).ToString());
            }

            Environment.Exit(0);
        }
    }
}

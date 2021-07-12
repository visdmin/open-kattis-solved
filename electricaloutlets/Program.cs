/*
    Problem:  https://open.kattis.com/problems/electricaloutlets
    CPU time: 0.03 s
*/

using System;
using System.IO;
using System.Linq;

namespace electricaloutlets
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var inputStream  = Console.OpenStandardInput())
            using (var streamReader = new StreamReader(inputStream)) {

                byte testCnt = Convert.ToByte(streamReader.ReadLine()?[0] ?? '0');

                byte[] caseValues;
                var line = string.Empty;
                for (var testIdx = 0; testIdx < testCnt; testIdx++) {

                    line = streamReader.ReadLine();
                    if (String.IsNullOrEmpty(line)) {
                        Environment.Exit(0);
                    }

                    caseValues = line.Split(' ').Select(x => Convert.ToByte(x)).ToArray();
                    if (caseValues[0] == 0 || caseValues[0] != caseValues.Length - 1) {
                        Environment.Exit(1);
                    }

                    var result = (0 - (caseValues.Length - 2)) ;
                    for (var valueIdx = 1; valueIdx < caseValues.Length; valueIdx++) { result += caseValues[valueIdx]; }

                    Console.WriteLine(result);
                }
            }

            Environment.Exit(0);
        }
    }
}

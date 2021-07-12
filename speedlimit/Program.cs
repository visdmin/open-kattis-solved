/*
    Problem:  https://open.kattis.com/problems/speedlimit
    CPU time: 0.03 s
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace speedlimit
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var inputStream  = Console.OpenStandardInput())
            using (var streamReader = new StreamReader(inputStream)) {

                short speedLimitCnt;
                while ((speedLimitCnt = Int16.Parse(streamReader.ReadLine() ?? "0")) != -1) {

                    var line      = string.Empty;
                    var mileSpans = new List<int>();
                    var time      = 0;
                    byte[] lineValues;
                    for (var testIdx = 0; testIdx < speedLimitCnt; testIdx++) {

                        line = streamReader.ReadLine();
                        if (String.IsNullOrEmpty(line)) {
                            Environment.Exit(1);
                        }

                        lineValues = line.Split(' ').Select(x => Convert.ToByte(x)).ToArray();

                        mileSpans.Add(lineValues[0] * (lineValues[1] - time));

                        time = lineValues[1];
                    }
                    Console.WriteLine($"{mileSpans.Sum()} miles");
                }
            }

            Environment.Exit(0);
        }
    }
}

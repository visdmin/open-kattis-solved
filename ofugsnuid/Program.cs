/*
    Problem:  https://open.kattis.com/problems/polygonarea
    CPU time: 0.44 s
*/

using System;
using System.IO;

namespace ofugsnuid
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var inputStream  = Console.OpenStandardInput())
            using (var streamReader = new StreamReader(inputStream)) {

                uint inputItemCount = UInt32.Parse(streamReader.ReadLine() ?? "0");

                var inputValues = new long[inputItemCount];
                var line        = String.Empty;
                for (var itemIdx = 0; itemIdx < inputItemCount; itemIdx++) {

                    line = streamReader.ReadLine();
                    if (String.IsNullOrEmpty(line)) {
                        Environment.Exit(0);
                    }

                    inputValues[itemIdx] = Convert.ToInt64(line);
                }

                for (var itemIdx = (inputValues.Length - 1); itemIdx >= 0; itemIdx--) {
                    Console.WriteLine(inputValues[itemIdx]);
                }
            }

            Environment.Exit(0);
        }
    }
}

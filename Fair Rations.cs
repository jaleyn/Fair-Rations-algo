using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'fairRations' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER_ARRAY B as parameter.
     */

    public static string fairRations(List<int> B)
    {
        int n = B.Count;
        int[] parity = new int[n];
        for (int i = 0; i < n; i++)
        {
            parity[i] = B[i] % 2;
        }
        int count = 0;
        for (int i = 0; i < n - 1; i++)
        {
            if (parity[i] == 1)
            {
                count++;
                parity[i] = 0;
                parity[i + 1] ^= 1;
            }
        }
        if (parity[n - 1] == 1)
        {
            return "NO";
        }
        return (count * 2).ToString();
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int N = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> B = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(BTemp => Convert.ToInt32(BTemp)).ToList();

        string result = Result.fairRations(B);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

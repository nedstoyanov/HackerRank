using Common;
using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{    
    private static readonly IPrinter printer = new ConsolePrinter();
    
    private static List<int> partition(List<int> ar)
    {
        if (ar.Count < 2)
           return ar;

        int partitionValue = ar[0];
        
        var left = new List<int>();
        var right = new List<int>();

        for (int i = 1; i < ar.Count; i++)
        {
            if (ar[i] < partitionValue)
            {
               left.Add(ar[i]);
            }
            else
            {
                right.Add(ar[i]);   
            }
        }

        left = partition(left);
        right = partition(right);

        left.Add(partitionValue);
        left.AddRange(right);

        printer.Print(left);

        return left;
    }

    static void quickSort(int[] ar)
    {
        partition(ar.ToList());        
    }

    /* Tail starts here */
    static void Main(String[] args)
    {
        // Input 
        //7
        //5 8 1 3 7 9 2

        // Output
        // 2 3
        // 1 2 3
        // 7 8 9
        // 1 2 3 5 7 8 9

        int _ar_size;
        _ar_size = Convert.ToInt32(Console.ReadLine());
        int[] _ar = new int[_ar_size];
        String elements = Console.ReadLine();
        String[] split_elements = elements.Split(' ');
        for (int _ar_i = 0; _ar_i < _ar_size; _ar_i++)
        {
            _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]);
        }

        quickSort(_ar);

        Console.ReadLine();
    }
}

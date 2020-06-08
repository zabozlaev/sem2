using System;
using System.Collections.Generic;
using System.Text;

namespace Sem_2
{
  public class RadixSort
  {
    private int iterations;

    public int Iterations
    {
      get
      {
        return iterations;
      }
    }

    private int getMax(int[] arr, int n)
    {
      var max = arr[0];
      for (var i = 1; i < n; i++)
      {
        iterations++;
        if (arr[i] > max)
          max = arr[i];
      }

      return max;
    }

    // A function to do counting sort of arr[] according to  
    // the digit represented by exp.  
    private void countingSort(int[] arr, int n, int exp)
    {
      var output = new int[n]; // output array  
      var i = 0;
      var count = new int[10];

      //initializing all elements of count to 0 
      for (i = 0; i < 10; i++)
      {
        this.iterations++;
        count[i] = 0;
      }

      // Store count of occurrences in count[]  
      for (i = 0; i < n; i++)
      {
        this.iterations++;
        count[(arr[i] / exp) % 10]++;
      }

      // Change count[i] so that count[i] now contains actual  
      //  position of this digit in output[]  
      for (i = 1; i < 10; i++)
        count[i] += count[i - 1];

      // Build the output array  
      for (i = n - 1; i >= 0; i--)
      {
        output[count[(arr[i] / exp) % 10] - 1] = arr[i];
        count[(arr[i] / exp) % 10]--;
      }

      // Copy the output array to arr[], so that arr[] now  
      // contains sorted numbers according to current digit  
      for (i = 0; i < n; i++)
        arr[i] = output[i];
    }

    public void Sort(int[] arr)
    {
      var n = arr.Length;
      // узнаём, чтоб понимать, сколько цифр в этом числе
      int max = getMax(arr, n);

      // по каждому числу используем counting sort  
      // exp = 10^i 
      for (int exp = 1; max / exp > 0; exp *= 10)
      {
        iterations++;
        countingSort(arr, n, exp);
      }
    }
  }
}
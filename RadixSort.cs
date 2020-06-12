using System;
using System.Collections.Generic;
using System.Text;

namespace Sem_2
{
  public class RadixSort
  {
    private int iterations;
    private int iterationsList;

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

    private void countingSort(int[] arr, int n, int exp)
    {
      var output = new int[n];
      var i = 0;
      var count = new int[10];

      for (i = 0; i < 10; i++)
      {
        this.iterations++;
        count[i] = 0;
      }

      for (i = 0; i < n; i++)
      {
        this.iterations++;
        count[(arr[i] / exp) % 10]++;
      }

      for (i = 1; i < 10; i++)
        count[i] += count[i - 1];

      for (i = n - 1; i >= 0; i--)
      {
        output[count[(arr[i] / exp) % 10] - 1] = arr[i];
        count[(arr[i] / exp) % 10]--;
      }

      for (i = 0; i < n; i++)
        arr[i] = output[i];
    }

    public void Sort(int[] arr)
    {
      var n = arr.Length;
      var max = getMax(arr, n);

      for (var exp = 1; max / exp > 0; exp *= 10)
      {
        iterations++;
        countingSort(arr, n, exp);
      }
    }

    private int getMaxFromList(LinkedList list)
    {
      var max = list.head.data;
      var curr = list.head.next;

      while (curr != null)
      {
        iterationsList++;
        if (curr.data > max)
          max = curr.data;
        curr = curr.next;
      }


      return max;
    }

    public void SortWithList(int[] arr)
    {
      var list = new LinkedList();
      foreach (var num in arr)
        list.AddNode(num);

      var n = arr.Length;
      var max = getMaxFromList(list);

      for (var exp = 1; max / exp > 0; exp *= 10)
      {
        iterations++;
        countingSort(arr, n, exp);
      }
    }
  }
}
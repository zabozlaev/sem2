using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Sem_2
{
  class Program
  {
    public static void Main(String[] args)
    {
      var ds = new DataStore();
      var fileName = @"./result.txt";
      StreamWriter sw = new StreamWriter(fileName);
      for (var i = 1; i < 500; i++)
      {
        var arr = ds.GetInputs(i);
        var watch = new Stopwatch();
        var sort = new RadixSort();
        var n = arr.Length;
        watch.Start();
        sort.Sort(arr);
        watch.Stop();
        ds.CreateOutput(sw, n, Int32.Parse(watch.ElapsedTicks.ToString()), sort.Iterations);
      }
      Console.WriteLine();
      sw.Close();
    }
  }
}



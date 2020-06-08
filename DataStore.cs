using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sem_2
{
  class DataStore
  {
    private string folderPath = @"./inputs/";
    public void CreateInputs()
    {
      for (var i = 0; i < 5000; i += 10)
      {
        if (File.Exists(folderPath + i + ".txt"))
          File.Delete(folderPath + i + ".txt");

        using (StreamWriter sw = File.CreateText(folderPath + i + ".txt"))
        {
          for (var j = 0; j < i; j++)
          {
            var rand = new Random();
            sw.WriteLine(rand.Next(1, 100).ToString());
          }
        }
      }
    }

    public int[] GetInputs(int number)
    {
      using (StreamReader sr = File.OpenText(folderPath + number * 10 + ".txt"))
      {
        var line = "";
        var list = new List<int>();
        while ((line = sr.ReadLine()) != null)
        {
          list.Add(Int32.Parse(line));
        }
        return list.ToArray();
      }
    }
    public void CreateOutput(StreamWriter sw, int inputsize, int ticks, int iterations)
    {
      sw.WriteLine(inputsize + " " + ticks + " " + iterations);
    }
  }
}

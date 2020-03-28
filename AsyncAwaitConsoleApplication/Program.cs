using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitConsoleApplication
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Before Async call from main");
      CallMethod();
      Console.WriteLine("After Async call from main");
      Console.ReadLine();
    }

    static async void CallMethod()
    {
      Task<int> tsk1 = DoWork1();
      Task<int> tsk2 = DoWork2();
      Task tsk3 = DoWork3();
      await Task.WhenAll(tsk1, tsk2, tsk3);
      Console.WriteLine("After Async call from CallMethod.");
      Console.WriteLine("Result from Task2 is: " + tsk2.Result);
    }

    private static async Task<int> DoWork1()
    {
      int count = 0;
      await Task.Run(() =>
      {
        for (int i = 0; i < 150; i++)
        {
          Console.WriteLine("DoWork1 :" + i.ToString());
          count++;
        }
      });
      return count;
    }

    private static async Task<int> DoWork2()
    {
      int count = 0;
      await Task.Run(() =>
      {
        for (int i = 0; i < 150; i++)
        {
          Console.WriteLine("DoWork2 :" + i.ToString());
          count++;
        }
      });
      return count;
    }

    private static async Task DoWork3()
    {
      int count = 0;
      await Task.Run(() =>
      {
        for (int i = 0; i < 150; i++)
        {
          Console.WriteLine("DoWork3 :" + i.ToString());
          count++;
        }
      });
     
    }
  }
}

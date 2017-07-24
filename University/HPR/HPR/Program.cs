using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Algo:
  Example for 1 HPR-word Multiplication
   */

namespace hpr
{
  class Program
  {
    private int Split()
    {
      throw new NotImplementedException();
    }
    static void Main(string[] args)
    {
      String X;
      String Y;
      String Ba;
      String Bb;
      string[] separator = new string[] { "," };
      string[] result;
      Console.WriteLine("Input X:");
      X = Console.ReadLine();
      Console.WriteLine("Input Y:");
      Y = Console.ReadLine();
      Console.WriteLine("Input first base RNS (split by coma):");
      Ba = Console.ReadLine();
      Console.WriteLine("Input second base RNS (split by coma):");
      Bb = Console.ReadLine();

      result = Ba.Split(separator,StringSplitOptions.None);

      var baseRNS = new List<int>();

      foreach (string st in result)
      {
        baseRNS.Add(Int32.Parse(st));
      }

      var Ma = 1;
      for (int i = 0; i < baseRNS.Count; i++)
      {
        Ma = Ma * baseRNS[i];
      }

      result = Bb.Split(separator, StringSplitOptions.None);

      var baseRNS1 = new List<int>();

      foreach (string st in result)
      {
        baseRNS1.Add(Int32.Parse(st));
      }

      var Mb = 1;
      for (int i = 0; i < baseRNS1.Count; i++)
      {
        Mb = Mb * baseRNS1[i];
      }

      var allBaseRNS = new List<int>();
      var HPx = new List<int>();
      var HPy = new List<int>();
      var A = Int32.Parse(X);
      var B = Int32.Parse(Y);

      foreach (var i in baseRNS)
      {
        allBaseRNS.Add(i);
        HPx.Add(A % i);
        HPy.Add(B % i);
      }

      foreach (var i in baseRNS1)
      {
        allBaseRNS.Add(i);
        HPx.Add(A % i);
        HPy.Add(B % i);
      }

      var HPyx = HPx.Select((t, i) => t * HPy[i] % allBaseRNS[i]).ToList();

      var higha = 0;
      var highb = 0;
      higha = (A * B) % Ma;
      highb = (A * B) / Ma;

      var HPBb = allBaseRNS.Select((t, i) => highb % t).ToList();

      var HPBa = allBaseRNS.Select((t, i) => higha % t).ToList();
    }
  }
}
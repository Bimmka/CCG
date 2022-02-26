using System.Collections.Generic;
using Services.Random;

namespace Extensions
{
  public static class ListExtensions
  {
    public static void Shuffle<T>(this List<T> list, IRandomService randomService)  
    {  
      int n = list.Count;
      T value;
      while (n > 1)
      {  
        n--;  
        int k = randomService.Next(n + 1);  
        value = list[k];  
        list[k] = list[n];  
        list[n] = value;  
      }  
    }
  }
}
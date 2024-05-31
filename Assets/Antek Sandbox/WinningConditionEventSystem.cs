using System;
using UnityEngine;

public class WinningConditionEventSystem : MonoBehaviour
{
   public static event Action<int> OnKnightComeBack;

   public static void KnightComeBack(int howManyStarts)
   {
      if (OnKnightComeBack != null)
      {
         OnKnightComeBack?.Invoke(howManyStarts);
      }
   }
}

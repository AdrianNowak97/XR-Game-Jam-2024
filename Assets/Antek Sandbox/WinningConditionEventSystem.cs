using System;
using UnityEngine;

public class WinningConditionEventSystem : MonoBehaviour
{
   public static WinningConditionEventSystem current;
   private void Awake()
   {
      current = this;
   }

   public event Action<int> OnKnightComeBack;

   public void KnightComeBack(int howManyStarts)
   {
      if (OnKnightComeBack != null)
      {
         OnKnightComeBack(howManyStarts);
      }
   }
}

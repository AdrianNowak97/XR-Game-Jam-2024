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

   public static event Action<SO_Enemy> OnNewItemGet;

   public static void NewItemGet(SO_Enemy newItem)
   {
      if (OnNewItemGet != null)
      {
         OnNewItemGet?.Invoke(newItem);
      }
   }

   public static event Action<string> OnEnemyText;
   
   public static void EnemyText(string text)
   {
      if (OnEnemyText != null)
      {
         OnEnemyText?.Invoke(text);
      }
   }
}
